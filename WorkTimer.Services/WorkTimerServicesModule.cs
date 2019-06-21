using Autofac;
using WorkTimer.Interfaces.Controllers;
using WorkTimer.Interfaces.Services;
using WorkTimer.Services.Controllers;
using WorkTimer.Services.Services;

namespace WorkTimer.Services
{
    public class WorkTimerServicesModule: Module
    {
        public WorkTimerServicesModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TimerController>().As<ITimerController>().SingleInstance();
            builder.RegisterType<RealTimeService>().As<ITimeService>().SingleInstance();
            builder.RegisterType<TimerTaskController>().As<ITimerTaskController>().SingleInstance();
        }
    }
}
