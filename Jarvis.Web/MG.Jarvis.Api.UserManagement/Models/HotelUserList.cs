using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class HotelUserList : Base.UserList
    {
        public HotelUserList()
        {
            this.Hotels = new List<Models.Hotel>();
        }
        public string Designation { get; set; }

        public ICollection<Models.Hotel> Hotels { get; set; }

    }
}
