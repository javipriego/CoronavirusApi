using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WebApiCorona
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var env = builderContext.HostingEnvironment;
                    config
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();
                });
    }
}
