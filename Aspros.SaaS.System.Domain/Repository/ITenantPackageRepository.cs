using Aspros.SaaS.System.Domain.Domain;
using Framework.Domain.Core;

namespace Aspros.SaaS.System.Domain.Repository
{
    public interface ITenantPackageRepository : IRepository<TenantPackage>
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
