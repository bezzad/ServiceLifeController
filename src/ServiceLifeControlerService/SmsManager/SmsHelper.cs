
namespace ServiceLifeControllerService.SmsManager
{
    public class SmsHelper
    {
        public string[] SendManySms(SmsModel sms)
        {
            var smsSoap = new SmsService.smsSoapClient();

            var msgs = smsSoap.doSendArraySMS(sms.Username, sms.Password,
                sms.FromNumber, sms.ToNumbers, sms.GetDuplicateMessgesForReceivers(),
                sms.GetDuplicateLanguagesForReceivers());

            return msgs;
        }

        public string SendSms(SmsModel sms)
        {
            var smsSoap = new SmsService.smsSoapClient();

            var msgs = smsSoap.doSendSMS(sms.Username, sms.Password,
                sms.FromNumber, sms.ToNumbers[0], sms.GetMessgeForReceiver(),
                sms.Farsi);

            return msgs;
        }
    }
}
