using System;
using System.ServiceProcess;
using SharedControllerHelper;
using SharedControllerHelper.Models;

namespace ServiceLifeControllerService
{
    partial class ServiceLifeControllerService : ServiceBase
    {
        public ServiceLifeControllerService()
        {
            InitializeComponent();

            this.ServiceName = this.GetType().Name;
            this.CanStop = true;
            this.CanPauseAndContinue = false;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            ServiceLifeController.ServiceStatusChanged += ServiceLifeController_ServiceStatusChanged;
            ServiceLifeController.StartLifeCycleController();
            WindowsEventLog.WriteInfoLog($"{ServiceName} Starting...");
        }

        private void ServiceLifeController_ServiceStatusChanged(ServiceNotifyEventArgs e)
        {
            #region Send email to receivers
            try
            {
                //========================= Send Email to all of receivers ===================================
                if (ServiceLifeController.NewSetting.SendEmailNotifyEnable)
                {
                    var email = new EmailModel();

                    email.Message = $"<h2>{ServiceLifeController.NewSetting.NotifyMessageContent}</h2><br/>" +
                                    $"<p>The <strong>{e.Service.Name}</strong> process is <strong>{e.NewStatus}</strong>!</p>";
                    email.From = ServiceLifeController.NewSetting.SenderEmailAddress;
                    email.SenderPassword = ServiceLifeController.NewSetting.SenderEmailPassword?.Decrypt();
                    email.Subject = string.IsNullOrEmpty(ServiceLifeController.NewSetting.NotifyMessageTitle)
                        ? $"A Service is {e.NewStatus}!"
                        : ServiceLifeController.NewSetting.NotifyMessageTitle;
                    email.To = ServiceLifeController.NewSetting.ReceiverEmails;
                    email.EmailHost = ServiceLifeController.NewSetting.EmailHost;
                    email.EmailHostPort = ServiceLifeController.NewSetting.EmailHostPort;


                    email.SendEmail();
                }
                //============================================================================================

            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Exception in ServiceLifeController_ServiceStatusChanged event (send email): {exp.Message}");
            }
            #endregion

            #region Send SMS to receivers
            try
            {
                //========================= Send SMS to all of receivers ===================================
                if (ServiceLifeController.NewSetting.SendSmsEnable)
                {
                    //try
                    //{
                    //    var smsc = new SmsService.smsSoapClient();
                    //    var msg = smsc.doSendSMS(uUsername: "dbco.oromieh", uPassword: "D@d@sh",
                    //        uNumber: "10000006306217", uCellphones: "9143159859", uMessage: "test", uFarsi: false);

                    //    MessageBox.Show(msg);
                    //}
                    //catch (Exception exp)
                    //{
                    //    MessageBox.Show(exp.Message);
                    //}
                }
                //============================================================================================

            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Exception in ServiceLifeController_ServiceStatusChanged event (send sms): {exp.Message}");
            }
            #endregion
        }

        protected override void OnStop()
        {
            WindowsEventLog.WriteErrorLog($"{ServiceName} Stopped.");
        }

        protected override void OnContinue()
        {
            WindowsEventLog.WriteWarningLog($"{ServiceName} Continued.");
        }

        protected override void OnPause()
        {
            WindowsEventLog.WriteWarningLog($"{ServiceName} Paused.");
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();

            WindowsEventLog.WriteInfoLog($"The {Environment.MachineName} server will be turned off.");
            ServiceLifeController.WillBeTurnOff();
        }

        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);

        }
    }
}