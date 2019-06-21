using Autofac;
using System;
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

        public Clock()
        {
            InitializeComponent();
            progressBar1.MarqueeAnimationSpeed = TimerSpeed;          
        }

        protected override void OnScopedSet(ILifetimeScope scope)
        {
            timerController = scope.Resolve<ITimerController>();
            timerTaskController = scope.Resolve<ITimerTaskController>();

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
            var currentTime = timerTaskController.GetCurrentProgress();
            this.InvokeEx(f => f.UpdateTime(currentTime));
        }

        private void UpdateTime(TimeSpan currentTime)
        {
            if(currentTime.TotalHours > 0)
            {
                label1.Text = $"{currentTime:mm\\:ss}";
            }
            else
            {
                label1.Text = $"{currentTime:hh\\:mm}";
            }
        }
    }
}
