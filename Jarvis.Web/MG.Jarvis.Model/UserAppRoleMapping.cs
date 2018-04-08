using MG.Jarvis.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MG.Jarvis.Model
{
    [Table("UserAppRoleMapping", Schema = "AccessPermission")]
    public class UserAppRoleMapping : IIdentifiableModel<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ApplicationId { get; set; }

        public Guid RoleId { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        //  Relationship

        [ForeignKey("UserId")]
        public JarvisUser User { get; set; }
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [ForeignKey("RoleId")]
        public JarvisRole Role { get; set; }

    }
}
