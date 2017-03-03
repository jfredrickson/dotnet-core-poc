using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CoreSandbox.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreSandbox
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var databaseUrl = Configuration["DATABASE_URL"];
            var databaseUri = new Uri(databaseUrl);
            var databaseServer = databaseUri.Host;
            var databaseUsername = databaseUri.UserInfo.Split(':')[0];
            var databasePassword = databaseUri.UserInfo.Split(':')[1];
            var databasePort = databaseUri.Port;
            var databaseName = databaseUri.AbsolutePath.TrimStart('/');
            var connectionString = $"Server={databaseServer};Uid={databaseUsername};Pwd={databasePassword};Port={databasePort};Database={databaseName};";
            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AppDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DatabaseInitializer.Initialize(context);
        }
    }
}
