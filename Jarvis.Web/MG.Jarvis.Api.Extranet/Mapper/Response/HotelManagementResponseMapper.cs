using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class HotelManagementResponseMapper
    {
        /// <summary>
        /// Returns Mapped Hotel Details view Model
        /// </summary>
        /// <param name="hoteldata"></param>
        /// <returns> Mapped Hotel Details view Model</returns>
        public static HotelDetailsViewModel MapHotelDetailsToHotelDetailsViewModel(BaseResult<List<HotelView>> hotelView)
        {
            HotelDetailsViewModel hotel = new HotelDetailsViewModel();

            foreach (var item in hotelView.Result)
            {
                if (!(hotel.HotelId == item.HotelId))
                {
                    hotel.HotelCode = item.HotelCode;
                    hotel.Location = item.CityName + ", " + item.CountryName;
                    hotel.HotelId = item.HotelId;
                    hotel.IsActive = item.IsActive;
                    hotel.HotelName = item.HotelName;
                    hotel.HotelChainId = item.HotelChainId;
                    hotel.HotelBrandId = item.HotelBrandId;
                    hotel.HotelTypeId = item.HotelTypeId;
                    hotel.CountryId = item.CountryId;
                    hotel.CityId = item.CityId;
                    hotel.Latitude = item.Latitude;
                    hotel.Longitude = item.Longitude;
                    hotel.ShortDescription = item.ShortDescription;
                    hotel.LongDescription = item.LongDescription;
                    hotel.Website = item.Website;
                    hotel.ReservationEmail = item.ReservationEmail;
                    hotel.ReservationContactNo = item.Telephone;
                    hotel.Address1 = item.Address1;
                    hotel.Address2 = item.Address2;
                    hotel.ZipCode = item.ZipCode;
                    hotel.IsExtranetAccess = item.IsExtranetAccess;
                    hotel.IsChannelManagerConnectivity = item.IsChannelManagerConnectivity;
                    hotel.ChannelManagerId = item.ChannelManagerId;
                    if (item.ChannelManagerId == 0)
                    {
                        hotel.ChannelManagerId = null;
                    };

                    hotel.StarRatingId = item.StarRatingID;
                    hotel.MGPoint = item.MGPoint;

                    DateTime dt;

                    if (item.CheckInFrom != null)
                    {
                        dt = new DateTime() + item.CheckInFrom;

                        hotel.CheckInFrom = dt.ToString("hh:mm tt");
                    }
                    //if (item.CheckInTo != null)
                    //{
                    //    dt = new DateTime() + (TimeSpan)item.CheckInTo;
                    //    hotel.CheckInTo = dt.ToString("hh:mm tt");
                    //}
                    //if (item.CheckOutFrom != null)
                    //{
                    //    dt = new DateTime() + (TimeSpan)item.CheckOutFrom;
                    //    hotel.CheckOutFrom = dt.ToString("hh:mm tt");
                    //}
                    if (item.CheckOutTo != null)
                    {
                        dt = new DateTime() + (TimeSpan)item.CheckOutTo;
                        hotel.CheckOutTo = dt.ToString("hh:mm tt");
                    }
                }

                if (!(hotel.ContactDetails.AsEnumerable().Where(id => id.ContactId == item.ContactId).Count() > 0))
                {

                    ContactDetailsViewModel contacts = new ContactDetailsViewModel
                    {
                        ContactId = item.ContactId,
                        IsPrimary = item.IsPrimary,
                        ContactPerson = item.ContactPerson,
                        DesignationId = item.DesignationId,
                        EmailAddress = item.ContactEmailAddress,
                        ContactNumber = item.ContactNumber
                    };

                    hotel.ContactDetails.Add(contacts);
                }

                if (!(hotel.TaxDetails.AsEnumerable().Where(id => id.TaxTypeId == item.TaxTypeId && id.TaxApplicabilityId == item.TaxApplicabilityId).Count() > 0))
                {

                    HotelTaxRelationViewModel tax = new HotelTaxRelationViewModel
                    {
                        TaxTypeId = item.TaxTypeId,
                        TaxesType = item.TaxesType,
                        TaxApplicabilityId = item.TaxApplicabilityId,
#pragma warning disable CA1305 // Specify IFormatProvider
                        Amount = Convert.ToDecimal(item.TaxAmount),
#pragma warning restore CA1305 // Specify IFormatProvider
                        IsIncludedInRates = item.IsIncludedInRates
                    };

                    hotel.TaxDetails.Add(tax);
                }
                HotelPaymentMethodRelationViewModel payment = new HotelPaymentMethodRelationViewModel()
                {
                    HotelPaymentMethodRelationId = item.HotelPaymentMethodRelationId,
                    PaymentMethodId = item.PaymentMethodId,
                    CurrencyId = item.CurrencyId,
                    RateTypeId = item.RateTypeId
                };
                hotel.HotelPaymentMethodRelation = payment;
            }

            return hotel;
        }

        /// <summary>
        /// Map Hotels Without Brands
        /// </summary>
        /// <param name="hotelResult"></param>
        /// <returns>HotelList</returns>
        public static BaseResult<List<HotelView>> MapHotelsWithoutBrands(BaseResult<List<HotelView>> hotelResult)
        {
            BaseResult<List<HotelView>> hotelViewModelList = new BaseResult<List<HotelView>>();
            List<HotelView> modelList = new List<HotelView>();
            List<int> lst = new List<int>();
            foreach (var item in hotelResult.Result)
            {
                if (item.HotelBrandId == null && item.IsActive)
                {
                    if (modelList.Where(x => x.Id == item.HotelId).Count() == 0)
                    {
                        modelList.Add(item);
                    }
                }
            }

            hotelViewModelList.Result = modelList;
            return hotelViewModelList;
        }
    }
}
