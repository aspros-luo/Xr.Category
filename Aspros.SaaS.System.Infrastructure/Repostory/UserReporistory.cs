using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using Framework.Domain.Core;
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
    }
}
