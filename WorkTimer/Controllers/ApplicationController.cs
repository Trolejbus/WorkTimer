using System;
using System.Windows.Forms;
using WorkTimer.Interfaces.Controllers;

namespace WorkTimer.Controllers
{
    internal class ApplicationController: IApplicationController
    {
        public event Action ApplicationExit;
        public event Action Initialized;

        public ApplicationController()
        {
            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            ApplicationExit?.Invoke();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}
