using System;
using System.Collections.Generic;

namespace ServiceLifeControllerService.SmsManager
{
    public class SmsHelper
    {
        public IList<ShortMessageServiceModel> SendManySms(string username, string password, string msg, string fromNumber, string[] toNumbers)
        {
            var results = new List<ShortMessageServiceModel>();
            var smsApi = new SmsWebService.Send();
            long[] rec = null;
            byte[] status = null;
            var smsMessage = msg.Replace("'", ""); // Fara payamak has problem by cama '
            var retrieve = smsApi.SendSms(username, password, toNumbers, fromNumber, smsMessage, false, "", ref rec, ref status);

            for (var i = 0; i < toNumbers.Length; i++)
            {
                results.Add(new ShortMessageServiceModel()
                {
                    Delivered = smsApi.GetDelivery(rec[i]),
                    Status = (Status)status[i],
                    RecId = rec[i],
                    FromNumber = fromNumber,
                    ToNumber = toNumbers[i],
                    Message = smsMessage,
                    MessageTime = DateTime.Now,
                    Retrieval = (Retrieval)retrieve
                });
            }

            return results;
        }

        public ShortMessageServiceModel SendSms(string username, string password, string msg, string fromNumber, string toNumbers)
        {
            var smsApi = new SmsWebService.Send();
            long[] rec = null;
            byte[] status = null;

            var retrieve = smsApi.SendSms(username, password, new[] { toNumbers }, fromNumber, msg, false, "", ref rec, ref status);

            var results = new ShortMessageServiceModel()
            {
                Delivered = smsApi.GetDelivery(rec[0]),
                Status = (Status)status[0],
                RecId = rec[0],
                FromNumber = fromNumber,
                ToNumber = toNumbers,
                Message = msg,
                MessageTime = DateTime.Now,
                Retrieval = (Retrieval)retrieve
            };

            return results;
        }
    }
}