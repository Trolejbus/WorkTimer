using System;

namespace WorkTimer.Interfaces.Controllers
{
    public interface IApplicationController
    {
        event Action ApplicationExit;
        event Action Initialized;

        void Initialize();
    }
}
