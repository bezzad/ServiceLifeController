﻿using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace ServiceLifeController.Models
{
    public class ServiceInfo
    {
        public string Name { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ServiceType StartupType { get; set; }
        public string LogInAs { get; set; }
    }
}
