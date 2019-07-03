using Hex.Event.Core.Domain.Respositories;
using Hex.Event.Repository;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectModelDipatcherAdapterCollectionExtensions
    {
        public static IServiceCollection AddProjectModelEventsRepository(this IServiceCollection services)//, ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICourseRespository, CourseRespository>();

            return services;
        }
    }
}
