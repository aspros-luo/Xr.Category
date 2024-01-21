using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Domain;
using MediatR;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class TenantPackageCreateCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<TenantPackageCreateCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<long> Handle(TenantPackageCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new TenantPackage(request.Name, request.Remark, request.MenuIds);
            await _unitOfWork.RegisterNew(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }
    }
}
