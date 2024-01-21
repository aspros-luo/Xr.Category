using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Application.ViewModel;
using Aspros.SaaS.System.Domain.ValueObjects;
using MediatR;

namespace Aspros.SaaS.System.Application.Query
{

    public class TenantPackageListQuery : IRequest<List<TenantPackageViewModel>>
    {
        /// <summary>
        /// 套餐名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 套餐状态
        /// </summary>
        public Status? Status { get; set; }
    }
}
