using MediatR;

namespace Xr.Category.Application
{
    public class CategoryModifyCmd : IRequest<bool>
    {
        public long Id { get; set; } 

        /// <summary>
        /// 类目名称
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int SortOrder { get; set; } = 0;

        /// <summary>
        /// 类目特征
        /// </summary>
        public string Features { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;
    }
}
