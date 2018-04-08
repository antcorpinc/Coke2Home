using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// UserType Entity
    /// </summary>
    public partial class UserType
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserType()
        {
            User = new HashSet<User>();
        }
        /// <summary>
        ///Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        ///IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        ///CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        ///CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        ///UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        ///UpdatedDate
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        ///User
        /// </summary>
        public ICollection<User> User { get; set; }
    }
}
