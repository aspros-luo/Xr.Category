using Aspros.SaaS.System.Domain.Domain;
using Framework.Domain.Core;

namespace Aspros.SaaS.System.Domain.Repository
{
    public interface IRoleReporistory : IRepository<Role>
    {
        IQueryable<Role> QueryDetail(long id);
        IQueryable<Role> QueryListByIds(List<long> ids);
    }
}
