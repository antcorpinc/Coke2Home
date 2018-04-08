using MG.Jarvis.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// The model represents the all applications in the Jarvis - Ex. Extranet / BackOffice / Booking
/// </summary>
namespace MG.Jarvis.Model
{
    [Table("Application",Schema = "AccessPermission")]
    public class Application : IIdentifiableModel<Guid>
    {
        public Application()
        {
            ApplicationFeatures = new HashSet<ApplicationFeature>();
            //  UserFeatureTypeMappings = new HashSet<UserFeatureTypeMapping>();
            //  UserRoleMappings = new HashSet<UserRoleMapping>();
            UserAppRoleMappings = new HashSet<UserAppRoleMapping>();
        }

        [Key]
        public Guid Id {get;set;}
        [Required]
        public string Name {get;set;}
        public string Description {get;set;}

        public bool IsDeleted { get; set; }

        //Navigation
           public ICollection<ApplicationFeature> ApplicationFeatures { get; set; }
        //  public ICollection<UserFeatureTypeMapping> UserFeatureTypeMappings { get; set; }
        // public ICollection<UserRoleMapping> UserRoleMappings { get; set; }
        public ICollection<UserAppRoleMapping> UserAppRoleMappings { get; set; }
        

    }
}