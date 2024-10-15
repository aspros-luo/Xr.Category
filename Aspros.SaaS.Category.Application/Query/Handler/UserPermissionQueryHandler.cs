using Aspros.Base.Framework.Infrastructure;
using Aspros.Base.Framework.Infrastructure.Const;
using Aspros.SaaS.System.Application.ViewModel;
using Aspros.SaaS.System.Domain.Repository;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Aspros.SaaS.System.Application.Query.Handler
{
    public class UserPermissionQueryHandler(IUserReporistory userReporistory, IRoleReporistory roleReporistory, IMenuReporistory menuReporistory, IWorkContext workContext, IDistributedCache cache) : IRequestHandler<UserPermissionQuery, ResultModel>
    {
        private readonly IUserReporistory _userReporistory = userReporistory;
        private readonly IRoleReporistory _roleReporistory = roleReporistory;
        private readonly IMenuReporistory _menuReporistory = menuReporistory;
        private readonly IWorkContext _workContext = workContext;
        private readonly IDistributedCache _cache = cache;

        public async Task<ResultModel> Handle(UserPermissionQuery request, CancellationToken cancellationToken)
        {
            var userId = await _workContext.GetUserId();
            var user = await _userReporistory.QueryDetail(userId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (user == null) return ResultModel.Fail($"用户id:{userId} 不存在");
            if (user.UserRole == null) return ResultModel.Fail($"用户id:{userId} 未绑定角色");
            var permissionModel = _cache.Get($"{CacheConst.UserPermission}{userId}")?.Adapt<UserPermissionViewModel>();
            if (permissionModel != null) return ResultModel.Success(permissionModel);
            else
            {
                var roles = await _roleReporistory.QueryListByIds(user.UserRole.RoleIds.Split(",").Select(long.Parse).ToList()).ToListAsync(cancellationToken: cancellationToken);
                var menuIds = roles.AsParallel().Where(x => x.RoleMenu != null).Select(x => x.RoleMenu.MenuIds).ToList();
                var munusIds = menuIds.AsParallel().Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Split(",").Select(long.Parse)).ToList();
                var mIds = (from id in munusIds from m in id select m).ToList();
                var menus = await _menuReporistory.QueryListByIds(mIds).ToListAsync(cancellationToken: cancellationToken);
                var result = new UserPermissionViewModel
                {
                    UserId = userId,
                    UserName = user.UserName,
                    TenantId = user.TenantId,
                    Roles = roles.Adapt<List<RoleViewModel>>(),
                    Permissions = menus.Adapt<List<MenuViewModel>>(),
                };
                return ResultModel.Success(result);
            }
        }
    }
}
