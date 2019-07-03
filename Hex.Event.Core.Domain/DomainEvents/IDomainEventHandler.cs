using Hex.Event.Core.Domain.DomainEvents.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hex.Event.Core.Domain.DomainEvents
{
    public interface IDomainEventHandler<T> where T : DomainEvent
    {
        void Handle(T domainEvent);
    }
}
