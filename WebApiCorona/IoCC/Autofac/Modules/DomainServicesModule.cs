using Autofac;
using Domain.Contract;
using Domain.Services;

namespace WebApiCorona.IoCC.Autofac.Modules
{
    public class DomainServicesModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Service<Domain.Model.World>>()
                .As<IService<Domain.Model.World>>()
                .SingleInstance();

            builder
                .RegisterType<Service<Domain.Model.Continent>>()
                .As<IService<Domain.Model.Continent>>()
                .SingleInstance();

            builder
                .RegisterType<Service<Domain.Model.Country>>()
                .As<IService<Domain.Model.Country>>()
                .SingleInstance();

            builder
                .RegisterType<Service<Domain.Model.City>>()
                .As<IService<Domain.Model.City>>()
                .SingleInstance();

            builder
                .RegisterType<Service<Domain.Model.Injury>>()
                .As<IService<Domain.Model.Injury>>()
                .SingleInstance();
        }
    }
}
