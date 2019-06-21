using System;
using System.Timers;
using WorkTimer.Domain.Models.Enums;
using WorkTimer.Interfaces.Controllers;

namespace WorkTimer.Services.Controllers
{
    internal class TimerController : ITimerController
    {
        private Timer timer;
        public event Action OnTick;
        public event Action<TimerState> StateChanged;
        public TimerState State { get; private set; }

        public TimerController(IApplicationController controller)
        {
            State = TimerState.TurnedOff;
            SetTimer();
            controller.Initialized += Controller_Initialized;
        }

        public void TurnOn()
        {
            timer.Enabled = true;
            State = TimerState.TurnedOn;
            StateChanged?.Invoke(State);
        }

        public void TurnOff()
        {
            timer.Enabled = false;
            State = TimerState.TurnedOff;
            StateChanged?.Invoke(State);
        }

        private void SetTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = false;
        }

        private void Controller_Initialized()
        {
            TurnOn();
        }


        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            OnTick?.Invoke();
        }
    }
}
