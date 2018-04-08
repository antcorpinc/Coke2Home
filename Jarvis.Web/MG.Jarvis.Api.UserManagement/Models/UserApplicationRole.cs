using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class UserApplicationRole : Base.UserApplicationRole
    {
      
        public string ApplicationName { get; set; }
      
        public string RoleName { get; set; }
    }
}
