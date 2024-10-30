using Aspros.Base.Framework.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xr.System.Domain.Repository;

namespace Xr.Category.Application.Command
{
    public class CategoryModifyCmdHandler(ICategoryReporistory categoryReporistory, IUnitOfWork unitOfWork) : IRequestHandler<CategoryModifyCmd, bool>
    {
        private readonly ICategoryReporistory _categoryReporistory = categoryReporistory;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(CategoryModifyCmd request, CancellationToken cancellationToken)
        {
            var category = await _categoryReporistory.QueryDetail(request.Id).FirstOrDefaultAsync() ?? throw new Exception("数据不存在");
            category.Update(category.ParentId, request.Name, request.SortOrder, request.Features, request.Remark);
            await _unitOfWork.RegisterDirty(category);
            return await _unitOfWork.CommitAsync();
        }
    }
}
