using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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


            ConfigureDomainServices(services);
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
