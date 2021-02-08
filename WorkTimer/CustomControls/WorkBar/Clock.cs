using Autofac;
using System;
using System.Drawing;
using System.Windows.Forms;
using WorkTimer.Behaviours;
using WorkTimer.CustomControls.Base;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;
using WorkTimer.Services.Controllers;

namespace WorkTimer.CustomControls.WorkBar
{
    public partial class Clock : ScoppedUserControl
    {
        private const int TimerSpeed = 20;
        private ITimerController timerController;
        private ITimeService dateService;
        private ITimerTaskController timerTaskController;
        private IWorkTimerController workTimerController;
        private WorkTimerEvents events;

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
            events = scope.Resolve<WorkTimerEvents>();

            timerController.OnTick += TimerController_OnTick;
            timerController.StateChanged += TimerController_StateChanged;
            events.OnWorkStarted += Events_OnWorkStarted;
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
            label.Text = $"{currentTime:hh\\:mm\\:ss}";
        }

        private void Events_OnWorkStarted(WorkLogModel work)
        {
            if (work.Type == WorkType.Work)
            {
                currentTimeLabel.ForeColor = Color.LawnGreen;
            }
            else
            {
                currentTimeLabel.ForeColor = Color.Wheat;
            }
        }
    }
}
