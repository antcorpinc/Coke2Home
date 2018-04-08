using MG.Jarvis.Core.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Roles having privileges for a feature . Ex BackOffice Support Role can R/W  manageuser feature 
/// </summary>

namespace MG.Jarvis.Model
{
    [Table("FeatureTypeRolePrivilege", Schema = "AccessPermission")]
    public class FeatureTypeRolePrivilege : IIdentifiableModel<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int FeatureTypeId { get; set; }
        [Required]
        public Guid RoleId { get; set; }

        public string Privileges { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        // Relationship
        [ForeignKey("FeatureTypeId")]
        public FeatureType FeatureType { get; set; }

        [ForeignKey("RoleId")]
        public JarvisRole Role { get; set; }
    }
}
