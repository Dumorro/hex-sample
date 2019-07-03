using Hex.Event.Core.Domain.DomainEvents.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hex.Event.EventsDispatcherAdapter.DomainEvents
{
    public abstract class BaseDomainEventHandler
    {
        public abstract void Handle(DomainEvent domainEvent);
    }
}
