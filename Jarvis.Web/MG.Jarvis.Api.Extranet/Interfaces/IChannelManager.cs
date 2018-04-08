using MG.Jarvis.Api.Extranet.Models;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IChannelManager
    {
        //Task<BaseResult<bool>> IsHotelValid(string hotelId);
        //Task<BaseResult<bool>> IsHotelActive(string hotelId);

        Task<BaseResult<bool>> ValidateRoomTypeRatePlanRequest(RoomTypeByHotelAndChannelManger request);
        Task<BaseResult<List<RoomTypeRatePlanResponse>>> GetRoomTypesAndRatePlans(RoomTypeByHotelAndChannelManger request);
        Task<BaseResult<bool>> ValidateUpdateAllocationRequest(UpdateAllocationsValidationRequest request);
        Task<BaseResult<bool>> UpdateAllocations(UpdateAllocationsRequest request);
        Task<BaseResult<bool>> UpdateAllocationRates(UpdateAllocationRatesRequest request);
    }
}
