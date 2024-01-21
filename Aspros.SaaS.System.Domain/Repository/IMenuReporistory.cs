using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Domain;
using Microsoft.Extensions.DependencyInjection;


namespace Aspros.SaaS.System.Domain.Repository
{
    public interface IMenuReporistory : IRepository<Menu>, ITransient
    {
        IQueryable<Menu> QueryDetail(long id);
        IQueryable<Menu> QueryListByIds(List<long> ids);
    }
}
