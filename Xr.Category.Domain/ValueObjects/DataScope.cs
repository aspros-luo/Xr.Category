using System.ComponentModel.DataAnnotations;

namespace Xr.System.Domain.ValueObjects
{
    public enum DataScope
    {
        [Display(Description = "全数据")]
        All = 1,

        [Display(Description = "本部门")]
        Dept = 2,

        [Display(Description = "本部门及以下")]
        DeptAll = 3,

        [Display(Description = "本人")]
        Personal = 4
    }
}
