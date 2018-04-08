using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IAmenities
    {
        Task<BaseResult<List<RoomFacilityGroup>>> GetRoomFacilityGroup();
        Task<BaseResult<List<RoomFacilityType>>> GetRoomFacilityType();
        Task<BaseResult<List<RoomFacility>>> GetRoomFacility();
        Task<BaseResult<List<RoomFacilityRelation>>> GetSelectedAmenities(int hotelId);
        Task<BaseResult<long>> InsertAndUpdateRoomFacilityRelation(RoomFacilityGroupListViewModel roomFacilityViewModel, string userName);
        Task<BaseResult<bool>> IsAmenitiesExits(int hotelId);

    }
}
