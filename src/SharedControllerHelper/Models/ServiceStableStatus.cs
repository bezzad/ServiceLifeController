using System.ServiceProcess;

namespace SharedControllerHelper.Models
{
    /// <summary>
    /// This is a stable status copy of <see cref="ServiceControllerStatus"/> enum.
    /// </summary>
    public enum ServiceStableStatus
    {
        None = 0,
        Stopped = 1,
        Running = 4,
        Paused = 7
    }

    // Main ServiceControllerStatus enum is:
    //
    //namespace System.ServiceProcess
    //{
    //    /// <summary>Indicates the current state of the service.</summary>
    //    public enum ServiceControllerStatus
    //    {
    //        Stopped = 1,
    //        StartPending = 2,
    //        StopPending = 3,
    //        Running = 4,
    //        ContinuePending = 5,
    //        PausePending = 6,
    //        Paused = 7,
    //    }
    //}

}
