using System;
using WorkTimer.Domain.Models.Models;

namespace WorkTimer.Services.Controllers
{
    public class WorkTimerEvents
    {
        public event Action<WorkLogModel> OnWorkStarted;
        public void StartWork(WorkLogModel model) => OnWorkStarted?.Invoke(model);
        public event Action<WorkLogModel> OnWorkStoped;
        public void StopWork(WorkLogModel model) => OnWorkStoped?.Invoke(model);
        public event Action OnSessionLocked;
        public void SessionLocked() => OnSessionLocked?.Invoke();
        public event Action OnSessionUnlock;
        public void SessionUnlock() => OnSessionUnlock?.Invoke();
    }
}
