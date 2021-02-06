using System;

namespace WorkTimer.Interfaces.Controllers
{
    public interface IWorkTimerController
    {
        TimeSpan FullTime { get; }
        TimeSpan WorkTime { get; }
        TimeSpan CurrentTime { get; }
    }
}