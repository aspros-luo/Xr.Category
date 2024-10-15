using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Domain;
using Microsoft.Extensions.DependencyInjection;


namespace Aspros.SaaS.System.Domain.Repository
{
    public interface IUserReporistory : IRepository<User>, ITransient
    {
        IQueryable<User> QueryUser(string name, string password, long tenantId);
        IQueryable<User> QueryDetail(long id);
        IQueryable<User> QueryListByIds(List<long> ids);
    }
}
