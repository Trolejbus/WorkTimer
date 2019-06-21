using Autofac;
using AutoMapper;
using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Repositories;
using WorkTimer.SQLite.Entities;
using WorkTimer.SQLite.Repositories.Base;

namespace WorkTimer.SQLite.Repositories
{
    internal class WorkTaskRepository 
        : BaseRepository<WorkTaskModel, WorkTask, int>, IWorkTaskRepository
    {
        public WorkTaskRepository(AppContext context, IMapper mapper, ILifetimeScope scope) 
            : base(context, mapper, scope)
        {
        }
    }
}
