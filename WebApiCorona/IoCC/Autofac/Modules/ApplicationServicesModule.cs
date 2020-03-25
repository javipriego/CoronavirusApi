using Application.Contracts;
using Application.Model;
using Application.Services;
using Autofac;

namespace WebApiCorona.IoCC.Autofac.Modules
{
    public class ApplicationServicesModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<InjuryService>()
                .As<IService<Injury>>()
                .SingleInstance();

            builder
                .RegisterType<CountryService>()
                .As<IService<Country>>()
                .SingleInstance();

            builder
                .RegisterType<ContinentService>()
                .As<IService<Continent>>()
                .SingleInstance();

            builder
                .RegisterType<WorldService>()
                .As<IService<World>>()
                .SingleInstance();
        }
    }
}
