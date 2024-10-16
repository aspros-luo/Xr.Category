using Aspros.Base.Framework.Domain;

namespace Xr.Category.Domain
{
    public class ActionCategory : BasicEntity, IAggregateRoot
    {
        public long Id { get; private set; }

        /// <summary>
        /// 父类目 ID，如果是一级类目，那么他的 parent_id 就等于 0。 
        /// </summary>
        public long ParentId { get; protected set; } = 0;

        /// <summary>
        /// 类目名称
        /// </summary>
        public string Name { get; protected set; } = string.Empty;

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; protected set; } = string.Empty;

        /// <summary>
        /// 排序值
        /// </summary>
        public int SortOrder { get; protected set; }

        /// <summary>
        /// 是否为叶子类目
        /// </summary>
        public bool IsLeaf { get; protected set; } = true;

        /// <summary>
        /// 类目特征
        /// </summary>
        public string Features { get; protected set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; protected set; } = string.Empty;

        public ActionCategory() { }

        public ActionCategory(long parentId, string name, string path, int sortOrder, string features, string remark)
        {
            ParentId = parentId;
            Name = name;
            Path = path;
            SortOrder = sortOrder;
            Features = features;
            Remark = remark;
        }
    }
}
