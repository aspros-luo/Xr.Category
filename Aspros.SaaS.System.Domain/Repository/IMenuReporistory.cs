using Aspros.SaaS.System.Domain.Domain;
using Framework.Domain.Core;

namespace Aspros.SaaS.System.Domain.Repository
{
    public interface IMenuReporistory : IRepository<Menu>
    {
        IQueryable<Menu> QueryDetail(long id);
        IQueryable<Menu> QueryListByIds(List<long> ids);
    }
}
