using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class TenantPackageCreateCommand : IRequest<long>
    {
        public required string Name { set; get; }
        public required string MenuIds { set; get; }
        public string Remark { set; get; } = string.Empty;
    }
}
