using Aspros.Base.Framework.Infrastructure;
using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class UserRoleConferCommand : IRequest<ResultModel>
    {
        public required long UserId { get; set; }
        public required string RoleIds { get; set; }
    }
}
