using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.Category.Domain;

namespace Xr.System.Domain.Repository
{
    public interface IBasePropertyReporistory : IRepository<BaseProperty>, ITransient
    {
        IQueryable<BaseProperty> QueryDetail(long id);
        IQueryable<BaseProperty> QueryListByIds(List<long> ids);
    }
}
