using System;
using System.Drawing;
using Autofac;
using WorkTimer.Behaviours;
using WorkTimer.CustomControls.Base;
using WorkTimer.UI.Enum;
using WorkTimer.UI.Interfaces;

namespace WorkTimer.CustomControls.WorkBar
{
    public partial class WorkBarForm : ScoppedForm, IWorkBar
    {
        private readonly IWorkBarController workBarController;

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
            Popup popup = new Popup();
            popup.MakePopup(this);

            Width = 54;
        }

        public void Initialize()
        {
            workBarController.SetWorkBar(this);
        }

        /*private void TimeManager_OnStateChanged(WorkTimerStates currentState)
        {
            switch (currentState)
            {
                case WorkTimerStates.Stop:
                    playPauseButton.StaticImage = Properties.Resources.play3;
                    playPauseButton.HoverImage = Properties.Resources.play3_hover;
                    playPauseButton.DownImage = Properties.Resources.play3_hover;
                    break;
                case WorkTimerStates.Start:
                    playPauseButton.StaticImage = Properties.Resources.pause2;
                    playPauseButton.HoverImage = Properties.Resources.pause_hover;
                    playPauseButton.DownImage = Properties.Resources.pause_hover;
                    break;
                default:
                    break;
            }
        }*/

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            
        }

        private void hoverButton_Click(object sender, EventArgs e)
        {
            workBarController.Hide();
        }

        public void SetVisible(ShowState state)
        {
            Visible = state == ShowState.Shown;
        }
    }
}
