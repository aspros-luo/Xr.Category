using Aspros.Base.Framework.Domain;

namespace Xr.Category.Domain
{
    public class BaseProperty : BasicEntity, IAggregateRoot
    {
        public long Id { get; protected set; }

        /// <summary>
        /// 父类目 ID，
        /// </summary>
        public long ParentId { get; protected set; } = 0;

        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; protected set; } = string.Empty;

        /// <summary>
        /// 属性分组 id
        /// </summary>
        public int PropertyType { get; protected set; } = 0;

        /// <summary>
        /// 特征值
        /// </summary>
        public string Features { get; protected set; } = string.Empty;

        public BaseProperty() { }

        public BaseProperty(long parentId, string name, int propertyType, string features)
        {
            ParentId = parentId;
            Name = name;
            PropertyType = propertyType;
            Features = features;
        }
    }
}
