using System.ComponentModel.DataAnnotations;

namespace Aspros.SaaS.System.Domain.ValueObjects
{
    public enum MenuType
    {
        [Display(Description = "根目录")]
        Root = 1,

        [Display(Description = "路由")]
        Routing = 2,

        [Display(Description = "功能")]
        Action = 3
    }
}
