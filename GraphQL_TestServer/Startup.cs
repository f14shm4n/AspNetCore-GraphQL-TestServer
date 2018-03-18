using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using f14;
using GraphQL_TestServer.Models.GraphQL;
using GraphQL_TestServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GraphQL_TestServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<RootGraphQuery>();
            services.AddSingleton<UserType>();
            services.AddSingleton<CategoryType>();
            services.AddSingleton<PostType>();
            services.AddSingleton<DataService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //var lf = app.ApplicationServices.GetService<ILoggerFactory>();
            //var log = lf.CreateLogger<Startup>();

            //var data = app.ApplicationServices.GetService<DataService>();

            //data.Users.ForEach(x => log.LogDebug(x.ToString()));
            //data.Categories.ForEach(x => log.LogDebug(x.ToString()));
            //data.Posts.ForEach(x => log.LogDebug(x.ToString()));
        }
    }
}
