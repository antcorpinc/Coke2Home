using MG.Jarvis.Core.Model.Markup;
using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Models.Markup.Response
{
    public class RevenueMarkup
    {
        public Core.Model.MasterData.RevenueMarkup MGRevenueMarkup { get; set; }

        public List<RevenueMarkupRule> RevenueMarkupRuleResponse { get; set; }
    }
}
