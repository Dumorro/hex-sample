using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hex.Event.Core.Application;
using Hex.Event.Core.Domain.Entities.Base;
using Hex.Event.EmailAdpter;
using Hex.Event.EventsDispatcherAdapter.DomainEvents;
using Hex.Event.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace Hex.Event.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Hex.Event API";
                    document.Info.Description = "A simple ASP.NET Core Web API Port to Hexagonal Architecture";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Thiago F Coelho",
                        Email = "tfcoelho@msn.com",
                        Url = "https://github.com/Dumorro/"
                    };
                   
                };
            });


            //ConfigureDomainServices(services);
            BuildDependencyInjectionProvider(services);
        }
        private static IServiceProvider BuildDependencyInjectionProvider(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            // Populate the container using the service collection
            builder.Populate(services);

            // TODO: Add Registry Classes to eliminate reference to Infrastructure
            Assembly webAssembly = Assembly.GetExecutingAssembly();
            Assembly coreAssembly = Assembly.GetAssembly(typeof(BaseEntity<>));
            Assembly serviceManagerAssembly = Assembly.GetAssembly(typeof(CourseServiceManager));
            Assembly emailAdapterAssembly = Assembly.GetAssembly(typeof(EmailAdapter)); // TODO: Move to Infrastucture Registry
            Assembly respositorydapterAssembly = Assembly.GetAssembly(typeof(CourseRespository)); 
            Assembly dispatcherAdapterAssembly = Assembly.GetAssembly(typeof(DomainEventDispatcher)); 
            
            builder.RegisterAssemblyTypes(webAssembly, coreAssembly, serviceManagerAssembly, emailAdapterAssembly, respositorydapterAssembly, dispatcherAdapterAssembly).AsImplementedInterfaces();

           IContainer applicationContainer = builder.Build();

           return new AutofacServiceProvider(applicationContainer);
        }

        private void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddProjectModelCoreApplication();
            services.AddProjectModelDipatcherAdapter();
            services.AddProjectModelEventsRepository();
        }       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
