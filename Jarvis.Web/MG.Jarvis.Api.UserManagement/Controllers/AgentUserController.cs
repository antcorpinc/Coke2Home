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
    [Route("api/Agent")]
    public class AgentUserController : BaseUserController
    {
        private AppSettings AppSetting { get; set; }
        private IRepository<Entities.Application> _repository;
        private UserMgmtContext _context;

        public AgentUserController(UserMgmtContext context, IRepository<Entities.Application> repository, UserManager<Entities.User> userManager, IOptions<AppSettings> settings) : base(userManager)
        {
            AppSetting = settings.Value;
            _repository = repository;
            _context = context;
        }


        [Route("Get")]
        [HttpGet]
        public IEnumerable<Models.AgentUserList> Get()
        {
            //var users = base.Get(AppSetting.AgentUserType);

            var list = _context.User.Where(u => u.UserType == AppSetting.AgentUserType)
                      .Include(userRole => userRole.UserAppRoleMapping)
                      .ThenInclude(role => role.Application)
                      .ThenInclude(role => role.ApplicationRole)
                       .ThenInclude(role => role.Role)
                      .Include(dept => dept.UserDepartments).ThenInclude(d => d.Department)
                       .Include(dept => dept.UserAgent).ThenInclude(d => d.Agency).ThenInclude(d => d.Branch).ToList();

            return Mapper.Map<IEnumerable<Models.AgentUserList>>(list);
        }

        [Route("GetById")]
        [HttpGet]
        public Models.AgentUserList GetById(Guid userId)
        {
            var users = base.GetById(AppSetting.AgentUserType, userId);
            return Mapper.Map<Models.AgentUserList>(users);
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IdentityResult> Create([FromBody] Models.AgentUser model)
        {
            try
            {
                var appId = _repository.Get(app => app.Name.ToLower() == AppSetting.BookingEngineAppName.ToLower()).FirstOrDefault();
                if (appId == null)
                    throw new Exception("B2B Application not found in the application table.");

                return await base.Create(Map(model, new Entities.User(), appId.Id, 'C'), AppSetting.AgentUserType, AppSetting.AgentDefaultPassword);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        [Route("Update/{id}")]
        [HttpPut]
        public async Task<IdentityResult> Update([FromRoute] Guid id, [FromBody] Models.AgentUser model)
        {
            var appId = _repository.Get(app => app.Name.ToLower() == AppSetting.BookingEngineAppName.ToLower()).FirstOrDefault();
            if (appId == null)
                throw new Exception("B2B Application not found in the application table.");

            var user = base.Get(AppSetting.AgentUserType).Find(u => u.Id == id);
            return await base.Update(Map(model, user, appId.Id, 'U'));

        }

        [Route("Delete")]
        [HttpPut]
        public new async Task<IdentityResult> Delete([FromBody]string userId)
        {
            return await base.Delete(userId);
        }

        private Entities.User Map(Models.AgentUser model, Entities.User user, Guid b2bApplicationId, char mode)
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
                ApplicationId = b2bApplicationId,
                RoleId = model.B2BRoleId,
                IsActive = model.IsActive
            });


            user.UserAgent = new Entities.UserAgent
            {
                AgencyBranchId = model.BranchId,
                AgencyId = model.AgencyId,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                UpdatedBy = model.UpdatedBy,
                UpdatedDate = model.UpdatedDate,
                IsDeleted = false,
            };


            return user;
        }
    }
}