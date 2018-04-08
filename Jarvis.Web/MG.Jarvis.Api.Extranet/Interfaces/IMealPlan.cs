using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IMealPlan
    {
        Task<BaseResult<List<Meals>>> GetMeals();
        Task<BaseResult<List<CuisineType>>> GetCuisineType();
        Task<BaseResult<List<HotelMeal>>> GetHotelMeal(int hotelId);
        Task<BaseResult<List<HotelMealType>>> GetHotelMealType(int hotelId);
        Task<BaseResult<HotelMealType>> SaveAndUpdateHotelMealAndMealType(List<MealPlanViewModel> mealPlanViewModelList, string userName);
    }
}
