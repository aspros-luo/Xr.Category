using Aspros.Base.Framework.Infrastructure.Common;
using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class RefreshTokenCommand : IRequest<SubmitResult>
    {
        public required string AccessToken { get; set; }
    }
}
