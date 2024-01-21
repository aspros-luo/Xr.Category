using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class UserRoleConferCommandHandler(IUnitOfWork unitOfWork, IUserReporistory userReporistory) : IRequestHandler<UserRoleConferCommand, ResultModel>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUserReporistory _userReporistory = userReporistory;

        public async Task<ResultModel> Handle(UserRoleConferCommand request, CancellationToken cancellationToken)
        {
            var user = await _userReporistory.QueryDetail(request.UserId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (user == null) return ResultModel.Fail("当前用户不存在");
            if (user.UserRole == null)
                user.AddUserRole(new UserRole(request.UserId, request.RoleIds, user.TenantId));
            else
                user.UserRole.Modify(request.RoleIds);
            await _unitOfWork.RegisterDirty(user);
            var result = await _unitOfWork.CommitAsync();
            return result ? ResultModel.Success() : ResultModel.Fail("添加权限失败");
        }
    }
}
