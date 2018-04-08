using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class AgentUser : Base.User
    {
        public int DesignationId { get; set; }

        public int BranchId { get; set; }

        public int AgencyId { get; set; }

       
        public string ContactNumber { get; set; }

        public Guid B2BRoleId { get; set; }

       
    }
}
