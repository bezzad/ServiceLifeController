using System;

namespace SharedControllerHelper.Models
{
    [Flags]
    public enum ServiceControllerStatusChanging
    {
        Stopped = 1,
        StartPending = 2,
        StopPending = 4,
        Running = 8,
        ContinuePending = 16,
        PausePending = 32,
        Paused = 64,
        AllChangingStatus = Stopped | StartPending | StopPending | Running | ContinuePending | PausePending | Paused // 127
    }
}

