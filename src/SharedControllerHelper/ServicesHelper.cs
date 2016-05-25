using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using Models;

namespace SharedControllerHelper
{
    public static class ServicesHelper
    {
        public static bool IsServiceInstalled(string serviceName)
        {
            // get list of Windows services
            var services = ServiceController.GetServices();

            // try to find service name
            return services.Any(service => string.Equals(service.ServiceName, serviceName, StringComparison.CurrentCultureIgnoreCase));
        }

        public static IList<ServiceInfo> GetRuningServices()
        {
            var scServices = ServiceController.GetServices();
            var result = scServices.GetServicesInfo(ServiceControllerStatus.Running);

            return result;
        }

        public static IList<ServiceInfo> GetAllServices()
        {
            var scServices = ServiceController.GetServices();
            var result = scServices.GetServicesInfo();

            return result;
        }

        public static ServiceInfo GetServiceInfo(this ServiceController sc)
        {
            var service = new ServiceInfo()
            {
                ServiceName = sc.ServiceName,
                Name = sc.DisplayName,
                StartupType = sc.ServiceType,
                Status = sc.Status
            };

            // Query WMI for additional information about this service.
            // Display the start name (LocalSytem, etc) and the service
            // description.
            var wmiService = new ManagementObject("Win32_Service.Name='" + sc.ServiceName + "'");
            wmiService.Get();

            service.LogInAs += wmiService["StartName"];
            service.Description += wmiService["Description"];

            return service;
        }

        public static List<ServiceInfo> GetServicesInfo(this ServiceController[] services, ServiceControllerStatus status)
        {
            // Create list of services currently running on this computer.
            var serviceInfos = services
                .Where(sc => sc.Status == status)
                .Select(sc => sc.GetServiceInfo()).ToList();

            return serviceInfos;
        }

        public static List<ServiceInfo> GetServicesInfo(this ServiceController[] services)
        {
            // Create list of services currently running on this computer.
            return services.Select(sc => sc.GetServiceInfo()).ToList();
        }
    }
}
