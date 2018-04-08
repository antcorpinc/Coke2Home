using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class HotelUser : Base.User
    {
        public string Designation { get; set; }
                
        public int[] HotelId { get; set; }
        public Guid ExtranetRoleId { get; set; }
    }
}
