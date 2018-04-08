using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class MasterDataController : BaseController
    {
        IMasterData iMasterData;
        static BaseResult<List<ContinentViewModel>> continentResultFromCache = null;

        public MasterDataController(IMasterData iMasterData)
        {
            this.iMasterData = iMasterData;
            if(continentResultFromCache == null || continentResultFromCache.Result.Count <= 0)
            {
                this.GetContinents().ConfigureAwait(false);
            }
        }

        #region API's of hoteldata

        /// <summary>
        /// Return the Types of hotel
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetHotelTypes()
        {
            BaseResult<List<HotelTypeViewModel>> hotelTypeResultFromCache = new BaseResult<List<HotelTypeViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<HotelTypeViewModel>>(Constants.CacheKeys.HotelTypeList)
            };

            if (hotelTypeResultFromCache.Result == null || hotelTypeResultFromCache.Result.Count == 0)
            {
                BaseResult<List<HotelType>> hotelTypeResult = await iMasterData.GetHotelTypes().ConfigureAwait(false);

                if (hotelTypeResult.IsError && hotelTypeResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (hotelTypeResult.Result == null || hotelTypeResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var hotelTypeResultAll = DbMapperMasterdata.MapHotelTypes(hotelTypeResult);
                    RedisCacheHelper.Instance.Set<List<HotelTypeViewModel>>(Constants.CacheKeys.HotelTypeList, hotelTypeResultAll.Result);
                    return Ok(hotelTypeResultAll); //200
                }
            }
            return Ok(hotelTypeResultFromCache); //200
        }

        /// <summary>
        /// Return the hotel chains
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetHotelChains()
        {
            BaseResult<List<HotelChainViewModel>> hotelChainResultFromCache = new BaseResult<List<HotelChainViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<HotelChainViewModel>>(Constants.CacheKeys.HotelChainList)
            };
            if (hotelChainResultFromCache.Result == null || hotelChainResultFromCache.Result.Count == 0)
            {
                BaseResult<List<HotelChain>> hotelChainResult = await iMasterData.GetHotelChains().ConfigureAwait(false);

                if (hotelChainResult.IsError && hotelChainResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (hotelChainResult.Result == null || hotelChainResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var hotelChainResultAll = DbMapperMasterdata.MapHotelChains(hotelChainResult);
                    RedisCacheHelper.Instance.Set<List<HotelChainViewModel>>(Constants.CacheKeys.HotelChainList, hotelChainResultAll.Result);
                    return Ok(hotelChainResultAll); //200
                }
            }
            return Ok(hotelChainResultFromCache); //200
        }

        /// <summary>
        /// Return the hotel brands
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetHotelBrands(int id)
        {
            BaseResult<List<HotelBrandViewModel>> hotelBrandResult = new BaseResult<List<HotelBrandViewModel>>();
            if (id < 1)
            {
                hotelBrandResult.Message = Constants.BadRequestErrorMessage.InvalidChainRequest;
                return BadRequest(hotelBrandResult);
            }
            var cacheData = RedisCacheHelper.Instance.Get<List<HotelBrandViewModel>>(Constants.CacheKeys.HotelBrandList);

            if (cacheData != null && cacheData.Any())
            {
                hotelBrandResult.Result = cacheData;
            }
            else
            {
                BaseResult<List<HotelBrand>> HotelBrandResultData = await iMasterData.GetHotelBrands().ConfigureAwait(false);

                if (HotelBrandResultData.IsError && HotelBrandResultData.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (HotelBrandResultData.Result == null || HotelBrandResultData.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {   // mapping model to viewmodel
                    List<HotelBrandViewModel> hotelBrandListAll = DbMapperMasterdata.MapAllHotelBrands(HotelBrandResultData);
                    hotelBrandResult.Result = hotelBrandListAll;
                    RedisCacheHelper.Instance.Set<List<HotelBrandViewModel>>(Constants.CacheKeys.HotelBrandList, hotelBrandListAll, false);
                }
            }
            hotelBrandResult.Result = hotelBrandResult.Result.Where(p => p.HotelChainId == id).ToList();
            return Ok(hotelBrandResult); //200
        }



        #endregion API's of hoteldata

        #region API's of masterdata

        /// <summary>
        /// Return the List of Countries
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task<IActionResult> GetCountries()
        {
            BaseResult<List<CountryViewModel>> countryResultFromCache = new BaseResult<List<CountryViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<CountryViewModel>>(Constants.CacheKeys.CountryList)
            };

            if (countryResultFromCache.Result == null || countryResultFromCache.Result.Count == 0)
            {
                BaseResult<List<Country>> countryResult = await iMasterData.GetCountries().ConfigureAwait(false);

                if (countryResult.IsError && countryResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (countryResult.Result == null || countryResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var countryListVm = DbMapperMasterdata.MapCountry(countryResult, continentResultFromCache);
                    RedisCacheHelper.Instance.Set<List<CountryViewModel>>(Constants.CacheKeys.CountryList, countryListVm.Result);
                    return Ok(countryListVm); //200
                }
            }
            return Ok(countryResultFromCache); //200
        }

        public async Task<IActionResult> GetContinents()
        {
            continentResultFromCache = new BaseResult<List<ContinentViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<ContinentViewModel>>(Constants.CacheKeys.ContinentList)
            };

            if (continentResultFromCache.Result == null || continentResultFromCache.Result.Count == 0)
            {
                BaseResult<List<Continent>> continentResult = await iMasterData.GetContinents().ConfigureAwait(false);

                if (continentResult.IsError && continentResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (continentResult.Result == null || continentResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var continentListVm = DbMapperMasterdata.MapContinent(continentResult);
                    RedisCacheHelper.Instance.Set<List<ContinentViewModel>>(Constants.CacheKeys.ContinentList, continentListVm.Result);
                    return Ok(continentListVm); //200
                }
            }
            return Ok(continentResultFromCache); //200
        }

        /// <summary>
        /// Return the List of Cities
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetCities(int id)
        {
            BaseResult<List<CityViewModel>> cityResult = new BaseResult<List<CityViewModel>>();
            if (id < 1)
            {
                cityResult.Message = Constants.BadRequestErrorMessage.InvalidCountyRequest;
                return BadRequest(cityResult);
            }

            var cacheData = RedisCacheHelper.Instance.Get<List<CityViewModel>>(Constants.CacheKeys.CityList);

            if (cacheData != null && cacheData.Any())
            {
                cityResult.Result = cacheData;
            }
            else
            {
                BaseResult<List<City>> cityResultData = await iMasterData.GetCities().ConfigureAwait(false);

                if (cityResultData.IsError && cityResultData.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (cityResultData.Result == null || cityResultData.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {   // mapping model to viewmodel
                    List<CityViewModel> cityListAll = DbMapperMasterdata.MapAllCity(cityResultData);
                    cityResult.Result = cityListAll;
                    RedisCacheHelper.Instance.Set<List<CityViewModel>>(Constants.CacheKeys.CityList, cityListAll, false);
                }
            }
            cityResult.Result = cityResult.Result.Where(p => p.CountryId == id).ToList();
            return Ok(cityResult); //200
        }

        /// <summary>
        /// Get star ratings master data
        /// </summary>
        /// <returns>Star rating master data</returns>
        public async Task<IActionResult> GetStarRating()
        {
            BaseResult<List<StarRatingViewModel>> starRatingResultFromCache = new BaseResult<List<StarRatingViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<StarRatingViewModel>>(Constants.CacheKeys.StarRatingList)
            };

            if (starRatingResultFromCache.Result == null || starRatingResultFromCache.Result.Count == 0)
            {
                BaseResult<List<StarRating>> starRatingResult = await iMasterData.GetStarRating().ConfigureAwait(false);
                if (starRatingResult.IsError && starRatingResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (starRatingResult.Result == null || starRatingResult.Result.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    var result = DbMapperMasterdata.MapStarRating(starRatingResult);
                    RedisCacheHelper.Instance.Set<List<StarRatingViewModel>>(Constants.CacheKeys.StarRatingList, result.Result);
                    return Ok(result);
                }
            }

            return Ok(starRatingResultFromCache);
        }


        #endregion API's of masterdata

        #region backgrounJob
        //public async Task<ActionResult> ActivateUser(string userId= null)
        //{
        //    BaseResult<bool> activateUserList = await iMasterData.ActivateUser(userId);
        //    return Ok(activateUserList);

        //}
        #endregion backgrounJob



    }
}