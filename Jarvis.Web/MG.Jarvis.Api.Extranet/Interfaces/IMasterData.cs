using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IMasterData
    {
        Task<BaseResult<List<HotelType>>> GetHotelTypes();
        Task<BaseResult<List<HotelBrand>>> GetHotelBrands();
        Task<BaseResult<List<HotelChain>>> GetHotelChains();
        Task<BaseResult<List<Continent>>> GetContinents();
        Task<BaseResult<List<Country>>> GetCountries();
        Task<BaseResult<List<City>>> GetCities();
        Task<BaseResult<List<City>>> GetCity(int countryId);
        Task<BaseResult<List<StarRating>>> GetStarRating();
    }
}
