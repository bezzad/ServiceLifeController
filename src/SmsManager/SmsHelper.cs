using System;
using System.Threading.Tasks;
using SmsManager.SmsService;

namespace SmsManager
{
    public class SmsHelper
    {
        public string[] SendManySms(SmsModel sms)
        {
            var smsSoap = new smsSoapClient();
            
            var msgs = smsSoap.doSendArraySMS(sms.Username, sms.Password,
                sms.FromNumber, sms.ToNumbers, sms.GetDuplicateMessgesForReceivers(),
                sms.GetDuplicateLanguagesForReceivers());

            return msgs;
        }
    }
}
