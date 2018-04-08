using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class AgencyMarkup
    {
        public AgencyMarkup MGAgencyMarkup { get; set; }

        public List<AgencyMarkupRuleResponse> AgencyMarkupRuleResponse { get; set; }
    }
}
