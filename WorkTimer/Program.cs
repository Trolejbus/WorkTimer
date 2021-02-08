using Autofac;
using Microsoft.Win32;
using System;
using System.Windows.Forms;
using WorkTimer.Behaviours;
using WorkTimer.CustomControls;
using WorkTimer.CustomControls.WorkBar;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Services.Controllers;
using WorkTimer.UI.Interfaces;

namespace WorkTimer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new WorkTimerContainerFactory().Build();

            using (var scope = container.BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var workBarController = scope.Resolve<IWorkBarController>();
                var applicationController = scope.Resolve<IApplicationController>();
                var timerController = scope.Resolve<ITimerController>();
                var timerTaskController = scope.Resolve<ITimerTaskController>();

                AppNotifyIcon trayWorker = 
                    new AppNotifyIcon(workBarController, applicationController);
                trayWorker.Initialize();

                BreakNotificationForm breakNotificationForm = new BreakNotificationForm();
                breakNotificationForm.SetScope(scope);
                new Popup().MakePopup(breakNotificationForm, PopupPosition.BottomRight);

                WorkBarForm bar = new WorkBarForm(workBarController);
                bar.SetScope(scope);
                bar.Initialize();

                applicationController.Initialize();
                var events = scope.Resolve<WorkTimerEvents>();
                var lockedController = scope.Resolve<ILockedController>();
                var quickActionController = scope.Resolve<IQuickActionController>();
                SystemEvents.SessionSwitch += SystemEvents_SessionSwitch(events);

                Application.Run();
            }
        }

        private static SessionSwitchEventHandler SystemEvents_SessionSwitch(WorkTimerEvents events)
        {
            return (object sender, SessionSwitchEventArgs e) =>
            {
                if (e.Reason == SessionSwitchReason.SessionLock)
                {
                    events.SessionLocked();
                }
                else if (e.Reason == SessionSwitchReason.SessionUnlock)
                {
                    events.SessionUnlock();
                }
            };
        }
    }
}
