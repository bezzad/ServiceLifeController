using System;
using System.Linq;

namespace SmsManager
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
            return ToNumbers.Select(tn => $"{Message}{Environment.CommandLine}{MessageTime.ToString("F")}").ToArray();
        }
        public bool[] GetDuplicateLanguagesForReceivers()
        {
            return ToNumbers.Select(tn => Farsi).ToArray();
        }
    }
}
