using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.Agency;
using MG.Jarvis.Core.Model.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class Branch
    {
        public Branch()
        {
            this.BranchContacts = new List<Core.Model.Agency.BranchContacts>();
        }

        [ChildParameter(true)]
        public MG.Jarvis.Core.Model.Agency.Branch MGBranch { get; set; }
        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.BranchContacts, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_AgencyBranchContacts)]
        public List<BranchContacts> BranchContacts { get; set; }
    }
}
