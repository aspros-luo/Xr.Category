using Aspros.Base.Framework.Infrastructure;
using Aspros.SaaS.System.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aspros.SaaS.System.Application.Command.Handler
{
    public class TenantPackageModifyCommandHandler(IUnitOfWork unitOfWork, ITenantPackageRepository tenantPackageRepository) : IRequestHandler<TenantPackageModifyCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITenantPackageRepository _tenantPackageRepository = tenantPackageRepository;

        public async Task<long> Handle(TenantPackageModifyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _tenantPackageRepository.QueryDetail(request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new ArgumentNullException("套餐不存在!");
            entity.ModifyName(request.Name);
            entity.ModifyMenus(request.MenuIds);
            entity.ModifyRemark(request.Remark);
            await _unitOfWork.RegisterDirty(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }
    }
}
