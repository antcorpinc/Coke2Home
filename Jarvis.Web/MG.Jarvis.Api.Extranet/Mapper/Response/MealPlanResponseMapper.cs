using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public class MealPlanResponseMapper
    {
        /// <summary>
        ///  Method to map selected meals to MealPlan viewmodel
        /// </summary>
        /// <param name="mealPlanListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<MealPlanViewModel>> MapMealPlan(BaseResult<List<HotelMeal>> hotelMealList, BaseResult<List<HotelMealType>> hotelMealTypeList)
        {
            BaseResult<List<MealPlanViewModel>> mealPlanViewModelList = new BaseResult<List<MealPlanViewModel>>();
            List<MealPlanViewModel> modelList = new List<MealPlanViewModel>();

            foreach (var hotelMealItem in hotelMealList.Result)
            {
                MealPlanViewModel model = new MealPlanViewModel
                {
                    HotelId = hotelMealItem.HotelId,
                    MealId = hotelMealItem.MealId,
                    IsSelected = true
                };
                model.MealPlanOptions = new MealOptionViewModel();
                model.MealPlanOptions.CurrencyId = hotelMealItem.CurrencyId;
                model.MealPlanOptions.Price = hotelMealItem.Price;

                foreach (var hotelMealTypeItem in hotelMealTypeList.Result)
                {
                    if (hotelMealTypeItem.MealId == hotelMealItem.MealId)    //Take Cusine list of related Meal only
                    {
                        CuisineTypeViewModel cuisineTypeViewModel = new CuisineTypeViewModel
                        {
                            Id = hotelMealTypeItem.CuisineTypeId,
                            IsSelected = true
                        };
                        model.MealPlanOptions.CuisineOptions.Add(cuisineTypeViewModel);
                    }
                }
                modelList.Add(model);
            }
            mealPlanViewModelList.Result = modelList;
            return mealPlanViewModelList;
        }

        /// <summary>
        ///  Return the mapped Meals viewmodel
        /// </summary>
        /// <param name="mealListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<MealsViewModel>> MapMeal(BaseResult<List<Meals>> mealListDetail)
        {
            BaseResult<List<MealsViewModel>> mealsViewModelList = new BaseResult<List<MealsViewModel>>();
            List<MealsViewModel> modelList = new List<MealsViewModel>();
            foreach (var item in mealListDetail.Result)
            {
                MealsViewModel model = new MealsViewModel
                {
                    Id = item.Id,
                    Meal = item.Meal
                };
                modelList.Add(model);
            }
            mealsViewModelList.Result = modelList;
            return mealsViewModelList;
        }

        /// <summary>
        ///  Return the mapped CuisineType viewmodel
        /// </summary>
        /// <param name="cuisineTypeListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<CuisineTypeViewModel>> MapCuisineType(BaseResult<List<CuisineType>> cuisineTypeListDetail)
        {
            BaseResult<List<CuisineTypeViewModel>> cuisineTypeViewModelList = new BaseResult<List<CuisineTypeViewModel>>();
            List<CuisineTypeViewModel> modelList = new List<CuisineTypeViewModel>();
            foreach (var item in cuisineTypeListDetail.Result)
            {
                CuisineTypeViewModel model = new CuisineTypeViewModel
                {
                    Id = item.Id,
                    Cusine = item.Cusine
                };
                modelList.Add(model);
            }
            cuisineTypeViewModelList.Result = modelList;
            return cuisineTypeViewModelList;
        }
    }
}
