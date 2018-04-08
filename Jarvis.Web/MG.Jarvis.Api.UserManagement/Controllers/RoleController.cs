using AutoMapper;
using MG.Jarvis.Api.UserManagement.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Controllers
{

    /// <summary>
    /// Controller to perform the CRUD operations for Role Entity
    /// </summary>
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
        RoleManager<Entities.Role> _roleManager = null;
        UserMgmtContext _context = null;
        public RoleController(UserMgmtContext context, RoleManager<Entities.Role> roleManager)
        {
            _roleManager = roleManager;
            _context = context;
        }


        [Route("Get")]
        [HttpGet]
        public IEnumerable<Models.RoleList> Get()
        {
            var roles = _roleManager.Roles.Where(u => u.IsActive == true)
                         .Include(r=> r.ApplicationRole)
                         .ThenInclude(r => r.Application).ToList();

            var rolesList = Mapper.Map<IEnumerable<Models.RoleList>>(roles);
            return rolesList;
        }

        [Route("GetByApplicationId")]
        [HttpGet]
        public IEnumerable<Models.RoleList> GetByApplicationId(Guid applicationId)
        {
            var roles = _context.ApplicationRole.Where(a => a.ApplicationId == applicationId && a.IsActive == true)
                         .Include(r => r. Application)
                         .Include(r => r.Role).ToList();
            return Mapper.Map<IEnumerable<Models.RoleList>>(roles);

        }

        [Route("GetByApplicationName")]
        [HttpGet]
        public IEnumerable<Models.RoleList> GetByApplicationName(string name)
        {
            var roles = _context.ApplicationRole.Where(a => a.Application.Name.ToLower() == name.ToLower() && a.IsActive == true)
                         .Include(r => r.Application)
                         .Include(r => r.Role).ToList();
            return Mapper.Map<IEnumerable<Models.RoleList>>(roles);

        }


        [Route("Create")]
        [HttpPost]
        public async Task<IdentityResult> Create([FromBody]Models.Role model)
        {
            var jarvisRole = Mapper.Map<Entities.Role>(model);
            return await _roleManager.CreateAsync(jarvisRole);
        }

        //[Route("Update")]
        //[HttpPut]
        //public async Task<IdentityResult> Update([FromBody]Models.Role model)
        //{
        //    var jarvisRole = _roleManager.Roles.Where(r => r.Id == model.Id && r.IsDeleted == false).Single();
        //    Mapper.Map<Role, JarvisRole>(model, jarvisRole);
        //    return await _roleManager.UpdateAsync(jarvisRole);
        //}

        //[Route("Delete")]
        //[HttpPut]
        //public async Task<IdentityResult> Delete([FromBody]string roleId)
        //{
        //    var jarvisRole = _roleManager.Roles.Where(r => r.Id.ToString() == roleId && r.IsDeleted == false).Single();
        //    if (jarvisRole == null)
        //    {
        //        return null;
        //    }
        //    jarvisRole.IsDeleted = true;
        //    return await _roleManager.UpdateAsync(jarvisRole);
        //}
    }
}
