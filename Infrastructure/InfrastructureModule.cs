using Autofac;
using Infrastructure.Bus;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<RequestBus>().AsImplementedInterfaces().SingleInstance();
        }
    }
}