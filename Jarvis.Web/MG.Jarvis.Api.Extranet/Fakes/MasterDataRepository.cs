//using MG.Jarvis.Api.Extranet.Interfaces;
//using MG.Jarvis.Core.DAL.Interfaces;
//using MG.Jarvis.Core.Model;
//using MG.Jarvis.Core.Model.Hotel;
//using MG.Jarvis.Core.Model.MasterData;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace MG.Jarvis.Api.Extranet.Fakes
//{
//    public class MasterDataRepository : IMasterData
//    {
//        #region Private variables
//        // private IMasterDataDAL iMasterDAL;
//        //  private IConnection<IBaseModel> iMasterDAL;
//        private IConnection<Hotel> iConnectionLibrary;
//        private IConnection<Langauges> iConnectionLanguages;
//        private IConnection<RoomType> iRoomTypeLibrary;
//        private IConnection<HotelFacilityGroup> iHotelFacilityGroupLibrary;
//        private IConnection<HotelFacilityType> iHotelFacilityTypeLibrary;
//        private IConnection<HotelFacility> iHotelFacilityLibrary;
//        private IConnection<Currency> iCurrencyConnectionLibrary;
//        private IConnection<Market> iMarketConnectionLibrary;
//        private IConnection<Occupancy> iOccupancyConnectionLibrary;
//        private IConnection<Supplier> iSupplierConnectionLibrary;
//        private IConnection<PaymentMethod> iPaymentMethodLibrary;
//        private IConnection<RateType> iRateTypeLibrary;
//        private IConnection<TaxType> iTaxTypeLibrary;
//        private IConnection<TaxApplicability> iTaxApplicabilityLibrary;
//        private IConnection<Core.Model.MasterData.Designation> iDesignationLibrary;
//        #endregion Private Variables

//        #region Public Variables
//        #endregion Public Variables

//        public MasterDataRepository(IConnection<Hotel> iConnectionLibrary, IConnection<Currency> iCurrencyConnectionLibrary,
//           IConnection<Market> iMarketConnectionLibrary, IConnection<Occupancy> iOccupancyConnectionLibrary, 
//           IConnection<Supplier> iSupplierConnectionLibrary ,IConnection<RoomType> iRoomTypeLibrary, IConnection<Langauges> iConnectionLanguages,
//                                    IConnection<HotelFacilityGroup> iHotelFacilityGroupLibrary, IConnection<HotelFacilityType> iHotelFacilityTypeLibrary, 
//                                    IConnection<HotelFacility> iHotelFacilityLibrary, IConnection<PaymentMethod> iPaymentMethodLibrary,
//                                    IConnection<RateType> iRateTypeLibrary, IConnection<TaxType> iTaxTypeLibrary, IConnection<TaxApplicability> iTaxApplicabilityLibrary)
//        {
//            this.iConnectionLibrary = iConnectionLibrary;
//            this.iCurrencyConnectionLibrary = iCurrencyConnectionLibrary;
//            this.iMarketConnectionLibrary = iMarketConnectionLibrary;
//            this.iOccupancyConnectionLibrary = iOccupancyConnectionLibrary;
//            this.iSupplierConnectionLibrary = iSupplierConnectionLibrary;
//            this.iConnectionLanguages = iConnectionLanguages;
//            this.iRoomTypeLibrary = iRoomTypeLibrary;
//            this.iHotelFacilityGroupLibrary = iHotelFacilityGroupLibrary;
//            this.iHotelFacilityTypeLibrary = iHotelFacilityTypeLibrary;
//            this.iHotelFacilityLibrary = iHotelFacilityLibrary;
//            this.iPaymentMethodLibrary = iPaymentMethodLibrary;
//            this.iRateTypeLibrary = iRateTypeLibrary;
//            this.iTaxTypeLibrary = iTaxTypeLibrary;
//            this.iTaxApplicabilityLibrary = iTaxApplicabilityLibrary;
//            this.iDesignationLibrary = iDesignationLibrary;
//        }

//        public Task<BaseResult<List<City>>> GetCities()
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<BaseResult<List<Country>>> GetCountries()
//        {
//            throw new System.NotImplementedException();
//        }

