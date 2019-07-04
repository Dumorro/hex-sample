using Hex.Event.Core.Domain.DomainEvents.Base;
using System.Threading.Tasks;

namespace Hex.Event.Core.Domain.DomainEvents
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(DomainEvent domainEvent);
    }
}
