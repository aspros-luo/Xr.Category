using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Application.Query.Handler
{
    public class TenantPackageListQueryHandler : IRequestHandler<TenantPackageListQuery, List<TenantPackage>>
    {
        private readonly ITenantPackageRepository _tenantPackageRepository;

        public TenantPackageListQueryHandler(ITenantPackageRepository tenantPackageRepository)
        {
            _tenantPackageRepository = tenantPackageRepository;
        }

        async Task<List<TenantPackage>> IRequestHandler<TenantPackageListQuery, List<TenantPackage>>.Handle(TenantPackageListQuery request, CancellationToken cancellationToken)
        {
            return await _tenantPackageRepository.QueryList(request.Name).ToListAsync();
        }
    }
}
