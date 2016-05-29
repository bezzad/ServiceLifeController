using System;
using System.Linq;

namespace ServiceLifeControllerService.SmsManager
{
    public class SmsModel
    {
        public string FromNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] ToNumbers { get; set; }
        public DateTime MessageTime { get; set; } = DateTime.Now;
        public bool Farsi { get; set; } = false;
        public string Message { get; set; }

        public string[] GetDuplicateMessgesForReceivers()
        {
            return ToNumbers.Select(tn => $"{Message}{Environment.NewLine}{MessageTime.ToString("F")}").ToArray();
        }

        public string GetMessgeForReceiver()
        {
            return $"{Message}{Environment.CommandLine}{MessageTime.ToString("F")}";
        }

        public bool[] GetDuplicateLanguagesForReceivers()
        {
            return ToNumbers.Select(tn => Farsi).ToArray();
        }
    }
}
