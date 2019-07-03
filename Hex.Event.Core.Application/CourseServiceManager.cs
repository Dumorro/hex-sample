using Hex.Event.Core.Application.DomainEvents;
using Hex.Event.Core.Domain.DomainEvents;
using Hex.Event.Core.Domain.DomainEvents.Messages;
using Hex.Event.Core.Domain.Entities;
using Hex.Event.Core.Domain.Entities.Dtos;
using Hex.Event.Core.Domain.Respositories;
using Hex.Event.Core.Domain.Services;
using System.Threading.Tasks;

namespace Hex.Event.Core.Application
{
    public class CourseServiceManager : ICourseService
    {
        private readonly ICourseRespository _courseRespository;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public CourseServiceManager(ICourseRespository courseRespository, IDomainEventDispatcher domainEventDispatcher)
        {
            _courseRespository = courseRespository;
            _domainEventDispatcher = domainEventDispatcher;
        }
        public async Task Resgister(SubscribeInputDto subscribe)
        {
            //TODO: add AutoMapper to entities/dtos
            var student = new Student { Email = subscribe.Email, Name = subscribe.Name };
            await _courseRespository.SaveSubscribe(subscribe.Course, student );

            var subscribeMessage = new RegisterCompleted(subscribe.Name, subscribe.Course, subscribe.Email);

            var @event = new OnCourseSubscribeCompletedEvent() { RegisterCompleted = subscribeMessage};

            _domainEventDispatcher.Dispatch(@event);
        }
    }
}
