using Hex.Event.Core.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hex.Event.Core.Application.DomainEvents
{
    public class SendSMSOnSubscribeCompletedHandle : IHandle<OnCourseSubscribeCompletedEvent>
    {
        public void Handle(OnCourseSubscribeCompletedEvent domainEvent)
        {
           //do something
        }
    }
}
