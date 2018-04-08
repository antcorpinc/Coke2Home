using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// UserAgent
    /// </summary>
    public class UserAgent
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// AgencyBranchId
        /// </summary>
        public int AgencyBranchId { get; set; }
        /// <summary>
        /// AgencyId
        /// </summary>
        public int AgencyId { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// CountryId
        /// </summary>
        public int? CountryId { get; set; }
        /// <summary>
        /// CityId
        /// </summary>
        public int? CityId { get; set; }
        
        /// <summary>
        /// Address1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Address2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// ZipCode
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// IsActive
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// UpdatedDate
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// User
        /// </summary>
        /// 
        public User User { get; set; }

        public Agency Agency { get; set; }

    }
}
     