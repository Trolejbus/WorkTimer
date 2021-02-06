using Autofac;
using System;
using System.Windows.Forms;
using WorkTimer.Behaviours;
using WorkTimer.CustomControls.Base;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;

namespace WorkTimer.CustomControls.WorkBar
{
    public partial class Clock : ScoppedUserControl
    {
        private const int TimerSpeed = 20;
        private ITimerController timerController;
        private ITimeService dateService;
        private ITimerTaskController timerTaskController;
        private IWorkTimerController workTimerController;

        public Clock()
        {
            InitializeComponent();
            progressBar1.MarqueeAnimationSpeed = TimerSpeed;          
        }

        protected override void OnScopedSet(ILifetimeScope scope)
        {
            timerController = scope.Resolve<ITimerController>();
            timerTaskController = scope.Resolve<ITimerTaskController>();
            workTimerController = scope.Resolve<IWorkTimerController>();

            timerController.OnTick += TimerController_OnTick;
            timerController.StateChanged += TimerController_StateChanged;
        }

        private void TimerController_StateChanged(TimerState state)
        {
            switch (state)
            {
                 case TimerState.TurnedOff:
                     progressBar1.MarqueeAnimationSpeed = int.MaxValue;
                     break;
                 case TimerState.TurnedOn:
                     progressBar1.MarqueeAnimationSpeed = TimerSpeed;
                     break;
                 default:
                     throw new ArgumentException($"TimerState '{state}' not recognized");
            }
        }

        private void TimerController_OnTick()
        {
            this.InvokeEx(f => f.UpdateTime(workTimerController.FullTime, fullTimeLabel));
            this.InvokeEx(f => f.UpdateTime(workTimerController.WorkTime, workTimeLabel));
            this.InvokeEx(f => f.UpdateTime(workTimerController.CurrentTime, currentTimeLabel));
        }

        private void UpdateTime(TimeSpan currentTime, Label label)
        {
            if(currentTime.TotalHours > 0)
            {
                label.Text = $"{currentTime:mm\\:ss}";
            }
            else
            {
                label.Text = $"{currentTime:hh\\:mm}";
            }
        }
    }
}
