using Hex.Event.Core.Domain.Adapters;
using Hex.Event.Core.Domain.DomainEvents;
using Hex.Event.Core.Domain.DomainEvents.Base;
using System;
using System.Linq;
using System.Reflection;

namespace Hex.Event.EventsDispatcherAdapter.DomainEvents
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        //TODO: refactor to cotainer injection.
        private const string METHOD_NAME = "Handle";
        public void Dispatch(DomainEvent domainEvent)
        {
            var assembly = domainEvent.GetType().Assembly;

            Type handlerType = typeof(IHandle<>).MakeGenericType(domainEvent.GetType());
            
            var wrappedHandlerTypes = (from type in assembly.DefinedTypes.ToList()
                                       from i in type.ImplementedInterfaces
                                       where i.FullName == handlerType.FullName
                                       select type).AsEnumerable();

            foreach (var wrappedType in wrappedHandlerTypes)
            {
                object handlerObject = Activator.CreateInstance(wrappedType);
                wrappedType.InvokeMember(METHOD_NAME, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                                          null, handlerObject, new object[] { domainEvent });
            }
        }
    }
}
