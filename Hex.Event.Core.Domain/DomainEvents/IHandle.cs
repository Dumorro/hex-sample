using Hex.Event.Core.Domain.DomainEvents.Base;

namespace Hex.Event.Core.Domain.DomainEvents
{
    public interface IHandle<T> where T : DomainEvent
    {
        public void Handle(T domainEvent);
    }
}
