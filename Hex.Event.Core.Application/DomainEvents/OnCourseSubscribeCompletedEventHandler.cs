using Hex.Event.Core.Domain.Adapters;
using Hex.Event.Core.Domain.DomainEvents;

namespace Hex.Event.Core.Application.DomainEvents
{
    public class OnCourseSubscribeCompletedEventHandler : IHandle<OnCourseSubscribeCompletedEvent>
    {
        private const string EMAIL_SENDER = "test@email.com";
        private readonly IEmailAdapter _emailAdapter;
        public OnCourseSubscribeCompletedEventHandler(IEmailAdapter emailAdapter)
        {
            _emailAdapter = emailAdapter;
        }
        public void Handle(OnCourseSubscribeCompletedEvent domainEvent)
        {
            _emailAdapter.SendEmail(EMAIL_SENDER, domainEvent.RegisterCompleted.Email, domainEvent.RegisterCompleted.Subject, domainEvent.RegisterCompleted.Body);
        }
    }
}