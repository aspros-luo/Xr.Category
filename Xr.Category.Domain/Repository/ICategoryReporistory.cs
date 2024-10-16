using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.Category.Domain;

namespace Xr.System.Domain.Repository
{
    public interface ICategoryReporistory : IRepository<ActionCategory>, ITransient
    {
        IQueryable<ActionCategory> QueryDetail(long id);
        IQueryable<ActionCategory> QueryListByIds(List<long> ids);
    }
}
