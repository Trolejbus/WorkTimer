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
            builder.RegisterType<WorkController>().As<IWorkController>().SingleInstance();
            builder.RegisterType<WorkTimerController>().As<IWorkTimerController>().SingleInstance();
            builder.RegisterType<WorkTimerEvents>().As<WorkTimerEvents>().SingleInstance();
            builder.RegisterType<LockedController>().As<ILockedController>().SingleInstance();
        }
    }
}
