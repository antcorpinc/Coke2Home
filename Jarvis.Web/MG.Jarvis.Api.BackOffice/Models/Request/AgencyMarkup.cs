using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.CustomAttributes;
using MG.Jarvis.Core.Model.Markup;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class AgencyMarkup 
    {
        [ChildParameter(true)]
        public Core.Model.MasterData.AgencyMarkup MGAgencyMarkup { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.AgencyMarkupRules,
                                    ParameterDirection.In, ParameterType.TableValued,
                                    new ParameterIncludeInAction[] { ParameterIncludeInAction.All },
                                    Constants.StoredProcedureParameters.UT_AgencyMarkupRules)]
        public List<AgencyMarkupRule> AgencyMarkupRule { get; set; }
    }
}
