using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    /// <summary>
    /// User Hotel
    /// </summary>
    public class UserHotel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// HotelId
        /// </summary>
        public int HotelId { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }

       

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
        ///// <summary>
        ///// Department
        ///// </summary>
        //public Ho Department { get; set; }
        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        public Hotel Hotel { get; set; }
    }
}
