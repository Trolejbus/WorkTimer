using System;

namespace WorkTimer.Interfaces.Controllers
{
    public interface ITimerTaskController
    {
        TimeSpan GetCurrentProgress();
        void Pause();
        void Start();
        void Stop();
    }
}
