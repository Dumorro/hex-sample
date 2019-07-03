using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hex.Event.Core.Application;
using Hex.Event.Core.Domain.Entities.Base;
using Hex.Event.EmailAdpter;
using Hex.Event.EventsDispatcherAdapter.DomainEvents;
using Hex.Event.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IContainer = Autofac.IContainer;

namespace Hex.Event.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hex API",
                    Description = "Example Onion/Hexagonal project ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago F. Coelho",
                        Email = string.Empty,
                        Url = new Uri("http://github.com/dumorro"),
                    }
                });
            });

            return BuildDependencyInjectionProvider(services);
        }

        private static IServiceProvider BuildDependencyInjectionProvider(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            // Populate the container using the service collection
            builder.Populate(services);

            
            builder.RegisterAssemblyTypes(GetAssemblies()).AsImplementedInterfaces();

            IContainer applicationContainer = builder.Build();
            return new AutofacServiceProvider(applicationContainer);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static Assembly[] GetAssemblies()
        {
            return new Assembly[] {
            // TODO: Add Registry Classes to eliminate reference to Infrastructure
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(BaseEntity<>)),
            Assembly.GetAssembly(typeof(CourseServiceManager)),
            Assembly.GetAssembly(typeof(DomainEventHandler)),
            Assembly.GetAssembly(typeof(CourseRespository)),
            Assembly.GetAssembly(typeof(EmailAdapter))
            }; // TODO: Move to Infrastucture Registry }
        }
    }
}
