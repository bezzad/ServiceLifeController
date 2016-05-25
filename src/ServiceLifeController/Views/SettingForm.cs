using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AdoManager;
using Models;
using Newtonsoft.Json;
using ServiceLifeController.Properties;
using SharedControllerHelper;

namespace ServiceLifeController.Views
{
    public partial class SettingForm : BaseForm
    {
        public static string Splitter = ",";

        public static char[] TrimChars = { '\n', '\r', ' ', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '~' };
        public SettingModel SettingObject;

        public SettingForm(SettingModel setting)
        {
            InitializeComponent();

            SettingObject = setting;

            LoadSettingData();
        }



        private async void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettingData();

                var path = FileManager.DefaultApplicationDataPath;

                var data = JsonConvert.SerializeObject(SettingObject, Formatting.Indented);

                await FileManager.WriteFileSafelyAsync(path, data);

                MessageBox.Show(Resources.SaveSettingSuccessfull);
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void LoadSettingData()
        {
            if (SettingObject == null) return;

            txtTimerInterval.Value = SettingObject.TimerIntervalMilliseconds < 10000 ? "10000" : SettingObject.TimerIntervalMilliseconds.ToString(CultureInfo.InvariantCulture);
            txtSenderMobileNo.Value = SettingObject.SenderMobileNo;
            txtSenderEmailAddress.Value = SettingObject.SenderEmailAddress;
            txtSenderEmailPassword.Value = SettingObject.SenderEmailPassword?.Decrypt();
            txtNotifyMsgTitle.Value = SettingObject.NotifyMessageTitle;
            txtNotifyMessageContent.Value = SettingObject.NotifyMessageContent;
            txtReceiverMobiles.Value = string.Join(Splitter, SettingObject.ReceiverMobilesNo);
            txtReceiverEmails.Value = string.Join(Splitter, SettingObject.ReceiverEmails);
        }


        private void SaveSettingData()
        {
            if (SettingObject == null) SettingObject = new SettingModel();

            SettingObject.TimerIntervalMilliseconds = string.IsNullOrEmpty(txtTimerInterval.Value)
                ? 60000
                : double.Parse(txtTimerInterval.Value);

            SettingObject.TimerIntervalMilliseconds =
            SettingObject.TimerIntervalMilliseconds < 10000
                ? 60000
                : SettingObject.TimerIntervalMilliseconds;

            SettingObject.SenderMobileNo = txtSenderMobileNo.Value;
            SettingObject.SenderEmailAddress = txtSenderEmailAddress.Value;
            SettingObject.SenderEmailPassword = txtSenderEmailPassword.Value?.Encrypt();
            SettingObject.NotifyMessageTitle = txtNotifyMsgTitle.Value;
            SettingObject.NotifyMessageContent = txtNotifyMessageContent.Value;
            SettingObject.ReceiverMobilesNo = txtReceiverMobiles.Value.Split(Splitter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(TrimChars)).ToList();
            SettingObject.ReceiverEmails = txtReceiverEmails.Value.Split(Splitter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(TrimChars)).ToList();
        }
    }
}
