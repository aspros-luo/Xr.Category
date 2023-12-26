using Aspros.SaaS.System.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Application.ViewModel
{
    public class TenantPackageViewModel
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public object Status { get; private set; } 
        public string Remark { get; private set; } 
        public string MenuIds { get; private set; }
    }
}
