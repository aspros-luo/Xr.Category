using MediatR;

namespace Xr.Category.Application
{
    /// <summary>
    /// 类目查询
    /// </summary>
    public class CategoryDetailQuery : IRequest<CategoryDetailViewModel>
    {
        /// <summary>
        /// 类目Id
        /// </summary>
        public required long Id { get; set; }
    }
}
