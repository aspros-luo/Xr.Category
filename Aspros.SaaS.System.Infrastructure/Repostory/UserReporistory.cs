using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Infrastructure.Repostory
{
    public class UserReporistory : BaseRepository<User>, IUserReporistory
    {
        private readonly IQueryable<User> _users;

        public UserReporistory(IDbContext dbContext) : base(dbContext)
        {
            _users = Entities.Where(x => !x.Deleted);
        }

        public IQueryable<User> QueryDetail(long id)
        {
            return _users.Include(x => x.UserRole).Where(x => x.Id == id);
        }

        public IQueryable<User> QueryListByIds(List<long> ids)
        {
            return _users.Where(x => ids.Contains(x.Id));
        }

        public IQueryable<User> QueryUser(string name, string password, long tenantId)
        {
            return _users.Where(x => x.UserName == name && x.Password == password && x.TenantId == tenantId);
        }
    }
}
