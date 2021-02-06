using System;
using System.Collections.Generic;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Domain.Models.Models.QuickActions;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;

namespace WorkTimer.Services.Controllers
{
    public class LockedController : ILockedController
    {
        private readonly IWorkController _workController;
        private readonly WorkTimerEvents _events;
        private readonly IQuickActionController _quickActionController;
        private readonly ITimeService _timeService;
        private DateTime lockedTime;

        public LockedController(
            IWorkController workController,
            WorkTimerEvents events,
            IQuickActionController quickActionController,
            ITimeService timeService)
        {
            _workController = workController;
            _events = events;
            _quickActionController = quickActionController;
            _timeService = timeService;
            events.OnSessionLocked += Events_OnSessionLocked;
            events.OnSessionUnlock += Events_OnSessionUnlock;
        }

        private void Events_OnSessionUnlock()
        {
            var breakAnswer = new AskAnswerModel()
            {
                Text = "Log as break",
                Default = true,
            };
            var workAnswer = new AskAnswerModel()
            {
                Text = "Log as work",
            };
            var timeIdle = _timeService.GetCurrentDate() - lockedTime;
            var answer = _quickActionController.Ask(new AskModel()
            {
                Text = $"You have spend {timeIdle:hh\\:mm\\:ss} as idle. Where do you want to spend time?",
                Answers = new List<AskAnswerModel>()
                    {
                        breakAnswer,
                        workAnswer,
                    },
            });

            var type = answer == breakAnswer ?
                WorkType.Break :
                WorkType.Work;
            ChangeTo(type);
        }

        private void Events_OnSessionLocked()
        {
            lockedTime = _timeService.GetCurrentDate();
        }

        private void ChangeTo(WorkType type)
        {
            if (type == WorkType.Work)
            {
                if (_workController.CurrentLog?.Type != WorkType.Work)
                {
                    _workController.StartOrResume(new WorkLogModel() { Type = WorkType.Work }, lockedTime);
                }
            }
            else
            {
                if (_workController.CurrentLog?.Type != WorkType.Break)
                {
                    _workController.StartOrResume(new WorkLogModel() { Type = WorkType.Break }, lockedTime);
                }
            }
        }
    }
}
