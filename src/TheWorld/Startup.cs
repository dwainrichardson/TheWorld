using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using TheWorld.Services;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;
using TheWorld.Models;
using AutoMapper;
using TheWorld.ViewModels;

namespace TheWorld
{
    public class Startup
    {
        public static Microsoft.Framework.Configuration.IConfiguration Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
                
                
            Configuration = builder.Build();
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddLogging();
            services.AddEntityFramework()
                .AddSqlServer().
                AddDbContext<WorldContext>();
           // if (env.IsDevelopment())
            //{
             services.AddScoped<IMailService, DebugMailService>();
            services.AddScoped<IWorldRepository, WorldRepository>();
           // }
            //else
            //{
            //  //  services.AddScoped<IMailService, RealMailService>();
            //}
 
        }

         
        public void Configure(IApplicationBuilder app)
        {

            app.UseStaticFiles();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Trip, TripViewModel>().ReverseMap();
            });

            app.UseMvc(config => {
                config.MapRoute(
                    name: "DefaultRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" });

            });
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
