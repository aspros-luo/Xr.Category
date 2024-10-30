using Aspros.Base.Framework.Infrastructure;

namespace Xr.System.Domain.DomainEvent
{
    public class ActionCategoryModifyEvent : IEvent
    {
        public required string Name { get; set; }
        public required long ParentId { get; set; }
    }
}
