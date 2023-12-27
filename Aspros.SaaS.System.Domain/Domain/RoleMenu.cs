using Aspros.Base.Framework.Domain;

namespace Aspros.SaaS.System.Domain.Domain
{
    public class RoleMenu : BaseEntity
    {
        #region
        public long Id { get; private set; }
        public long RoleId { get; private set; }
        public string MenuIds { get; private set; }
        public long TenantId { get; private set; }

        public virtual Role Role { get; protected set; }
        #endregion
        public RoleMenu() { }

        public RoleMenu(long roleId, string menuIds, long tenantId)
        {
            RoleId = roleId;
            MenuIds = menuIds;
            TenantId = tenantId;
        }

        public void Modify(string menuIds)
        {
            MenuIds = menuIds;
        }
    }
}
