using System;
using System.IO;
using AutoMapper;
using MG.Jarvis.Api.UserManagement.Interfaces;
using MG.Jarvis.Api.UserManagement.Models;
using MG.Jarvis.Api.UserManagement.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MG.Jarvis.Api.UserManagement
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<DbContext, Context.UserMgmtContext>();
            services.AddScoped(typeof(IRepository<Entities.Application>), typeof(Repository<Entities.Application>));
            services.AddScoped(typeof(IRepository<Entities.Department>), typeof(Repository<Entities.Department>));
            services.AddScoped(typeof(IRepository<Entities.Feature>), typeof(Repository<Entities.Feature>));
            services.AddScoped(typeof(IRepository<Entities.UserType>), typeof(Repository<Entities.UserType>));

            services.AddDbContext<Context.UserMgmtContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("UserManagementConnection"));
                });

            services.AddIdentity<Entities.User, Entities.Role>()
                    .AddEntityFrameworkStores<Context.UserMgmtContext>();

            services.AddCors();
            services.Configure<AppSettings>(Configuration.GetSection("Settings"));

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Jarvis User Management API", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "MG.Jarvis.Api.UserManagement.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            }); services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jarvis UserManagement API v1");

            });



            app.UseMvc();
            app.UseAuthentication();


            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Application, Models.Application>();
                cfg.CreateMap<Models.Base.Application, Entities.Application>();


                cfg.CreateMap<Entities.Department, Models.Department>();
                cfg.CreateMap<Models.Base.Department, Entities.Department>();

                cfg.CreateMap<Entities.Feature, Models.Feature>();
                cfg.CreateMap<Models.Base.Feature, Entities.Feature>();


                cfg.CreateMap<Entities.UserType, Models.UserType>();
                cfg.CreateMap<Models.Base.UserType, Entities.UserType>();




                cfg.CreateMap<Entities.User, Models.MGUserList>()
                     .ForMember(des => des.ActivationDate, opt => opt.MapFrom(s => s.ActivationDate))
                     .ForMember(des => des.DeActivationDate, opt => opt.MapFrom(s => s.DeActivateDate))
                     .ForMember(des => des.Departments, opt => opt.MapFrom(s => s.UserDepartments))
                     .ForMember(des => des.Email, opt => opt.MapFrom(s => s.Email))
                     .ForMember(des => des.EmployeeId, opt => opt.MapFrom(s => s.EmployeeId))
                     .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                     .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                     .ForMember(des => des.ProfilePictureUri, opt => opt.MapFrom(s => s.PhotoUrl))
                     .ForMember(des => des.UserApplicationRole, opt => opt.MapFrom(s => s.UserAppRoleMapping))
                     .ForMember(des => des.UserName, opt => opt.MapFrom(s => s.UserName));


                cfg.CreateMap<Entities.User, Models.HotelUserList>()
                     .ForMember(des => des.ActivationDate, opt => opt.MapFrom(s => s.ActivationDate))
                     .ForMember(des => des.DeActivationDate, opt => opt.MapFrom(s => s.DeActivateDate))
                     .ForMember(des => des.Email, opt => opt.MapFrom(s => s.Email))
                     .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                     .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                     .ForMember(des => des.ProfilePictureUri, opt => opt.MapFrom(s => s.PhotoUrl))
                     .ForMember(des => des.UserApplicationRole, opt => opt.MapFrom(s => s.UserAppRoleMapping))
                     .ForMember(des => des.UserName, opt => opt.MapFrom(s => s.UserName))
                     .ForMember(des => des.Hotels, opt => opt.MapFrom(s => s.UserHotels));


                cfg.CreateMap<Entities.User, Models.AgentUserList>()
                     .ForMember(des => des.ActivationDate, opt => opt.MapFrom(s => s.ActivationDate))
                     .ForMember(des => des.DeActivationDate, opt => opt.MapFrom(s => s.DeActivateDate))
                     .ForMember(des => des.Email, opt => opt.MapFrom(s => s.Email))
                     .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                     .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                     .ForMember(des => des.ProfilePictureUri, opt => opt.MapFrom(s => s.PhotoUrl))
                     .ForMember(des => des.UserApplicationRole, opt => opt.MapFrom(s => s.UserAppRoleMapping))
                     .ForMember(des => des.UserName, opt => opt.MapFrom(s => s.UserName))
                     .ForMember(des => des.AgencyName, opt => opt.MapFrom(s => s.UserAgent.Agency.Name))
                     .ForMember(des => des.AgencyCode, opt => opt.MapFrom(s => s.UserAgent.Agency.Code))
                     .ForMember(des => des.BranchId, opt => opt.MapFrom(s => s.UserAgent.Agency.Branch.Id))
                     .ForMember(des => des.BranchName, opt => opt.MapFrom(s => s.UserAgent.Agency.Branch.Name));
                     //.ForMember(des => des.ContactNumber, opt => opt.MapFrom(s => s.UserAgent.));

                cfg.CreateMap<Entities.UserHotel, Models.Hotel>()
                     .ForMember(des => des.Id, opt => opt.MapFrom(s => s.HotelId))
                     .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Hotel.Name));


                cfg.CreateMap<Entities.UserDepartments, Models.UserDepartments>()
                     .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Department.Id))
                     .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Department.Name));

                cfg.CreateMap<Entities.UserAppRoleMapping, Models.UserApplicationRole>()
                    .ForMember(des => des.ApplicationId, opt => opt.MapFrom(s => s.Application.Id))
                    .ForMember(des => des.ApplicationName, opt => opt.MapFrom(s => s.Application.Name))
                    .ForMember(des => des.RoleId, opt => opt.MapFrom(s => s.Role.Id))
                    .ForMember(des => des.RoleName, opt => opt.MapFrom(s => s.Role.Name));


                cfg.CreateMap<Entities.Role, Models.RoleList>()
                    .ForMember(des => des.ApplicationList, opt => opt.MapFrom(s => s.ApplicationRole))
                    .ForMember(des => des.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
                    .ForMember(des => des.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                    .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Description))
                    .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                    .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Name))
                    .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(s => s.UpdatedBy))
                    .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate));

                cfg.CreateMap<Entities.ApplicationRole, Models.Application>()
                    .ForMember(des => des.Id, opt => opt.MapFrom(s => s.ApplicationId))
                    .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Application.Name))
                    .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(s => s.UpdatedBy))
                    .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate))
                    .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                    .ForMember(des => des.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
                    .ForMember(des => des.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                    .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Application.Description));

                cfg.CreateMap<Entities.ApplicationRole, Models.RoleList>()
                   .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Role.Id))
                   .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Role.Name))
                   .ForMember(des => des.UpdatedBy, opt => opt.MapFrom(s => s.UpdatedBy))
                   .ForMember(des => des.UpdatedDate, opt => opt.MapFrom(s => s.UpdatedDate))
                   .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                   .ForMember(des => des.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
                   .ForMember(des => des.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                   .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Role.Description))
                  .ForMember(des => des.ApplicationList, opt => opt.MapFrom(s => s.Role.ApplicationRole));

            });
        }
    }
}
