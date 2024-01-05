using Aspros.Base.Framework.Infrastructure.Common;
using Aspros.SaaS.System.Application.ViewModel;
using Aspros.SaaS.System.Domain.Repository;
using Aspros.SaaS.System.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class RefreshTokenCommandHandler(IUserReporistory userReporistory, JwtHandler jwtHandler) : IRequestHandler<RefreshTokenCommand, SubmitResult>
    {
        private readonly IUserReporistory _userReporistory = userReporistory;
        private readonly JwtHandler _jwtHandler = jwtHandler;
        public async Task<SubmitResult> Handle(RefreshTokenCommand cmd, CancellationToken cancellationToken)
        {
            var token = _jwtHandler.RefreshToken(cmd.AccessToken);
            var refreshToken = _jwtHandler.GenerateRefreshToken();

            return SubmitResult.Success(new { AccessToken = token, RefreshToken = refreshToken });
        }
    }
}
