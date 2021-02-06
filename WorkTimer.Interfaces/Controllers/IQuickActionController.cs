using WorkTimer.Domain.Models.Models.QuickActions;

namespace WorkTimer.Interfaces.Controllers
{
    public interface IQuickActionController
    {
        AskAnswerModel Ask(AskModel model);
    }
}
