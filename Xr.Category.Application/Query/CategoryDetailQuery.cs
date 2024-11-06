using MediatR;

namespace Xr.Category.Application
{
    public class CategoryDetailQuery : IRequest<CategoryDetailViewModel>
    {
        public required long Id { get; set; }
    }
}
