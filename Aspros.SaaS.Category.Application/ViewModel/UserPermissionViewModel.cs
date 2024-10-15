using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Application.ViewModel
{
    public class UserPermissionViewModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long TenantId { get; set; }

        public List<RoleViewModel> Roles { get; set; }

        public List<MenuViewModel> Permissions { get; set; }
    }
}
