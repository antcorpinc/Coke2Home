using AutoMapper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Hotel;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public class MealPlanRequestMapper
    {
        /// <summary>
        ///  Return the mapped HotelMeal and HotelMealType model
        /// </summary>
        /// <param name="hotelAssociateMealPlanViewModel"></param>
        /// <returns></returns>
        public static void MapHotelMealAndHotelMealType(ref HotelMeal hotelMeal, ref List<HotelMealType> hotelMealTypeList, MealPlanViewModel mealPlanViewModel, string userName)
        {
            hotelMeal = new HotelMeal();
            hotelMeal.HotelId = mealPlanViewModel.HotelId;
            hotelMeal.MealId = mealPlanViewModel.MealId;
            hotelMeal.Code = "Meal_" + hotelMeal.HotelId + "_" + hotelMeal.MealId;
            hotelMeal.Price = mealPlanViewModel.MealPlanOptions.Price;
            hotelMeal.CurrencyId = (mealPlanViewModel.MealPlanOptions.CurrencyId==null)? 0: mealPlanViewModel.MealPlanOptions.CurrencyId.Value;
            hotelMeal.CreatedBy = userName;
            hotelMeal.UpdatedBy = userName;
            if (mealPlanViewModel.IsSelected)
            {
                hotelMeal.IsDeleted = false;
            }
            else
            {
                hotelMeal.IsDeleted = true;
            }
            hotelMealTypeList = new List<HotelMealType>();
            foreach (var cuisine in mealPlanViewModel.MealPlanOptions.CuisineOptions)
            {
                HotelMealType model = new HotelMealType();
                model.HotelId = mealPlanViewModel.HotelId;
                model.MealId = mealPlanViewModel.MealId;
                model.CuisineTypeId = cuisine.Id;
                model.Code = "MealType_" + hotelMeal.HotelId + "_" + hotelMeal.MealId + "_" + model.CuisineTypeId;
                model.Name = cuisine.Cusine;
                model.NameItemId = 1;
                model.CreatedBy = userName;
                model.UpdatedBy = userName;
                model.IsActive = true;

                if (cuisine.IsSelected)
                {
                    model.IsDeleted = false;
                }
                else
                {
                    model.IsDeleted = true;
                }
                hotelMealTypeList.Add(model);
            }
        }

        /// <summary>
        /// Maps view model of hotelmeal to hotelmeal model
        /// </summary>
        /// <param name="hotelMealToMap"></param>
        /// <param name="hotelMealDatabase"></param>
        /// <param name="userName"></param>
        /// <returns>Message</returns>
        public static HotelMeal AutoMapperHotelMeal(HotelMeal hotelMealToMap, HotelMeal hotelMealDatabase, string userName)
        {
            var hotelMealMapped = AutoMapper.Mapper.Map<HotelMeal>(hotelMealToMap);
            ResolveRemainingParamtersHotelMeal(hotelMealMapped, hotelMealDatabase, userName);
            return hotelMealMapped;
        }

        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamtersHotelMeal(HotelMeal destination, HotelMeal source, string userName)
        {
            destination.Id = source.Id;
            destination.CreatedBy = source.CreatedBy;
            destination.UpdatedBy = userName;
        }

        /// <summary>
        /// Maps view model of hotelmealtype to hotelmealtype model
        /// </summary>
        /// <param name="hotelMealTypeToMap"></param>
        /// <param name="hotelMealTypeDatabase"></param>
        /// <param name="userName"></param>
        /// <returns>Message</returns>
        public static HotelMealType AutoMapperHotelMealType(HotelMealType hotelMealTypeToMap, HotelMealType hotelMealTypeDatabase, string userName)
        {
            var hotelMealTypeMapped = AutoMapper.Mapper.Map<HotelMealType>(hotelMealTypeToMap);
            ResolveRemainingParamtersOfHotelMealType(hotelMealTypeMapped, hotelMealTypeDatabase, userName);
            return hotelMealTypeMapped;
        }

        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamtersOfHotelMealType(HotelMealType destination, HotelMealType source, string userName)
        {
            destination.Id = source.Id;
            destination.CreatedBy = source.CreatedBy;
            destination.UpdatedBy = userName;
        }
    }

    public class HotelMealIdResolver : IValueResolver<HotelMeal, HotelMeal, int>
    {
        public int Resolve(HotelMeal source, HotelMeal destination, int destMember, ResolutionContext context)
        {
            return source.Id;
        }
    }

    public class HotelMealTypeIdResolver : IValueResolver<HotelMealType, HotelMealType, int>
    {
        public int Resolve(HotelMealType source, HotelMealType destination, int destMember, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
