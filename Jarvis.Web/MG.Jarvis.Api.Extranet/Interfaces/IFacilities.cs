using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IFacilities
    {
        Task<BaseResult<List<HotelFacilityGroup>>> GeHotelFacilityGroup();
        Task<BaseResult<List<HotelFacilityType>>> GeHotelFacilityType();
        Task<BaseResult<List<HotelFacility>>> GeHotelFacility();
        Task<BaseResult<long>> InsertAndUpdateHotelFacilityRelation(HotelFacilityViewModel hotelFacilityViewModel, string userName);
        Task<BaseResult<List<HotelFacilityRelation>>> GetSelectedFacilities(int? hotelId);
        Task<BaseResult<bool>> IsHotelFacilityExits(int? hotelId);


    }
}
