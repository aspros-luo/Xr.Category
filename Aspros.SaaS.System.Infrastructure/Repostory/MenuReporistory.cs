using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using Framework.Domain.Core;

namespace Aspros.SaaS.System.Infrastructure.Repostory
{
    public class MenuReporistory : BaseRepository<Menu>, IMenuReporistory
    {
        private readonly IQueryable<Menu> _menus;

        public MenuReporistory(IDbContext dbContext) : base(dbContext)
        {
            _menus = Entities.Where(x => !x.Deleted);
        }

        public IQueryable<Menu> QueryDetail(long id)
        {
            return _menus.Where(x => x.Id == id);
        }

        public IQueryable<Menu> QueryListByIds(List<long> ids)
        {
            return _menus.Where(x => ids.Contains(x.Id));
        }
    }
}
