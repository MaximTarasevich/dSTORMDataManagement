using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Http;
using dSTORMWeb.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using dSTORMWeb.DAL.Accessors;

namespace dSTORMWeb.Server
{
    public class Startup
    {
        const string SqlConnectionString = "SQLConnectionString";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<RepositoryContext>( // replace "YourDbContext" with the class name of your DbContext
                options => options.UseMySql(Configuration.GetValue<string>(SqlConnectionString), // replace with your Connection String
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                    }
            ), ServiceLifetime.Transient);


            services.AddTransient<DataManager>();
            #region DbAccessors
            services.AddTransient<AOTFilterAccessor>();
            services.AddTransient<AuthorAccessor>();
            services.AddTransient<CameraAccessor>();
            services.AddTransient<dSTORMInfoAccessor>();
            services.AddTransient<ExperimentAccessor>();
            services.AddTransient<FinalImageAccessor>();
            services.AddTransient<FluorophoreAccessor>();
            services.AddTransient<FluorophoreResearchObjectAccessor>();
            services.AddTransient<InitialVideoAccessor>();
            services.AddTransient<LaserAccessor>();
            services.AddTransient<MicroscopeAccessor>();
            services.AddTransient<ObjectiveAccessor>();
            services.AddTransient<PhysicalPropertiesAccessor>();
            services.AddTransient<ResearchObjectAccessor>();
            services.AddTransient<SetupAccessor>();
            services.AddTransient<VideoFragmentAccessor>();

            #endregion



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.Use((context, next) =>
            {
                context.Request.EnableBuffering();
                return next();
            });

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
