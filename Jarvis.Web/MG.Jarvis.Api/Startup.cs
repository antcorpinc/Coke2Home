using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MG.Jarvis.Data;
using Microsoft.EntityFrameworkCore;
using MG.Jarvis.Model;
using IdentityServer4.AccessTokenValidation;

namespace MG.Jarvis.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddMvc();
            //services.AddMvcCore()
            //     .AddAuthorization()
            //     .AddJsonFormatters();

            services.AddDbContext<JarvisContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("JarvisContextConnection"));
                });
            services.AddTransient<JarvisContextSeedData>();

            services.AddIdentity<JarvisUser, JarvisRole>()
                    .AddEntityFrameworkStores<JarvisContext>();

            // services.AddAuthorization();
            //       .AddJsonFormatters();
            //  IdentityServerAuthenticationDefaults.AuthenticationScheme
            // services.AddAuthentication("Bearer")
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000/";//Uri of IDS
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1";
                });
            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, JarvisContextSeedData seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
            // app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

           // seeder.SeedAsync().Wait();
        }
    }
}
