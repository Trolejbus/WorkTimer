using Autofac;
using System;
using System.Windows.Forms;
using WorkTimer.Behaviours;
using WorkTimer.CustomControls.Base;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Services.Controllers;

namespace WorkTimer.CustomControls.WorkBar
{
    public partial class BreakNotificationForm : ScoppedForm
    {
        private int tick = 0;
        private IWorkController workController;
        private WorkTimerEvents events;
        private IWorkTimerController workTimerController;
        private ITimerController timerControler;

        public BreakNotificationForm()
        {
            InitializeComponent();
            TopMost = true;
        }

        protected override void OnScopedSet(ILifetimeScope scope)
        {
            base.OnScopedSet(scope);
            workController = scope.Resolve<IWorkController>();
            events = scope.Resolve<WorkTimerEvents>();
            workTimerController = scope.Resolve<IWorkTimerController>();
            timerControler = scope.Resolve<ITimerController>();
            timerControler.OnTick += TimerController_OnTick;

            events.OnWorkStarted += Events_OnWorkStarted;
        }

        private void Events_OnWorkStarted(WorkLogModel model)
        {
            var pause = model.Type == WorkType.Break;
            if (pause)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void TimerController_OnTick()
        {
            this.InvokeEx(f => f.UpdateTime(workTimerController.FullTime, breakTimeLabel));
        }

        private void UpdateTime(TimeSpan currentTime, Label label)
        {
            label.Text = $"{currentTime:hh\\:mm\\:ss}";
        }

        private void ChillingLabel_Click(object sender, System.EventArgs e)
        {
            workController.FinishBreak();
        }

        private void chillingAnimation_Tick(object sender, System.EventArgs e)
        {
            switch (tick)
            {
                case 0:
                    chillingLabel.Text = "Chilling";
                    break;
                case 1:
                    chillingLabel.Text = "Chilling.";
                    break;
                case 2:
                    chillingLabel.Text = "Chilling..";
                    break;
                case 3:
                    chillingLabel.Text = "Chilling...";
                    break;
            }

            tick++;
            if (tick >= 4)
            {
                tick = 0;
            }
        }
    }
}
