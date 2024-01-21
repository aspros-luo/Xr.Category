using Aspros.Base.Framework.Infrastructure;
using MediatR;

namespace Aspros.SaaS.System.Application.Command
{
    public class RefreshTokenCommand : IRequest<ResultModel>
    {
        public required string AccessToken { get; set; }
    }
}
