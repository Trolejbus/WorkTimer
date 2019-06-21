using System;
using WorkTimer.Domain.Models.Enums;

namespace WorkTimer.Interfaces.Controllers
{
    public interface ITimerController
    {
        TimerState State { get; }
        event Action OnTick;
        event Action<TimerState> StateChanged;
        void TurnOff();
        void TurnOn();
    }
}
