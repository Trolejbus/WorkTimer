using Autofac;
using WorkTimer.Controllers;
using WorkTimer.Interfaces.Controllers;

namespace WorkTimer
{
    public class WorkTimerModule : Module
    {
        public WorkTimerModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationController>().As<IApplicationController>().SingleInstance();
            builder.RegisterType<MusicPlayerController>().As<IMusicPlayerController>().SingleInstance();
            builder.RegisterType<QuickActionController>().As<IQuickActionController>().SingleInstance();
        }
    }
}
