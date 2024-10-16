using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xr.System.Application.ViewModel
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long TenantId { get; set; }
    }
}
