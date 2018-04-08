using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models.Base
{
    public class UserList
    {
        public UserList()
        {
            this.UserApplicationRole = new List<Models.UserApplicationRole>();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string ProfilePictureUri { get; set; }

        public ICollection<Models.UserApplicationRole> UserApplicationRole { get; set; }

        public DateTime ActivationDate { get; set; }
        public DateTime DeActivationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
