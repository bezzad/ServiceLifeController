using System;
using System.ServiceProcess;
using Models;

namespace ServiceLifeControllerService
{
    //This is a class which describes the event to the class that recieves it.
    //An EventArgs class must always derive from System.EventArgs.
    public class ServiceNotifyEventArgs : EventArgs
    {
        public ServiceInfo Service { get; set; }
        public ServiceControllerStatus NewStatus { get; set; }
        public ServiceControllerStatus OldStatus { get; set; }

        public ServiceNotifyEventArgs(ServiceInfo service, ServiceControllerStatus newStatus)
        {
            Service = service;
            NewStatus = newStatus;
            OldStatus = Service.Status;
        }
    }

}
