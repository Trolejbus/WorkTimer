using System;
using WorkTimer.Domain.Models.Enums;

namespace WorkTimer.Domain.Models.Models
{
    public class WorkLogModel
    {
        public WorkTaskModel Task { get; set; }

        public int TaskId { get; set; }

        public WorkType Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
