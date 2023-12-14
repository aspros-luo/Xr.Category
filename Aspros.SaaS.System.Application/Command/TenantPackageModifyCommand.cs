using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class TenantPackageModifyCommand : TenantPackageCreateCommand, IRequest<long>
    {
        public long Id{ set; get; }
    }
}
