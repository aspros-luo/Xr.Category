using Aspros.Base.Framework.Infrastructure;

namespace Xr.System.Domain.DomainEvent
{
    public class TenentUserAddEvent : IEvent
    {
        public required string Name { get; set; }
        public required long TenantId { get; set; }
    }
}
