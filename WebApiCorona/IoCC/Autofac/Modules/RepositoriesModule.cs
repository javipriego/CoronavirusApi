using Autofac;
using Domain.Factories;
using Domain.Model;
using Infra.Repository;
using Infra.Repository.Cached;
using System.Linq;

namespace WebApiCorona.IoCC.Autofac.Modules
{
    public class RepositoriesModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var initialWorld = new WorldsFactory(new ContinentsFactory(new ContinentFactory(new CountriesFactory(new CountryFactory())))).Create();

            builder
                .Register( 
                    context =>
                    {
                        var cachedList = initialWorld.SelectMany(x => x.Injuries).ToList();
                        return new Repository<Injury>(cachedList);
                    })
                .As<IRepository<Injury>>()
                .SingleInstance();

            builder
                .Register(
                    context =>
                    {
                        var continents = initialWorld.SelectMany(x => x.Continents);
                        var countries = continents.SelectMany(x => x.Countries).ToList();

                        return new Repository<Country>(countries);
                    })
                .As<IRepository<Country>>()
                .SingleInstance();

            builder
                .Register(
                    context =>
                    {
                        var worlds = initialWorld.ToList();
                        return new Repository<World>(worlds);
                    })
                .As<IRepository<World>>()
                .SingleInstance();

            builder
                .Register(
                    context =>
                    {
                        var continents = initialWorld.SelectMany(x => x.Continents).ToList();

                        return new Repository<Continent>(continents);
                    })
                .As<IRepository<Continent>>()
                .SingleInstance();
        }
    }
}
