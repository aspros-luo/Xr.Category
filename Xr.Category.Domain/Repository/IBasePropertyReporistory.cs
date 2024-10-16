using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.Category.Domain;

namespace Xr.System.Domain.Repository
{
    public interface IBaseValueReporistory : IRepository<BaseValue>, ITransient
    {
        IQueryable<BaseValue> QueryDetail(long id);
        IQueryable<BaseValue> QueryListByIds(List<long> ids);
    }
}
