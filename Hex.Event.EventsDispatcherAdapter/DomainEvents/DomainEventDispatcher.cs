using Autofac;
using Hex.Event.Core.Domain.DomainEvents;
using Hex.Event.Core.Domain.DomainEvents.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hex.Event.EventsDispatcherAdapter.DomainEvents
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {

        private readonly IComponentContext _container;
        public DomainEventDispatcher(IComponentContext container)
        {
            _container = container;
        }

        public async Task Dispatch(DomainEvent domainEvent)
        {
            Type handlerType = typeof(IHandle<>).MakeGenericType(domainEvent.GetType());
            Type wrapperType = typeof(DomainEventHandler<>).MakeGenericType(domainEvent.GetType());

            IEnumerable handlers = (IEnumerable)_container.Resolve(typeof(IEnumerable<>).MakeGenericType(handlerType));

            IEnumerable<DomainEventHandler> wrappedHandlers = handlers.Cast<object>()
                .Select(handler => (DomainEventHandler)Activator.CreateInstance(wrapperType, handler));
                
            foreach (DomainEventHandler handler in wrappedHandlers)
            {
                await Task.Run(() => handler.Handle(domainEvent));
            }
        }
    }
}
