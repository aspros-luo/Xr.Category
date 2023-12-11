using Aspros.Base.Framework.Domain.Interface;
using Aspros.SaaS.System.Domain.ValueObjects;

namespace Aspros.SaaS.System.Domain.Domain
{
    public class TenantPackage : BaseEntity, IAggregateRoot
    {
        #region 属性
        public long Id { get; private set; }
        public string Name { get; private set; }
        public PackageStatus Status { get; private set; } = PackageStatus.Normal;
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

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="updater"></param>
        public void ModifyMenus(string menuIds, string updater)
        {
            MenuIds = menuIds;
            Updater = updater;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 备注
        /// </summary>
        /// <param name="remark"></param>
        /// <param name="updater"></param>
        public void ModifyRemark(string remark, string updater)
        {
            Remark = remark;
            Updater = updater;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 修改套餐状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="updater"></param>
        public void ModifyStatus(PackageStatus status, string updater)
        {
            Status = status;
            Updater = updater;
            UpdateTime = DateTime.Now;
        }
    }
}
