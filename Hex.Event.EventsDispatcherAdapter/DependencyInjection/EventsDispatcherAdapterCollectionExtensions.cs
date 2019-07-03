using Hex.Event.Core.Domain.DomainEvents;
using Hex.Event.EventsDispatcherAdapter.DomainEvents;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectModelDipatcherAdapterCollectionExtensions
    {
        public static IServiceCollection AddProjectModelDipatcherAdapter(this IServiceCollection services)//, ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            return services;
        }
    }
}
