using System.Collections.Generic;

namespace WorkTimer.Domain.Models.Models.QuickActions
{
    public class AskModel
    {
        public string Text { get; set; }
        public IEnumerable<AskAnswerModel> Answers { get; set; }
    }
}
