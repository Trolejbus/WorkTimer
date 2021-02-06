using System;
using System.Collections.Generic;
using System.Linq;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;

namespace WorkTimer.Services.Controllers
{
    internal class WorkController : IWorkController
    {
        public WorkLogModel CurrentLog { get; set; }
        private List<WorkLogModel> _logs = new List<WorkLogModel>();
        private readonly ITimeService _realTimeService;
        private readonly WorkTimerEvents _events;

        public WorkController(ITimeService realTimeService, WorkTimerEvents events)
        {
            _realTimeService = realTimeService;
            _events = events;
        }

        public WorkLogModel StartOrResume(WorkLogModel model, DateTime? from = null)
        {
            return StartWork(model, from);
        }

        public void StartBreak()
        {
            if (CurrentLog?.Type == WorkType.Break)
            {
                return;
            }

            StartWork(CreateBreakModel());
        }

        public void FinishBreak()
        {
            if (CurrentLog.Type != WorkType.Break)
            {
                return;
            }

            var workBefore = GetWorkBeforeBreak();
            if (workBefore == null)
            {
                return;
            }

            StartWork(workBefore);
        }

        public IEnumerable<WorkLogModel> GetCurrentLogs()
        {
            return _logs;
        }

        private WorkLogModel StartWork(WorkLogModel workLogModel, DateTime? from = null)
        {
            if (workLogModel == CurrentLog)
            {
                return CurrentLog;
            }

            var currentDate = from ?? _realTimeService.GetCurrentDate();
            StopWork(currentDate);
            workLogModel.StartDate = currentDate;
            CurrentLog = workLogModel;
            _logs.Add(workLogModel);
            _events.StartWork(workLogModel);
            return workLogModel;
        }

        private void StopWork(DateTime endDate)
        {
            if (CurrentLog == null)
            {
                return;
            }

            CurrentLog.EndDate = endDate;
            var stopedWork = CurrentLog;
            CurrentLog = null;
            _events.StopWork(stopedWork);
        }

        private WorkLogModel CreateBreakModel()
        {
            return new WorkLogModel()
            {
                Type = WorkType.Break,
            };
        }

        private WorkLogModel GetWorkBeforeBreak()
        {
            return _logs.Where(l => l.Type == WorkType.Work)
                .OrderByDescending(l => l.EndDate)
                .FirstOrDefault();
        }
    }
}
