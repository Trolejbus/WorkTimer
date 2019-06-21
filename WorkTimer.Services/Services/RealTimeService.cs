using System;
using WorkTimer.Interfaces.Services;

namespace WorkTimer.Services.Services
{
    public class RealTimeService: ITimeService
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
