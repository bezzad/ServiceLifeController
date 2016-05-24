using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using Models;
using Newtonsoft.Json;

namespace ServiceLifeController.Views
{
    public partial class SettingForm : BaseForm
    {
        public List<ServiceInfo> SelectedServices;

        public SettingForm(List<ServiceInfo> selectedServices)
        {
            InitializeComponent();

            SelectedServices = selectedServices;
        }

        private async void btnSaveSetting_Click(object sender, EventArgs e)
        {
            var commonApplicationData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData);

            var path = Path.Combine(commonApplicationData, Properties.Settings.Default.SettingFileName);

            var data = JsonConvert.SerializeObject(SelectedServices, Formatting.Indented);

            await FileManager.WriteFileSafelyAsync(path, data);
        }
    }
}
