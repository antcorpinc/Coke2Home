using Dapper;
using MG.Jarvis.Api.Extranet.Mapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;

using MG.Jarvis.Api.Extranet.Models;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Supplier;
using System.Collections.Generic;
using System.Threading.Tasks;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class ChannelManagerRepository : IChannelManager
    {
        #region Private Variables
        IConnection<ChannelManagerRequestValidationResponse> iConnection;
        IConnection<RoomTypesRatePlan> iRoomConnection;
        #endregion Private Varibales
        //public ChannelRepositories(IConnection<Hotel> ihotelConnection)
        //{
        //    this.ihotelConnection = ihotelConnection;
        //}
        public ChannelManagerRepository(IConnection<ChannelManagerRequestValidationResponse> iConnection, IConnection<RoomTypesRatePlan> iRoomConnection)
        {
            this.iConnection = iConnection;
            this.iRoomConnection = iRoomConnection;
        }
        //public async Task<BaseResult<bool>> IsHotelValid(string hotelId)
        //{
        //    BaseResult<bool> response = new BaseResult<bool>();

        //    BaseResult<List<Hotel>> hotelList = await this.ihotelConnection.GetListByPredicate(a => a.Code == hotelId);
        //    if (hotelList == null || hotelList.Result == null || !hotelList.Result.Any())
        //    {
        //        response.Result = false;
        //        return response;
        //    }
        //    return response;
        //}

        //public async Task<BaseResult<bool>> IsHotelActive(string hotelId)
        //{
        //    BaseResult<bool> response = new BaseResult<bool>();
        //    BaseResult<List<Hotel>> hotelList = await ihotelConnection.GetListByPredicate(h => h.Code == hotelId && h.IsActive == true);
        //    if (hotelList == null && hotelList.Result == null || !hotelList.Result.Any())
        //    {
        //        response.Result = false;
        //        return response;
        //    }
        //    return response;
        //}

        public async Task<BaseResult<bool>> ValidateRoomTypeRatePlanRequest(RoomTypeByHotelAndChannelManger request)
        {
            DynamicParameters paramCollection = ChannelManagerRequestMapper.CreateChannelMangerValidationRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>>  validationResponse = 
                await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.ValidateChannelMangerRequest, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }

        public async Task<BaseResult<List<RoomTypeRatePlanResponse>>> GetRoomTypesAndRatePlans(RoomTypeByHotelAndChannelManger request)
        {
            DynamicParameters paramCollection = ChannelManagerRequestMapper.CreateChannelMangerValidationRequest(request);
            BaseResult<List<RoomTypesRatePlan>> roomRateResponse = await iRoomConnection.ExecuteStoredProcedure(Constants.StoredProcedure.GetRoomTypesAndRatePlans, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapRoomTypeRatePlanResponse(roomRateResponse);// await iRoomConnection.ExecuteStoredProcedure(Constants.StoredProcedure.GetRoomTypesAndRatePlans, paramCollection).ConfigureAwait(false);
        }

        public async Task<BaseResult<bool>> ValidateUpdateAllocationRequest(UpdateAllocationsValidationRequest request)
        {
            DynamicParameters paramCollection = ChannelManagerRequestMapper.CreateUpdateAllocationsValidationRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>> validationResponse =
                await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.ValidateAllocationsRequest, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }

        public async Task<BaseResult<bool>> UpdateAllocations(UpdateAllocationsRequest request)
        {
            DynamicParameters paramCollection = ChannelManagerRequestMapper.CreateUpdateAllocationsRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>> validationResponse =
                await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.UpdateAllocations, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }

        public async Task<BaseResult<bool>> UpdateAllocationRates(UpdateAllocationRatesRequest request)
        {
            DynamicParameters paramCollection = ChannelManagerRequestMapper.CreateUpdateAllocationRatesRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>> validationResponse =
                await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.UpdateAllocationRates, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }
    }
}
