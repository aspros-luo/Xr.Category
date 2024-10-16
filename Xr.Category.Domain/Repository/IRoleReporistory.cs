using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.System.Domain.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Xr.System.Domain.Repository
{
    public interface IRoleReporistory : IRepository<Role>, ITransient
    {
        IQueryable<Role> QueryDetail(long id);
        IQueryable<Role> QueryListByIds(List<long> ids);
    }
}
