using Application.Model;
using Autofac;
using AutoMapper;

namespace WebApiCorona.IoCC.Autofac.Modules
{
    public class MappersModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(MappersModule).Assembly)
                .As<Profile>();

            builder
                .Register(context => new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<World, Domain.Model.World>().ReverseMap();
                        cfg.CreateMap<Continent, Domain.Model.Continent>().ReverseMap();
                        cfg.CreateMap<Country, Domain.Model.Country>().ReverseMap();
                        cfg.CreateMap<City, Domain.Model.City>().ReverseMap();
                        cfg.CreateMap<Injury, Domain.Model.Injury>().ReverseMap();
                    }))
                .AsSelf()
                .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
