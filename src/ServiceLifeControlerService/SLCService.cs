using System;
using System.Diagnostics;
using System.Globalization;
using System.ServiceProcess;
using SharedControllerHelper;
using SharedControllerHelper.Models;

namespace ServiceLifeControllerService
{
    partial class SLCService : ServiceBase
    {
        public SLCService()
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

            #region Send Notify

            var emailMsg = $"<p>The <strong>{e.KeepService.Service.Name}</strong> process is <strong>{e.NewStatus}</strong>!</p>";

            var emailSubject = string.IsNullOrEmpty(ServiceLifeController.NewSetting.NotifyMessageTitle)
                        ? $"A Service is {e.NewStatus}!"
                        : ServiceLifeController.NewSetting.NotifyMessageTitle;

            var smsMsg = $@"{ServiceLifeController.NewSetting.NotifyMessageContent}{Environment.NewLine}" +
                         $"The <{e.KeepService.Service.Name}> process is '{e.NewStatus}'. {Environment.NewLine}";

            SendNotify(e, emailSubject, emailMsg, smsMsg);

            #endregion

            #region Keep Service Stablity Status

            try
            {
                // Keep service status on a stable state which is selected by user
                if (e.KeepService.KeepStatusOn != ServiceStableStatus.None)
                {
                    WindowsEventLog.WriteInfoLog($"Keep service status is ON for '{e.KeepService.Service.Name}'.");

                    if ((int)e.KeepService.KeepStatusOn != (int)e.NewStatus)
                    {
                        WindowsEventLog.WriteInfoLog(
                            $"Tying to keep '{e.KeepService.Service.Name}' status on {e.KeepService.KeepStatusOn} state...");
                        var result = false;
                        switch (e.KeepService.KeepStatusOn)
                        {
                            case ServiceStableStatus.Running:
                                result = ServiceInstallHelper.StartService(e.KeepService.Service.Name);
                                break;
                            case ServiceStableStatus.Stopped:
                                result = ServiceInstallHelper.StopService(e.KeepService.Service.Name);
                                break;
                            case ServiceStableStatus.Paused:
                                result = ServiceInstallHelper.PauseService(e.KeepService.Service.Name);
                                break;
                        }

                        if (result) // success
                        {
                            WindowsEventLog.WriteInfoLog($"The '{e.KeepService.Service.Name}' status rollbacked on {e.KeepService.KeepStatusOn} stable state successfull");

                            #region Send Notify

                            emailSubject = $"{e.KeepService.Service.Name} Rollbacked to {e.KeepService.KeepStatusOn} state Successfully";

                            emailMsg = $"<p style='color: #90EE90'>The <strong>{e.KeepService.Service.Name}</strong> process be rollbacked to <strong>{e.KeepService.KeepStatusOn}</strong> Successfully.</p>";
                            
                            smsMsg = $@"Ok !{Environment.NewLine}" +
                                        $"The '{e.KeepService.Service.Name}' process be rollbacked to '{e.KeepService.KeepStatusOn}' Successfully.{Environment.NewLine}";

                            SendNotify(e, emailSubject, emailMsg, smsMsg);

                            #endregion
                        }
                        else // fail
                        {
                            WindowsEventLog.WriteWarningLog($"The '{e.KeepService.Service.Name}' status can not rollbacked, and state is still on {e.NewStatus} !!!");

                            #region Send Notify

                            emailSubject = $"{e.KeepService.Service.Name} Rollback to {e.KeepService.KeepStatusOn} state Failed!!";

                            emailMsg = $"<p style='color: #CD5C5C'>The <strong>{e.KeepService.Service.Name}</strong> process Rollbacking to <strong>{e.KeepService.KeepStatusOn}</strong> failed!!!</p>";

                            smsMsg = $@"Fail !!!{Environment.NewLine}" +
                                      $"The '{e.KeepService.Service.Name}' process can not rollbacked, and state is still on {e.NewStatus} !!!. {Environment.NewLine}";

                            SendNotify(e, emailSubject, emailMsg, smsMsg);

                            #endregion
                        }
                    }
                    else
                    {
                        WindowsEventLog.WriteInfoLog(
                            $"The '{e.KeepService.Service.Name}' process status is stable state({e.KeepService.KeepStatusOn}), Now.");
                    }
                }
                else
                {
                    WindowsEventLog.WriteInfoLog($"Keep service status is OFF for '{e.KeepService.Service.Name}' !!!");
                }
            }
            catch (Exception exp)
            {
                WindowsEventLog.WriteErrorLog($"Error in Keep service status on stable state by this Message: {exp.Message}");
            }

            #endregion
        }

        private void SendNotify(ServiceNotifyEventArgs e, string emailSubject, string emailMessage, string smsMessage)
        {
            var preEmailMsg = (Debugger.IsAttached ? "<h3 style='color: #CD5C5C;'>Message sent in <strong>Developer</strong> mode</h3><br/>" : "")
             + $"<h2>{ServiceLifeController.NewSetting.NotifyMessageContent}</h2><br/>";

            var postEmailMsg = $"<br/><br/><hr/><h5>Server Name is <strong>{Environment.MachineName}</strong></h5>";

            emailMessage = preEmailMsg + emailMessage + postEmailMsg;


            var preSmsMsg = Debugger.IsAttached ? $"Message sent in 'Developer' mode {Environment.MachineName}" : "";
            var postSmsMsg = $"Server Name is '{Environment.MachineName}'";

            smsMessage = preSmsMsg + smsMessage + postSmsMsg;

            #region Send email to receivers
            try
            {
                //========================= Send Email to all of receivers ===================================
                if (ServiceLifeController.NewSetting.SendEmailNotifyEnable)
                {
                    var email = new EmailModel();

                    email.Message = emailMessage;
                    email.From = ServiceLifeController.NewSetting.SenderEmailAddress;
                    email.SenderPassword = ServiceLifeController.NewSetting.GetSenderEmailNoHashPassword();
                    email.Subject = emailSubject;
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
                    var sms = new SmsManager.SmsModel();
                    sms.Farsi = false;
                    sms.Message = smsMessage;
                    sms.ToNumbers = ServiceLifeController.NewSetting.SmsReceiverMobilesNo.ToArray();
                    sms.Username = ServiceLifeController.NewSetting.SmsServiceUsername;
                    sms.Password = ServiceLifeController.NewSetting.GetSmsServiceNoHashPassword();
                    sms.FromNumber = ServiceLifeController.NewSetting.SmsSenderNumber;

                    var results = new SmsManager.SmsHelper().SendManySms(sms);
                    for (int i = 0; i < results.Length; i++)
                    {
                        if (results[i].StartsWith("Send Ok", true, CultureInfo.InvariantCulture))
                            WindowsEventLog.WriteInfoLog($"An SMS send to {sms.ToNumbers[i]} by result: {results[i]}");
                        else
                        {
                            WindowsEventLog.WriteWarningLog($"An SMS can't send to {sms.ToNumbers[i]}, result: {results[i]}");
                        }
                    }
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