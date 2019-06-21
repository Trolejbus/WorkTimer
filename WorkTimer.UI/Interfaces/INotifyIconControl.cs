using System;
using WorkTimer.UI.Enum;

namespace WorkTimer.UI.Interfaces
{
    public interface INotifyIconControl
    {
        void SetVisible(ShowState state);
        event Action OnDoubleClicked;
    }
}
