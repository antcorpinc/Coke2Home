using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Models;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Helper;
using MG.Jarvis.Core.Model.Supplier;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class ChannelManagerController : Controller
    {
        #region Private Variables
        IChannelManager iChannelManager;
        #endregion Private Variables
        public ChannelManagerController(IChannelManager iChannelManager)
        {
         
            this.iChannelManager = iChannelManager;
        }

        #region Public actions
        [HttpPost]
        public async Task<IActionResult> GetRoomTypesAndRatePlans([FromBody] RoomTypeByHotelAndChannelManger request)
        {

            BaseResult<List<RoomTypeRatePlanResponse>> roomRateResponse = new BaseResult<List<RoomTypeRatePlanResponse>>();
            BaseResult<bool> requestValidationResponse = new BaseResult<bool>();

            requestValidationResponse = await ValidateRoomTypeRatePlanRequest(request);
            if (requestValidationResponse == null || !requestValidationResponse.Result && requestValidationResponse.IsError && requestValidationResponse.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }

            if (!requestValidationResponse.Result)
            {
                return new BadRequestObjectResult(requestValidationResponse);
            }
            if (requestValidationResponse.Result)
            {
                roomRateResponse = await iChannelManager.GetRoomTypesAndRatePlans(request);
            }
            if (roomRateResponse.IsError && roomRateResponse.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            if(roomRateResponse.Result == null || !roomRateResponse.Result.Any())
            {
                return new NoContentResult();
            }

            //if (!IsValidRequest(request, response))
            //{
            //    return new BadRequestObjectResult(response);
            //}

            //if (!IsValidHotel(request.HotelId, response).Result)
            //{
            //    return new BadRequestObjectResult(response);
            //}
            return Ok(roomRateResponse);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateAllocations([FromBody] UpdateAllocationBaseRequest request)
        {
            BaseResult<bool> requestValidationResponse = new BaseResult<bool>();
            if(request == null)
            {
                requestValidationResponse.IsError = true;
                requestValidationResponse.Message = string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans ");
                requestValidationResponse.ErrorCode = (int)Constants.ErrorCodes.RequiredFieldMissing;
                return new BadRequestObjectResult(requestValidationResponse);
            }

            requestValidationResponse = await ValidateUpdateAllocationRequest(request.UpdateAllocationsValidationRequest);

            if (!requestValidationResponse.Result && requestValidationResponse.IsError && requestValidationResponse.ExceptionMessage != null)
            {
                 return new StatusCodeResult(500);
            }

            if (!requestValidationResponse.Result)
            {
                 return new BadRequestObjectResult(requestValidationResponse);
            }

            //foreach(UpdateAllocationsRequest allocationRequest in request.UpdateAllocationsRequest)
            //{
            //    try
            //    {
            //        BaseResult<bool> updateAllocationResponse = await iChannelManager.UpdateAllocations(allocationRequest).ConfigureAwait(false);
            //        if(updateAllocationResponse.IsError)
            //        {
            //            //Log the error
            //        }
            //    }
            //    catch(Exception ex)
            //    {
                    
            //    }
            //}

            return Ok(requestValidationResponse);
            //  return await iChannelManager.ValidateRoomTypeRatePlanRequest(request).ConfigureAwait(false);
        }

        public async Task<IActionResult> UpdateAllocationRates([FromBody] UpdateAllocationRatesBaseRequest request)
        {
            BaseResult<bool> requestValidationResponse = new BaseResult<bool>();
            if (request == null)
            {
                requestValidationResponse.IsError = true;
                requestValidationResponse.Message = string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans ");
                requestValidationResponse.ErrorCode = (int)Constants.ErrorCodes.RequiredFieldMissing;
                return new BadRequestObjectResult(requestValidationResponse);
            }

            requestValidationResponse = await ValidateUpdateAllocationRequest(request.UpdateAllocationsValidationRequest);

            if (!requestValidationResponse.Result && requestValidationResponse.IsError && requestValidationResponse.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }

            if (!requestValidationResponse.Result)
            {
                return new BadRequestObjectResult(requestValidationResponse);
            }
     
            //
            return Ok(requestValidationResponse);
        }
        #endregion Public actions

        #region Private Methods


        public async Task<BaseResult<bool>> ValidateRoomTypeRatePlanRequest(RoomTypeByHotelAndChannelManger request) 
        {
            BaseResult<bool> validationResponse = new BaseResult<bool>();
            if (request == null || string.IsNullOrEmpty(request.HotelCode) || request.ChannelManagerId == 0)
            {
                validationResponse.IsError = true;
                validationResponse.ErrorCode = (int) Constants.ErrorCodes.RequiredFieldMissing;
                validationResponse.Message = string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe Manager Id ");
                return validationResponse;
            }
            return await iChannelManager.ValidateRoomTypeRatePlanRequest(request).ConfigureAwait(false);
        }


        public async Task<BaseResult<bool>> ValidateUpdateAllocationRequest(UpdateAllocationsValidationRequest request)
        {
            BaseResult<bool> validationResponse = new BaseResult<bool>();
            if (request == null || String.IsNullOrWhiteSpace(request.HotelCode) || request.ChannelManagerId == 0 || request.RoomTypeRatePlanList == null 
                || !request.RoomTypeRatePlanList.Any() || !request.RoomTypeRatePlanList.Where(RT=>RT.RoomTypeCode != null && RT.RatePlanCode != null).Any())
            {
                validationResponse.IsError = true;
                validationResponse.Message = string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans ");
                validationResponse.ErrorCode = (int)Constants.ErrorCodes.RequiredFieldMissing;
                return validationResponse; 
            }
            validationResponse = await iChannelManager.ValidateUpdateAllocationRequest(request).ConfigureAwait(false);

            //if (!validationResponse.Result && validationResponse.IsError && validationResponse.ExceptionMessage != null)
            //{
            //    // return new StatusCodeResult(500);
            //}

            //if (!validationResponse.Result)
            //{
            //    // return new BadRequestObjectResult(validationResponse);
            //}

            return validationResponse;
            //return Ok(validationResponse);
            //  return await iChannelManager.ValidateRoomTypeRatePlanRequest(request).ConfigureAwait(false);
        }

        /*
        private bool IsValidRequest<U, T>(U request, BaseResult<T> response)
        {
            if (request == null)
            {
                response.Message = string.Format(Constants.ErrorMessage.RequiredFieldMissing);
                response.IsError = true;
                response.ErrorCode = (int)Constants.ErrorCodes.RequiredFieldMissing;
                return false;
            }
            return true;
        }
        private  async Task<bool> IsValidHotel<T>(string hotelId, BaseResult<T> response)
        {

            //HotelManagementController hc = new HotelManagementController(this.iHotel);
            //if( hc.IsHotelValid(hotelId);
            BaseResult<bool> result = await iHotel.IsHotelValid(hotelId);
            if (!result.Result)
            {
                response.Message = string.Format(Constants.ErrorMessage.InactiveHotel, hotelId);
                response.IsError = true;
                response.ErrorCode = (int)Constants.ErrorCodes.InactiveHotel;
                return false;
            }

            return true;
        }

        private async Task<bool> IsActiveHotelAndValidContract<T>(string hotelId, BaseResult<T> response)
        {
            BaseResult<bool> result = await iHotel.IsHotelActive(hotelId);
            if (!result.Result)
            {
                response.Message = string.Format(Constants.ErrorMessage.RequiredFieldMissing,hotelId);
                response.IsError = true;
                response.ErrorCode = (int)Constants.ErrorCodes.RequiredFieldMissing;
                return false;
            }

            return true;
        }
        private bool IsValidChannelManager(string hotelId, int channelMagerId)
        {
            return false;
        }

        private bool IsValidRoomType()
        {
            return false;
        }

        private bool IsRoomTypeCreated()
        {
            return false;
        }
        private bool IsValidRatePlan()
        {
            return false;
        }
        private bool IsRatePlanCreated()
        {
            return false;
        }
        */
        #endregion Private Methods

    }
}