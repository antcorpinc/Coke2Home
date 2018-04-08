using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContractHotelTaxRelationViewModel : BaseViewModel
    {
        public int ContractId { get; set; }
        public int TaxTypeId { get; set; }
        public int TaxApplicabilityId { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncludedInRates { get; set; }
        public bool IsDeleted { get; set; }
    }
}
