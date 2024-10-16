using Aspros.Base.Framework.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xr.Category.Domain;
using Xr.System.Domain.Repository;

namespace Xr.Category.Application.Command
{
    public class CategoryAddCmdHandler(ICategoryReporistory categoryReporistory, IUnitOfWork unitOfWork) : IRequestHandler<CategoryAddCmd, bool>
    {
        private readonly ICategoryReporistory _categoryReporistory = categoryReporistory;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(CategoryAddCmd request, CancellationToken cancellationToken)
        {
            var path = string.Empty;
            _unitOfWork.BeginTransaction();
            if (request.ParentId != 0)
            {
                var parentCat = await _categoryReporistory.QueryDetail(request.ParentId).FirstOrDefaultAsync() ?? throw new Exception("父类不存在");
                path = $"{parentCat.Path}|";
            }
            var category = new ActionCategory(request.ParentId, request.Name, request.SortOrder, request.Features, request.Remark);
            await _unitOfWork.RegisterNew(category);
            path += category.Id;
            category.ModifyPath(path);
            await _unitOfWork.RegisterDirty(category);
            return await _unitOfWork.CommitAsync();
        }
    }
}
