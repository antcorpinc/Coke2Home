using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Models.ViewModels
{
    public class HotelDetailsViewModel
    {
        public HotelDetailsViewModel()
        {
            ContactDetails = new List<ContactDetailsViewModel>();
            TaxDetails = new List<HotelTaxRelationViewModel>();
            HotelPaymentMethodRelation = new HotelPaymentMethodRelationViewModel();
        }
        public int HotelId { get; set; }
        public string HotelCode { get; set; }
        public bool IsActive { get; set; }
        public string HotelName { get; set; }
        public int? HotelChainId { get; set; }
        public int? HotelBrandId { get; set; }
        public int? HotelTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Location { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int? ProfileScore { get; set; }
        public List<ContactDetailsViewModel> ContactDetails { get; }
        public HotelPaymentMethodRelationViewModel HotelPaymentMethodRelation { get; set; }
        public string Website { get; set; }
        public string ReservationEmail { get; set; }
        public string ReservationContactNo { get; set; }
        public bool IsExtranetAccess { get; set; }
        public bool IsChannelManagerConnectivity { get; set; }
        public int? ChannelManagerId { get; set; }
        public List<HotelTaxRelationViewModel> TaxDetails { get; }
        public short StarRatingId { get; set; }
        public int? MGPoint { get; set; }
        public ObjectState? ObjectState { get; set; }

        public string CheckInFrom { get; set; }
        public string CheckInTo { get; set; }
        public string CheckOutFrom { get; set; }
        public string CheckOutTo { get; set; }
    }
}
