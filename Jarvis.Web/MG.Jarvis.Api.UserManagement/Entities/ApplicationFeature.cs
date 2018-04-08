using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// ApplicationFeature Entity
    /// </summary>
    public partial class ApplicationFeature
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ApplicationId
        /// </summary>
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// FeatureTypeId
        /// </summary>
        public int FeatureTypeId { get; set; }
        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Application
        /// </summary>
        public Application Application { get; set; }
        /// <summary>
        /// FeatureType
        /// </summary>
        public Feature FeatureType { get; set; }
    }
}
