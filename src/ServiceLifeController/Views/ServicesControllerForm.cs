using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Models;
using Newtonsoft.Json;
using SharedControllerHelper;
using SharedControllerHelper.Models;

namespace ServiceLifeController.Views
{
    public partial class ServicesControllerForm : BaseForm
    {
        #region Fields

        private SettingModel _setting = new SettingModel();

        #endregion

        #region Constructors

        public ServicesControllerForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrids

        protected override void OnLoaded(object sender, EventArgs e)
        {
            base.OnLoaded(sender, e);

            FillKeepServiceStatusOnCombo();

            LoadGridByServicesInfo();

            LoadSettingData();

            dgvServices.CellContentClick += dgvServices_CellContentClick;
            dgvServices.CellValueChanged += dgvServices_CellValueChanged;

            dgvSelectedServices.CellContentClick += dgvSelectedServices_CellContentClick;
            dgvSelectedServices.CellValueChanged += dgvSelectedServices_CellValueChanged;

            dgvSelectedServices.SelectionChanged += dgvSelectedServices_SelectionChanged;
        }

        #endregion

        #region Methods

        private void FillKeepServiceStatusOnCombo()
        {
            // Fill ComboBox of ServiceStableStatus:
            var items = typeof(ServiceStableStatus).GetEnumValues().OfType<ServiceStableStatus>();
            var enumNameValue = items.Select(val => new { Name = val.ToString(), Value = (int)val }).ToList();

            ColKeepServiceStatusOn.DataSource = enumNameValue;
            ColKeepServiceStatusOn.DisplayMember = "Name";
            ColKeepServiceStatusOn.ValueMember = "Value";
        }

        private void LoadSettingData()
        {
            try
            {
                var path = FileManager.DefaultApplicationDataPath;

                var settingJson = FileManager.ReadFileSafely(path);

                if (settingJson == null) return;

                _setting = JsonConvert.DeserializeObject<SettingModel>(settingJson);

                SetStoredSelectedServices();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void SetStoredSelectedServices()
        {
            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                if (_setting.CoveredServices.Exists(cs => cs.Service.Name == row.Cells["Name"]?.Value.ToString()))
                {
                    row.Cells["Selected"].Value = true;
                }
            }

            foreach (var keepServiceState in _setting.CoveredServices)
            {
                AddRowToSelectedServicesGrid(keepServiceState);
            }
        }

        private void LoadGridByServicesInfo()
        {
            var services = ServicesHelper.GetAllServices();
            var servicesSource = services.ToDataTable();

            SetColumnsToReadOnly(servicesSource);

            servicesSource.Columns.Add("Selected", typeof(bool)).SetOrdinal(0);

            dgvServices.DataSource = servicesSource;
        }

        private void SetColumnsToReadOnly(DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                col.ReadOnly = true;
            }
        }

        private void AddRowToSelectedServicesGrid(KeepServiceStatus data)
        {
            var index = dgvSelectedServices.Rows.Add();
            dgvSelectedServices.Rows[index].Cells["ColServiceName"].Value = data.Service.Name;
            (dgvSelectedServices.Rows[index].Cells["ColKeepServiceStatusOn"] as DataGridViewComboBoxCell).Value = (int)data.KeepStatusOn;
        }

        private void RemoveRowToSelectedServicesGrid(ServiceInfo serv)
        {
            foreach (DataGridViewRow row in dgvSelectedServices.Rows)
            {
                if (row.Cells["ColServiceName"].Value?.ToString() == serv.Name)
                    dgvSelectedServices.Rows.Remove(row);
            }
        }

        #endregion

        #region Event Handlers


        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            new SettingForm(_setting).ShowDialog(this);
        }

        private void btnShowEventLogs_Click(object sender, EventArgs e)
        {
            new ServiceLogViewerForm().Show(this);
        }

        void dgvServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                if (row.Cells["Selected"].Value == DBNull.Value) continue;

                var serviceName = row.Cells["Name"].Value?.ToString();
                var isSelected =
                    _setting.CoveredServices.Any(x => x.Service.Name == serviceName);

                if ((bool?)row.Cells["Selected"].Value == true && !isSelected)
                {
                    var serv = row.ToObject<ServiceInfo>();
                    var kss = new KeepServiceStatus() { Service = serv };
                    _setting.CoveredServices.Add(kss);
                    AddRowToSelectedServicesGrid(kss);
                }
                else if ((bool?)row.Cells["Selected"].Value == false && isSelected)
                {
                    // Remove from setting object
                    _setting.CoveredServices.RemoveAll(x => x.Service.Name == serviceName);
                    //
                    // Remove from Selected Services Grid
                    RemoveRowToSelectedServicesGrid(row.ToObject<ServiceInfo>());
                }
            }
        }

        void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvServices.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvSelectedServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var servName = dgvSelectedServices.Rows[e.RowIndex].Cells["ColServiceName"].Value?.ToString();

            var dgvComboCell = dgvSelectedServices.Rows[e.RowIndex].Cells["ColKeepServiceStatusOn"] as DataGridViewComboBoxCell;

            if (dgvComboCell == null) return;

            var servKeepStatus = dgvComboCell.Value ?? 0;

            var kss = _setting.CoveredServices.FirstOrDefault(x => x.Service.Name == servName);
            if (kss != null) kss.KeepStatusOn = (ServiceStableStatus)servKeepStatus;
        }

        private void dgvSelectedServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSelectedServices.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvSelectedServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSelectedServices.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSelectedServices.SelectedRows[0];
                var servName = selectedRow.Cells["ColServiceName"].Value?.ToString();

                foreach (DataGridViewRow row in dgvServices.Rows)
                {
                    if (row.Cells["Name"].Value?.ToString() == servName)
                    {
                        row.Selected = true;
                        dgvServices.FirstDisplayedScrollingRowIndex = row.Index;
                        return;
                    }
                }
            }
        }

        #endregion
    }
}
