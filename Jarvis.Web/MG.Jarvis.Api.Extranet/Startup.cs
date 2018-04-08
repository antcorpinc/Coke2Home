using IdentityServer4.AccessTokenValidation;
using MG.Jarvis.Api.Extranet.AutoMapperHelper.Resolvers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Model.Common;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.Job;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Models.EntityModels;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.RatesCategory;
using MG.Jarvis.Core.Model.Reservation;
using MG.Jarvis.Core.Model.Room;
using MG.Jarvis.Core.Model.Supplier;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MG.Jarvis.Api.Extranet
{
    using System.Globalization;

    public class Startup : IDisposable
    {
        private Container container = new Container();
        public IConfigurationRoot Configuration { get; }

        private bool disposed = false;

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
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
          .AddIdentityServerAuthentication(options =>
          {

              options.Authority = Configuration["BaserUrls:Auth"];
              options.RequireHttpsMetadata = false; // Todo: Need to change this when moving to other env
              options.ApiName = "mg.jarvis.api.extranet";

          });
            services.AddMvc();
            services.AddCors();

            InitializeSimpleInjector(services);
            InitializeAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                // app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region Private Methods
        private void InitializeSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            //services.AddSingleton<IConfiguration>(Configuration);
            //services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));
            //  services.EnableSimpleInjectorCrossWiring(container);
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            //container.RegisterMvcViewComponents(app);
            bool isTestMode = false;
            var appSettings = Configuration.GetSection("AppSettings");
            if (appSettings != null)
            {
                Boolean.TryParse(appSettings.GetValue<string>("IsTestMode"), out isTestMode);
            }
            if (!isTestMode)
            {
                container.Register<IMasterData, Repositories.MasterDataRepository>();
                container.Register<IContract, Repositories.ContractRepository>();
                container.Register<IContractStatic, Repositories.ContractStaticRepository>();
                container.Register<IHotels, Repositories.HotelRepository>();
                container.Register<IFacilities, Repositories.FacilitiesRepository>();
                container.Register<IRoom, Repositories.RoomRepository>();
                container.Register<IChannelManager, Repositories.ChannelManagerRepository>();
                container.Register<IAmenities, Repositories.AmenitiesRepository>();
                container.Register<IMiscellaneous, Repositories.MiscellaneousDataRepository>();
                container.Register<IPayment, Repositories.PaymentDataRepository>();
                container.Register<IRatesCategory, Repositories.RatesCategoryRepository>();
                container.Register<IMealPlan, Repositories.MealPlanRepository>();
                container.Register<IMessage, Repositories.MessageRepository>();
                container.Register<IPolicies, Repositories.PoliciesRepository>();
                container.Register<ITemplate, Repositories.TemplateRepository>();
                container.Register<IReservations, Repositories.ReservationRepository>();
                container.Register<IXMLServices,Repositories.XMLServicesRepository > ();
                container.Register<IMarket, Repositories.MarketRepository>();
                container.Register<IAllocations, Repositories.AllocationsRepository>();

                container.Register<IDocument, Repositories.DocumentRepository>();
                container.RegisterSingleton<IConfiguration>(Configuration);


                //container.Register<IConnectionConfiguration, ConnectionConfigurationRepository
                //container.Register<IMasterDataDAL, Core.DAL.Repositories.MasterDataDALRepository>();
                //container.Register(typeof(IConnection<>), typeof(EntityConnection<>));
                // container.Register(typeof(IConnection<HotelTypeModel>), typeof(EntityConnection<HotelTypeModel>));
                container.Register(typeof(IConnection<Contract>), typeof(DapperConnection<Contract>));
                //container.Register(typeof(IConnection<HotelTypeModel>), typeof(EntityConnection<HotelTypeModel>));
                //container.Register<IConnectionLibrary,ConnectionLibraryRepository>();
                container.Register(typeof(IConnection<Hotel>), typeof(DapperConnection<Hotel>));
                container.Register(typeof(IConnection<HotelType>), typeof(DapperConnection<HotelType>));
                container.Register(typeof(IConnection<HotelChain>), typeof(DapperConnection<HotelChain>));
                container.Register(typeof(IConnection<HotelBrand>), typeof(DapperConnection<HotelBrand>));
                container.Register(typeof(IConnection<Designation>), typeof(DapperConnection<Designation>));
                container.Register(typeof(IConnection<MG.Jarvis.Core.Model.Hotel.Contacts>), typeof(DapperConnection<MG.Jarvis.Core.Model.Hotel.Contacts>));
                container.Register(typeof(IConnection<EmailReservation>), typeof(DapperConnection<EmailReservation>));
                container.Register(typeof(IConnection<TelephoneReservation>), typeof(DapperConnection<TelephoneReservation>));

                container.Register(typeof(IConnection<dynamic>), typeof(DapperConnection<dynamic>));
                container.Register<ITest, Repositories.TestRepositories>();
                container.Register(typeof(IConnection<Test>), typeof(DapperConnection<Test>));

                container.Register(typeof(IConnection<HotelView>), typeof(DapperConnection<HotelView>));
                container.Register(typeof(IConnection<City>), typeof(DapperConnection<City>));
                container.Register(typeof(IConnection<Continent>), typeof(DapperConnection<Continent>));
                container.Register(typeof(IConnection<Country>), typeof(DapperConnection<Country>));
                container.Register(typeof(IConnection<Currency>), typeof(DapperConnection<Currency>));
                container.Register(typeof(IConnection<Market>), typeof(DapperConnection<Market>));
                container.Register(typeof(IConnection<Occupancy>), typeof(DapperConnection<Occupancy>));
                container.Register(typeof(IConnection<Supplier>), typeof(DapperConnection<Supplier>));
                container.Register(typeof(IConnection<ChannelManagers>), typeof(DapperConnection<ChannelManagers>));
                container.Register(typeof(IConnection<Producers>), typeof(DapperConnection<Producers>));
                container.Register(typeof(IConnection<Langauges>), typeof(DapperConnection<Langauges>));
                container.Register(typeof(IConnection<RoomType>), typeof(DapperConnection<RoomType>));
                container.Register(typeof(IConnection<HotelFacilityGroup>), typeof(DapperConnection<HotelFacilityGroup>));
                container.Register(typeof(IConnection<HotelFacilityType>), typeof(DapperConnection<HotelFacilityType>));
                container.Register(typeof(IConnection<HotelFacility>), typeof(DapperConnection<HotelFacility>));
                container.Register(typeof(IConnection<PaymentMethod>), typeof(DapperConnection<PaymentMethod>));
                container.Register(typeof(IConnection<RateType>), typeof(DapperConnection<RateType>));
                container.Register(typeof(IConnection<TaxType>), typeof(DapperConnection<TaxType>));
                container.Register(typeof(IConnection<TaxApplicability>), typeof(DapperConnection<TaxApplicability>));
                container.Register(typeof(IConnection<Meals>), typeof(DapperConnection<Meals>));
                container.Register(typeof(IConnection<CuisineType>), typeof(DapperConnection<CuisineType>));
                container.Register(typeof(IConnection<HotelFacilityRelation>), typeof(DapperConnection<HotelFacilityRelation>));
                container.Register(typeof(IConnection<HotelPaymentMethodRelation>), typeof(DapperConnection<HotelPaymentMethodRelation>));
                container.Register(typeof(IConnection<HotelTaxRelation>), typeof(DapperConnection<HotelTaxRelation>));
                container.Register(typeof(IConnection<ChannelManagerRequestValidationResponse>), typeof(DapperConnection<ChannelManagerRequestValidationResponse>));
                container.Register(typeof(IConnection<RoomTypesRatePlan>), typeof(DapperConnection<RoomTypesRatePlan>));
                container.Register(typeof(IConnection<RoomFacility>), typeof(DapperConnection<RoomFacility>));
                container.Register(typeof(IConnection<RoomFacilityType>), typeof(DapperConnection<RoomFacilityType>));
                container.Register(typeof(IConnection<RoomFacilityGroup>), typeof(DapperConnection<RoomFacilityGroup>));
                container.Register(typeof(IConnection<Bed>), typeof(DapperConnection<Bed>));
                container.Register(typeof(IConnection<SmokingPolicy>), typeof(DapperConnection<SmokingPolicy>));
                container.Register(typeof(IConnection<SizeMeasure>), typeof(DapperConnection<SizeMeasure>));
                container.Register(typeof(IConnection<InOutTime>), typeof(DapperConnection<InOutTime>));
                container.Register(typeof(IConnection<RoomFacilityRelation>), typeof(DapperConnection<RoomFacilityRelation>));
                container.Register(typeof(IConnection<Room>), typeof(DapperConnection<Room>));
                container.Register(typeof(IConnection<MessageType>), typeof(DapperConnection<MessageType>));
                container.Register(typeof(IConnection<Message>), typeof(DapperConnection<Message>));
                container.Register(typeof(IConnection<RoomBedRelation>), typeof(DapperConnection<RoomBedRelation>));

                container.Register(typeof(IConnection<StarRating>), typeof(DapperConnection<StarRating>));
                container.Register(typeof(IConnection<ChildrenAndExtraBedPolicies>), typeof(DapperConnection<ChildrenAndExtraBedPolicies>));
                container.Register(typeof(IConnection<MaxChildAndExtraBedPerRoom>), typeof(DapperConnection<MaxChildAndExtraBedPerRoom>));
                container.Register(typeof(IConnection<HotelMeal>), typeof(DapperConnection<HotelMeal>));
                container.Register(typeof(IConnection<HotelMealType>), typeof(DapperConnection<HotelMealType>));
                container.Register(typeof(IConnection<ProfileCompletenessAggregateModel>), typeof(DapperConnection<ProfileCompletenessAggregateModel>));
                container.Register(typeof(IConnection<ContractTemplate>), typeof(DapperConnection<ContractTemplate>));
                container.Register(typeof(IConnection<HotelField>), typeof(DapperConnection<HotelField>));
                container.Register(typeof(IConnection<RoomField>), typeof(DapperConnection<RoomField>));
                container.Register(typeof(IConnection<ContractOverview>), typeof(DapperConnection<ContractOverview>));

                container.Register(typeof(IConnection<CancellationCharges>), typeof(DapperConnection<CancellationCharges>));
                container.Register(typeof(IConnection<CancellationPolicy>), typeof(DapperConnection<CancellationPolicy>));
                container.Register(typeof(IConnection<CancellationPolicyClauses>), typeof(DapperConnection<CancellationPolicyClauses>));
                container.Register(typeof(IConnection<CancellationPolicyType>), typeof(DapperConnection<CancellationPolicyType>));

                container.Register(typeof(IConnection<TemplateHotelField>), typeof(DapperConnection<TemplateHotelField>));
                container.Register(typeof(IConnection<TemplateRoomField>), typeof(DapperConnection<TemplateRoomField>));
                container.Register(typeof(IConnection<RatePlans>), typeof(DapperConnection<RatePlans>));
                container.Register(typeof(IConnection<RateCategoryList>), typeof(DapperConnection<RateCategoryList>));
                container.Register(typeof(IConnection<RateCategory>), typeof(DapperConnection<RateCategory>));
                container.Register(typeof(IConnection<TemplateClauseLibrary>), typeof(DapperConnection<TemplateClauseLibrary>));
                container.Register(typeof(IConnection<TemplateClauseLibraryRelation>), typeof(DapperConnection<TemplateClauseLibraryRelation>));
                container.Register(typeof(IConnection<Reservation>), typeof(DapperConnection<Reservation>));
                container.Register(typeof(IConnection<Field>), typeof(DapperConnection<Field>));
                container.Register(typeof(IConnection<ContractHotel>),typeof(DapperConnection<ContractHotel>));
                container.Register(typeof(IConnection<ContractHotelProperties>), typeof(DapperConnection<ContractHotelProperties>));
                container.Register(typeof(IConnection<ContractRoomProperties>), typeof(DapperConnection<ContractRoomProperties>));
                container.Register(typeof(IConnection<ContractContact>), typeof(DapperConnection<ContractContact>));
                container.Register(typeof(IConnection<ContractHotelTaxRelation>), typeof(DapperConnection<ContractHotelTaxRelation>));
                


                container.Register(typeof(IConnection<MarketIncludedCountryRelation>), typeof(DapperConnection<MarketIncludedCountryRelation>));
                container.Register(typeof(IConnection<MarketExcludedCountryRelation>), typeof(DapperConnection<MarketExcludedCountryRelation>));
                container.Register(typeof(IConnection<MarketIncludedAndExcludedCountries>), typeof(DapperConnection<MarketIncludedAndExcludedCountries>));
                container.Register(typeof(IConnection<HotelContractRelation>), typeof(DapperConnection<HotelContractRelation>));
                container.Register(typeof(IConnection<ContractStatus>), typeof(DapperConnection<ContractStatus>));
                container.Register(typeof(IConnection<Calendar>), typeof(DapperConnection<Calendar>));
            }
            else
            {
                //  container.Register<IMasterData, Fakes.MasterDataRepository>();
                //container.Register<IMasterDataDAL, Core.DAL.Fakes.MasterDataDALRepository>();
            }
            //// Cross wire Identity services
            //container.CrossWire<UserManager<ApplicationUser>>(app);
            //container.CrossWire<SignInManager<ApplicationUser>>(app);

            //// Cross wire other AccountController dependencies
            //container.CrossWire<ILoggerFactory>(app);
            //container.CrossWire<IOptions<IdentityCookieOptions>>(app);

            // NOTE: It is highly advisable Class.csto refactor the AccountController
            // and NOT to depend on IOptions<IdentityCookieOptions> and ILoggerFactory
            // See: https://simpleinjector.org/aspnetcore#working-with-ioption-t
        }
        private static void InitializeAutoMapper()
        {
            AutoMapperHelper.AutoMapper.Initialize();
        }


        protected virtual void Dispose( bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose resources
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Private Methods
    }
}


