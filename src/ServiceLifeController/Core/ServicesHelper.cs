using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using ServiceLifeController.Models;

namespace ServiceLifeController.Core
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
            var result = scServices.GetServicesInfo(ServiceControllerStatus.Running.ToString());

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
                Status = sc.Status.ToString()
            };

            // Query WMI for additional information about this service.
            // Display the start name (LocalSytem, etc) and the service
            // description.
            var wmiService = new ManagementObject("Win32_Service.Name='" + sc.ServiceName + "'");
            wmiService.Get();

            service.LogInAs +=  wmiService["StartName"] ;
            service.Description += wmiService["Description"];

            return service;
        }

        public static List<ServiceInfo> GetServicesInfo(this ServiceController[] services, string status = null)
        {
            List<ServiceInfo> serviceInfos;

            if (status == null)
            {
                serviceInfos = services.Select(s => s.GetServiceInfo()).ToList();
            }
            else
            {
                // Create list of services currently running on this computer.
                serviceInfos = services
                    .Where(sc => string.Equals(sc.Status.ToString(), status, StringComparison.CurrentCultureIgnoreCase))
                    .Select(sc => sc.GetServiceInfo()).ToList();
            }

            return serviceInfos;
        }
    }
}
