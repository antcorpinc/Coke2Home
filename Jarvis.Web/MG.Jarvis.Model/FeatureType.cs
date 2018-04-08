using MG.Jarvis.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
///  All the features in the Jarvis application
/// </summary>
namespace MG.Jarvis.Model
{
    [Table("FeatureType", Schema = "AccessPermission")]
    public class FeatureType : IIdentifiableModel<int>
    {
        public FeatureType()
        {
            ApplicationFeatures = new HashSet<ApplicationFeature>();
            FeatureTypeRolePrivileges = new HashSet<FeatureTypeRolePrivilege>();
         }

        [Key]
        public int Id {get;set;}

        [Required]
        [MaxLength(30)]
        public string TypeName {get;set;}
        
        [MaxLength(200)]
        public string  Description {get;set;}

        public int? ParentFeatureId {get;set;}
        public int? Order{get;set;}

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation
        public ICollection<ApplicationFeature> ApplicationFeatures { get; set; }
        public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivileges { get; set; }
        

    }
}      
