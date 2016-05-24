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
using Model;
using Models;
using Newtonsoft.Json;

namespace ServiceLifeController.Views
{
    public partial class SettingForm : BaseForm
    {
        public SettingModel SettingObject;

        public SettingForm(SettingModel setting)
        {
            InitializeComponent();

            SettingObject = setting;
        }

        private async void btnSaveSetting_Click(object sender, EventArgs e)
        {
            var path = FileManager.DefaultApplicationDataPath;

            var data = JsonConvert.SerializeObject(SettingObject, Formatting.Indented);

            await FileManager.WriteFileSafelyAsync(path, data);
        }
    }
}
