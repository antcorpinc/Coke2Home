using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// Application Entity
    /// </summary>
    public partial class Application
    {
        /// <summary>
        /// Default Contrustor
        /// </summary>
        public Application()
        {
            ApplicationFeature = new HashSet<ApplicationFeature>();
            ApplicationRole = new HashSet<ApplicationRole>();
            UserAppRoleMapping = new HashSet<UserAppRoleMapping>();
        }
        /// <summary>
        /// Unique Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Application Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Application Name
        /// </summary>
        public string Name { get; set; }
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
        /// ApplicationFeature
        /// </summary>
        public ICollection<ApplicationFeature> ApplicationFeature { get; set; }
        /// <summary>
        /// ApplicationRole
        /// </summary>
        public ICollection<ApplicationRole> ApplicationRole { get; set; }
        /// <summary>
        /// UserAppRoleMapping
        /// </summary>
        public ICollection<UserAppRoleMapping> UserAppRoleMapping { get; set; }
    }
}
