using System;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;

namespace WorkTimer.Services.Controllers
{
    public class TimerTaskController : ITimerTaskController
    {
        public DateTime? StartedDate;
        public bool pause;
        public event Action OnPause;
        public event Action OnTaskCompleted;

        private readonly ITimeService timeService;
        private readonly IApplicationController applicationController;
        private readonly ITimerController timerController;

        public TimerTaskController(ITimeService timeService,
            ITimerController timerController,
            IApplicationController applicationController)
        {
            this.timeService = timeService;
            this.timerController = timerController;
            this.applicationController = applicationController;
            applicationController.Initialized += ApplicationController_Initialized;
            timerController.OnTick += TimerController_OnTick;
        }

        private void TimerController_OnTick()
        {
            if(pause)
            {
                if(GetCurrentProgress().TotalMinutes > 5)
                {
                    
                }
            }
        }

        private void ApplicationController_Initialized()
        {
            Start();
        }

        public TimeSpan GetCurrentProgress()
        {
            if(!StartedDate.HasValue)
            {
                return TimeSpan.Zero;
            }

            var currentTime = timeService.GetCurrentDate();
            return currentTime - StartedDate.Value;
        }

        public void Start()
        {
            StartedDate = timeService.GetCurrentDate();
        }

        public void Stop()
        {

        }

        public void Pause()
        {

        }
    }
}
