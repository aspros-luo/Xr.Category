using Aspros.Base.Framework.Infrastructure;
using Xr.System.Application.ViewModel;
using Xr.System.Domain.ValueObjects;
using MediatR;

namespace Xr.System.Application.Query
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
