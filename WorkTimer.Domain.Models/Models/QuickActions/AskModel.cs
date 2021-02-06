using System.Collections.Generic;

namespace WorkTimer.Domain.Models.Models.QuickActions
{
    public class AskModel
    {
        public string Question { get; set; }
        public IEnumerable<AskAnswerModel> Answers { get; set; }
    }
}
