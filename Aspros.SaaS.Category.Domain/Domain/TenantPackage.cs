using Aspros.Base.Framework.Domain;
using Aspros.SaaS.System.Domain.ValueObjects;

namespace Aspros.SaaS.System.Domain.Domain
{
    public class TenantPackage : BaseEntity, IAggregateRoot
    {
        #region 属性
        public long Id { get; private set; }
        public string Name { get; private set; }
        public Status Status { get; private set; } = Status.Normal;
        public string Remark { get; private set; } = string.Empty;
        public string MenuIds { get; private set; }

        #endregion
        public TenantPackage() { }
        public TenantPackage(string name, string remark, string menuIds)
        {
            Name = name;
            Remark = remark;
            MenuIds = menuIds;
        }

        public void ModifyName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menuIds"></param>
        public void ModifyMenus(string menuIds)
        {
            MenuIds = menuIds;
        }

        /// <summary>
        /// 备注
        /// </summary>
        /// <param name="remark"></param>
        public void ModifyRemark(string remark)
        {
            Remark = remark;

        }

        /// <summary>
        /// 修改套餐状态
        /// </summary>
        /// <param name="status"></param>
        public void ModifyStatus(Status status)
        {
            Status = status;
        }
    }
}
