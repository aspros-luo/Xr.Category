using System.ComponentModel.DataAnnotations;

namespace Xr.System.Domain.ValueObjects
{
    public enum Status
    {
        [Display(Description = "停用")]
        Invalid = 1,

        [Display(Description = "正常")]
        Normal = 0
    }
}
