using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class MasterDataRepository : IMasterData
    {
        #region Private Variables

        private IConnection<Continent> iContinentLibrary;
        private IConnection<Country> iCountryLibrary;
        private IConnection<City> iCityLibrary;
        private IConnection<HotelType> iHotelTypeLibrary;
        private IConnection<HotelChain> iHotelChainLibrary;
        private IConnection<HotelBrand> iHotelBrandLibrary;
        private IConnection<StarRating> iStarRatingLibrary;
        #endregion Private Variables

        #region public variables

        #endregion public variables

        public MasterDataRepository(
                                    IConnection<HotelType> iHotelTypeLibrary,
                                    IConnection<City> iCityLibrary,
                                    IConnection<Country> iCountryLibrary,
                                    IConnection<HotelBrand> iHotelBrandLibrary,
                                    IConnection<HotelChain> iHotelChainLibrary,
                                    IConnection<StarRating> iStarRatingLibrary,
                                    IConnection<Continent> iContinentLibrary
                                    )
        {
            this.iHotelTypeLibrary = iHotelTypeLibrary;
            this.iHotelBrandLibrary = iHotelBrandLibrary;
            this.iHotelChainLibrary = iHotelChainLibrary;
            this.iContinentLibrary = iContinentLibrary;
            this.iCityLibrary = iCityLibrary;
            this.iCountryLibrary = iCountryLibrary;
            this.iStarRatingLibrary = iStarRatingLibrary;
        }

        /// <summary>
        /// Returns all cities / cities by countryId
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<City>>> GetCities()
        {
            return  await iCityLibrary.GetListByPredicate(p=>p.IsDeleted==false && p.IsActive==true).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns all countries
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<Country>>> GetCountries()
        {
            return await iCountryLibrary.GetListByPredicate(p=>p.IsActive==true && p.IsDeleted==false).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns all hotel chains
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<HotelChain>>> GetHotelChains()
        {
            return await iHotelChainLibrary.GetListByPredicate(p => p.IsDeleted == false).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns all hotel brands / hotel brands by hotelChainId
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<HotelBrand>>> GetHotelBrands()
        {
            return await iHotelBrandLibrary.GetListByPredicate(p=>p.IsDeleted==false).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns all hotel types
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<HotelType>>> GetHotelTypes()
        {
            return await iHotelTypeLibrary.GetListByPredicate(p=>p.IsActive==true && p.IsDeleted==false).ConfigureAwait(false);
        }



        public async Task<BaseResult<List<City>>> GetCity(int countryId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CountryId", countryId);
            // param.ParameterNames();
            return await iCityLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetCity, param).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Star rating information for Hotel
        /// </summary>
        /// <returns>Star Rating data</returns>
        public async Task<BaseResult<List<StarRating>>> GetStarRating()
        {
            return await iStarRatingLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }

        public async Task<BaseResult<List<Continent>>> GetContinents()
        {
            return await iContinentLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }

        //public async Task<BaseResult<IEnumerable<dynamic>>> GetCity(int Id)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@Id", Id);
        //    // param.ParameterNames();
        //    return await iCityLibrary.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.GetCity, param);
        //}


    }
}
