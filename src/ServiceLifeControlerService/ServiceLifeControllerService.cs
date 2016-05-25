using System;
using System.ServiceProcess;
using SharedControllerHelper;

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
            ServiceLifeController.StartLifeCycleController();
            WindowsEventLog.WriteInfoLog($"{ServiceName} Starting...");
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