using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using MG.Jarvis.Web.Settings;

namespace MG.Jarvis.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            //Todo: Do we need this appsettings.json or can we rely on the config og angular -- Remove if not needed
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
            services.AddOptions();
            services.Configure<AppSettings>(Configuration);

            services.AddMvc();
            
         //   JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options => {
                //options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                //options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                //Added
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";

            })
               .AddOpenIdConnect("oidc",options => {
                //   options.Authority = "http://localhost:5000/";//Url of IDS
                   options.Authority = Configuration["BaserUrls:Auth"];
                    options.ClientId = "mg.jarvis.web";// Client Id as configured in IDS

                   //ToDO: Change this password
                   options.ClientSecret = "02F97D49-18F8-4E20-AD8D-0EA51F3450A0";
                   options.TokenValidationParameters.NameClaimType = "name";
                    // Todo: Remove later for DEV purposes only
                   options.RequireHttpsMetadata = false;
                   ////Added
                   options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                   options.ResponseType = "code id_token";

                   //////////////////////
                   options.SaveTokens = true;
                   // NOte INfo: OpenId and Profile are added by default - BUt we'll be explicit about the 
                   // Scopes we need 
                   //Added
                   options.Scope.Clear();

                   options.Scope.Add("openid");
                   options.Scope.Add("profile");
                   options.Scope.Add("mg.jarvis.api.backoffice");
                   options.Scope.Add("mg.jarvis.api.extranet");

                   options.Scope.Add("offline_access");

                   options.GetClaimsFromUserInfoEndpoint = true;                  
               })
               .AddCookie(options => {
                   options.Cookie.Name = "mg.jarvis.web";
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute("spa-fallback",
                new { controller = "Home", action = "Index" });
            });
        }
    }
}
