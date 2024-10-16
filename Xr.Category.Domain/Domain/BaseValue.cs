using Aspros.Base.Framework.Domain;

namespace Xr.Category.Domain
{
    public class BaseValue : BasicEntity, IAggregateRoot
    {
        public long Id { get; protected set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string ValueData { get; protected set; } = string.Empty;

        /// <summary>
        /// 属性值名称大写，创建索引的字段，unique
        /// </summary>
        public string ValueDataUpper { get; protected set; } = string.Empty;

        public BaseValue() { }

        public BaseValue(string valueData, string valueDataUpper)
        {
            ValueData = valueData;
            ValueDataUpper = valueDataUpper;
        }
    }
}
