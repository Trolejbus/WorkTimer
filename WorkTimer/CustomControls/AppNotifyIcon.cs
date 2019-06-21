using System;
using System.Diagnostics;
using System.Windows.Forms;
using WorkTimer.CustomControls.Browser;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.UI.Enum;
using WorkTimer.UI.Interfaces;

namespace WorkTimer.CustomControls
{
    internal class AppNotifyIcon
    {
        private readonly IWorkBarController workBarController;
        private readonly IApplicationController applicationController;
        private NotifyIcon notifyIcon;
        private MenuItem showMenuItem;

        public AppNotifyIcon(IWorkBarController workBarController, IApplicationController applicationController)
        {
            this.workBarController = workBarController;
            this.applicationController = applicationController;
        }

        public void Initialize()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.clock,
                Visible = true
            };

            CreateComponents();

            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            applicationController.ApplicationExit += Application_ApplicationExit;
        }

        private void CreateComponents()
        {
            notifyIcon.ContextMenu = new ContextMenu();

            showMenuItem = notifyIcon.ContextMenu.MenuItems.Add("Work Bar", (s, e) => { workBarController.Toggle(); });
            notifyIcon.ContextMenu.MenuItems.Add("Browser", (s, e) => { new BrowserForm().Show(); });
            notifyIcon.ContextMenu.MenuItems.Add("Close", (s, e) => { Application.Exit(); });
            //notifyIcon.ContextMenu.MenuItems.Add("Settings", (s, e) => { Managers.Instance.SettingsManager.Show(); });

            workBarController.OnWorkBarStateChanged += WorkBarController_OnWorkBarStateChanged;
            WorkBarController_OnWorkBarStateChanged(workBarController.State);
        }

        private void RunBrowser()
        {
            new BrowserForm().Show();
        }

        private void WorkBarController_OnWorkBarStateChanged(ShowState currentState)
        {
            showMenuItem.Checked = currentState == ShowState.Shown;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void ShowMainForm()
        {
            /* SettingsWindow.Instance.Show();
             SettingsWindow.Instance.BringToFront();*/
        }

        private void Application_ApplicationExit()
        {
            notifyIcon.Visible = false;
        }
    }
}
