using MG.Jarvis.Api.Extranet.Models;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Supplier;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class ChannelManagerResponseMapper
    {
        #region Channel manager
        public static BaseResult<bool> MapChannelManagerRequestValidationResponse(BaseResult<List<ChannelManagerRequestValidationResponse>> response)
        {
            if (response != null)
            {
                if (response.Result != null && response.Result.Any())
                {
                    
                    BaseResult<bool> result = new BaseResult<bool>
                    {
                        IsError = !string.IsNullOrEmpty(response.Result[0].ErrorMessage) || response.Result[0].ErrorCode > 0,
                        ErrorCode = response.Result[0].ErrorCode,
                        Message = response.Result[0].ErrorMessage
                    };
                    result.Result = !result.IsError;
                    return result;
                }
                else
                {
                    BaseResult<bool> result = new BaseResult<bool>
                    {
                        IsError = response.IsError,
                        ExceptionMessage = response.ExceptionMessage
                    };
                    return result;
                }
            }
            return null;
        }
        public static BaseResult<List<RoomTypeRatePlanResponse>> MapRoomTypeRatePlanResponse(BaseResult<List<RoomTypesRatePlan>> response)
        {
            BaseResult<List<RoomTypeRatePlanResponse>> roomRateReponse = new BaseResult<List<RoomTypeRatePlanResponse>>
            {
                Result = new List<RoomTypeRatePlanResponse>()
            };
            if (response != null)
            {
                if (response.Result != null && response.Result.Any())
                {
                    foreach (RoomTypesRatePlan roomRate in response.Result)
                    {
                        RoomTypeRatePlanResponse roomTypeRatePlan = new RoomTypeRatePlanResponse
                        {
                            RatePlanCode = roomRate.RatePlanCode,
                            RatePlanDescription = roomRate.RatePlanDescription,
                            RatePlanName = roomRate.RatePlanName,
                            RoomTypeCode = roomRate.RoomTypeCode,
                            RoomTypeDescription = roomRate.RoomTypeDescription,
                            RoomTypeName = roomRate.RoomTypeName,
                            MaxOccupancy = roomRate.MaxOccupancy
                        };
                        roomRateReponse.Result.Add(roomTypeRatePlan);
                    }
                }

            }
            return roomRateReponse;
        }
        #endregion Channel manager
    }
}
