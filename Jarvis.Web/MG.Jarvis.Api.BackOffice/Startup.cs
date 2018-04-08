using AutoMapper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models.Response;
using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.Configuration;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Data;
using MG.Jarvis.Data.Contracts;
using MG.Jarvis.Data.DataRepositories;
using MG.Jarvis.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace MG.Jarvis.Api.BackOffice
{
    public class Startup
    {
        private Container container = new Container();
        static Core.Logger.ILogger logger;

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
            //services.AddDbContext<Core.DAL.JarvisContext>(
            //    options =>
            //    {
            //        options.UseSqlServer(
            //            Configuration.GetConnectionString("JarvisContextConnection"));
            //    });
            //services.AddTransient<JarvisContextSeedData>();
            //services.AddIdentity<JarvisUser, JarvisRole>()
            //        .AddEntityFrameworkStores<Core.DAL.JarvisContext>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();



            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //   .AddIdentityServerAuthentication(options =>
            //   {
            //       //  options.Authority = "http://localhost:5000/";//Uri of IDS - ToDO: Read from Config.
            //       options.Authority = Configuration["BaserUrls:Auth"];
            //       options.RequireHttpsMetadata = false; // Todo: Need to change this when moving to other env
            //       options.ApiName = "mg.jarvis.api.backoffice";

            //   });
            services.AddCors();

            
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IFeatureTypeRepository, FeatureTypeRepository>();
            services.AddScoped<IApplicationFeatureRepository, ApplicationFeatureRepository>();

            //services.AddScoped<IUserService, UserService>();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Jarvis BackOffice API", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "MG.Jarvis.Api.BackOffice.xml");
                c.IncludeXmlComments(xmlPath);
                c.CustomSchemaIds(x => x.FullName);
            });                        
            InitializeSimpleInjector(services);
            InitializeLogger();

        }

        private void InitializeSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
          //container2.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle(); 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IConfiguration>(Configuration);
            services.EnableSimpleInjectorCrossWiring(container);
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            //container.RegisterMvcViewComponents(app);
            container.RegisterSingleton<IConfiguration>(Configuration);

            container.Register(typeof(IConnection<Core.Model.Agency.Agents>), typeof(DapperConnection<Core.Model.Agency.Agents>));
            container.Register(typeof(IConnection<Core.Model.Agency.Branch>), typeof(DapperConnection<Core.Model.Agency.Branch>));
            container.Register(typeof(IConnection<Core.Model.Agency.Agency>), typeof(DapperConnection<Core.Model.Agency.Agency>));
            container.Register(typeof(IConnection<Core.Model.Hotel.Hotel>), typeof(DapperConnection<Core.Model.Hotel.Hotel>));
            container.Register(typeof(IConnection<Core.Model.Hotel.RoomTypes>), typeof(DapperConnection<Core.Model.Hotel.RoomTypes>));
            container.Register(typeof(IConnection<Core.Model.Mappings.Nationality>), typeof(DapperConnection<Core.Model.Mappings.Nationality>));
            container.Register(typeof(IConnection<Core.Model.Mappings.Country>), typeof(DapperConnection<Core.Model.Mappings.Country>));
            container.Register(typeof(IConnection<Core.Model.Mappings.City>), typeof(DapperConnection<Core.Model.Mappings.City>));
            container.Register(typeof(IConnection<Core.Model.Mappings.Hotel>), typeof(DapperConnection<Core.Model.Mappings.Hotel>));
            container.Register(typeof(IConnection<Core.Model.Mappings.MealTypes>), typeof(DapperConnection<Core.Model.Mappings.MealTypes>));
            container.Register(typeof(IConnection<Core.Model.Mappings.Promotions>), typeof(DapperConnection<Core.Model.Mappings.Promotions>));
            container.Register(typeof(IConnection<Core.Model.Mappings.RoomTypes>), typeof(DapperConnection<Core.Model.Mappings.RoomTypes>));
            container.Register(typeof(IConnection<Core.Model.Markup.AgencyMarkupRule>), typeof(DapperConnection<Core.Model.Markup.AgencyMarkupRule>));
            container.Register(typeof(IConnection<Core.Model.Markup.AgencyDailyMarkupRule>), typeof(DapperConnection<Core.Model.Markup.AgencyDailyMarkupRule>));
            container.Register(typeof(IConnection<Core.Model.Markup.RevenueMarkupRule>), typeof(DapperConnection<Core.Model.Markup.RevenueMarkupRule>));
            container.Register(typeof(IConnection<Core.Model.Markup.RevenueDailyMarkupRule>), typeof(DapperConnection<Core.Model.Markup.RevenueDailyMarkupRule>));
            container.Register(typeof(IConnection<Core.Model.MasterData.Currency>), typeof(DapperConnection<Core.Model.MasterData.Currency>));
            container.Register(typeof(IConnection<Core.Model.MasterData.Nationality>), typeof(DapperConnection<Core.Model.MasterData.Nationality>));
            container.Register(typeof(IConnection<Core.Model.MasterData.City>), typeof(DapperConnection<Core.Model.MasterData.City>));
            container.Register(typeof(IConnection<Core.Model.MasterData.Country>), typeof(DapperConnection<Core.Model.MasterData.Country>));
            container.Register(typeof(IConnection<Core.Model.MasterData.CurrencyConversion>), typeof(DapperConnection<Core.Model.MasterData.CurrencyConversion>));
            container.Register(typeof(IConnection<Core.Model.MasterData.RateType>), typeof(DapperConnection<Core.Model.MasterData.RateType>));
            container.Register(typeof(IConnection<Core.Model.MasterData.ChargeTypes>), typeof(DapperConnection<Core.Model.MasterData.ChargeTypes>));
            container.Register(typeof(IConnection<Core.Model.MasterData.AgencyMarkup>), typeof(DapperConnection<Core.Model.MasterData.AgencyMarkup>));
            container.Register(typeof(IConnection<Core.Model.MasterData.RevenueMarkup>), typeof(DapperConnection<Core.Model.MasterData.RevenueMarkup>));
            container.Register(typeof(IConnection<Core.Model.Supplier.Suppliers>), typeof(DapperConnection<Core.Model.Supplier.Suppliers>));
            container.Register(typeof(IConnection<Core.Model.Supplier.XMLConfiguration>), typeof(DapperConnection<Core.Model.Supplier.XMLConfiguration>));
            container.Register(typeof(IConnection<Core.Model.Supplier.Bank>), typeof(DapperConnection<Core.Model.Supplier.Bank>));
            container.Register(typeof(IConnection<Core.Model.Supplier.Contacts>), typeof(DapperConnection<Core.Model.Supplier.Contacts>));
            container.Register(typeof(IConnection<Core.Model.Supplier.Payment   >), typeof(DapperConnection<Core.Model.Supplier.Payment>));
            container.Register(typeof(IConnection<Core.Model.Supplier.FunctionSupplierRelation>), typeof(DapperConnection<Core.Model.Supplier.FunctionSupplierRelation>));
            container.Register(typeof(IConnection<Core.Model.Supplier.Functions>), typeof(DapperConnection<Core.Model.Supplier.Functions>));
            container.Register(typeof(IConnection<Core.Model.Supplier.UserRelation>), typeof(DapperConnection<Core.Model.Supplier.UserRelation>));
            container.Register(typeof(IConnection<Core.Model.Agency.AgencyContacts>), typeof(DapperConnection<Core.Model.Agency.AgencyContacts>));
            container.Register(typeof(IConnection<Core.Model.Agency.IncludedCountryRelation>), typeof(DapperConnection<Core.Model.Agency.IncludedCountryRelation>));
            container.Register(typeof(IConnection<Core.Model.Agency.ExcludedCountryRelation>), typeof(DapperConnection<Core.Model.Agency.ExcludedCountryRelation>));
            container.Register(typeof(IConnection<Core.Model.Agency.Payment>), typeof(DapperConnection<Core.Model.Agency.Payment>));
            container.Register(typeof(IConnection<Core.Model.Agency.Bank>), typeof(DapperConnection<Core.Model.Agency.Bank>));
            container.Register(typeof(IConnection<Core.Model.Agency.AgencySupplierRelation>), typeof(DapperConnection<Core.Model.Agency.AgencySupplierRelation>));
            container.Register(typeof(IConnection<Core.Model.Agency.BranchAgentRelation>), typeof(DapperConnection<Core.Model.Agency.BranchAgentRelation>));
            container.Register(typeof(IConnection<Core.Model.Agency.BranchContacts>), typeof(DapperConnection<Core.Model.Agency.BranchContacts>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.ChannelManager>), typeof(DapperConnection<Core.Model.ChannelManager.ChannelManager>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.Payment>), typeof(DapperConnection<Core.Model.ChannelManager.Payment>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.Bank>), typeof(DapperConnection<Core.Model.ChannelManager.Bank>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.Contacts>), typeof(DapperConnection<Core.Model.ChannelManager.Contacts>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.EmailAddresses>), typeof(DapperConnection<Core.Model.ChannelManager.EmailAddresses>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.Functions>), typeof(DapperConnection<Core.Model.ChannelManager.Functions>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.FunctionChannelManagerRelation>), typeof(DapperConnection<Core.Model.ChannelManager.FunctionChannelManagerRelation>));
            container.Register(typeof(IConnection<Core.Model.ChannelManager.UserRelation>), typeof(DapperConnection<Core.Model.ChannelManager.UserRelation>));
            container.Register(typeof(IConnection<Core.Model.CacheBuilder.OccupancyCombinations>), typeof(DapperConnection<Core.Model.CacheBuilder.OccupancyCombinations>));
            container.Register(typeof(IConnection<Core.Model.CacheBuilder.CitySuppliers>), typeof(DapperConnection<Core.Model.CacheBuilder.CitySuppliers>));

            container.Register(typeof(IConnection<Models.Request.Supplier>), typeof(DapperConnection<Models.Request.Supplier>));
            container.Register(typeof(IConnection<Models.Request.RevenueMarkup>), typeof(DapperConnection<Models.Request.RevenueMarkup>));
            container.Register(typeof(IConnection<Models.Request.AgencyMarkup>), typeof(DapperConnection<Models.Request.AgencyMarkup>));
            container.Register(typeof(IConnection<Models.Request.Agency>), typeof(DapperConnection<Models.Request.Agency>));
            container.Register(typeof(IConnection<Models.Request.Branch>), typeof(DapperConnection<Models.Request.Branch>));
            container.Register(typeof(IConnection<Models.Request.Agent>), typeof(DapperConnection<Models.Request.Agent>));
            container.Register(typeof(IConnection<Models.Request.ChannelManager>), typeof(DapperConnection<Models.Request.ChannelManager>));
            
            container.Register(typeof(IMapping<Core.Model.Mappings.City>), typeof(MappingRepository<Core.Model.Mappings.City>));
            container.Register(typeof(IMapping<Core.Model.Mappings.Country>), typeof(MappingRepository<Core.Model.Mappings.Country>));
            container.Register(typeof(IMapping<Core.Model.Mappings.Hotel>), typeof(MappingRepository<Core.Model.Mappings.Hotel>));
            container.Register(typeof(IMapping<Core.Model.Mappings.MealTypes>), typeof(MappingRepository<Core.Model.Mappings.MealTypes>));
            container.Register(typeof(IMapping<Core.Model.Mappings.Nationality>), typeof(MappingRepository<Core.Model.Mappings.Nationality>));
            container.Register(typeof(IMapping<Core.Model.Mappings.Promotions>), typeof(MappingRepository<Core.Model.Mappings.Promotions>));
            container.Register(typeof(IMapping<Core.Model.Mappings.RoomTypes>), typeof(MappingRepository<Core.Model.Mappings.RoomTypes>));
            container.Register(typeof(IMasterData<Core.Model.Hotel.Hotel, int>), typeof(MasterRepository<Core.Model.Hotel.Hotel, int>));
            container.Register(typeof(IMasterData<Core.Model.Mappings.Nationality, int>), typeof(MasterRepository<Core.Model.Mappings.Nationality, int>));
            container.Register(typeof(IMasterData<Core.Model.Mappings.Country, int>), typeof(MasterRepository<Core.Model.Mappings.Country, int>));
            container.Register(typeof(IMasterData<Core.Model.Mappings.City, int>), typeof(MasterRepository<Core.Model.Mappings.City, int>));
            container.Register(typeof(IMasterData<Core.Model.Mappings.Hotel, int>), typeof(MasterRepository<Core.Model.Mappings.Hotel, int>));
            container.Register(typeof(IMasterData<Core.Model.Mappings.Promotions, int>), typeof(MasterRepository<Core.Model.Mappings.Promotions, int>));
            container.Register(typeof(IMasterData<Core.Model.Mappings.RoomTypes, int>), typeof(MasterRepository<Core.Model.Mappings.RoomTypes, int>));
            container.Register(typeof(IMasterData<Core.Model.Mappings.MealTypes, int>), typeof(MasterRepository<Core.Model.Mappings.MealTypes, int>));
            container.Register(typeof(IMasterData<Core.Model.Markup.AgencyMarkupRule, int>), typeof(MasterRepository<Core.Model.Markup.AgencyMarkupRule, int>));
            container.Register(typeof(IMasterData<Core.Model.Markup.AgencyDailyMarkupRule, int>), typeof(MasterRepository<Core.Model.Markup.AgencyDailyMarkupRule, int>));
            container.Register(typeof(IMasterData<Core.Model.Markup.RevenueMarkupRule, int>), typeof(MasterRepository<Core.Model.Markup.RevenueMarkupRule, int>));
            container.Register(typeof(IMasterData<Core.Model.Markup.RevenueDailyMarkupRule, int>), typeof(MasterRepository<Core.Model.Markup.RevenueDailyMarkupRule, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.Currency, int>), typeof(MasterRepository<Core.Model.MasterData.Currency, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.Nationality, int>), typeof(MasterRepository<Core.Model.MasterData.Nationality, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.City, int>), typeof(MasterRepository<Core.Model.MasterData.City, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.Country, int>), typeof(MasterRepository<Core.Model.MasterData.Country, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.CurrencyConversion, int>), typeof(MasterRepository<Core.Model.MasterData.CurrencyConversion, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.Supplier, int>), typeof(MasterRepository<Core.Model.MasterData.Supplier, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.RateType, int>), typeof(MasterRepository<Core.Model.MasterData.RateType, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.AgencyMarkup, int>), typeof(MasterRepository<Core.Model.MasterData.AgencyMarkup, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.RevenueMarkup, int>), typeof(MasterRepository<Core.Model.MasterData.RevenueMarkup, int>));
            container.Register(typeof(IMasterData<Core.Model.MasterData.ChargeTypes, int>), typeof(MasterRepository<Core.Model.MasterData.ChargeTypes, int>));
            container.Register(typeof(IMasterData<Core.Model.Supplier.XMLConfiguration, int>), typeof(MasterRepository<Core.Model.Supplier.XMLConfiguration, int>));
            container.Register(typeof(IMasterData<Core.Model.Supplier.Bank, int>), typeof(MasterRepository<Core.Model.Supplier.Bank, int>));
            container.Register(typeof(IMasterData<Core.Model.Supplier.Contacts, int>), typeof(MasterRepository<Core.Model.Supplier.Contacts, int>));
            container.Register(typeof(IMasterData<Core.Model.Supplier.Payment, int>), typeof(MasterRepository<Core.Model.Supplier.Payment, int>));
            container.Register(typeof(IMasterData<Core.Model.Supplier.FunctionSupplierRelation, int>), typeof(MasterRepository<Core.Model.Supplier.FunctionSupplierRelation, int>));
            container.Register(typeof(IMasterData<Core.Model.Supplier.Functions, int>), typeof(MasterRepository<Core.Model.Supplier.Functions, int>));
            container.Register(typeof(IMasterData<Core.Model.Supplier.UserRelation, int>), typeof(MasterRepository<Core.Model.Supplier.UserRelation, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.ChannelManager, int>), typeof(MasterRepository<Core.Model.ChannelManager.ChannelManager, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.Payment, int>), typeof(MasterRepository<Core.Model.ChannelManager.Payment, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.Bank, int>), typeof(MasterRepository<Core.Model.ChannelManager.Bank, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.Contacts, int>), typeof(MasterRepository<Core.Model.ChannelManager.Contacts, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.EmailAddresses, int>), typeof(MasterRepository<Core.Model.ChannelManager.EmailAddresses, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.Functions, int>), typeof(MasterRepository<Core.Model.ChannelManager.Functions, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.FunctionChannelManagerRelation, int>), typeof(MasterRepository<Core.Model.ChannelManager.FunctionChannelManagerRelation, int>));
            container.Register(typeof(IMasterData<Core.Model.ChannelManager.UserRelation, int>), typeof(MasterRepository<Core.Model.ChannelManager.UserRelation, int>));
            container.Register(typeof(IMasterData<Core.Model.CacheBuilder.OccupancyCombinations, int>), typeof(MasterRepository<Core.Model.CacheBuilder.OccupancyCombinations, int>));
            container.Register(typeof(IMasterData<Core.Model.CacheBuilder.CitySuppliers, int>), typeof(MasterRepository<Core.Model.CacheBuilder.CitySuppliers, int>));

            container.Register(typeof(IMasterData<Models.Request.Supplier, int>), typeof(MasterRepository<Models.Request.Supplier, int>));
            container.Register(typeof(IMasterData<Models.Request.RevenueMarkup, int>), typeof(MasterRepository<Models.Request.RevenueMarkup, int>));
            container.Register(typeof(IMasterData<Models.Request.AgencyMarkup, int>), typeof(MasterRepository<Models.Request.AgencyMarkup, int>));
            container.Register(typeof(IMasterData<Models.Request.Agency, int>), typeof(MasterRepository<Models.Request.Agency, int>));
            container.Register(typeof(IMasterData<Models.Request.Branch, int>), typeof(MasterRepository<Models.Request.Branch, int>));
            container.Register(typeof(IMasterData<Models.Request.Agent, int>), typeof(MasterRepository<Models.Request.Agent, int>));
            container.Register(typeof(IMasterData<Models.Request.ChannelManager, int>), typeof(MasterRepository<Models.Request.ChannelManager, int>));

            container.Register(typeof(IAgency), typeof(AgencyRepository));
            container.Register(typeof(IAgencyMarkup), typeof(AgencyMarkupRepository));
            container.Register(typeof(IAgent), typeof(AgentRepository));
            container.Register(typeof(ISupplier), typeof(SupplierRepository));
            container.Register(typeof(IBranch), typeof(BranchRepository));
            container.Register(typeof(IChannelManager), typeof(ChannelManagerRepository));
            container.Register(typeof(IRevenueMarkup), typeof(RevenueMarkupRepository));

            //container.Register(typeof(IUserRepository), typeof(UserRepository));
            //container.Register(typeof(IRoleRepository), typeof(RoleRepository));

            //container.Register(typeof(IUserService), typeof(UserService));

            //container.Register(typeof(IUserRepository), typeof(UserRepository));
            container.Register(typeof(IdentityDbContext<JarvisUser, JarvisRole, Guid>), typeof(JarvisContext));
            //  container.Register(typeof(IDbContextOptionsBuilderInfrastructure), typeof(DbContextOptionsBuilder));
            //  container.Register(app.ApplicationServices.GetService<JarvisContext>, Lifestyle.Singleton);
            var optionsBuilder = new DbContextOptionsBuilder<JarvisContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("JarvisContextConnection"));
            container.Register(() => new JarvisContext(optionsBuilder.Options), Lifestyle.Singleton);
            container.RegisterSingleton(logger);
            //// Cross wire Identity services

            //   container.CrossWire<UserManager<JarvisUser>>(app);
            //    container.CrossWire<SignInManager<JarvisUser>>(app);

            //// Cross wire other AccountController dependencies
            //container.CrossWire<ILoggerFactory>(app);
            //container.CrossWire<IOptions<IdentityCookieOptions>>(app);

            // NOTE: It is highly advisable Class.csto refactor the AccountController
            // and NOT to depend on IOptions<IdentityCookieOptions> and ILoggerFactory
            // See: https://simpleinjector.org/aspnetcore#working-with-ioption-t
        }
        private void InitializeLogger()
        {
            var Environment = Enum.Parse<Core.Model.Helper.Constants.Enviornments>(Configuration["Environment"], true);
            Core.Model.Configurations.Configuration dbConfigurations = ConfigurationManager.GetConfigurations(Environment, Configuration, "JarvisContextConnection");
            if (dbConfigurations is null)
            {
                Console.WriteLine("Database configurations are null or empty");
                return;
            }
            if (string.IsNullOrEmpty(dbConfigurations.ElasticServerAddress))
            {
                Console.WriteLine("Elastic Server Address is null or empty");
                return;
            }

            logger = MG.Jarvis.Core.Logger.Logger.Instance;
            logger.EnviornmentConfigurations = dbConfigurations;

            if (logger==null)
            {
                return;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {          
            InitializeContainer(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
           // app.UseAuthentication();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jarvis BackOffice API v1");
                
            });
            app.UseMvc();

            // Do it in the last Seed Data only in Development
            if (env.IsDevelopment())
            {
                //using (var scope = app.ApplicationServices.CreateScope())
                //{
                //    var seeder = scope.ServiceProvider.GetService<JarvisContextSeedData>();
                //    // Make it like Sync        
                //    seeder.SeedAsync().Wait();
                //}
            }

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Core.Model.Agency.Agency, AgencyViewModel>();
                cfg.CreateMap<AgencyViewModel, Core.Model.Agency.Agency>();
                cfg.CreateMap<Core.Model.Agency.IncludedCountryRelation, AgencyIncludedCountry>();
                cfg.CreateMap<AgencyIncludedCountry, Core.Model.Agency.IncludedCountryRelation>();
                cfg.CreateMap<Core.Model.Agency.ExcludedCountryRelation, AgencyExcludedCountry>();
                cfg.CreateMap<AgencyExcludedCountry, Core.Model.Agency.ExcludedCountryRelation>();
            });
        }
    }
}
