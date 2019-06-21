using AutoMapper;
using WorkTimer.SQLite;

namespace WorkTimer
{
    public class AutoMapperConfigurationFactory
    {
        public IMapper Build()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<WorkTimerDataProfile>();
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
