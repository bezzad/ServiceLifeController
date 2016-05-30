using System;
using System.ServiceProcess;
using Models;
using SharedControllerHelper.Models;

namespace ServiceLifeControllerService
{
    //This is a class which describes the event to the class that recieves it.
    //An EventArgs class must always derive from System.EventArgs.
    public class ServiceNotifyEventArgs : EventArgs
    {
        public KeepServiceStatus KeepService { get; set; }
        public ServiceControllerStatus NewStatus { get; set; }
        public ServiceControllerStatus OldStatus { get; set; }

        public ServiceNotifyEventArgs(KeepServiceStatus kss, ServiceControllerStatus newStatus)
        {
            KeepService = kss;
            NewStatus = newStatus;
            OldStatus = KeepService.Service.Status;
        }
    }

}
