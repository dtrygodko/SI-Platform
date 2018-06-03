using System;
using Application;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess.Modules;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SI_Platform
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });
            services.AddCors();

            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<DataAccessReadModule>();
            builder.RegisterModule<DataAccessWriteModule>();

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors(cp => cp.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        }
    }
}
