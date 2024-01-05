using Aspros.Base.Framework.Infrastructure.Common;
using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class UserRoleConferCommandHandler(IUnitOfWork unitOfWork, IUserReporistory userReporistory) : IRequestHandler<UserRoleConferCommand, SubmitResult>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUserReporistory _userReporistory = userReporistory;

        public async Task<SubmitResult> Handle(UserRoleConferCommand request, CancellationToken cancellationToken)
        {
            var user = await _userReporistory.QueryDetail(request.UserId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (user == null) return SubmitResult.Fail("当前用户不存在");
            if (user.UserRole == null)
                user.AddUserRole(new UserRole(request.UserId, request.RoleIds, user.TenantId));
            else
                user.UserRole.Modify(request.RoleIds);
            await _unitOfWork.RegisterDirty(user);
            var result = await _unitOfWork.CommitAsync();
            return result ? SubmitResult.Success() : SubmitResult.Fail("添加权限失败");
        }
    }
}
