using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xr.Category.Domain;
using Xr.System.Domain.Repository;

namespace Xr.Category.Application
{
    public class CategoryDetailQueryHandler(ICategoryReporistory categoryReporistory) : IRequestHandler<CategoryDetailQuery, CategoryDetailViewModel>
    {
        private readonly ICategoryReporistory _categoryReporistory = categoryReporistory;

        public async Task<CategoryDetailViewModel> Handle(CategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _categoryReporistory.QueryDetail(request.Id).FirstOrDefaultAsync();
            if (entity == null)  return new CategoryDetailViewModel();

            TypeAdapterConfig<ActionCategory, CategoryDetailViewModel>.NewConfig().Map(d => d.Name, s => s.Name + "maper");

            return entity.Adapt<CategoryDetailViewModel>();
        }
    }
}
