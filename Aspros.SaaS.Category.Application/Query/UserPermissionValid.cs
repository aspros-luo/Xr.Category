using MediatR;

namespace Aspros.SaaS.System.Application.Query
{
    public class UserPermissionValid : IRequest<bool>
    {
        public long? UserId { get; set; }
        public required string PermissionCode { get; set; }
    }
}
