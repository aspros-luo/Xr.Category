using Aspros.Base.Framework.Infrastructure.Interface;

namespace Aspros.SaaS.System.Domain.DomainEvent
{
    public class TenentUserAddEvent : IEvent
    {
        public required string Name { get; set; }
        public required long TenantId { get; set; }
    }
}
