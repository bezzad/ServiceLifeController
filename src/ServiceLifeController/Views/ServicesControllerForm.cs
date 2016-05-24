using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using Model;
using Models;
using Newtonsoft.Json;
using ServiceLifeController.Core;

namespace ServiceLifeController.Views
{
    public partial class ServicesControllerForm : BaseForm
    {
        private SettingModel setting = new SettingModel();

        public ServicesControllerForm()
        {
            InitializeComponent();

            dgvServices.CellContentClick += dgvServices_CellContentClick;
            dgvServices.CellValueChanged += dgvServices_CellValueChanged;
        }

        void dgvServices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.Columns[e.ColumnIndex].Name == "Selected")
            {
                bool selected = ((bool?)dgvServices[e.ColumnIndex, e.RowIndex].Value == true);

                var src = (SortableBindingList<ServiceInfo>)dgvServices.DataSource;
                if (selected)
                {
                    setting.CoveredServices.Add(src[e.RowIndex]);
                    lstSelectedServices.Items.Add(src[e.RowIndex].Name);
                }
                else if (setting.CoveredServices.Exists(cs=>cs.Name == src[e.RowIndex].Name))
                {
                    setting.CoveredServices.Remove(src[e.RowIndex]);
                    lstSelectedServices.Items.Remove(src[e.RowIndex].Name);
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
        }

        private async void LoadSettingData()
        {
            try
            {
                var path = FileManager.DefaultApplicationDataPath;

                var settingJson = await FileManager.ReadFileSafelyAsync(path);

                if (setting == null) return;

                setting = JsonConvert.DeserializeObject<SettingModel>(settingJson);

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
                if (setting.CoveredServices.Exists(cs => cs.Name == row.Cells["Name"]?.Value.ToString()))
                {
                    row.Cells["Selected"].Value = true;
                }
            }
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
            new SettingForm(setting).ShowDialog(this);
        }

        private void btnShowEventLogs_Click(object sender, EventArgs e)
        {
            new ServiceLogViewerForm().Show(this);
        }
    }
}
