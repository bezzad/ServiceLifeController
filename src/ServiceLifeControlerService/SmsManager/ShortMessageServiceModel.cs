using System;
using System.Linq;

namespace ServiceLifeControllerService.SmsManager
{
    public class ShortMessageServiceModel
    {
        public string FromNumber { get; set; }
        public string ToNumber { get; set; }
        public DateTime MessageTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public long RecId { get; set; }
        public Status Status { get; set; }
        public Retrieval Retrieval { get; set; }
        public int Delivered { get; set; }


        public string GetMessage()
        {
            return $"{Message}{Environment.NewLine}{MessageTime.ToString("F")}";
        }

        public string[] GetDuplicateMessgesForReceivers()
        {
            return ToNumber.Select(tn => GetMessage()).ToArray();
        }

        public string GetMessgeForReceiver()
        {
            return $"{Message}{Environment.CommandLine}{MessageTime.ToString("F")}";
        }
    }

    public enum Status
    {
        Sent = 0,
        Failed = 1
    }

    public enum Retrieval
    {
        InvalidUserPass = 0,
        Successful = 1,
        NoCredit = 2,
        DailyLimit = 3,
        SendLimit = 4,
        InvalidNumber = 5,
        SystemIsDisable = 6,
        BadWords = 7,
        PardisMinimumReceivers = 8,
        NumberIsPublic = 9
    }
}