using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class MealPlanController : BaseController
    {
        IMealPlan iMealPlan;
        public MealPlanController(IMealPlan iMealPlan)
        {
            this.iMealPlan = iMealPlan;
        }

        /// <summary>
        /// Return the list of Meals
        /// </summary>
        /// <returns>MealList</returns>
        public async Task<IActionResult> GetMeals()
        {
            BaseResult<List<MealsViewModel>> mealResultFromCache = new BaseResult<List<MealsViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<MealsViewModel>>(Constants.CacheKeys.MealList)
            };

            if (mealResultFromCache.Result == null || mealResultFromCache.Result.Count == 0)
            {
                BaseResult<List<Meals>> mealResult = await iMealPlan.GetMeals().ConfigureAwait(false);

                if (mealResult.IsError && mealResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (mealResult.Result == null || mealResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = MealPlanResponseMapper.MapMeal(mealResult);
                    RedisCacheHelper.Instance.Set<List<MealsViewModel>>(Constants.CacheKeys.MealList, result.Result);
                    return Ok(result); //200
                }
            }
            return Ok(mealResultFromCache); //200
        }

        /// <summary>
        /// Return the list of CuisineType
        /// </summary>
        /// <returns>CuisineTypeList</returns>
        public async Task<IActionResult> GetCuisineType()
        {
            BaseResult<List<CuisineTypeViewModel>> cuisineTypeResultFromCache = new BaseResult<List<CuisineTypeViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<CuisineTypeViewModel>>(Constants.CacheKeys.CuisineTypeList)
            };

            if (cuisineTypeResultFromCache.Result == null || cuisineTypeResultFromCache.Result.Count == 0)
            {
                BaseResult<List<CuisineType>> cuisineTypeResult = await iMealPlan.GetCuisineType().ConfigureAwait(false);

                if (cuisineTypeResult.IsError && cuisineTypeResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (cuisineTypeResult.Result == null || cuisineTypeResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = MealPlanResponseMapper.MapCuisineType(cuisineTypeResult);
                    RedisCacheHelper.Instance.Set<List<CuisineTypeViewModel>>(Constants.CacheKeys.CuisineTypeList, result.Result);
                    return Ok(result); //200
                }
            }
            return Ok(cuisineTypeResultFromCache); //200
        }

        /// <summary>
        /// Get API to check if meal polan exist
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetIsMealPlanExist([FromBody]int hotelId)
        {
            if (hotelId > default(int))
            {
                BaseResult<bool> isMealPlanExist = new BaseResult<bool>();

                BaseResult<List<HotelMeal>> hotelMealResult = await iMealPlan.GetHotelMeal(hotelId).ConfigureAwait(false);
                if (hotelMealResult.IsError && hotelMealResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (hotelMealResult.Result == null || hotelMealResult.Result.Count == 0)
                {
                    return Ok(isMealPlanExist); //204
                }

                isMealPlanExist.Result = true;
                return Ok(isMealPlanExist); //200
            }
            return BadRequest();//400
        }


        /// <summary>
        /// Get API for MealPlan
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetMealPlan([FromBody]int hotelId)
        {
            if (hotelId > default(int))
            {
                BaseResult<List<HotelMeal>> hotelMealResult = await iMealPlan.GetHotelMeal(hotelId).ConfigureAwait(false);
                if (hotelMealResult.IsError && hotelMealResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (hotelMealResult.Result == null || hotelMealResult.Result.Count == 0)
                {
                    return NoContent();//204
                }
                BaseResult<List<HotelMealType>> hotelMealTypeResult = await iMealPlan.GetHotelMealType(hotelId).ConfigureAwait(false);
                if (hotelMealTypeResult.IsError && hotelMealTypeResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }

                var result = MealPlanResponseMapper.MapMealPlan(hotelMealResult, hotelMealTypeResult);
                return Ok(result); //200
            }
            return BadRequest();//400
        }

        /// <summary>
        /// POST API to Create Meal Plan
        /// </summary>
        /// <param name="mealPlanViewModelList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMealPlan([FromBody] List<MealPlanViewModel> mealPlanViewModelList)
        {
            string userName = base.LoggedInUserName;

            if (mealPlanViewModelList != null && mealPlanViewModelList.Any())
            {
                BaseResult<HotelMealType> addOrUpdateHotelMealResult = await iMealPlan.SaveAndUpdateHotelMealAndMealType(mealPlanViewModelList, userName).ConfigureAwait(false);
                if (addOrUpdateHotelMealResult.IsError && addOrUpdateHotelMealResult.ExceptionMessage != null)
                {
                    return StatusCode(500, addOrUpdateHotelMealResult);
                }
                else if (addOrUpdateHotelMealResult.Result == null)
                {
                    return new NoContentResult();
                }

                return Ok(mealPlanViewModelList); //200
            }
            return BadRequest();//400
        }
    }
}