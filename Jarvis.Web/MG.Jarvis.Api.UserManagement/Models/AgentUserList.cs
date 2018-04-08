using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class AgentUserList : Base.UserList
    {
        public string AgencyName { get; set; }
        public string AgencyCode { get; set; }
        public string BranchName { get; set; }
        public string ContactNumber { get; set; }
        public int BranchId { get; set; }
        public int DesignationId { get; set; }

        public string Designation { get; set; }

    }

    
}
