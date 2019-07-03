using Hex.Event.Core.Domain.Adapters;
using Hex.Event.EmailAdpter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectModelEmailAdapterCollectionExtensions
    {
        public static IServiceCollection AddProjectModelEmailAdapter(this IServiceCollection services)//, ApplicationConfiguration applicationConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IEmailAdapter, EmailAdapter>();

            return services;
        }
    }
}
