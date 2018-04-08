using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ChildAndExraBedPolicyListViewModel
    {
        public int ChildAndExtrabedPolicyId { get; set; }
        public int? MinChildAge { get; set; }
        public int? MaxChildAge { get; set; }
        public int? MaxInfantAge { get; set; }
        public bool IsExtraBedAllowed { get; set; }
        public int? CotPriceTypeId { get; set; }
        public int? CotPrice { get; set; }
    }
}
