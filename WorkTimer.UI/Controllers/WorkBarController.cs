using System;
using WorkTimer.UI.Enum;
using WorkTimer.UI.Interfaces;

namespace WorkTimer.UI.Controllers
{
    internal class WorkBarController : IWorkBarController
    {
        public event ShowStateChangeDelegate OnWorkBarStateChanged;
        private IWorkBar workBar;
        private ShowState state;

        public WorkBarController()
        {

        }

        public void SetWorkBar(IWorkBar workBar)
        {
            this.workBar = workBar;
            GetWorkBar().SetVisible(state);
        }

        public void Show()
        {
            State = ShowState.Shown;
        }

        public void Hide()
        {
            State = ShowState.Hidden;
        }

        public void Toggle()
        {
            if (State == ShowState.Hidden)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        public ShowState State
        {
            get
            {
                return state;
            }
            set
            {
                if (state == value)
                {
                    return;
                }

                state = value;
                OnWorkBarStateChanged?.Invoke(state);
                GetWorkBar().SetVisible(state);
            }
        }

        private IWorkBar GetWorkBar(){
            return workBar ?? throw new ArgumentException("WorkBar has not been set");
        }
    }
}
