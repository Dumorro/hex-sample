using Hex.Event.Core.Domain.DomainEvents.Base;

namespace Hex.Event.Core.Domain.DomainEvents
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(DomainEvent domainEvent);
    }
}
