using MG.Jarvis.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Model.DTOs
{
   public class UserDetails
    {

        public UserDetails()
        {
            ApplicationPermissions = new List<ApplicationPermission>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Disabled { get; set; }
        public UserType UserType { get; set; }
        public bool IsSuperUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Todo: Add other properties

        public List<ApplicationPermission> ApplicationPermissions { get; set; }
    }
}
