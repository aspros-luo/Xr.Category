using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Application.Command
{
    public class TenantPackageCreateCommand : IRequest<long>
    {
        public required string Name { set; get; }
        public required string MenuIds { set; get; }
        public string Remark { set; get; } = string.Empty;
    }
}
