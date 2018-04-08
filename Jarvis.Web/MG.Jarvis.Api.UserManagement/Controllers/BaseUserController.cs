using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Controllers
{
    [Produces("application/json")]

    public abstract class BaseUserController : Controller
    {
        UserManager<Entities.User> _userManager = null;
        public BaseUserController(UserManager<Entities.User> userManager)
        {
            _userManager = userManager;
        }

        internal List<Entities.User> Get(int userType)
        {
            var list = _userManager.Users.Where(u => u.UserType == userType)
                        .Include(userRole => userRole.UserAppRoleMapping)
                        .ThenInclude(role => role.Application)
                        .ThenInclude(role => role.ApplicationRole)
                         .ThenInclude(role => role.Role)
                        .Include(dept => dept.UserDepartments).ThenInclude(d => d.Department).ToList();


            return list;

        }

        internal Entities.User GetById(int userType, Guid userId)
        {
            var list = _userManager.Users.Where(u => u.UserType == userType && u.Id == userId)
                        .Include(userRole => userRole.UserAppRoleMapping)
                        .ThenInclude(role => role.Application)
                        .ThenInclude(role => role.ApplicationRole)
                        .ThenInclude(role => role.Role)
                        .Include(dept => dept.UserDepartments).ThenInclude(d => d.Department).FirstOrDefault();


            return list;

        }

        internal async Task<IdentityResult> Create(Entities.User model, int userType, string defaultPassword)
        {
            model.UserType = userType;
            return await _userManager.CreateAsync(model, defaultPassword);
        }
        internal async Task<IdentityResult> Delete(string userId)
        {
            var model = await _userManager.FindByIdAsync(userId);
            if (model == null)
                return null;

            return await _userManager.DeleteAsync(model);


        }

        internal async Task<IdentityResult> Update(Entities.User model)
        {
            return await _userManager.UpdateAsync(model);
        }

    }
}