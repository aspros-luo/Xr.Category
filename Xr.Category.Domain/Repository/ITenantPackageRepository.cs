using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.System.Domain.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Xr.System.Domain.Repository
{
    public interface ITenantPackageRepository : IRepository<TenantPackage>, ITransient
    {
        /// <summary>
        /// 根据id获取套餐详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<TenantPackage> QueryDetail(long id);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IQueryable<TenantPackage> QueryList(string? name);
    }
}
