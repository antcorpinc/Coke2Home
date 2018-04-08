using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.CustomAttributes;
using MG.Jarvis.Core.Model.Markup;
using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class RevenueMarkup 
    {
        [ChildParameter(true)]
        public Core.Model.MasterData.RevenueMarkup MGRevenueMarkup { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.RevenueMarkupRules, 
                                    ParameterDirection.In, ParameterType.TableValued, 
                                    new ParameterIncludeInAction[] { ParameterIncludeInAction.All },
                                    Constants.StoredProcedureParameters.UT_RevenueMarkupRules)]
        public List<RevenueMarkupRule> RevenueMarkupRules { get; set; }                
    }
}
