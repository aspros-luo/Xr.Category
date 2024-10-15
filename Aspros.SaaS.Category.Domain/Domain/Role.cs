using Aspros.Base.Framework.Domain;
using Aspros.SaaS.System.Domain.ValueObjects;

namespace Aspros.SaaS.System.Domain.Domain
{
    public class Role : BaseEntity, IAggregateRoot
    {
        #region

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public int Sort { get; private set; }
        public DataScope DataScope { get; private set; } = DataScope.All;
        public string DataScopeDeptIds { get; private set; }
        public Status Status { get; private set; } = Status.Normal;
        public RoleType Type { get; private set; } = RoleType.Normal;
        public string Remark { get; private set; } = string.Empty;
        public long TenantId { get; private set; }

        public virtual RoleMenu RoleMenu { get; protected set; }

        #endregion

        public Role() { }

        public Role(string name, string code, int sort, DataScope dataScope, string dataScopeDeptIds, RoleType type, string remark, long tenantId)
        {
            Name = name;
            Code = code;
            Sort = sort;
            DataScope = dataScope;
            DataScopeDeptIds = dataScopeDeptIds;
            Type = type;
            Remark = remark;
            TenantId = tenantId;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="sort"></param>
        /// <param name="dataScope"></param>
        /// <param name="dataScopeDeptIds"></param>
        /// <param name="type"></param>
        /// <param name="remark"></param>
        public void Modify(string name, string code, int sort, DataScope dataScope, string dataScopeDeptIds, RoleType type, string remark)
        {
            Name = name;
            Code = code;
            Sort = sort;
            DataScope = dataScope;
            DataScopeDeptIds = dataScopeDeptIds;
            Type = type;
            Remark = remark;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            Deleted = true;
        }

    }
}
