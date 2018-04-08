//using MG.Jarvis.Core.Model.Agency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class Branch
    {
        public Branch()
        {
            this.BranchContacts = new List<Core.Model.Agency.BranchContacts>();
        }

        public Core.Model.Agency.Branch MGBranch { get; set; }
        public List<Core.Model.Agency.BranchContacts> BranchContacts { get; set; }
    }
}