//        public async Task<BaseResult<List<Currency>>> GetCurrency()
//        {
//            return await iCurrencyConnectionLibrary.GetList().ConfigureAwait(false);
//            //throw new System.NotImplementedException();
//        }

//        public async Task<BaseResult<List<Market>>> GetMarkets()
//        {
//            return await iMarketConnectionLibrary.GetList().ConfigureAwait(false);
//            //throw new System.NotImplementedException();
//        }

//        public async Task<BaseResult<List<Occupancy>>> GetOccupancy()
//        {
//            return await iOccupancyConnectionLibrary.GetList().ConfigureAwait(false);
//            //throw new System.NotImplementedException();
//        }

//        public async Task<BaseResult<List<Supplier>>> GetSupplier()
//        {
//            return await iSupplierConnectionLibrary.GetList().ConfigureAwait(false);
//            //throw new System.NotImplementedException();
//        }
//        public async Task<BaseResult<List<Core.DAL.Models.DapperModels.Hotel>>> GetHotelAndRoomsByDapper()
//        {
//            //return await iConnectionLibrary.GetHotelAndRoomsByDapper();
//            throw new System.NotImplementedException();
//        }

//        public Task<BaseResult<dynamic>> GetHotelAndRoomsByDapperCustomModel()
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<BaseResult<List<HotelBrand>>> GetHotelBrands()
//        {
//            throw new System.NotImplementedException();
//        }

//        public Task<BaseResult<List<HotelChain>>> GetHotelChains()
//        {
//            throw new System.NotImplementedException();
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<HotelType>>> GetHotelTypes()
//        {
//            //return  await iConnectionLibrary.GetHotelType();
//            throw new System.NotImplementedException();
//        }

//        public async Task<BaseResult<long>> InsertHotelAndRoomsByDapper()
//        {
//            throw new System.NotImplementedException();
//        }

//        /// <summary>
//        /// Return list of languages
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<Langauges>>> GetLanguages()
//        {
//            return await iConnectionLanguages.GetList().ConfigureAwait(false);
//        }
//        /// <summary>
//        /// Return List of Room types
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<RoomType>>> GetRoomType()
//        {
//            return await iRoomTypeLibrary.GetList().ConfigureAwait(false);
//        }
//        /// <summary>
//        /// Returns list of Hotel Facility Group list
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<HotelFacilityGroup>>> GeHotelFacilityGroup()
//        {
//            return await iHotelFacilityGroupLibrary.GetList().ConfigureAwait(false);
//        }
//        /// <summary>
//        /// Returns list of Hotel Facility type list
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<HotelFacilityType>>> GeHotelFacilityType()
//        {
//            return await iHotelFacilityTypeLibrary.GetList().ConfigureAwait(false);
//        }
//        /// <summary>
//        /// Returns list of Hotel Facility list
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<HotelFacility>>> GeHotelFacility()
//        {
//            return await iHotelFacilityLibrary.GetList().ConfigureAwait(false);
//        }

//        /// <summary>
//        ///  Return list of Payment methods
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<PaymentMethod>>> GetPaymentMethod()
//        {
//            return await iPaymentMethodLibrary.GetList().ConfigureAwait(false);
//        }
//        /// <summary>
//        /// Return list of Rate types
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<RateType>>> GetRateType()
//        {
//            return await iRateTypeLibrary.GetList().ConfigureAwait(false);
//        }

//        /// <summary>
//        /// Return list of Tax types
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<TaxType>>> GetTaxType()
//        {
//            return await iTaxTypeLibrary.GetList().ConfigureAwait(false);
//        }

//        /// <summary>
//        /// Return Tax applicability
//        /// </summary>
//        /// <returns></returns>
//        public async Task<BaseResult<List<TaxApplicability>>> GetTaxApplicability()
//        {
//            return await iTaxApplicabilityLibrary.GetList().ConfigureAwait(false);
//        }
//        public Task<BaseResult<List<Core.Model.MasterData.Designation>>> GetDesignation()
//        {
//            throw new System.NotImplementedException();
//        }

//        Task<BaseResult<List<Core.Model.MasterData.Designation>>> IMasterData.GetDesignation()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
