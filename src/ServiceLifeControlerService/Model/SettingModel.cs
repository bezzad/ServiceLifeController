using System;
using Models;

namespace Model
{
    public class SettingModel
    {
        public double TimerIntervalMilliseconds { get; set; }
        public string NotifyMessageTitle { get; set; }
        public string NotifyMessageContent { get; set; }
        public string SenderMobileNo { get; set; }
        public string SenderEmailAddress { get; set; }
        public string SenderEmailPassword { get; set; }
        public ServiceInfo[] CoveredServices { get; set; }
        public Tuple<string, string> ReceiverMobilesNo { get; set; }
        public Tuple<string, string> ReceiverEmails { get; set; }
    }
}
