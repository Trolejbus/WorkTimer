using Autofac;
using AutoMapper;
using WorkTimer.Services;
using WorkTimer.SQLite;
using WorkTimer.UI;

namespace WorkTimer
{
    public class WorkTimerContainerFactory
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<WorkTimerSQLiteModule>();
            builder.RegisterModule<WorkTimerServicesModule>();
            builder.RegisterModule<WorkTimerUIModule>();
            builder.RegisterModule<WorkTimerModule>();

            builder.Register(c => new AutoMapperConfigurationFactory().Build()).As<IMapper>();
            return builder.Build();
        }
    }
}
