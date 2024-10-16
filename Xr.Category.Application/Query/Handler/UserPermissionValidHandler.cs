using Aspros.Base.Framework.Infrastructure;
using Aspros.Base.Framework.Infrastructure.Const;
using Xr.System.Application.ViewModel;
using Xr.System.Domain.Repository;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace Xr.System.Application.Query.Handler
{
    public class UserPermissionValidHandler(IUserReporistory userReporistory, IRoleReporistory roleReporistory, IMenuReporistory menuReporistory, IWorkContext workContext, IDistributedCache cache) : IRequestHandler<UserPermissionValid, bool>
    {
        private readonly IUserReporistory _userReporistory = userReporistory;
        private readonly IRoleReporistory _roleReporistory = roleReporistory;
        private readonly IMenuReporistory _menuReporistory = menuReporistory;
        private readonly IWorkContext _workContext = workContext;
        private readonly IDistributedCache _cache = cache;

        public async Task<bool> Handle(UserPermissionValid request, CancellationToken cancellationToken)
        {
            var userId = request.UserId ?? await _workContext.GetUserId();
            if (userId == 0) return false;
            var permissionModel = _cache.Get($"{CacheConst.UserPermission}{userId}")?.Adapt<UserPermissionViewModel>();
            if (permissionModel != null) return permissionModel.Permissions.Any(x => x.Permission == request.PermissionCode);
            else
            {
                var user = await _userReporistory.QueryDetail(userId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                if (user == null) return false;
                if (user.UserRole == null) return false;
                var roles = await _roleReporistory.QueryListByIds(user.UserRole.RoleIds.Split(",").Select(long.Parse).ToList()).ToListAsync(cancellationToken: cancellationToken);
                var menuIds = roles.AsParallel().Where(x => x.RoleMenu != null).Select(x => x.RoleMenu.MenuIds).ToList();
                var munusIds = menuIds.AsParallel().Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Split(",").Select(long.Parse)).ToList();
                var mIds = (from id in munusIds from m in id select m).ToList();
                var menus = await _menuReporistory.QueryListByIds(mIds).ToListAsync(cancellationToken: cancellationToken);
                return menus.Any(x => x.Permission == request.PermissionCode);
            }
        }
    }
}
