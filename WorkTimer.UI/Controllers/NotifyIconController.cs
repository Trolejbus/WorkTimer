using System;
using WorkTimer.UI.Interfaces;

namespace WorkTimer.UI.Controllers
{
    /*public class NotifyIconController
    {
        private readonly INotifyIconControl notifyIconControl;
        private readonly IApplicationController controller;

        public NotifyIconController(IApplicationController controller)
        {
            notifyIconControl.OnDoubleClicked += NotifyIcon_DoubleClick;

            CreateMenuItems();
        }

        public void SetNotifyIconControl(INotifyIconControl control)
        {
            if(notifyIconControl != null)
            {
                throw new Exception("Notify Icon Control has been already set");
            }

            controller.ApplicationExit += Controller_ApplicationExit;
            CreateMenuItems();
        }

        private void CreateMenuItems()
        {
            showMenuItem.Text = "Work Bar";
            //showMenuItem.Click += (s, e) => { Managers.Instance.WorkBarManager.SwitchHidden(); };

            notifyIcon.ContextMenu.MenuItems.Add(showMenuItem);
            //notifyIcon.ContextMenu.MenuItems.Add("Settings", (s, e) => { Managers.Instance.SettingsManager.Show(); });
            notifyIcon.ContextMenu.MenuItems.Add("Close", (s, e) => { Application.Exit(); });

            /*if (Managers.Instance != null && Managers.Instance.WorkBarManager != null)
            {
                Managers.Instance.WorkBarManager.OnWorkBarStateChanged += WorkBarManager_OnWorkBarStateChanged;
                WorkBarManager_OnWorkBarStateChanged(Managers.Instance.WorkBarManager.State);
            }*/
        /*}

        /*private void WorkBarManager_OnWorkBarStateChanged(ShowState currentState)
        {
            showMenuItem.Checked = currentState == ShowState.Shown;
        }*/

        /*private void Controller_ApplicationExit()
        {
            throw new NotImplementedException();
        }

        private void ShowMainForm()
        {
            /* SettingsWindow.Instance.Show();
             SettingsWindow.Instance.BringToFront();*/
        //}

        /*private void NotifyIcon_DoubleClick()
        {
            ShowMainForm();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
        }
    }*/
}
