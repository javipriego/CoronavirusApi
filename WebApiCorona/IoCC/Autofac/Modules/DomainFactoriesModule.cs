using Autofac;
using Domain.Contract;
using Domain.Factories;

namespace WebApiCorona.IoCC.Autofac.Modules
{
    public class DomainFactoriesModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<WorldsFactory>()
                .As<IWorldsFactory>()
                .SingleInstance();

            builder
                .RegisterType<ContinentsFactory>()
                .As<IContinentsFactory>()
                .SingleInstance();

            builder
                .RegisterType<ContinentFactory>()
                .As<IContinentFactory>()
                .SingleInstance();

            builder
                .RegisterType<CountriesFactory>()
                .As<ICountriesFactory>()
                .SingleInstance();

            builder
                .RegisterType<CountryFactory>()
                .As<ICountryFactory>()
                .SingleInstance();
        }
    }
}
