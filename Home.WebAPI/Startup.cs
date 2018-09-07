using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Home.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Home.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddMvc(
                //opn => opn.Filters.Add(typeof(Filter.ValidationFilter))//https://blogs.msdn.microsoft.com/webdev/2018/02/02/asp-net-core-2-1-roadmap/
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=HomeApp;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<HomeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HomeAppDataBase")));
            //services.AddDbContext<HomeContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<HomeContext>(opn =>  opn.UseInMemoryDatabase("HomeWebAPI"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employees}/{action=Get}/{id?}");
            });
        }
    }
}
