using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class HotelRepository : IHotels
    {

        #region Private Variables
        private IConnection<Hotel> iConnectionLibrary;
        private IConnection<HotelView> iHotelView;
        private IConnection<Contacts> iContact;
        private IConnection<EmailReservation> iEmailReservation;
        private IConnection<TelephoneReservation> iTelephoneReservation;
        private IConnection<HotelPaymentMethodRelation> iHotelPaymentMethodRelation;
        private IConnection<HotelTaxRelation> iHotelTaxRelation;
        private IConnection<ProfileCompletenessAggregateModel> iProfileCompletenessLibrary;

        //   TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Constants.JakartaTimeZone);
        #endregion Private Variables

        #region public variables

        #endregion public variables

        public HotelRepository(IConnection<Hotel> iConnectionLibrary, IConnection<Contacts> iContacts, IConnection<EmailReservation> iEmailReservations,
            IConnection<TelephoneReservation> iTelephoneReservations, IConnection<HotelPaymentMethodRelation> iHotelPaymentMethodRelation, IConnection<HotelTaxRelation> iHotelTaxRelation,
            IConnection<ProfileCompletenessAggregateModel> iProfileCompletenessLibrary,
            IConnection<HotelView> iHotelView)
        {
            this.iConnectionLibrary = iConnectionLibrary;
            this.iContact = iContacts;
            this.iEmailReservation = iEmailReservations;
            this.iTelephoneReservation = iTelephoneReservations;
            this.iHotelPaymentMethodRelation = iHotelPaymentMethodRelation;
            this.iHotelTaxRelation = iHotelTaxRelation;
            this.iProfileCompletenessLibrary = iProfileCompletenessLibrary;
            this.iHotelView = iHotelView;
        }

        /// <summary>
        /// Create Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task<BaseResult<List<Hotel>>> CreateHotel(HotelDetailsViewModel hotel, string LoggedInUserName)
        {
            BaseResult<List<Hotel>> result = new BaseResult<List<Hotel>>();
            //   TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Constants.JakartaTimeZone);

            //// Add hotel Details
            var param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.Name, hotel.HotelName);
            param.Add(Constants.StoredProcedureParameters.CityId, hotel.CityId);
            param.Add(Constants.StoredProcedureParameters.Longitude, hotel.Longitude);
            param.Add(Constants.StoredProcedureParameters.Latitude, hotel.Latitude);
            param.Add(Constants.StoredProcedureParameters.StarRating, hotel.StarRatingId);
            param.Add(Constants.StoredProcedureParameters.IsActive, hotel.IsActive);
            param.Add(Constants.StoredProcedureParameters.HotelBrandId, hotel.HotelBrandId);
            param.Add(Constants.StoredProcedureParameters.ShortDescription, hotel.ShortDescription);
            param.Add(Constants.StoredProcedureParameters.LongDescription, hotel.LongDescription);
            param.Add(Constants.StoredProcedureParameters.CreatedBy, LoggedInUserName);
            param.Add(Constants.StoredProcedureParameters.CreatedDate, DateTime.Now.JakartaOffset());
            param.Add(Constants.StoredProcedureParameters.UpdatedBy, LoggedInUserName);
            param.Add(Constants.StoredProcedureParameters.UpdatedDate, DateTime.Now.JakartaOffset());
            param.Add(Constants.StoredProcedureParameters.Website, hotel.Website);
            param.Add(Constants.StoredProcedureParameters.HotelTypeId, hotel.HotelTypeId);
            param.Add(Constants.StoredProcedureParameters.IsExtranetAccess, hotel.IsExtranetAccess);
            param.Add(Constants.StoredProcedureParameters.IsChannelManagerConnectivity, hotel.IsChannelManagerConnectivity);
            if (hotel.ChannelManagerId == 0)
            {
                hotel.ChannelManagerId = null;
            }
            param.Add(Constants.StoredProcedureParameters.ChannelManagerId, hotel.ChannelManagerId);
            param.Add(Constants.StoredProcedureParameters.CountryId, hotel.CountryId);
            param.Add(Constants.StoredProcedureParameters.Address1, hotel.Address1);
            param.Add(Constants.StoredProcedureParameters.Address2, hotel.Address2);
            param.Add(Constants.StoredProcedureParameters.ZipCode, hotel.ZipCode);
            param.Add(Constants.StoredProcedureParameters.MGPoints, hotel.MGPoint);

            if (!string.IsNullOrEmpty(hotel.CheckInFrom))
            {
                bool res = DateTime.TryParse(hotel.CheckInFrom, out DateTime dt);
                if (res)
                {
                    param.Add(Constants.StoredProcedureParameters.CheckInFrom, dt.TimeOfDay);
                }
            }

            //if (!string.IsNullOrEmpty(hotel.CheckInTo))
            //{
            //    bool res = DateTime.TryParse(hotel.CheckInTo, out DateTime dt);
            //    if (res)
            //    {
            //        param.Add(Constants.StoredProcedureParameters.CheckInTo, dt.TimeOfDay);
            //    }
            //}
            //else
            //{
            //    param.Add(Constants.StoredProcedureParameters.CheckInTo, null);
            //}
            //if (!string.IsNullOrEmpty(hotel.CheckOutFrom))
            //{
            //    bool res = DateTime.TryParse(hotel.CheckOutFrom, out DateTime dt);
            //    if (res)
            //    {
            //        param.Add(Constants.StoredProcedureParameters.CheckOutFrom, dt.TimeOfDay);
            //    }
            //}
            //else
            //{
            //    param.Add(Constants.StoredProcedureParameters.CheckOutFrom, null);
            //}
            if (!string.IsNullOrEmpty(hotel.CheckOutTo))
            {
                bool res = DateTime.TryParse(hotel.CheckOutTo, out DateTime dt);
                if (res)
                {
                    param.Add(Constants.StoredProcedureParameters.CheckOutTo, dt.TimeOfDay);
                }
            }
            else
            {
                param.Add(Constants.StoredProcedureParameters.CheckOutTo, null);
            }

            result = await iConnectionLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.AddHotel, param).ConfigureAwait(false);
            if (result.IsError)
            {
                return result;
            }
            return result;
        }

        /// <summary>
        /// Create contacts
        /// </summary>
        /// <param name="contactVm"></param>
        /// <param name="loggedInUserName"></param>
        /// <returns></returns>
        public Task<BaseResult<long>> CreateContacts(ContactDetailsViewModel contactVm, string loggedInUserName)
        {
            Contacts contact = new Contacts
            {
                HotelId = contactVm.HotelId,
                ContactPerson = contactVm.ContactPerson,
                DesignationId = contactVm.DesignationId,
                EmailAddress = contactVm.EmailAddress,
                IsPrimary = contactVm.IsPrimary,
                ContactNumber = contactVm.ContactNumber,
                CreatedBy = loggedInUserName,
                CreatedDate = DateTime.Now.JakartaOffset(),
                UpdatedBy = loggedInUserName,
                UpdatedDate = DateTime.Now.JakartaOffset(),
            };
            return iContact.InsertEntity(contact);
        }
        /// <summary>
        /// create reservation emails
        /// </summary>
        /// <param name="hotelVm"></param>
        /// <param name="editMode"></param>
        /// <returns></returns>
        public async Task<BaseResult<long>> CreateAndUpdateReservationEmail(HotelDetailsViewModel hotelVm, bool editMode)
        {
            if (hotelVm.ReservationEmail == null)
            {
                return null;
            }
            List<string> lstEmail = hotelVm.ReservationEmail.Split(",").ToList();
            List<EmailReservation> lstEmailReservations = new List<EmailReservation>();
            if (editMode)
            {
                var param = new DynamicParameters();
                param.Add(Constants.StoredProcedureParameters.HotelId, hotelVm.HotelId);
                await iHotelTaxRelation.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.UpdateReservationEmail, param).ConfigureAwait(false);
                foreach (var item in lstEmail)
                {
                    EmailReservation email = new EmailReservation
                    {
                        HotelId = hotelVm.HotelId,
                        Email = item
                    };
                    lstEmailReservations.Add(email);
                }

                return await iEmailReservation.InsertEntityList(lstEmailReservations).ConfigureAwait(false);
            }
            else
            {
                foreach (var item in lstEmail)
                {
                    EmailReservation email = new EmailReservation
                    {
                        HotelId = hotelVm.HotelId,
                        Email = item
                    };

                    lstEmailReservations.Add(email);
                }
                return await iEmailReservation.InsertEntityList(lstEmailReservations).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// create reservation telephone
        /// </summary>
        /// <param name="hotelVm"></param>
        /// <param name="editMode"></param>
        /// <returns></returns>
        public async Task<BaseResult<long>> CreateAndUpdateReservationTelephone(HotelDetailsViewModel hotelVm, bool editMode)
        {
            if (hotelVm.ReservationContactNo == null)
            {
                return null;
            }
            List<string> lstTelephoneNumbers = hotelVm.ReservationContactNo.Split(",").ToList();
            List<TelephoneReservation> lstTelephoneReservations = new List<TelephoneReservation>();
            if (editMode)
            {
                var param = new DynamicParameters();
                param.Add(Constants.StoredProcedureParameters.HotelId, hotelVm.HotelId);
                await iHotelTaxRelation.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.UpdateReservationTelephone, param).ConfigureAwait(false);
                foreach (var item in lstTelephoneNumbers)
                {
                    TelephoneReservation telephone = new TelephoneReservation
                    {
                        HotelId = hotelVm.HotelId,
                        Telephone = item
                    };
                    lstTelephoneReservations.Add(telephone);
                }
                return await iTelephoneReservation.InsertEntityList(lstTelephoneReservations).ConfigureAwait(false);
            }
            else
            {
                foreach (var item in lstTelephoneNumbers)
                {
                    TelephoneReservation telephone = new TelephoneReservation
                    {
                        HotelId = hotelVm.HotelId,
                        Telephone = item
                    };
                    lstTelephoneReservations.Add(telephone);
                }
                return await iTelephoneReservation.InsertEntityList(lstTelephoneReservations).ConfigureAwait(false);
            }

        }
        /// <summary>
        /// create payment
        /// </summary>
        /// <param name="paymentVm"></param>
        /// <returns></returns>
        public Task<BaseResult<long>> CreateHotelPaymentMethodRelation(HotelPaymentMethodRelationViewModel paymentVm)
        {
            HotelPaymentMethodRelation payment = new HotelPaymentMethodRelation
            {
                HotelId = paymentVm.HotelId,
                PaymentMethodId = paymentVm.PaymentMethodId,
                CurrencyId = paymentVm.CurrencyId,
                RateTypeId = paymentVm.RateTypeId
            };
            return iHotelPaymentMethodRelation.InsertEntity(payment);
        }
        /// <summary>
        /// create hotel tax
        /// </summary>
        /// <param name="taxVm"></param>
        /// <returns></returns>
        public Task<BaseResult<long>> CreateHotelTaxRelation(HotelTaxRelationViewModel taxVm)
        {
            HotelTaxRelation tax = new HotelTaxRelation
            {
                HotelId = taxVm.HotelId,
                TaxTypeId = taxVm.TaxTypeId,
                TaxApplicabilityId = taxVm.TaxApplicabilityId,
                Amount = taxVm.Amount,
                IsIncludedInRates = taxVm.IsIncludedInRates
            };

            return iHotelTaxRelation.InsertEntity(tax);
        }
        /// <summary>
        /// create and update hotel info
        /// </summary>
        /// <param name="hotelVm"></param>
        /// <param name="LoggedInUserName"></param>
        /// <returns></returns>
        public async Task<BaseResult<List<Hotel>>> SaveAndUpdateHotelInfo(HotelDetailsViewModel hotelVm, string LoggedInUserName)
        {
            BaseResult<List<Hotel>> resultHotel = new BaseResult<List<Hotel>>();
            resultHotel.Result = new List<Hotel>();
            Hotel hotel = new Hotel() { Id = hotelVm.HotelId };
            BaseResult<long> result = new BaseResult<long>();

            #region hotel operations

            hotel = await UpdateHotel(hotelVm, LoggedInUserName, resultHotel, hotel).ConfigureAwait(false);
            #endregion hotel operations

            #region contacts operations

            await UpdateContacts(hotelVm, LoggedInUserName, resultHotel, hotel).ConfigureAwait(false);
            #endregion contacts operations

            #region tax details
            await UpdateTaxDetails(hotelVm, resultHotel, hotel).ConfigureAwait(false);
            #endregion tax details

            #region payment method relation
            await UpdatePaymentMethodRelation(hotelVm, resultHotel, hotel).ConfigureAwait(false);

            #endregion payment method relation

            resultHotel.Result.Add(hotel);
            return resultHotel;

        }

        /// <summary>
        /// update payment method relation
        /// </summary>
        /// <param name="hotelVm"></param>
        /// <param name="resultHotel"></param>
        /// <param name="hotel"></param>
        /// <returns></returns>
        private async Task UpdatePaymentMethodRelation(HotelDetailsViewModel hotelVm, BaseResult<List<Hotel>> resultHotel, Hotel hotel)
        {
            var paymentDbList = iHotelPaymentMethodRelation.GetList().Result.Result;
            if (hotelVm.HotelPaymentMethodRelation.ObjectState == ObjectState.Added)
            {
                hotelVm.HotelPaymentMethodRelation.HotelId = hotel.Id;
                await this.CreateHotelPaymentMethodRelation(hotelVm.HotelPaymentMethodRelation).ConfigureAwait(false);
                resultHotel.Result.Add(hotel);
            }
            else if (hotelVm.HotelPaymentMethodRelation.ObjectState == ObjectState.Modified)
            {
                var paymentDb = paymentDbList.Where(p => p.Id == hotelVm.HotelPaymentMethodRelation.HotelPaymentMethodRelationId).FirstOrDefault();
                paymentDb.HotelId = hotel.Id;
                HotelPaymentMethodRelation payment = DbMapperMasterdata.AutomapperPaymentMethodRelation(hotelVm.HotelPaymentMethodRelation, paymentDb);
                await iHotelPaymentMethodRelation.UpdateEntityByDapper(payment).ConfigureAwait(false);
                resultHotel.Result.Add(hotel);
            }
        }

        /// <summary>
        /// Update tax details
        /// </summary>
        /// <param name="hotelVm"></param>
        /// <param name="resultHotel"></param>
        /// <param name="hotel"></param>
        /// <returns></returns>
        private async Task UpdateTaxDetails(HotelDetailsViewModel hotelVm, BaseResult<List<Hotel>> resultHotel, Hotel hotel)
        {
            foreach (var item in hotelVm.TaxDetails)
            {
                if (item.ObjectState == ObjectState.Added)
                {
                    item.HotelId = hotel.Id;
                    await this.CreateHotelTaxRelation(item).ConfigureAwait(false);
                    resultHotel.Result.Add(hotel);
                }
                else if (item.ObjectState == ObjectState.Modified)
                {
                    var param = new DynamicParameters();
                    param.Add(Constants.StoredProcedureParameters.HotelId, hotelVm.HotelId);
                    param.Add(Constants.StoredProcedureParameters.TaxTypeId, item.TaxTypeId);
                    param.Add(Constants.StoredProcedureParameters.TaxApplicabilityId, item.TaxApplicabilityId);
                    param.Add(Constants.StoredProcedureParameters.Amount, item.Amount);
                    param.Add(Constants.StoredProcedureParameters.IsIncludedInRates, item.IsIncludedInRates);
                    param.Add(Constants.StoredProcedureParameters.IsDeleted, item.IsDeleted);
                    await iHotelTaxRelation.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.SaveUpdateHotelTaxRelation, param).ConfigureAwait(false);
                    resultHotel.Result.Add(hotel);
                }
            }
        }

        /// <summary>
        /// update hotel
        /// </summary>
        /// <param name="hotelVm"></param>
        /// <param name="LoggedInUserName"></param>
        /// <param name="resultHotel"></param>
        /// <param name="hotel"></param>
        /// <returns></returns>
        private async Task<Hotel> UpdateHotel(HotelDetailsViewModel hotelVm, string LoggedInUserName, BaseResult<List<Hotel>> resultHotel, Hotel hotel)
        {
            var hotelDb = iConnectionLibrary.GetList().Result.Result.Where(p => p.Id == hotelVm.HotelId).FirstOrDefault();
            if (hotelVm.ObjectState == ObjectState.Added)
            {
                var res = await this.CreateHotel(hotelVm, LoggedInUserName).ConfigureAwait(false);
                hotelVm.HotelId = res.Result[0].Id;

                await this.CreateAndUpdateReservationEmail(hotelVm, false).ConfigureAwait(false);
                resultHotel.Result.Add(hotel);

                await this.CreateAndUpdateReservationTelephone(hotelVm, false).ConfigureAwait(false);
                resultHotel.Result.Add(hotel);

                hotel.Id = res.Result[0].Id;
            }
            else if (hotelVm.ObjectState == ObjectState.Modified)
            {
                hotel = DbMapperMasterdata.AutomapperHotel(hotelVm, hotelDb, LoggedInUserName);
                await iConnectionLibrary.UpdateEntityByDapper(hotel as Hotel).ConfigureAwait(false);

                await this.CreateAndUpdateReservationEmail(hotelVm, true).ConfigureAwait(false);
                resultHotel.Result.Add(hotel);

                await this.CreateAndUpdateReservationTelephone(hotelVm, true).ConfigureAwait(false);
                resultHotel.Result.Add(hotel);

                resultHotel.Result.Add(hotel);
            }

            return hotel;
        }

        /// <summary>
        /// update contacts
        /// </summary>
        /// <param name="hotelVm"></param>
        /// <param name="LoggedInUserName"></param>
        /// <param name="resultHotel"></param>
        /// <param name="hotel"></param>
        /// <returns></returns>
        private async Task UpdateContacts(HotelDetailsViewModel hotelVm, string LoggedInUserName, BaseResult<List<Hotel>> resultHotel, Hotel hotel)
        {
            var contactDbList = iContact.GetListByPredicate(x => x.HotelId == hotelVm.HotelId).Result.Result;
            foreach (var item in hotelVm.ContactDetails)
            {
                if (item.ObjectState == ObjectState.Added)
                {
                    item.HotelId = hotel.Id;
                    await this.CreateContacts(item, LoggedInUserName).ConfigureAwait(false);
                    resultHotel.Result.Add(hotel);
                }
                else if (item.ObjectState == ObjectState.Modified)
                {
                    var contactDb = contactDbList.Where(p => p.Id == item.ContactId).FirstOrDefault();
                    contactDb.HotelId = hotelVm.HotelId;
                    Contacts contact = DbMapperMasterdata.AutomapperContacts(item, contactDb, LoggedInUserName);
                    await iContact.UpdateEntity(contact).ConfigureAwait(false);
                    resultHotel.Result.Add(hotel);
                }
            }
        }

        public Task<BaseResult<List<HotelView>>> GetHotel(int Id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@HotelId", Id);
            // param.ParameterNames();
            return iHotelView.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelDetails, param);
        }

        public Task<BaseResult<List<HotelView>>> GetAllHotels()
        {
            var parameters = new DynamicParameters();
            return iHotelView.ExecuteStoredProcedure(Constants.StoredProcedure.GetAllHotels, parameters);
        }

        public async Task<BaseResult<bool>> IsHotelValid(string hotelId)
        {
            BaseResult<bool> response = new BaseResult<bool>();
            BaseResult<List<Hotel>> hotelList = await iConnectionLibrary.GetListByPredicate(h => h.Code == hotelId);
            if (hotelList == null && hotelList.Result == null || !hotelList.Result.Any())
            {
                response.Result = false;
                return response;
            }
            return response;
        }

        public async Task<BaseResult<bool>> IsHotelActive(string hotelId)
        {
            BaseResult<bool> response = new BaseResult<bool>();
            BaseResult<List<Hotel>> hotelList = await iConnectionLibrary.GetListByPredicate(h => h.Code == hotelId && h.IsActive == true);
            if (hotelList == null && hotelList.Result == null || !hotelList.Result.Any())
            {
                response.Result = false;
                return response;
            }
            return response;
        }

        public async Task<BaseResult<List<ProfileCompletenessAggregateModel>>> GetProfileCompleteness(int hotelId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HotelId", hotelId);
            return await iProfileCompletenessLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetProfileCompletenessByHotelID, parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Hotels
        /// </summary>
        /// <returns>Hotel Names Listing</returns>
        public async Task<BaseResult<List<HotelView>>> GetHotels()
        {
            return await iHotelView.GetList().ConfigureAwait(false);
        }

        /// <summary>
        /// Get Hotels
        /// </summary>
        /// <returns>Hotel Names Listing</returns>
        public async Task<BaseResult<List<HotelView>>> GetAllHotelsByCityId(string cityCode, int languageId = 1)
        {
            var parameters = HotelManagementRequestMapper.CreateGetHotelsByCityRequest(cityCode, languageId);
            return await iHotelView.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelsByCityId, parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a particular hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="userName"></param>
        /// <returns> Task<BaseResult<bool>> </returns>
        public async Task<BaseResult<bool>> DeleteHotelByHotelId(int hotelId, string userName)
        {
            BaseResult<bool> result = new BaseResult<bool> { Result = false };
            var model = await iConnectionLibrary.GetListByPredicate(x => x.Id == hotelId && !x.IsDeleted).ConfigureAwait(false);
            if (model.IsError || model.ExceptionMessage != null)
            {
                result.IsError = model.IsError;
                result.ExceptionMessage = model.ExceptionMessage;
                return result;
            }
            if (model.Result.Any() && model.Result[0] != null)
            {
                model.Result[0].IsDeleted = true;
                model.Result[0].UpdatedBy = userName;
                model.Result[0].UpdatedDate = DateTime.Now.JakartaOffset();
                result = await iConnectionLibrary.UpdateEntityByDapper(model.Result[0]).ConfigureAwait(false);
                return result;
            }
            result.IsError = true;
            result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.HotelNotFound;
            result.Message = string.Format(coreHelper.Constants.ErrorMessage.HotelNotFound, hotelId);
            return result;
        }

        /// <summary>
        /// Get All Hotels Info for XML Services
        /// </summary>
        /// <returns>Hotels Info</returns>
        public Task<BaseResult<List<HotelView>>> GetAllHotelsInfo(string HotelCode)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.HotelCode, HotelCode);
            var result = iHotelView.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelDetailsDataForXMLServices, param);
            return result;
        }

        /// <summary>
        /// Get All Hotel By BrandId
        /// </summary>
        /// <param name="Collection of BrandId"></param>
        /// <returns>All Hotel</returns>
        public Task<BaseResult<List<HotelView>>> GetAllHotelsByBrandId(List<int> BrandId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.HotelBrandId, string.Join(",", BrandId));
            var result = iHotelView.ExecuteStoredProcedure(Constants.StoredProcedure.GetAllHotelByBrandId, param);
            return result;
        }
    }
}
