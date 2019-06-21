using System;
using WorkTimer.Domain.Models.Models.Base;

namespace WorkTimer.Domain.Models.Models
{
    public class WorkTaskModel: DomainModel<int>
    {
        public string Name { get; set; }

        public TimeSpan? PlannedTime { get; set; }

        public string ShortText { get; set; }
    }
}
