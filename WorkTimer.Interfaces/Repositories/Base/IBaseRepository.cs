using System.Collections.Generic;
using WorkTimer.Domain.Models.Models.Base;

namespace WorkTimer.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TDomainModel>
        where TDomainModel : DomainModel<int>, new()
    {
        IEnumerable<TDomainModel> GetAll();
        void Add(TDomainModel item);
    }
}
