using System;
using System.Collections.Generic;
using WorkTimer.Domain.Models.Models;

namespace WorkTimer.Interfaces.Controllers
{
    public interface IWorkController
    {
        WorkLogModel CurrentLog { get; set; }
        IEnumerable<WorkLogModel> GetCurrentLogs();
        WorkLogModel StartOrResume(WorkLogModel model, DateTime? from = null);
        void StartBreak();
        void FinishBreak();
    }
}