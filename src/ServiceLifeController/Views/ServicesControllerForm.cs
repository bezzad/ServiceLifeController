using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ServiceLifeController.Core;
using ServiceLifeController.Models;

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



        protected override void LoadCompleted(object sender, EventArgs e)
        {
            base.LoadCompleted(sender, e);

            var services = Core.ServicesHelper.GetAllServices();
            var servicesSource = new SortableBindingList<ServiceInfo>(services);

            dgvServices.DataSource = servicesSource;

            SetGridColumnsToReadOnly(dgvServices);

            var colSelected = new DataGridViewCheckBoxColumn(false)
            {
                Name = "Selected",
                HeaderText = "Selected"
            };


            dgvServices.Columns.Add(colSelected);
        }

        private void SetGridColumnsToReadOnly(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.ReadOnly = true;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

    }
}
