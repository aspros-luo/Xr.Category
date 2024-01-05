using Aspros.Base.Framework.Infrastructure.Common;
using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class UserRoleConferCommand : IRequest<SubmitResult>
    {
        public required long UserId { get; set; }
        public required string RoleIds { get; set; }
    }
}
