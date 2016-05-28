using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Models;
using Newtonsoft.Json;
using ServiceLifeController.Properties;
using SharedControllerHelper;
using SharedControllerHelper.Models;

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
        }

        protected override void OnLoaded(object sender, EventArgs e)
        {
            base.OnLoaded(sender, e);

            // Fill ComboBox of Notify Status Change On:
            var items = typeof(ServiceControllerStatusChanging).GetEnumValues().OfType<ServiceControllerStatusChanging>();
            var enumNameValue = items.Select(val => new { Name = val.ToString(), Value = (int)val }).ToList();
            cmbStatusOn.DataSource = enumNameValue;
            cmbStatusOn.DisplayMember = "Name";
            cmbStatusOn.ValueMember = "Value";

            // Read Setting file:
            LoadSettingData();
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettingData();

                var path = FileManager.DefaultApplicationDataPath;

                var data = JsonConvert.SerializeObject(SettingObject, Formatting.Indented);

                FileManager.WriteFileSafely(path, data);

                MessageBox.Show($"{Resources.SaveSettingSuccessfull}\n\r\n\rPath: {path}");
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

            txtTimerInterval.Value = SettingObject.TimerIntervalSec < 10 ? "10" : SettingObject.TimerIntervalSec.ToString(CultureInfo.InvariantCulture);
            txtSenderMobileNo.Value = SettingObject.SmsSenderNumber;
            txtSenderEmailAddress.Value = SettingObject.SenderEmailAddress;
            txtSenderEmailPassword.Value = SettingObject.GetSenderEmailNoHashPassword();
            txtNotifyMsgTitle.Value = SettingObject.NotifyMessageTitle;
            txtNotifyMessageContent.Value = SettingObject.NotifyMessageContent;
            txtReceiverMobiles.Value = string.Join(Splitter + Environment.NewLine, SettingObject.SmsReceiverMobilesNo);
            txtReceiverEmails.Value = string.Join(Splitter + Environment.NewLine, SettingObject.ReceiverEmails);
            txtEmailHost.Value = SettingObject.EmailHost;
            txtEmailHostPort.Value = SettingObject.EmailHostPort.ToString();
            txtSmsServiceUsername.Value = SettingObject.SmsServiceUsername;
            txtSmsServicePassword.Value = SettingObject.GetSmsServiceNoHashPassword();
            cmbStatusOn.SelectedValue = (int)SettingObject.NotifyJustStatusChangingTo;
            chkEnableSMS.Checked = SettingObject.SendSmsEnable;
            chkEnableEmail.Checked = SettingObject.SendEmailNotifyEnable;
        }


        private void SaveSettingData()
        {
            if (SettingObject == null) SettingObject = new SettingModel();

            SettingObject.TimerIntervalSec = string.IsNullOrEmpty(txtTimerInterval.Value)
                ? 60
                : double.Parse(txtTimerInterval.Value);

            SettingObject.TimerIntervalSec =
            SettingObject.TimerIntervalSec < 10
                ? 10
                : SettingObject.TimerIntervalSec;

            SettingObject.SmsSenderNumber = txtSenderMobileNo.Value;
            SettingObject.SenderEmailAddress = txtSenderEmailAddress.Value;
            SettingObject.SenderEmailPassword = txtSenderEmailPassword.Value;
            SettingObject.NotifyMessageTitle = txtNotifyMsgTitle.Value;
            SettingObject.NotifyMessageContent = txtNotifyMessageContent.Value;
            SettingObject.SmsReceiverMobilesNo = txtReceiverMobiles.Value.Split(Splitter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(TrimChars)).ToList();
            SettingObject.ReceiverEmails = txtReceiverEmails.Value.Split(Splitter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(TrimChars)).ToList();
            SettingObject.EmailHost = string.IsNullOrEmpty(txtEmailHost.Value) ? "mail.shoniz.com" : txtEmailHost.Value;
            SettingObject.EmailHostPort = string.IsNullOrEmpty(txtEmailHostPort.Value) ? 587 : int.Parse(txtEmailHostPort.Value);
            SettingObject.SmsServiceUsername = txtSmsServiceUsername.Value;
            SettingObject.SmsServicePassword = txtSmsServicePassword.Value;
            SettingObject.NotifyJustStatusChangingTo = (ServiceControllerStatusChanging)cmbStatusOn.SelectedValue;
            SettingObject.SendEmailNotifyEnable = chkEnableEmail.Checked;
            SettingObject.SendSmsEnable = chkEnableSMS.Checked;
        }

        private void chkEnableEmail_CheckedChanged(object sender, EventArgs e)
        {
            gbEmailSetting.Enabled = chkEnableEmail.Checked;
        }

        private void chkEnableSMS_CheckedChanged(object sender, EventArgs e)
        {
            gbSms.Enabled = chkEnableSMS.Checked;
        }
    }
}
