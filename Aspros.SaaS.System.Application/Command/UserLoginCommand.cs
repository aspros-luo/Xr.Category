using Aspros.Base.Framework.Infrastructure.Common;
using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class UserLoginCommand : IRequest<SubmitResult>
    {
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
        public required long TenantId { get; set; }
    }
}
