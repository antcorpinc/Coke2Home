using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class MealPlanRepository : IMealPlan
    {
        #region private variables
        private IConnection<Meals> iMealsConnectionLibrary;
        private IConnection<CuisineType> iCuisineTypeConnectionLibrary;
        private IConnection<HotelMeal> iHotelMealConnectionLibrary;
        private IConnection<HotelMealType> iHotelMealTypeConnectionLibrary;
        #endregion private variables

        public MealPlanRepository(IConnection<Meals> iMealsConnectionLibrary, IConnection<CuisineType> iCuisineTypeConnectionLibrary,
            IConnection<HotelMeal> iHotelMealConnectionLibrary, IConnection<HotelMealType> iHotelMealTypeConnectionLibrary)
        {

            this.iMealsConnectionLibrary = iMealsConnectionLibrary;
            this.iCuisineTypeConnectionLibrary = iCuisineTypeConnectionLibrary;
            this.iHotelMealConnectionLibrary = iHotelMealConnectionLibrary;
            this.iHotelMealTypeConnectionLibrary = iHotelMealTypeConnectionLibrary;
        }

        /// <summary>
        /// Retrun all Meals
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<Meals>>> GetMeals()
        {
            return await iMealsConnectionLibrary.GetListByPredicate(id => id.IsActive).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrun all HotelMeal
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<HotelMeal>>> GetHotelMeal(int hotelId)
        {
            return await iHotelMealConnectionLibrary.GetListByPredicate(id => id.HotelId == hotelId && !id.IsDeleted).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrun all HotelMealType
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<HotelMealType>>> GetHotelMealType(int hotelId)
        {
            return await iHotelMealTypeConnectionLibrary.GetListByPredicate(id => id.HotelId == hotelId && id.IsActive && !id.IsDeleted).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrun all CuisineTypes
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<CuisineType>>> GetCuisineType()
        {
            return await iCuisineTypeConnectionLibrary.GetListByPredicate(id => id.IsActive && !id.IsDeleted).ConfigureAwait(false);
        }

        /// <summary>
        /// Add/Update HotelMeal and HotelMealType
        /// </summary>
        /// <param name="mealPlanViewModelList"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<BaseResult<HotelMealType>> SaveAndUpdateHotelMealAndMealType(List<MealPlanViewModel> mealPlanViewModelList, string userName)
        {
            BaseResult<HotelMealType> result = new BaseResult<HotelMealType>();
            result.Result = new HotelMealType();
            HotelMeal hotelMealRequest = null;
            List<HotelMealType> hotelMealTypeRequest = null;
            foreach (var mealplan in mealPlanViewModelList)
            {
                MealPlanRequestMapper.MapHotelMealAndHotelMealType(ref hotelMealRequest, ref hotelMealTypeRequest, mealplan, userName);

                //To Add/Update HotelMeal
                if (mealplan.ObjectState == ObjectState.Added)
                {
                    var insertResult = await iHotelMealConnectionLibrary.InsertEntity(hotelMealRequest).ConfigureAwait(false);
                    if (insertResult.IsError || insertResult.ExceptionMessage != null)
                    {
                        result.IsError = true;
                        result.ExceptionMessage = insertResult.ExceptionMessage;
                        return result;
                    }

                }
                else if (mealplan.ObjectState == ObjectState.Modified || mealplan.ObjectState == ObjectState.Deleted || mealplan.MealPlanOptions.ObjectState == ObjectState.Modified)
                {
                    var hotelMealResult = await iHotelMealConnectionLibrary.GetListByPredicate(id => id.HotelId == hotelMealRequest.HotelId && id.MealId == hotelMealRequest.MealId && !id.IsDeleted).ConfigureAwait(false);
                    if (hotelMealResult.Result.Count > 0 && hotelMealResult != null)
                    {
                        var updatedHotelMeal = MealPlanRequestMapper.AutoMapperHotelMeal(hotelMealRequest, hotelMealResult.Result[0], userName);

                        var updateResult = await iHotelMealConnectionLibrary.UpdateEntityByDapper(updatedHotelMeal).ConfigureAwait(false);
                        if (updateResult.IsError || updateResult.ExceptionMessage != null)
                        {
                            result.IsError = true;
                            result.ExceptionMessage = updateResult.ExceptionMessage;
                            return result;
                        }
                    }
                    else
                    {
                        result.IsError = true;
                        result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoHotelMealOfID;
                        result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoHotelMealOfID, hotelMealRequest.Id);
                        return result;
                    }
                }

                //To Add/Update HotelMealType
                if (hotelMealTypeRequest != null)
                {
                    foreach (var hotelMealType in hotelMealTypeRequest)
                    {
                        foreach (var cuisine in mealplan.MealPlanOptions.CuisineOptions)
                        {
                            if (hotelMealType.CuisineTypeId == cuisine.Id)
                            {
                                if (cuisine.ObjectState == ObjectState.Added)
                                {

                                    var insertResult = await iHotelMealTypeConnectionLibrary.InsertEntity(hotelMealType).ConfigureAwait(false);
                                    if (insertResult.IsError || insertResult.ExceptionMessage != null)
                                    {
                                        result.IsError = true;
                                        result.ExceptionMessage = insertResult.ExceptionMessage;
                                        return result;
                                    }

                                    result.Result.Id = (int)insertResult.Result;

                                }
                                else if (cuisine.ObjectState == ObjectState.Deleted)
                                {
                                    var hotelMealTypeResult = await iHotelMealTypeConnectionLibrary.GetListByPredicate(x => x.CuisineTypeId == hotelMealType.CuisineTypeId && x.MealId == hotelMealType.MealId && x.HotelId == hotelMealType.HotelId && x.IsActive && !x.IsDeleted).ConfigureAwait(false);
                                    if (hotelMealTypeResult.Result.Count > 0 && hotelMealTypeResult != null)
                                    {
                                        var updatedHotelMealType = MealPlanRequestMapper.AutoMapperHotelMealType(hotelMealType, hotelMealTypeResult.Result[0], userName);

                                        var updateResult = await iHotelMealTypeConnectionLibrary.UpdateEntityByDapper(hotelMealType).ConfigureAwait(false);
                                        if (updateResult.IsError || updateResult.ExceptionMessage != null)
                                        {
                                            result.IsError = true;
                                            result.ExceptionMessage = updateResult.ExceptionMessage;
                                            return result;
                                        }
                                        else if (updateResult.Result)
                                        {
                                            result.Result.Id = hotelMealType.Id;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

    }
}
