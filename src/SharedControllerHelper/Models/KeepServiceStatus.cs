using Models;

namespace SharedControllerHelper.Models
{
    public class KeepServiceStatus
    {
        public ServiceInfo Service { get; set; }
        public ServiceStableStatus KeepStatusOn { get; set; } = ServiceStableStatus.None;
    }
}