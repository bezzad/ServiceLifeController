using System.Collections.Generic;
using SharedControllerHelper.Models;

namespace Models
{
    public class SettingModel
    {
        public double TimerIntervalMilliseconds { get; set; } = 60000;
        public string NotifyMessageTitle { get; set; }
        public string NotifyMessageContent { get; set; }
        public string SenderMobileNo { get; set; }
        public string SenderEmailAddress { get; set; }
        public string SenderEmailPassword { get; set; }
        public List<ServiceInfo> CoveredServices { get; set; } = new List<ServiceInfo>();
        public List<string> ReceiverMobilesNo { get; set; } = new List<string>();
        public List<string> ReceiverEmails { get; set; } = new List<string>();
        public ServiceControllerStatusChanging NotifyJustStatusChangingTo { get; set; } = ServiceControllerStatusChanging.AllChangingStatus;
    }
}
