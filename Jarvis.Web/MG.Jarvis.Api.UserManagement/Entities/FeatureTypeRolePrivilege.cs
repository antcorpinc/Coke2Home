using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// FeatureTypeRolePrivilege Entity
    /// </summary>
    public partial class FeatureTypeRolePrivilege
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// FeatureTypeId
        /// </summary>
        public int FeatureTypeId { get; set; }
        /// <summary>
        /// Privileges
        /// 
        /// </summary>
        public string Privileges { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public Guid RoleId { get; set; }
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
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// FeatureType
        /// </summary>
        public Feature FeatureType { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public Role Role { get; set; }
    }
}
