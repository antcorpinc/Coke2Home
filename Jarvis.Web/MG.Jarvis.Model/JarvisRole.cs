using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MG.Jarvis.Core.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Roles in the Jarvis application
/// </summary>
namespace MG.Jarvis.Model
{
    
    public class JarvisRole : IdentityRole<Guid> , IIdentifiableModel<Guid>
    {
        public JarvisRole()
        {
              FeatureTypeRolePrivilege = new HashSet<FeatureTypeRolePrivilege>();
            //  UserFeatureTypeMappings = new HashSet<UserFeatureTypeMapping>();
            // UserRoleMappings = new HashSet<UserRoleMapping>();
            UserAppRoleMappings = new HashSet<UserAppRoleMapping>();
        }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        // Navigation

        public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        //  public ICollection<UserFeatureTypeMapping> UserFeatureTypeMappings { get; set; }
        // public ICollection<UserRoleMapping> UserRoleMappings { get; set; }
         public ICollection<UserAppRoleMapping> UserAppRoleMappings { get; set; }
    }
}
