using Aspros.Base.Framework.Domain;
using Aspros.SaaS.System.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Domain.Domain
{
    public class User : BaseEntity
    {
        public long Id { get; private set; }
        public string UserName { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string NickName { get; private set; } = string.Empty;
        public string Remark { get; private set; } = string.Empty;
        public long DeptId { get; private set; }
        public string PostIds { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public int Sex { get; private set; } = 0;
        public string Avatar { get; private set; } = string.Empty;
        public Status Status { get; private set; }
        public string LoginIp { get; private set; } = string.Empty;
        public DateTime LoginDate { get; private set; }
        public long TenantId { get; private set; }
    }
}
