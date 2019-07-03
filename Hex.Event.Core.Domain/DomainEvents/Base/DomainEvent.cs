using System;

namespace Hex.Event.Core.Domain.DomainEvents.Base
{
    public abstract class DomainEvent
    {
        public DateTime DateTimeOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
