using Aspros.SaaS.System.Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Infrastructure
{
    public static class PermissionExtensions
    {
        public static IApplicationBuilder UsePermissionValid(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PermissionMiddleware>();
        }
    }


    public class PermissionMiddleware(RequestDelegate next)
    {
        public static Endpoint GetEndpoint(HttpContext context)
        {
            return context == null ? throw new ArgumentNullException(nameof(context)) : (context.Features.Get<IEndpointFeature>()?.Endpoint);
        }
        private readonly RequestDelegate _next = next;
        public async Task Invoke(HttpContext context, IRoleReporistory roleReporistory, IMenuReporistory menuReporistory)
        {
            var endpoint = GetEndpoint(context);
            if (endpoint != null)
            {
                var permission = endpoint.Metadata.GetMetadata<Permission>();
                if (permission != null)
                {
                    var code = permission.Code;
                    var ids = permission.RoleIds.Split(",").Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
                    var roles = await roleReporistory.QueryListByIds(ids).ToListAsync();
                    var menus = roles.AsParallel().Select(x => x.RoleMenu.MenuIds).ToList();
                    var munusIds = menus.AsParallel().Select(x => x.Split(",").Select(long.Parse)).ToList();
                    var mIds = (from id in munusIds
                                from m in id
                                select m).ToList();

                    var munus = await menuReporistory.QueryListByIds(mIds).ToListAsync();
                    if (!munus.Any(x => x.Permission == code)) throw new Exception("当前接口无权限");
                }
            }
            await _next.Invoke(context);
        }
    }
}
