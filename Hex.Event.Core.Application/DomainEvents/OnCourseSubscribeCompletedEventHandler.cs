using Hex.Event.Core.Domain.DomainEvents;

namespace Hex.Event.Core.Application.DomainEvents
{
    public class OnCourseSubscribeCompletedEventHandler : IHandle<OnCourseSubscribeCompletedEvent>
    {

        public OnCourseSubscribeCompletedEventHandler()
        {
        }
        public void Handle(OnCourseSubscribeCompletedEvent domainEvent)
        {
            //TODO: implement handler
        }
    }
}