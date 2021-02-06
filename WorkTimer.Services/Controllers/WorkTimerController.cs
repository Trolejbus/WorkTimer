using System;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;

namespace WorkTimer.Services.Controllers
{
    internal class WorkTimerController : IWorkTimerController
    {
        private readonly WorkTimerEvents _events;
        private readonly ITimeService _timeService;
        private readonly IWorkController _workController;
        private TimeSpan fullTime;
        private TimeSpan workTime;

        public WorkTimerController(
            WorkTimerEvents events,
            ITimeService timeService,
            IWorkController workController)
        {
            _events = events;
            _timeService = timeService;
            _workController = workController;
            _events.OnWorkStarted += _events_OnWorkStarted;
            _events.OnWorkStoped += _events_OnWorkStoped;
        }

        public TimeSpan FullTime
        {
            get
            {
                return fullTime + GetCurrentWorkSpan();
            }
        }

        public TimeSpan WorkTime
        {
            get
            {
                return workTime + (
                    _workController.CurrentLog?.Type == WorkType.Work ?
                        GetCurrentWorkSpan() :
                        TimeSpan.Zero);
            }
        }

        public TimeSpan CurrentTime
        {
            get
            {
                return GetCurrentWorkSpan();
            }
        }

        private TimeSpan GetCurrentWorkSpan()
        {
            return _workController.CurrentLog != null ?
                _timeService.GetCurrentDate() - _workController.CurrentLog.StartDate :
                TimeSpan.Zero;
        }

        private void _events_OnWorkStarted(WorkLogModel model)
        {

        }

        private void _events_OnWorkStoped(WorkLogModel model)
        {
            var timeSpan = model.EndDate.Value - model.StartDate;
            if (model.Type == WorkType.Work)
            {
                workTime += timeSpan;
            }

            fullTime += timeSpan;
        }
    }
}
