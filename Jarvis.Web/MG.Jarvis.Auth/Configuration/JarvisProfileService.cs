using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MG.Jarvis.Model;
using IdentityServer4.Services;
using IdentityServer4.Models;
using MG.Jarvis.Data;
using IdentityServer4.Extensions;

namespace MG.Jarvis.Auth.Configuration
{
        // Override the Profile Service to  get the custom claims for the User
    public class JarvisProfileService: IProfileService 
    {
        private readonly JarvisContext _context;
        private readonly UserManager<JarvisUser> _userManager;

        public JarvisProfileService(UserManager<JarvisUser> userManager, JarvisContext context)
        {
            _context = context;
            _userManager = userManager;
        }        
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.FindByIdAsync(context.Subject.GetSubjectId());
            // ToDO: Check if there is User returned before the below
            var userData = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            var claims = new Claim[]
             {
                new Claim("disabled",userData.Disabled.ToString()),
                new Claim("firstname",userData.FirstName),
                new Claim("username",userData.UserName)
             };
            context.IssuedClaims = claims.ToList();
        }      

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
