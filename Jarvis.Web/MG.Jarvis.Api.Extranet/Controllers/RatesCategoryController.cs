using MG.Jarvis.Api.Extranet.Attributes;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.RatesCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Controllers
{

    public class RatesCategoryController : BaseController
    {
        IRatesCategory iRatesCategory;
        public RatesCategoryController(IRatesCategory iRatesCategory)
        {
            this.iRatesCategory = iRatesCategory;
        }

        /// <summary>
        /// Return the list of Markets
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetMarkets()
        {
            BaseResult<List<MarketViewModel>> marketResultFromCache = new BaseResult<List<MarketViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<MarketViewModel>>(Constants.CacheKeys.MarketList)
            };

            if (marketResultFromCache.Result == null || marketResultFromCache.Result.Count == 0)
            {
                BaseResult<List<Market>> marketResult = await iRatesCategory.GetMarkets().ConfigureAwait(false);

                if (marketResult.IsError && marketResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (marketResult.Result == null || marketResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = RatesCategoryResponseMapper.MapMarket(marketResult);
                    RedisCacheHelper.Instance.Set<List<MarketViewModel>>(Constants.CacheKeys.MarketList, result.Result);
                    return Ok(result); //200
                }
            }
            return Ok(marketResultFromCache); //200
        }
        /// <summary>
        /// get the list of rate categories
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> GetRateCategory([FromBody]int hotelId)
        {
            if (hotelId <= default(int))
            {
                return BadRequest();
            }
            BaseResult<List<RateCategoryList>> rateCategoryResult = new BaseResult<List<RateCategoryList>>();
            rateCategoryResult = await iRatesCategory.GetRateCategory(hotelId);
            if (rateCategoryResult.IsError && rateCategoryResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (!rateCategoryResult.Result.Any())
            {
                return NoContent(); //204
            }
            var responseResult = RatesCategoryResponseMapper.MapRateCategoryList(rateCategoryResult.Result);
            return Ok(responseResult);
        }

        /// <summary>
        /// Get rate category by Id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetRateCategoryById([FromBody]int rateCategoryId)
        {
            BaseResult<RateCategoryViewModel> rateCategoryViewModelResult = new BaseResult<RateCategoryViewModel>();
            BaseResult<List<RateCategory>> rateCategoryResult = new BaseResult<List<RateCategory>>();
            BaseResult<List<RatePlans>> ratePlansResult = new BaseResult<List<RatePlans>>();
            RateCategory rateCategoryRequest = new RateCategory();

            if (rateCategoryId <= default(int))
            {
                rateCategoryResult.IsError = true;
                rateCategoryResult.Message = string.Format(coreHelper.Constants.ErrorMessage.InvalidId, rateCategoryId);
                return BadRequest(rateCategoryResult);
            }

            rateCategoryResult = await iRatesCategory.GetRateCategoryById(rateCategoryId).ConfigureAwait(false);
            if (rateCategoryResult.IsError && rateCategoryResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (rateCategoryResult.Result == null)
            {
                return new NoContentResult(); //204
            }

            ratePlansResult = await iRatesCategory.GetRatePlansById(rateCategoryId).ConfigureAwait(false);
            if (ratePlansResult.IsError && ratePlansResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }

            rateCategoryRequest = rateCategoryResult.Result.First();

            var result = RatesCategoryResponseMapper.MapToRateCategoryViewModel(rateCategoryRequest, ratePlansResult.Result);
            rateCategoryViewModelResult.Result = result;
            return Ok(rateCategoryViewModelResult);
        }

        /// <summary>
        /// Add/Update Rate Category
        /// </summary>
        /// <param name="rateCategoryViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRateCategory([FromBody]RateCategoryViewModel rateCategoryViewModel)
        {
            string userName = base.LoggedInUserName;
            BaseResult<RateCategory> rateCategoryResult = new BaseResult<RateCategory>();
            if (rateCategoryViewModel == null)
            {
                rateCategoryResult.IsError = true;
                rateCategoryResult.Message = string.Format(coreHelper.Constants.ErrorMessage.EmptyModel);
                return BadRequest(rateCategoryResult);
            }

            rateCategoryResult = await iRatesCategory.SaveAndUpdateRateCategory(rateCategoryViewModel, userName).ConfigureAwait(false);

            if (rateCategoryResult.IsError && rateCategoryResult.ExceptionMessage != null)
            {
                return StatusCode(500, rateCategoryResult);
            }
            else if (rateCategoryResult.Result == null)
            {
                return new NoContentResult();
            }
            return Ok(rateCategoryResult);
        }
    }
}