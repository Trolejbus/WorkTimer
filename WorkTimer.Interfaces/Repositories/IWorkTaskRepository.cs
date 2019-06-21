using WorkTimer.Domain.Models.Models;
using WorkTimer.Interfaces.Repositories.Base;

namespace WorkTimer.Interfaces.Repositories
{
    public interface IWorkTaskRepository: IBaseRepository<WorkTaskModel>
    {
    }
}
