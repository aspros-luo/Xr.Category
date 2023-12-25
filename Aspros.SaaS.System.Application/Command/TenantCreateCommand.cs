using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class TenantCreateCommand : IRequest<long>
    {
        public required string Name { set; get; }
        public string Website { set; get; } = string.Empty;
        public required long PackgeId { set; get; }
        public required DateTime ExpireTime { set; get; }
        public required int UserCount { set; get; }
    }
}
