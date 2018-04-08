using AutoMapper;
using MG.Jarvis.Api.UserManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MG.Jarvis.Api.UserManagement.Context;
using Microsoft.EntityFrameworkCore;

namespace MG.Jarvis.Api.UserManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/HotelUser")]
    public class HotelUserController : BaseUserController
    {
        private AppSettings AppSetting { get; set; }
        private IRepository<Entities.Application> _repository;
        private UserMgmtContext _context;
        public HotelUserController(UserMgmtContext context, IRepository<Entities.Application> repository, UserManager<Entities.User> userManager, IOptions<AppSettings> settings) : base(userManager)
        {
            AppSetting = settings.Value;
            _repository = repository;
            _context = context;
        }


        [Route("Get")]
        [HttpGet]
        public IEnumerable<Models.HotelUserList> Get()
        {
            var list = _context.User.Where(u => u.UserType == AppSetting.HotelUserType)
                       .Include(userRole => userRole.UserAppRoleMapping)
                       .ThenInclude(role => role.Application)
                       .ThenInclude(role => role.ApplicationRole)
                        .ThenInclude(role => role.Role)
                       .Include(dept => dept.UserDepartments).ThenInclude(d => d.Department)
                        .Include(dept => dept.UserHotels).ThenInclude(d => d.Hotel).ToList();
           
            return Mapper.Map<IEnumerable<Models.HotelUserList>>(list);
        }
        [Route("GetById")]
        [HttpGet]
        public Models.HotelUserList GetById(Guid userId)
        {

            var users = _context.User.Where(u => u.UserType == AppSetting.HotelUserType && u.Id == userId)
                     .Include(userRole => userRole.UserAppRoleMapping)
                     .ThenInclude(role => role.Application)
                     .ThenInclude(role => role.ApplicationRole)
                      .ThenInclude(role => role.Role)
                     .Include(dept => dept.UserDepartments).ThenInclude(d => d.Department)
                      .Include(dept => dept.UserHotels).ThenInclude(d => d.Hotel).ToList();

            return Mapper.Map<Models.HotelUserList>(users);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IdentityResult> Create([FromBody] Models.HotelUser model)
        {
            var appId = _repository.Get(app => app.Name.ToLower() == AppSetting.ExtranetAppName.ToLower()).FirstOrDefault();
            if (appId == null)
                throw new Exception("Extranet Application not found in the application table.");

            return await base.Create(Map(model, new Entities.User(), appId.Id, 'C'), AppSetting.HotelUserType, AppSetting.HotelDefaultPassword);
        }

        [Route("Update/{id}")]
        [HttpPut]
        public async Task<IdentityResult> Update([FromRoute] Guid id, [FromBody] Models.HotelUser model)
        {
            var appId = _repository.Get(app => app.Name.ToLower() == AppSetting.ExtranetAppName.ToLower()).FirstOrDefault();
            if (appId == null)
                throw new Exception("Extranet Application not found in the application table.");

            var user = base.Get(AppSetting.HotelUserType).Find(u => u.Id == id);
            return await base.Update(Map(model, user, appId.Id, 'U'));

        }

        [Route("Delete")]
        [HttpPut]
        public new async Task<IdentityResult> Delete([FromBody]string userId)
        {
            return await base.Delete(userId);
        }

        private Entities.User Map(Models.HotelUser model, Entities.User user, Guid extranetAppId, char mode)
        {
            if (user == null)
                throw new Exception("User not found");

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhotoUrl = model.ProfilePictureUri;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.NormalizedEmail = model.Email;
            user.ActivationDate = model.ActivationDate;
            user.DeActivateDate = model.DeActivationDate;
            user.IsActive = model.IsActive;
            user.CreatedBy = model.CreatedBy;
            user.CreatedDate = model.CreatedDate;
            user.UpdatedBy = model.UpdatedBy;
            user.UpdatedDate = model.UpdatedDate;

            if (mode == 'U')
                return user;

            user.UserAppRoleMapping.Add(new Entities.UserAppRoleMapping
            {
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                UpdatedBy = model.UpdatedBy,
                UpdatedDate = model.UpdatedDate,
                ApplicationId = extranetAppId,
                RoleId = model.ExtranetRoleId,
                IsActive = model.IsActive
            });

            foreach (var item in model.HotelId)
            {
                user.UserHotels.Add(new Entities.UserHotel
                {
                    HotelId = item,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate,
                    UpdatedBy = model.UpdatedBy,
                    UpdatedDate = model.UpdatedDate,
                });
            }



            return user;
        }
    }
}