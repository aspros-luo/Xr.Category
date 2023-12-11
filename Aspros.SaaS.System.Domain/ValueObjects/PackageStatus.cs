using System.ComponentModel.DataAnnotations;

namespace Aspros.SaaS.System.Domain.ValueObjects
{
    public enum PackageStatus
    {
        [Display(Description = "停用")]
        Invalid = 0,

        [Display(Description = "正常")]
        Normal = 1
    }
}
