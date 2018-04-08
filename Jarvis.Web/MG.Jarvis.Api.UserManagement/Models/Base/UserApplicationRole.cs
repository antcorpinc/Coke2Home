using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models.Base
{
    public class UserApplicationRole
    {
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
    }
}
