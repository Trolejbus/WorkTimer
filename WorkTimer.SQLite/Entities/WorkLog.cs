using WorkTimer.Domain.Models.Enums;

namespace WorkTimer.SQLite.Entities
{
    internal class WorkLog
    {
        public WorkTask Task { get; set; }

        public int TaskId { get; set; }

        public WorkType Type { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
