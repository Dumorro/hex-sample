using Hex.Event.Core.Domain.DomainEvents;
using Hex.Event.Core.Domain.DomainEvents.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hex.Event.EventsDispatcherAdapter.DomainEvents
{

    public abstract class DomainEventHandler  
    {
        public abstract void Handle(DomainEvent domainEvent);
    }
    public class DomainEventHandler<T> : DomainEventHandler where T : DomainEvent
    {
        private readonly IHandle<T> _handler;
        public DomainEventHandler()
        { }

        public DomainEventHandler(IHandle<T> handler)
        {
            _handler = handler;
        }

        public override void Handle(DomainEvent domainEvent)
        {
            _handler.Handle((T)domainEvent);
        }
    }
}
