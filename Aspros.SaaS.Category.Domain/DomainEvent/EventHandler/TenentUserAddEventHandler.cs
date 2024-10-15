using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Aspros.SaaS.System.Domain.DomainEvent.EventHandler
{
    public class TenentUserAddEventHandler(IHttpContextAccessor httpContextAccessor) : IEventHandler<TenentUserAddEvent>
    {
        private readonly IUnitOfWork _unitOfWork = httpContextAccessor.HttpContext is null
                ? ServiceLocator.Instance.GetService<IUnitOfWork>()
                : httpContextAccessor.HttpContext.RequestServices.GetService<IUnitOfWork>();

        public async Task HandleAsync(TenentUserAddEvent @event)
        {
            var user = new User(@event.Name, @event.TenantId);
            await _unitOfWork.RegisterNew(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
