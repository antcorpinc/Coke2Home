using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using MG.Jarvis.Core.Model.Contracts;
using static MG.Jarvis.Api.Extranet.Helper.Enums;

namespace MG.Jarvis.Api.Extranet.Helper.Mapper
{
    public static class DbMapperMasterdata
    {
        /// <summary>
        ///  Return the mapped Cities viewmodel
        /// </summary>
        /// <param name="cityList"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public static BaseResult<List<CityViewModel>> MapCity(BaseResult<List<CityViewModel>> cityList, int countryId)
        {
            BaseResult<List<CityViewModel>> responseModelList = new BaseResult<List<CityViewModel>>();
            responseModelList.Result = cityList.Result.Where(p => p.CountryId == countryId).ToList();

            if (responseModelList.IsError)
            {
                responseModelList.Message = "Error in request";
            }
            return responseModelList;
        }

        /// <summary>
        /// Maps all cities to city viewmodel
        /// </summary>
        /// <param name="cityList"></param>
        /// <returns></returns>
        public static List<CityViewModel> MapAllCity(BaseResult<List<City>> cityList)
        {

            List<CityViewModel> modelList = new List<CityViewModel>();
            if (cityList.Result.Count() > 0)
            {
                foreach (var item in cityList.Result)
                {
                    CityViewModel city = new CityViewModel()
                    {
                        CityId = item.Id,
                        CityName = item.Name,
                        CountryId = item.CountryId
                    };
                    modelList.Add(city);
                }
            }
            return modelList;
        }

        /// <summary>
        /// Return the mapped Country viewmodel
        /// </summary>
        /// <param name="countryList"></param>
        /// <returns></returns>
        public static BaseResult<List<CountryViewModel>> MapCountry(BaseResult<List<Country>> countryList, BaseResult<List<ContinentViewModel>> continentResultFromCache)
        {
            BaseResult<List<CountryViewModel>> responseModelList = new BaseResult<List<CountryViewModel>>();
            List<CountryViewModel> modelList = new List<CountryViewModel>();
            Func<int, string> GetName = (x) => continentResultFromCache.Result.Where(p => p.ContinentId == x).FirstOrDefault().Name;
            foreach (var item in countryList.Result)
            {
                CountryViewModel model = new CountryViewModel
                {
                    CountryId = item.Id,
                    CountryName = item.Name,
                    ContinentId = item.ContinentId,
                    ContinentName = GetName(item.ContinentId)
                };
                modelList.Add(model);
            }
            responseModelList.Result = modelList;
            if (responseModelList.IsError)
            {
                responseModelList.Message = "Error in request";
            }
            return responseModelList;
        }

