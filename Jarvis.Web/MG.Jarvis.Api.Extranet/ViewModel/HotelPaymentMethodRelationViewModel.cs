namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelPaymentMethodRelationViewModel : BaseViewModel
    {
        public int HotelPaymentMethodRelationId { get; set; }
        public int PaymentMethodId { get; set; }
        public int CurrencyId { get; set; }
        public int RateTypeId { get; set; }
    }
}
