using Aspros.Base.Framework.Infrastructure.Interface;
using Aspros.SaaS.System.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class TenantPackageDelCommandHandler(IUnitOfWork unitOfWork, ITenantPackageRepository tenantPackageRepository) : IRequestHandler<TenantPackageDelCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITenantPackageRepository _tenantPackageRepository = tenantPackageRepository;

        public async Task<long> Handle(TenantPackageDelCommand request, CancellationToken cancellationToken)
        {
            var entity = (await _tenantPackageRepository.QueryDetail(request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new ArgumentNullException("套餐不存在!")) ?? throw new Exception("数据不存在");
            await _unitOfWork.RegisterDeleted(entity, true);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }
    }
}
