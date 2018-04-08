using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IHotels
    {
        Task<BaseResult<List<HotelView>>> GetHotel(int Id);
        Task<BaseResult<List<Hotel>>> CreateHotel(HotelDetailsViewModel hotel, string LoggedInUserName);
        Task<BaseResult<List<HotelView>>> GetAllHotels();
        Task<BaseResult<List<HotelView>>> GetAllHotelsByCityId(string cityCode , int languageId = 1);
        Task<BaseResult<bool>> IsHotelValid(string hotelId);
        Task<BaseResult<bool>> IsHotelActive(string hotelId);
        Task<BaseResult<List<ProfileCompletenessAggregateModel>>> GetProfileCompleteness(int hotelId);
        Task<BaseResult<List<HotelView>>> GetHotels();
        Task<BaseResult<List<Hotel>>> SaveAndUpdateHotelInfo(HotelDetailsViewModel hotelVm, string LoggedInUserName);
        Task<BaseResult<bool>> DeleteHotelByHotelId(int hotelId, string userName);
        Task<BaseResult<List<HotelView>>> GetAllHotelsByBrandId(List<int> BrandId);
    }
}
