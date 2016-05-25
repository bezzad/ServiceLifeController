using System;
using System.Linq;
using System.Windows.Forms;
using Helper;
using Models;
using Newtonsoft.Json;
using ServiceLifeController.Core;

namespace ServiceLifeController.Views
{
    public partial class ServicesControllerForm : BaseForm
    {
        private SettingModel _setting = new SettingModel();

        public ServicesControllerForm()
        {
            InitializeComponent();
        }

        void dgvServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var src = (SortableBindingList<ServiceInfo>)dgvServices.DataSource;

            _setting.CoveredServices.Clear();
            lstSelectedServices.Items.Clear();

            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                if ((bool?)row.Cells["Selected"].Value == true)
                {
                    _setting.CoveredServices.Add(src[row.Index]);
                    lstSelectedServices.Items.Add(src[row.Index].Name);
                }
            }
        }

        void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvServices.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }



        protected override void OnLoaded(object sender, EventArgs e)
        {
            base.OnLoaded(sender, e);

            LoadGridByServicesInfo();

            LoadSettingData();

            dgvServices.CellContentClick += dgvServices_CellContentClick;
            dgvServices.CellValueChanged += dgvServices_CellValueChanged;
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
            //lstSelectedServices.Items.AddRange(setting.CoveredServices.Select(cs=> cs.Name).ToArray());

            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                if (_setting.CoveredServices.Exists(cs => cs.Name == row.Cells["Name"]?.Value.ToString()))
                {
                    row.Cells["Selected"].Value = true;
                }
            }

            lstSelectedServices.Items.AddRange(_setting.CoveredServices.Select(cs => cs.Name).ToArray());
        }

        private void LoadGridByServicesInfo()
        {
            var services = ServicesHelper.GetAllServices();
            var servicesSource = new SortableBindingList<ServiceInfo>(services);

            dgvServices.DataSource = servicesSource;

            SetGridColumnsToReadOnly(dgvServices);

            var colSelected = new DataGridViewCheckBoxColumn(false)
            {
                Name = "Selected",
                HeaderText = "Selected"
            };


            dgvServices.Columns.Insert(0, colSelected);
        }

        private void SetGridColumnsToReadOnly(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.ReadOnly = true;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            new SettingForm(_setting).ShowDialog(this);
        }

        private void btnShowEventLogs_Click(object sender, EventArgs e)
        {
            new ServiceLogViewerForm().Show(this);
        }
    }
}
