using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.Category.Domain;
using Xr.System.Domain.Repository;

namespace Xr.System.Infrastructure.Repostory
{
    public class CategoryReporistory : BaseRepository<ActionCategory>, ICategoryReporistory
    {
        private readonly IQueryable<ActionCategory> _categories;

        public CategoryReporistory(IDbContext dbContext) : base(dbContext)
        {
            _categories = Entities;
        }

        IQueryable<ActionCategory> ICategoryReporistory.QueryDetail(long id)
        {
            return _categories.Where(x => x.Id == id);
        }

        IQueryable<ActionCategory> ICategoryReporistory.QueryListByIds(List<long> ids)
        {
            return _categories.Where(x => ids.Contains(x.Id));
        }
    }
}
