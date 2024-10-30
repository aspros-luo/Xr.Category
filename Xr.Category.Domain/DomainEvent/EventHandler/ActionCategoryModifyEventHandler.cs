using Aspros.Base.Framework.Infrastructure;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Xr.System.Domain.DomainEvent.EventHandler
{
    public class ActionCategoryModifyEventHandler(IHttpContextAccessor httpContextAccessor) : IEventHandler<ActionCategoryModifyEvent>
    {
        private readonly IUnitOfWork _unitOfWork = httpContextAccessor.HttpContext is null
                ? ServiceLocator.Instance.GetService<IUnitOfWork>()
                : httpContextAccessor.HttpContext.RequestServices.GetService<IUnitOfWork>();

        public async Task HandleAsync(ActionCategoryModifyEvent @event)
        {
            //var user = new User(@event.Name, @event.TenantId);
            //await _unitOfWork.RegisterNew(user);
            //await _unitOfWork.CommitAsync();
        }
    }
}
