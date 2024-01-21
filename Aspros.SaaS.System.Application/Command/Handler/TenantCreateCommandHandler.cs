using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.DomainEvent;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class TenantCreateCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<TenantCreateCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IEventBus _eventBus = ServiceLocator.Instance.GetService<IEventBus>();
        public async Task<long> Handle(TenantCreateCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTransaction();
            var tenant = new Tenant(request.Name, request.Website, request.PackgeId, request.ExpireTime);
            await _unitOfWork.RegisterNew(tenant);

            await _eventBus.PublishAsync(new TenentUserAddEvent() { Name = request.Name, TenantId = tenant.Id });

            await _unitOfWork.CommitAsync();
            return tenant.Id;
        }
    }
}
