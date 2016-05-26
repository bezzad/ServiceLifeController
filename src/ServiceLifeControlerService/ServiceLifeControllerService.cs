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
            try
            {
                #region Send email to receivers

                //========================= Send Email to all of receivers ===================================
                var email = new EmailModel();

                email.Message = $"<h2>{ServiceLifeController.NewSetting.NotifyMessageContent}</h2><br/>" +
                                $"<p>The <strong>{e.Service.Name}</strong> service is <strong>{e.NewStatus}</strong>!</p>";
                email.From = ServiceLifeController.NewSetting.SenderEmailAddress;
                email.SenderPassword = ServiceLifeController.NewSetting.SenderEmailPassword?.Decrypt();
                email.Subject = string.IsNullOrEmpty(ServiceLifeController.NewSetting.NotifyMessageTitle)
                    ? $"A Service is {e.NewStatus}!"
                    : ServiceLifeController.NewSetting.NotifyMessageTitle;
                email.To = ServiceLifeController.NewSetting.ReceiverEmails;



                email.SendEmail();
                //============================================================================================

                #endregion
            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Exception in ServiceLifeController_ServiceStatusChanged event: {exp.Message}");
            }
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