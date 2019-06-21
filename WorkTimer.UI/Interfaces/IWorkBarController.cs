using WorkTimer.UI.Enum;
using WorkTimer.UI.Interfaces;

namespace WorkTimer.UI.Interfaces
{
    public delegate void ShowStateChangeDelegate(ShowState currentState);

    public interface IWorkBarController
    {
        ShowState State { get; set; }

        event ShowStateChangeDelegate OnWorkBarStateChanged;

        void Show();
        void Hide();
        void Toggle();
        void SetWorkBar(IWorkBar workBar);      
    }
}