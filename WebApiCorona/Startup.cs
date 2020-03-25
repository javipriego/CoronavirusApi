using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Controllers;
using WebApiCorona.Configuration;
using WebApiCorona.IoCC.Autofac.Modules;

namespace WebApiCorona
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
            var assembly = typeof(CountryController).Assembly;

            services
                .AddMvc()
                .AddApplicationPart(assembly)
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddSwaggerConfiguration(Configuration)
                .AddOptions();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<DomainServicesModule>();
            containerBuilder.RegisterModule<DomainFactoriesModule>();
            containerBuilder.RegisterModule<ApplicationServicesModule>();
            containerBuilder.RegisterModule<RepositoriesModule>();
            containerBuilder.RegisterModule<MappersModule>();
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

            app.UseHttpsRedirection();

            app
                .UseMvc()
                .UseSwaggerConfiguration(Configuration); 
        }
    }
}
