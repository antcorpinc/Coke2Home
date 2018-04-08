using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.Quickstart.UI;
using IdentityServer4.Services;
using MG.Jarvis.Auth.Configuration;
using MG.Jarvis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MG.Jarvis.Model;
using Microsoft.AspNetCore.Identity;
using MG.Jarvis.Auth.Settings;
using IdentityServer4.Stores;

namespace MG.Jarvis.Auth
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<JarvisContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("JarvisContextConnection"));
                });
            services.AddIdentity<JarvisUser, JarvisRole>()
                .AddEntityFrameworkStores<JarvisContext>()
                .AddDefaultTokenProviders();
            services.AddOptions();
            services.Configure<AppSettings>(Configuration);

            services.AddMvc();
            services.AddIdentityServer()
                .AddDeveloperSigningCredential() //Todo: For DEV only
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                // .AddTestUsers(IdentityServerConfig.GetUsers())
                 .AddAspNetIdentity<JarvisUser>()
                .AddProfileService<JarvisProfileService>()
                .AddClientStore<JarvisClientStore>();                

            services.AddScoped<IProfileService, JarvisProfileService>();
            services.AddSingleton<IClientStore,JarvisClientStore>();
           
           services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
             ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            AccountOptions.ShowLogoutPrompt = false;
            AccountOptions.AutomaticRedirectAfterSignOut = true;

             app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
            
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
