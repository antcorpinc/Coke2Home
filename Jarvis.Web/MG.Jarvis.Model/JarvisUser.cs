using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MG.Jarvis.Model.Enums;
using MG.Jarvis.Core.Contracts;

/// <summary>
/// Users in the Jarvis application
/// </summary>
namespace MG.Jarvis.Model
{
   public  class JarvisUser : IdentityUser<Guid>,  IIdentifiableModel<Guid>
    {
        public JarvisUser()
        {
            // UserFeatureTypeMappings = new HashSet<UserFeatureTypeMapping>();
            //  UserRoleMappings = new HashSet<UserRoleMapping>();
            UserAppRoleMappings = new HashSet<UserAppRoleMapping>();
        }
        public bool Disabled { get; set; }
        
        public UserType UserType { get; set; }
        public bool IsSuperUser { get; set; }

        public string FirstName {get;set;}
        public string LastName {get;set;}

        public DateTime? ActivateDate { get; set; }
        public DateTime? DeActivateDate { get; set; }
        public bool? IsDeleted { get; set; }
        // Navigation

        // public ICollection<UserFeatureTypeMapping> UserFeatureTypeMappings { get; set; }
        // public ICollection<UserRoleMapping> UserRoleMappings { get; set; }
        public ICollection<UserAppRoleMapping> UserAppRoleMappings { get; set; }
    }
}
