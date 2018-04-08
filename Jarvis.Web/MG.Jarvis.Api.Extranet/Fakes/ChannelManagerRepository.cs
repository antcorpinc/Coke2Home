using Dapper;

using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.Models;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Supplier;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MG.Jarvis.Api.Extranet.Fakes
{
    public class ChannelManagerRepository :IChannelManager
    {
        #region Private Variables
       // IConnection<ChannelManagerRequestValidationResponse> iConnection;
       // IConnection<RoomTypesRatePlan> iRoomConnection;
        #endregion Private Varibales
        //public ChannelRepositories(IConnection<Hotel> ihotelConnection)
        //{
        //    this.ihotelConnection = ihotelConnection;
        //}
        public ChannelManagerRepository()
        {
            //this.iConnection = iConnection;
           // this.iRoomConnection = iRoomConnection;
        }
    

        public async Task<BaseResult<bool>> ValidateRoomTypeRatePlanRequest(RoomTypeByHotelAndChannelManger request)
        {
            DynamicParameters paramCollection = ChannelManagerRequestMapper.CreateChannelMangerValidationRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>> validationResponse = new BaseResult<List<ChannelManagerRequestValidationResponse>>();
            switch (request.HotelCode)
            {
                case "TestCaseForException":
                    try
                    {
                        throw new Exception("Exception Thrown From Fake for Unit Test");
                    }
                    catch (Exception ex)
                    {
                        validationResponse.IsError = true;
                        validationResponse.ExceptionMessage = ex;
                    }
                    break;
                    case "TestCaseForOkResponse":
                    validationResponse.Result = new List<ChannelManagerRequestValidationResponse> { new ChannelManagerRequestValidationResponse () };
                    break;
            }
               // await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.ValidateChannelMangerRequest, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }

        public async Task<BaseResult<List<RoomTypeRatePlanResponse>>> GetRoomTypesAndRatePlans(RoomTypeByHotelAndChannelManger request)
        {
            //DynamicParameters paramCollection = RequestMapper.CreateChannelMangerValidationRequest(request);
            // return await iRoomConnection.ExecuteStoredProcedure(Constants.StoredProcedure.GetRoomTypesAndRatePlans, paramCollection).ConfigureAwait(false);

            BaseResult<List<RoomTypeRatePlanResponse>> roomRatePlanList = new BaseResult<List<RoomTypeRatePlanResponse>>
            {
                Result = new List<RoomTypeRatePlanResponse>()
            };
            //roomRatePlanList.Result.Add(new RoomTypeRatePlanResponse { RoomTypeCode = "Test Room Type", RatePlanCode = "Test Rate Plan Code" });
            roomRatePlanList.Result.Add(new RoomTypeRatePlanResponse { RatePlanCode = "1", RatePlanDescription = "Tets Rate PLAN DESC", RatePlanName = "test Rate Plan", RoomTypeCode = "Test Room Type Code",
                RoomTypeDescription = "Test Room Tyep Desc", RoomTypeName = "Tets Room Tyep Neame" });

    
            return roomRatePlanList;

        }

        public async Task<BaseResult<bool>> ValidateUpdateAllocationRequest(UpdateAllocationsValidationRequest request)
        {
            // DynamicParameters paramCollection = RequestMapper.CreateUpdateAllocationsValidationRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>> validationResponse = new BaseResult<List<ChannelManagerRequestValidationResponse>>();
              //  await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.ValidateAllocationsRequest, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }

        public async Task<BaseResult<bool>> UpdateAllocations(UpdateAllocationsRequest request)
        {
            //  DynamicParameters paramCollection = RequestMapper.CreateUpdateAllocationsRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>> validationResponse = new BaseResult<List<ChannelManagerRequestValidationResponse>>();
               // await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.ValidateAllocationsRequest, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }

        public async Task<BaseResult<bool>> UpdateAllocationRates(UpdateAllocationRatesRequest request)
        {
            DynamicParameters paramCollection = ChannelManagerRequestMapper.CreateUpdateAllocationRatesRequest(request);
            BaseResult<List<ChannelManagerRequestValidationResponse>> validationResponse = new BaseResult<List<ChannelManagerRequestValidationResponse>>();
           //     await iConnection.ExecuteStoredProcedure(Constants.StoredProcedure.ValidateAllocationsRequest, paramCollection).ConfigureAwait(false);
            return ChannelManagerResponseMapper.MapChannelManagerRequestValidationResponse(validationResponse);
        }
    }
}
