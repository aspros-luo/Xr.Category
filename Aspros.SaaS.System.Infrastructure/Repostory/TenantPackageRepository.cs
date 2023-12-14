using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using Framework.Domain.Core;

namespace Aspros.SaaS.System.Infrastructure.Repostory
{
    public class TenantPackageRepository : BaseRepository<TenantPackage>, ITenantPackageRepository
    {
        private readonly IQueryable<TenantPackage> _tenantPackages;

        public TenantPackageRepository(IDbContext dbContext) : base(dbContext)
        {
            _tenantPackages = Entities.Where(x => !x.Deleted);
        }

        public IQueryable<TenantPackage> QueryDetail(long id)
        {
            return _tenantPackages.Where(x => x.Id == id);
        }

        public IQueryable<TenantPackage> QueryList(string? name)
        {
            return _tenantPackages.Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name));
        }
    }
}
