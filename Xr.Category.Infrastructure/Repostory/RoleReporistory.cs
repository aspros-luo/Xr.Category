using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.System.Domain.Domain;
using Xr.System.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Xr.System.Infrastructure.Repostory
{
    public class RoleReporistory : BaseRepository<Role>, IRoleReporistory
    {
        private readonly IQueryable<Role> _roles;

        public RoleReporistory(IDbContext dbContext) : base(dbContext)
        {
            _roles = Entities.Where(x => !x.Deleted);
        }

        public IQueryable<Role> QueryDetail(long id)
        {
            return _roles.Include(x => x.RoleMenu).Where(x => x.Id == id);
        }

        public IQueryable<Role> QueryListByIds(List<long> ids)
        {
            return _roles.Include(x => x.RoleMenu).Where(x => ids.Contains(x.Id));
        }
    }
}
