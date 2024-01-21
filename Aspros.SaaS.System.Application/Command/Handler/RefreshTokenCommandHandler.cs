using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Application.ViewModel;
using Aspros.SaaS.System.Domain.Repository;
using Aspros.SaaS.System.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class RefreshTokenCommandHandler(IUserReporistory userReporistory, JwtHandler jwtHandler) : IRequestHandler<RefreshTokenCommand, ResultModel>
    {
        private readonly IUserReporistory _userReporistory = userReporistory;
        private readonly JwtHandler _jwtHandler = jwtHandler;
        public async Task<ResultModel> Handle(RefreshTokenCommand cmd, CancellationToken cancellationToken)
        {
            var token = _jwtHandler.RefreshToken(cmd.AccessToken);
            var refreshToken = _jwtHandler.GenerateRefreshToken();

            return ResultModel.Success(new { AccessToken = token, RefreshToken = refreshToken });
        }
    }
}
