using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// Feature Entity
    /// </summary>
    public partial class Feature
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Feature()
        {
            ApplicationFeature = new HashSet<ApplicationFeature>();
            FeatureTypeRolePrivilege = new HashSet<FeatureTypeRolePrivilege>();
            InverseParentFeature = new HashSet<Feature>();
        }
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Order
        /// </summary>
        public int? Order { get; set; }
        /// <summary>
        /// ParentFeatureId
        /// </summary>
        public int? ParentFeatureId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
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
        /// ParentFeature
        /// </summary>
        public Feature ParentFeature { get; set; }
        /// <summary>
        /// ApplicationFeature
        /// </summary>
        public ICollection<ApplicationFeature> ApplicationFeature { get; set; }
        /// <summary>
        /// FeatureTypeRolePrivilege
        /// </summary>
        public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        /// <summary>
        /// InverseParentFeature
        /// </summary>
        public ICollection<Feature> InverseParentFeature { get; set; }
    }
}
