using Aspros.SaaS.System.Domain.Domain;
using Framework.Domain.Core;

namespace Aspros.SaaS.System.Domain.Repository
{
    public interface IUserReporistory : IRepository<User>
    {
        IQueryable<User> QueryDetail(long id);
        IQueryable<User> QueryListByIds(List<long> ids);
    }
}
