using System.ComponentModel.DataAnnotations;

namespace Xr.System.Domain.ValueObjects
{
    public enum RoleType
    {
        [Display(Description = "管理员")]
        Admin = 1,

        [Display(Description = "普通角色")]
        Normal = 2
    }
}
