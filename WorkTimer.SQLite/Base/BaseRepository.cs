using Autofac;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WorkTimer.Domain.Models.Models.Base;
using WorkTimer.SQLite.Entities.Base;

namespace WorkTimer.SQLite.Repositories.Base
{
    internal class BaseRepository<TDomainModel, TEntityModel, TId>
        where TDomainModel: DomainModel<TId>, new()
        where TEntityModel: Entity<TId>, new()
    {
        protected readonly AppContext context;
        protected readonly IMapper mapper;
        protected readonly ILifetimeScope scope;

        public BaseRepository(AppContext context,
            IMapper mapper,
            ILifetimeScope scope)
        {
            this.context = context;
            this.mapper = mapper;
            this.scope = scope;
        }

        public IEnumerable<TDomainModel> GetAll()
        {
            var entities = context.Set<TEntityModel>().ToList();
            return entities.Select(e => mapper.Map<TDomainModel>(e)).ToList();
        }

        public virtual void Add(TDomainModel model)
        {
            var entityModel = mapper.Map<TEntityModel>(model);
            var entities = context.Set<TEntityModel>();
            entities.Add(entityModel);
            context.SaveChanges();
        }
    }
}
