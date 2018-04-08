using MG.Jarvis.Api.Extranet.Helper;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelTaxRelationViewModel : BaseViewModel
    {
        public int TaxTypeId { get; set; }
        public string TaxesType { get; set; }
        public int TaxApplicabilityId { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncludedInRates { get; set; }
        public bool IsDeleted { get; set; }
    }
}
