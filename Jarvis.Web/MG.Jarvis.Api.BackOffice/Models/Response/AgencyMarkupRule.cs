using MG.Jarvis.Core.Model.Markup;
using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class AgencyMarkupRuleResponse : AgencyMarkupRule
    {
        public string MarkupName { get; set; }
        public string Agency { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public string RoomType { get; set; }
        public string ChargeType { get; set; }
    }
}
