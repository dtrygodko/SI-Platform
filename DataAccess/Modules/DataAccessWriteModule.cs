using Autofac;
using DataAccess.Repositories.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Modules
{
    public class DataAccessWriteModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterContext(builder);
            builder.RegisterType<IdeasRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<UsersRepository>().AsImplementedInterfaces().SingleInstance();
        }

        protected virtual void RegisterContext(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();

                DbContextOptions<SIPlatformDbContext> options = new DbContextOptionsBuilder<SIPlatformDbContext>()
                    .UseSqlServer(configuration.GetConnectionString("SIPlatformConnection")).Options;

                return options;
            });

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