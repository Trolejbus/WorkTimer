using Autofac;
using System;
using System.Windows.Forms;
using WorkTimer.Controllers;
using WorkTimer.CustomControls;
using WorkTimer.CustomControls.WorkBar;
using WorkTimer.Interfaces.Controllers;
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

                WorkBarForm bar = new WorkBarForm(workBarController);
                bar.SetScope(scope);
                bar.Initialize();

                applicationController.Initialize();

                Application.Run();
            }
        }
    }
}
