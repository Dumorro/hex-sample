using Hex.Event.Core.Domain.DomainEvents.Base;
using Hex.Event.Core.Domain.DomainEvents.Messages;

namespace Hex.Event.Core.Application.DomainEvents
{
    public class OnCourseSubscribeCompletedEvent : DomainEvent
    {
        public RegisterCompleted RegisterCompleted { get; set; }
    }
}
