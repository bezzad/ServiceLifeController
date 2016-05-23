using System;
using System.ServiceProcess;

namespace ServiceLifeControllerService
{
    partial class SLCService : ServiceBase
    {
        public SLCService()
        {
            InitializeComponent();

            this.ServiceName = this.GetType().Name;
        }

        protected override void OnStart(string[] args)
        {
            WindowsEventLog.WriteInfoLog(string.Format("{0} Starting...", this.ServiceName));
        }

        protected override void OnStop()
        {
            WindowsEventLog.WriteErrorLog(string.Format("{0} Stopped.", this.ServiceName));
        }

        protected override void OnContinue()
        {
            WindowsEventLog.WriteWarningLog(string.Format("{0} Continued.", this.ServiceName));
        }

        protected override void OnPause()
        {
            WindowsEventLog.WriteWarningLog(string.Format("{0} Paused.", this.ServiceName));
        }
    }
}
