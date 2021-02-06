using WorkTimer.CustomControls.QuickActions;
using WorkTimer.Domain.Models.Models.QuickActions;
using WorkTimer.Interfaces.Controllers;

namespace WorkTimer.Controllers
{
    public class QuickActionController : IQuickActionController
    {
        public AskAnswerModel Ask(AskModel model)
        {
            var askForm = new AskForm()
            {
                Question = model,
            };
            askForm.Init();
            var dialog = askForm.ShowDialog();
            return askForm.Answer;
        }
    }
}
