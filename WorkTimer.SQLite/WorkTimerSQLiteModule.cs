using Autofac;
using WorkTimer.Interfaces.Repositories;
using WorkTimer.SQLite.Repositories;

namespace WorkTimer.SQLite
{
    public class WorkTimerSQLiteModule : Module
    {
        public WorkTimerSQLiteModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkTaskRepository>().As<IWorkTaskRepository>();
            builder.RegisterType<AppContext>().As<AppContext>().SingleInstance();
        }
    }
}
