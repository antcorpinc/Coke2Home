using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IRoom
    {
        Task<BaseResult<List<RoomType>>> GetRoomType();
        Task<BaseResult<List<Room>>> GetRoomsByHotelId(int hotelId);
        Task<BaseResult<List<SmokingPolicy>>> GetSmokingPolicy();
        Task<BaseResult<List<Bed>>> GetBed();
        Task<BaseResult<List<SizeMeasure>>> GetSizeMeasure();
        Task<BaseResult<List<OccupancyViewModel>>> GetOccupancy();
        Task<BaseResult<List<Room>>> SaveAndUpdateRoom(HotelRoomTypeViewModel request,string userName);
        Task<BaseResult<RoomBedRelation>> SaveAndUpdateRoomBedRelation(HotelRoomTypeViewModel request, int hotelRoomId, string userName);
        Task<BaseResult<HotelRoomTypeViewModel>> GetRoomDetailsByRoomId(int roomId);
        Task<BaseResult<bool>> DeleteRoomBedRelationById(int Id, string userName);
        Task<BaseResult<bool>> DeleteRoomById(int Id, string userName);

    }
}
