using Aspros.Base.Framework.Domain;

namespace Xr.System.Domain.Domain
{
    public class UserRole : BaseEntity
    {
        #region
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public string RoleIds { get; private set; }
        public long TenantId { get; private set; }

        public virtual User User { get; protected set; }
        #endregion
        public UserRole() { }

        public UserRole(long userId, string roleIds, long tenantId)
        {
            UserId = userId;
            RoleIds = roleIds;
            TenantId = tenantId;
        }

        public void Modify(string roleIds)
        {
            RoleIds = roleIds;
        }
    }
}
