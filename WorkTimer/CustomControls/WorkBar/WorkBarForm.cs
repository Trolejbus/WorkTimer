using System;
using System.Drawing;
using Autofac;
using WorkTimer.Behaviours;
using WorkTimer.CustomControls.Base;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Services.Controllers;
using WorkTimer.UI.Enum;
using WorkTimer.UI.Interfaces;

namespace WorkTimer.CustomControls.WorkBar
{
    public partial class WorkBarForm : ScoppedForm, IWorkBar
    {
        private readonly IWorkBarController workBarController;
        private IWorkController workController;
        private WorkTimerEvents events;
        private bool pause = true;

        public WorkBarForm(IWorkBarController workBarController)
        {
            this.workBarController = workBarController;
            InitializeComponent();
            DragWindow dragWindow = new DragWindow();
            dragWindow.Controller = moveControlPanel;
            dragWindow.DraggableControl = this;
            dragWindow.DragHorizontal = false;
            dragWindow.FitToParentDimensions = true;
            dragWindow.FitToParentDimensionsDelayMin = new Point(0, moveControlPanel.Top + moveControlPanel.Margin.Top);

            Visible = true;
            TopMost = true;

            Popup popup = new Popup();
            popup.MakePopup(this, PopupPosition.TopRight);

            Width = 54;
        }

        public void Initialize()
        {
            workBarController.SetWorkBar(this);
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                workController.StartOrResume(new WorkLogModel()
                {
                    Type = WorkType.Work,
                });
            }
            else
            {
                workController.StartBreak();
            }
        }

        private void hoverButton_Click(object sender, EventArgs e)
        {
            workBarController.Hide();
        }

        public void SetVisible(ShowState state)
        {
            Visible = state == ShowState.Shown;
        }

        protected override void OnScopedSet(ILifetimeScope scope)
        {
            base.OnScopedSet(scope);
            workController = scope.Resolve<IWorkController>();
            events = scope.Resolve<WorkTimerEvents>();
            events.OnWorkStarted += Events_OnWorkStarted;
        }

        private void Events_OnWorkStarted(WorkLogModel model)
        {
            pause = model.Type == WorkType.Break;
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            if (pause)
            {
                playPauseButton.StaticImage = Properties.Resources.play3;
                playPauseButton.HoverImage = Properties.Resources.play3_hover;
                playPauseButton.DownImage = Properties.Resources.play3_hover;
            }
            else
            {
                playPauseButton.StaticImage = Properties.Resources.pause2;
                playPauseButton.HoverImage = Properties.Resources.pause_hover;
                playPauseButton.DownImage = Properties.Resources.pause_hover;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new WorkTimerForm(Scope).ShowDialog();
        }
    }
}
