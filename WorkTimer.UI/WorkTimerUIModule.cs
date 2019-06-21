using Autofac;
using WorkTimer.UI.Controllers;
using WorkTimer.UI.Interfaces;

namespace WorkTimer.UI
{
    public class WorkTimerUIModule : Module
    {
        public WorkTimerUIModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkBarController>().As<IWorkBarController>().SingleInstance();           
        }
    }
}