        /// <summary>
        /// Return the mapped Continent viewmodel
        /// </summary>
        /// <param name="continentList"></param>
        /// <returns></returns>
        public static BaseResult<List<ContinentViewModel>> MapContinent(BaseResult<List<Continent>> continentList)
        {
            BaseResult<List<ContinentViewModel>> responseModelList = new BaseResult<List<ContinentViewModel>>();
            List<ContinentViewModel> modelList = new List<ContinentViewModel>();
            foreach (var item in continentList.Result)
            {
                ContinentViewModel model = new ContinentViewModel
                {
                    ContinentId = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            responseModelList.Result = modelList;
            if (responseModelList.IsError)
            {
                responseModelList.Message = "Error in request";
            }
            return responseModelList;
        }

        /// <summary>
        ///  Return the mapped Occupancy viewmodel
        /// </summary>
        /// <param name="occupancyListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<OccupancyViewModel>> MapOccupancy()
        {         
            BaseResult<List<OccupancyViewModel>> occupancyViewModelList = new BaseResult<List<OccupancyViewModel>>();
            List<OccupancyViewModel> modelList = new List<OccupancyViewModel>();
            foreach (var item in Enum.GetValues(typeof(NumberOfGuest)))
            {
                OccupancyViewModel model = new OccupancyViewModel
                {         
                    OccupancyId=(int)item,
                    NoOfGuest = (int)item
                };
                modelList.Add(model);
            }
            occupancyViewModelList.Result = modelList;
            return occupancyViewModelList;
        }

        /// <summary>
        /// Return the mapped Supplier viewmodel
        /// </summary>
        /// <param name="suppliersListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<SupplierViewModel>> MapSupplier(BaseResult<List<Supplier>> suppliersListDetail)
        {
            BaseResult<List<SupplierViewModel>> supplierViewModelList = new BaseResult<List<SupplierViewModel>>();
            List<SupplierViewModel> modelList = new List<SupplierViewModel>();
            foreach (var item in suppliersListDetail.Result)
            {
                SupplierViewModel model = new SupplierViewModel
                {
                    Id = item.Id,
                    IsChannelManager = item.IsChannelManager
                };
                modelList.Add(model);
            }
            supplierViewModelList.Result = modelList;
            return supplierViewModelList;
        }

        /// <summary>
        /// Return the mapped Hotel Types viewmodel
        /// </summary>
        /// <param name="hotelList"></param>
        /// <returns></returns>
        public static BaseResult<List<HotelTypeViewModel>> MapHotelTypes(BaseResult<List<HotelType>> hotelList)
        {
            BaseResult<List<HotelTypeViewModel>> hotelTypeViewModelList = new BaseResult<List<HotelTypeViewModel>>();
            List<HotelTypeViewModel> modelList = new List<HotelTypeViewModel>();
            foreach (var item in hotelList.Result)
            {
                HotelTypeViewModel model = new HotelTypeViewModel
                {
                    HotelTypeId = item.Id,
                    HotelTypeName = item.Name
                };
                modelList.Add(model);
            }
            hotelTypeViewModelList.Result = modelList;
            return hotelTypeViewModelList;
        }

        /// <summary>
        /// Return the mapped HotelChains viewmodel
        /// </summary>
        /// <param name="hotelChainList"></param>
        /// <returns></returns>
        public static BaseResult<List<HotelChainViewModel>> MapHotelChains(BaseResult<List<HotelChain>> hotelChainList)
        {
            BaseResult<List<HotelChainViewModel>> responseModelList = new BaseResult<List<HotelChainViewModel>>();
            List<HotelChainViewModel> modelList = new List<HotelChainViewModel>();
            foreach (var item in hotelChainList.Result)
            {
                HotelChainViewModel model = new HotelChainViewModel
                {
                    HotelChainId = item.Id,
                    HotelChainName = item.Name
                };
                modelList.Add(model);
            }
            responseModelList.Result = modelList;
            if (responseModelList.IsError)
            {
                responseModelList.Message = "Error in request";
            }
            return responseModelList;
        }

        /// <summary>
        /// Return the mapped Hotel Brands viewmodel
        /// </summary>
        /// <param name="hotelBrandList"></param>
        /// <param name="chainId"></param>
        /// <returns></returns>
        public static BaseResult<List<HotelBrandViewModel>> MapHotelBrands(BaseResult<List<HotelBrandViewModel>> hotelBrandList, int chainId)
        {
            BaseResult<List<HotelBrandViewModel>> responseModelList = new BaseResult<List<HotelBrandViewModel>>();
            responseModelList.Result = hotelBrandList.Result.Where(p => p.HotelChainId == chainId).ToList();

            if (responseModelList.IsError)
            {
                responseModelList.Message = "Error in request";
            }
            return responseModelList;
        }

        public static List<HotelBrandViewModel> MapAllHotelBrands(BaseResult<List<HotelBrand>> hotelBrandList)
        {

            List<HotelBrandViewModel> hotelBrandListAll = new List<HotelBrandViewModel>();
            if (hotelBrandList.Result.Count > 0)
            {
                foreach (var item in hotelBrandList.Result)
                {
                    HotelBrandViewModel model = new HotelBrandViewModel
                    {
                        HotelBrandId = item.Id,
                        HotelBrandName = item.Name,
                        HotelChainId = item.HotelChainId
                    };
                    hotelBrandListAll.Add(model);
                }
            }
            return hotelBrandListAll;
        }

        //for GetAllHotels
        public static BaseResult<List<HotelBrandExtendedViewModel>> MapToHotelBrandExtendeViewModel(BaseResult<List<HotelView>> HotelList)
        {
            var othersBrandId = -1;
            var othersBrandName = string.Empty;
            var result = new List<HotelBrandExtendedViewModel>();
            foreach (var item in HotelList.Result)
            {
                if (item != null)
                {
                    int? brandId = item.HotelBrandId;
                    string brandName = item.HotelBrandName;
                    FillHotelsAndBrand(brandId, brandName, item, ref result);
                }
                else
                {
                    FillHotelsAndBrand(othersBrandId, othersBrandName, item, ref result);
                }

            }

            return new BaseResult<List<HotelBrandExtendedViewModel>>() { Result = result };
        }
        //for GetAllHotels
        private static void FillHotelsAndBrand(int? brandId, string brandName, HotelView hotelView, ref List<HotelBrandExtendedViewModel> hotelBrandlist)
        {
            var hotelBrand = hotelBrandlist.FirstOrDefault(x => x.HotelBrandId == brandId);
            if (hotelBrand == null)
            {
                hotelBrand = new HotelBrandExtendedViewModel
                {
                    //Hotels = new List<HotelDetailsExtendedViewModel>(),
                    HotelBrandId = brandId,
                    HotelBrandName = brandName
                };
                hotelBrandlist.Add(hotelBrand);
            }
            hotelBrand.Hotels.Add
            (
                new HotelDetailsExtendedViewModel()
                {
                    HotelId = hotelView.HotelId,
                    HotelName = hotelView.HotelName,
                    IsActive = hotelView.IsActive,
                    HotelCode = hotelView.HotelCode,
                    Location = hotelView.HotelLocation,
                    ContactPerson = hotelView.ContactPerson,
                    Email = hotelView.ContactEmailAddress,
                    ContactNumber = hotelView.ContactNumber,
                    HotelBrandId = hotelBrand.HotelBrandId
                }
            );
        }

        /// <summary>
        ///  Maps to Smoking Policy View Model
        /// </summary>
        /// <param name="smokingPolicyList"></param>
        /// <returns>List<SmokingPolicyViewModel></returns>
        public static BaseResult<List<SmokingPolicyViewModel>> MapSmokingPolicyList(BaseResult<List<SmokingPolicy>> smokingPolicyList)
        {
            BaseResult<List<SmokingPolicyViewModel>> smokingPolicyViewModelList = new BaseResult<List<SmokingPolicyViewModel>>();
            List<SmokingPolicyViewModel> modelList = new List<SmokingPolicyViewModel>();
            foreach (var item in smokingPolicyList.Result)
            {
                SmokingPolicyViewModel model = new SmokingPolicyViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            smokingPolicyViewModelList.Result = modelList;
            return smokingPolicyViewModelList;
        }

        /// <summary>
        ///  Maps to Size Measure View Model
        /// </summary>
        /// <param name="sizeMeasureList"></param>
        /// <returns>List<SizeMeasureViewModel></returns>
        public static BaseResult<List<SizeMeasureViewModel>> MapSizeMeasureList(BaseResult<List<SizeMeasure>> sizeMeasureList)
        {
            BaseResult<List<SizeMeasureViewModel>> sizeMeasureViewModelList = new BaseResult<List<SizeMeasureViewModel>>();
            List<SizeMeasureViewModel> modelList = new List<SizeMeasureViewModel>();
            foreach (var item in sizeMeasureList.Result)
            {
                SizeMeasureViewModel model = new SizeMeasureViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            sizeMeasureViewModelList.Result = modelList;
            return sizeMeasureViewModelList;
        }

        /// <summary>
        ///  Maps to Bed View Model
        /// </summary>
        /// <param name="bedList"></param>
        /// <returns>List<BedViewModel></returns>
        public static BaseResult<List<BedViewModel>> MapBedList(BaseResult<List<Bed>> bedList)
        {
            BaseResult<List<BedViewModel>> bedViewModelList = new BaseResult<List<BedViewModel>>();
            List<BedViewModel> modelList = new List<BedViewModel>();
            foreach (var item in bedList.Result)
            {
                BedViewModel model = new BedViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            bedViewModelList.Result = modelList;
            return bedViewModelList;
        }
        public static BaseResult<List<StarRatingViewModel>> MapStarRating(BaseResult<List<StarRating>> starRatingListDetail)
        {
            BaseResult<List<StarRatingViewModel>> starRatingModelList = new BaseResult<List<StarRatingViewModel>>();
            List<StarRatingViewModel> modelList = new List<StarRatingViewModel>();
            foreach (var item in starRatingListDetail.Result)
            {
                StarRatingViewModel model = new StarRatingViewModel
                {
                    HotelStarRatingId = item.Id,
                    HotelStarRatingName = item.Name
                };
                modelList.Add(model);
            }
            starRatingModelList.Result = modelList;
            return starRatingModelList;
        }
        public static void FillProfileCompletenessViewModel(ProfileCompletenessViewModel profileCompletenessViewModel, BaseResult<List<ProfileCompletenessAggregateModel>> profileCompletenessData)
        {
            foreach (var row in profileCompletenessData.Result)
            {
                profileCompletenessViewModel.Criteria.Add(new ProfileCompletenessDetailsViewModel
                {
                    Key = row.Key,
                    Value = row.Value,
                    ConfigurationId = row.ConfigurationId,
                    RedirectUrl = row.RedirectUrl,
                    RedirectUrlText = row.RedirectUrlText,
                    Description = row.Description,
                    IsFullfilled = row.IsFullfilled//true if criteria is fillfilled false if not
                });
            }
        }

        /// <summary>
        /// GET Hotel Name List
        /// </summary>
        /// <param name="hotelResult">hotelResult</param>
        /// <returns>Hotel Name List</returns>
        public static BaseResult<List<HotelNameViewModel>> MapHotels(BaseResult<List<HotelView>> hotelResult)
        {
            BaseResult<List<HotelNameViewModel>> hotelNameViewModelList = new BaseResult<List<HotelNameViewModel>>();
            List<HotelNameViewModel> modelList = new List<HotelNameViewModel>();

            hotelResult.Result = hotelResult.Result.Where(x => x.IsActive).ToList();

            foreach (var item in hotelResult.Result)
            {
                if (modelList.Where(x => x.Id == item.HotelId).Count() == 0 )
                {
                    HotelNameViewModel model = new HotelNameViewModel
                    {
                        Id = item.HotelId,
                        Name = item.HotelName
                    };
                    modelList.Add(model);
                }
            }
            hotelNameViewModelList.Result = modelList;
            return hotelNameViewModelList;
        }

        public static BaseResult<List<CancellationPolicyTypeViewModel>> MapCancellationPolicyType(BaseResult<List<CancellationPolicyType>> policyResult)
        {
            BaseResult<List<CancellationPolicyTypeViewModel>> policyViewModelList = new BaseResult<List<CancellationPolicyTypeViewModel>>();
            List<CancellationPolicyTypeViewModel> modelList = new List<CancellationPolicyTypeViewModel>();
            foreach (var item in policyResult.Result)
            {
                CancellationPolicyTypeViewModel model = new CancellationPolicyTypeViewModel
                {
                    CancellationPolicyTypeId = item.Id,
                    Name = item.Name
                };

                modelList.Add(model);

            }
            policyViewModelList.Result = modelList;
            return policyViewModelList;
        }

        public static BaseResult<List<CancellationChargesViewModel>> MapCancellationCharges(BaseResult<List<CancellationCharges>> chargesResult)
        {
            BaseResult<List<CancellationChargesViewModel>> policyViewModelList = new BaseResult<List<CancellationChargesViewModel>>();
            List<CancellationChargesViewModel> modelList = new List<CancellationChargesViewModel>();
            foreach (var item in chargesResult.Result)
            {
                CancellationChargesViewModel model = new CancellationChargesViewModel
                {
                    CancellationChargesId = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            policyViewModelList.Result = modelList;
            return policyViewModelList;
        }
        public static BaseResult<List<CancellationPolicyViewModel>> MapCancellationPolicy(BaseResult<List<CancellationPolicyViewModel>> chargesResult)
        {
            BaseResult<List<CancellationPolicyViewModel>> policyViewModelList = new BaseResult<List<CancellationPolicyViewModel>>();
            List<CancellationPolicyViewModel> modelList = new List<CancellationPolicyViewModel>();
            foreach (var item in chargesResult.Result)
            {
                CancellationPolicyViewModel model = new CancellationPolicyViewModel
                {
                    CancellationPolicyId = item.CancellationPolicyId,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            policyViewModelList.Result = modelList;
            return policyViewModelList;
        }

        #region hotel automapper

        /// <summary>
        /// hotel Automapper
        /// </summary>
        /// <param name="hotelViewModel"></param>
        /// <param name="hotelDatabase"></param>
        /// <returns>mapped hotel</returns>
        public static Hotel AutomapperHotel(HotelDetailsViewModel hotelViewModel, Hotel hotelDatabase, string LoggedInUserName)
        {
            var hotelMapped = AutoMapper.Mapper.Map<Hotel>(hotelViewModel);
            ResolveRemainingParamters(hotelMapped, hotelDatabase, LoggedInUserName);
            return hotelMapped;
        }
        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamters(Hotel destination, Hotel source, string LoggedInUserName)
        {
            destination.Landmark = source.Landmark;
            destination.LongDescriptionItemId = source.LongDescriptionItemId;
            destination.ShortDescriptionItemId = source.ShortDescriptionItemId;
            destination.NameItemId = source.NameItemId;
            destination.CreatedBy = source.CreatedBy;
            destination.UpdatedBy = LoggedInUserName;
        }

        #endregion hotel automapper


        #region hotel tax automapper
        /// <summary>
        /// taxes automapper
        /// </summary>
        /// <param name="taxViewModel"></param>
        /// <param name="taxDatabase"></param>
        /// <returns>mapped hoteltax</returns>
        public static HotelTaxRelation AutomapperTaxes(HotelTaxRelationViewModel taxViewModel, HotelTaxRelation taxDatabase)
        {
            var taxMapped = AutoMapper.Mapper.Map<HotelTaxRelation>(taxViewModel);
            ResolveRemainingParamters(taxMapped, taxDatabase);
            return taxMapped;
        }
        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamters(HotelTaxRelation destination, HotelTaxRelation source)
        {
            destination.HotelId = source.HotelId;
            destination.TaxApplicabilityId = source.TaxApplicabilityId;
        }

        #endregion  hotel tax automapper


        #region hotel payment automapper

        /// <summary>
        /// payment automapper
        /// </summary>
        /// <param name="paymentViewModel"></param>
        /// <param name="paymentDatabase"></param>
        /// <returns>mapped payment instance</returns>
        public static HotelPaymentMethodRelation AutomapperPaymentMethodRelation(HotelPaymentMethodRelationViewModel paymentViewModel, HotelPaymentMethodRelation paymentDatabase)
        {
            var paymentMapped = AutoMapper.Mapper.Map<HotelPaymentMethodRelation>(paymentViewModel);
            ResolveRemainingParamters(paymentMapped, paymentDatabase);
            return paymentMapped;
        }
        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamters(HotelPaymentMethodRelation destination, HotelPaymentMethodRelation source)
        {
            destination.HotelId = source.HotelId;
        }

        #endregion hotel payment automapper and resolver


        #region contact automapper
        /// <summary>
        /// contacts automapper
        /// </summary>
        /// <param name="contactVm"></param>
        /// <param name="contactDb"></param>
        /// <returns>mapped contact instance</returns>
        public static Contacts AutomapperContacts(ContactDetailsViewModel contactViewModel, Contacts contactDatabase, string LoggedInUserName)
        {
            var contactMapped = AutoMapper.Mapper.Map<Contacts>(contactViewModel);
            ResolveRemainingParamters(contactMapped, contactDatabase, LoggedInUserName);
            return contactMapped;
        }
        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamters(Contacts destination, Contacts source, string LoggedInUserName)
        {


            destination.HotelId = source.HotelId;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
            destination.UpdatedBy = LoggedInUserName;
            destination.UpdatedDate = DateTime.Now.JakartaOffset();
        }

        #endregion contact automapper

        #region cancellation policy

        public static CancellationPolicy AutomapperCancellationPolicy(CancellationPolicyViewModel viewModel, CancellationPolicy model)
        {
            var modelMapped = AutoMapper.Mapper.Map<CancellationPolicy>(viewModel);
            return modelMapped;
        }
        public static void ResolveRemainingParamters(CancellationPolicy destination, CancellationPolicy source)
        {
            destination.HotelId = source.HotelId;

        }
        public static CancellationPolicyClauses AutomapperCancellationPolicyClause(CancellationPolicyClausesViewModel viewModel, CancellationPolicyClauses model)
        {
            var modelMapped = AutoMapper.Mapper.Map<CancellationPolicyClauses>(viewModel);
            ResolveRemainingParamters(modelMapped, model);
            return modelMapped;
        }
        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamters(CancellationPolicyClauses destination, CancellationPolicyClauses source)
        {
            destination.CancellationPolicyId = source.CancellationPolicyId;
        }
        #endregion cancellation policy

        #region Contracts 

        public static ContractHotelProperties AutomapperContractHotelProperties(ContractHotelPropertiesViewModel viewModel,string loggedUserName)
        {
            var modelMapped = AutoMapper.Mapper.Map<ContractHotelProperties>(viewModel);
            modelMapped.CreatedBy = loggedUserName;
            modelMapped.UpdatedBy = loggedUserName;
            modelMapped.CreatedDate = DateTime.Now.JakartaOffset();
            modelMapped.UpdatedDate = DateTime.Now.JakartaOffset();
            return modelMapped;
        }

        public static Contract AutomapperContract(ContractStaticViewModel viewModel, Contract model, string loggedUserName)
        {
            var modelMapped = AutoMapper.Mapper.Map<Contract>(viewModel);
            modelMapped.CreatedBy = loggedUserName;
            modelMapped.UpdatedBy = loggedUserName;
            modelMapped.CreatedDate = DateTime.Now.JakartaOffset();
            modelMapped.UpdatedDate = DateTime.Now.JakartaOffset();
            ResolveRemainingParamters(modelMapped, model);
            return modelMapped;
        }

        public static ContractHotelViewModel AutoMapperContractHotelViewModel(
            ContractStaticViewModel contractStaticViewModel)
        {
            var mapped = AutoMapper.Mapper.Map<ContractHotelViewModel>(contractStaticViewModel);
            return mapped;
        }

        public static ContractHotel AutomapperContractHotel(HotelDetailsViewModel hotelDetailsViewModel, string loggedUser)
        {
            var mappedModel = AutoMapper.Mapper.Map<ContractHotel>(hotelDetailsViewModel);
            ResolveRemainingParamters(mappedModel, hotelDetailsViewModel, loggedUser);
            return mappedModel;
        }

        public static ContractContactViewModel AutomapperContractContactViewModel(ContactDetailsViewModel contactDetailsViewModel)
        {
            var mappedModel = AutoMapper.Mapper.Map<ContractContactViewModel>(contactDetailsViewModel);
            return mappedModel;
        }
        public static ContractContact AutomapperContractContact(ContractContactViewModel contractContactViewModel, string loggedUser)
        {
            var mappedModel = AutoMapper.Mapper.Map<ContractContact>(contractContactViewModel);
            ResolveRemainingParamters(mappedModel, contractContactViewModel, loggedUser);
            return mappedModel;
        }

        public static ContractHotelTaxRelation AutomapperContractHotelTaxRelation(ContractHotelTaxRelationViewModel contractHotelTaxRelationViewModel,string loggedUser)
        {
            var mappedModel = AutoMapper.Mapper.Map<ContractHotelTaxRelation>(contractHotelTaxRelationViewModel);
            ResolveRemainingParamters(mappedModel, contractHotelTaxRelationViewModel, loggedUser);
            return mappedModel;
        }
        public static void ResolveRemainingParamters(ContractHotelTaxRelation destination, ContractHotelTaxRelationViewModel source, string loggedUser)
        {
            destination.CreatedBy = loggedUser;
            destination.UpdatedBy = loggedUser;
            destination.CreatedDate = DateTime.Now.JakartaOffset();
            destination.UpdatedDate = DateTime.Now.JakartaOffset();
        }
        public static void ResolveRemainingParamters(ContractContact destination, ContractContactViewModel source, string loggedUser)
        {
            destination.CreatedBy = loggedUser;
            destination.UpdatedBy = loggedUser;
            destination.CreatedDate = DateTime.Now.JakartaOffset();
            destination.UpdatedDate = DateTime.Now.JakartaOffset();
        }
        public static void ResolveRemainingParamters(ContractHotel destination, HotelDetailsViewModel source, string loggedUser)
        {
            destination.Code = source.HotelCode;
            destination.Name = source.HotelName;
            destination.CreatedBy = loggedUser;
            destination.UpdatedBy = loggedUser;
            destination.CreatedDate = DateTime.Now.JakartaOffset();
            destination.UpdatedDate = DateTime.Now.JakartaOffset();
        }

        public static void ResolveRemainingParamters(Contract destination, Contract source)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Constants.JakartaTimeZone);
            destination.CreatedBy = "MGIT";
            destination.CreatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            destination.UpdatedBy = "MGIT";
            destination.UpdatedDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }


        #endregion
    }
}

