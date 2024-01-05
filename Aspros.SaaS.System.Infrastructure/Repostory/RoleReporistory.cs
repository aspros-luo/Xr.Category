using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using Framework.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Infrastructure.Repostory
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
