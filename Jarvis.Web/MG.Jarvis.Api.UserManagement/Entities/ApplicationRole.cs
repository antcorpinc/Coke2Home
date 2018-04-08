using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// ApplicationRole Entity
    /// </summary>
    public partial class ApplicationRole
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ApplicationId
        /// </summary>
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public Guid RoleId { get; set; }
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
        /// UpdatedDate
        /// </summary>
        public Application Application { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public Role Role { get; set; }
    }
}
