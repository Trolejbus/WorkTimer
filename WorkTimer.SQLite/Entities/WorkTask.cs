using WorkTimer.SQLite.Entities.Base;

namespace WorkTimer.SQLite.Entities
{
    internal class WorkTask: Entity<int>
    {
        public string Name { get; set; }

        public string PlannedTime { get; set; }

        public string ShortText { get; set; }
    }
}
