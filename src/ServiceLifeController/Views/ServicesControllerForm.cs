using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using Models;
using Newtonsoft.Json;
using ServiceLifeController.Core;

namespace ServiceLifeController.Views
{
    public partial class ServicesControllerForm : BaseForm
    {
        public static Dictionary<string, ServiceInfo> SelectedServicesInfo = new Dictionary<string, ServiceInfo>();

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
                    SelectedServicesInfo.Add(src[e.RowIndex].Name, src[e.RowIndex]);
                    lstSelectedServices.Items.Add(src[e.RowIndex].Name);
                }
                else if (SelectedServicesInfo.ContainsKey(src[e.RowIndex].Name))
                {
                    SelectedServicesInfo.Remove(src[e.RowIndex].Name);
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

            var services = Core.ServicesHelper.GetAllServices();
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
            new SettingForm(SelectedServicesInfo.Values.ToList()).ShowDialog(this);
        }

        private void btnShowEventLogs_Click(object sender, EventArgs e)
        {
            new ServiceLogViewerForm().Show(this);
        }
    }
}
