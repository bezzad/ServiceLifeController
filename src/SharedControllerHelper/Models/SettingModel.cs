using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SharedControllerHelper;
using SharedControllerHelper.Models;

namespace Models
{
    public class SettingModel
    {
        public double TimerIntervalSec { get; set; } = 60;

        public bool SendSmsEnable { get; set; } = true;
        public bool SendEmailNotifyEnable { get; set; } = true;

        public string NotifyMessageTitle { get; set; }
        public string NotifyMessageContent { get; set; }

        public string SmsSenderNumber { get; set; }
        public string SmsServiceUsername { get; set; }
        private string _smsServicePassword = "";
        public string SmsServicePassword
        {
            get { return _smsServicePassword?.Encrypt(); }
            set { _smsServicePassword = (value ?? "").StartsWith("#") ? value.Decrypt() : value; }
        }
        public List<string> SmsReceiverMobilesNo { get; set; } = new List<string>();

        public string SenderEmailAddress { get; set; }

        private string _senderEmailPassword = "";
        public string SenderEmailPassword
        {
            get { return _senderEmailPassword?.Encrypt(); }
            set { _senderEmailPassword = (value ?? "").StartsWith("#") ? value.Decrypt() : value; }
        }

        
        public string EmailHost { get; set; } = "mail.shoniz.com";
        public int EmailHostPort { get; set; } = 587;
        public List<string> ReceiverEmails { get; set; } = new List<string>();

        public List<ServiceInfo> CoveredServices { get; set; } = new List<ServiceInfo>();

        public ServiceControllerStatusChanging NotifyJustStatusChangingTo { get; set; } = ServiceControllerStatusChanging.AllChangingStatus;


        public string GetSenderEmailNoHashPassword()
        {
            return _senderEmailPassword;
        }

        public string GetSmsServiceNoHashPassword()
        {
            return _smsServicePassword;
        }
    }
}
