using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    public class AgencyBranch
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AgencyId { get; set; }

        public Agency Agency { get; set; }
    }
}
