using MG.Jarvis.Api.UserManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// Role Entity
    /// </summary>
    public partial class Role : IdentityRole<Guid>, IIdentifiableModel<Guid>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Role()
        {
            ApplicationRole = new HashSet<ApplicationRole>();
            FeatureTypeRolePrivilege = new HashSet<FeatureTypeRolePrivilege>();
            UserAppRoleMapping = new HashSet<UserAppRoleMapping>();
        }
        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// UpdatedDate
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ApplicationRole
        /// </summary>
        public ICollection<ApplicationRole> ApplicationRole { get; set; }
        /// <summary>
        /// FeatureTypeRolePrivilege
        /// </summary>
        public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        /// <summary>
        /// UserAppRoleMapping
        /// </summary>
        public ICollection<UserAppRoleMapping> UserAppRoleMapping { get; set; }


        #region unused
        // public Guid Id { get; set; }
        // public string ConcurrencyStamp { get; set; }
        // public string Name { get; set; }
        //  public string NormalizedName { get; set; }
        #endregion
    }
}
