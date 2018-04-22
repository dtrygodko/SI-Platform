using Autofac;
using DataAccess.Repositories.Write;

namespace DataAccess.Modules
{
    public class DataAccessWriteModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterContext(builder);
            //builder.RegisterType<IdeasRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<UsersRepository>().AsImplementedInterfaces().SingleInstance();
        }

        protected virtual void RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterType<SIPlatformDbContext>().AsSelf().SingleInstance();
        }
    }

    public class TestDataAccessWriteModule : DataAccessWriteModule
    {
        protected override void RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterInstance(MockedDbContext.Create()).As<SIPlatformDbContext>();
        }
    }
}