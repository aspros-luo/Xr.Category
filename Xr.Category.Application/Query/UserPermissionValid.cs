using MediatR;

namespace Xr.System.Application.Query
{
    public class UserPermissionValid : IRequest<bool>
    {
        public long? UserId { get; set; }
        public required string PermissionCode { get; set; }
    }
}
