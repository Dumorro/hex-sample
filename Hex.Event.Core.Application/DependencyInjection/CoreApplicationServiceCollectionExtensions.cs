using Hex.Event.Core.Application;
using Hex.Event.Core.Domain.Adapters;
using Hex.Event.Core.Domain.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CoreApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectModelCoreApplication(this IServiceCollection services)//, ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICourseService, CourseServiceManager>();

            return services;
        }
    }
}
