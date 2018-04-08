using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class AmenitiesController : BaseController
    {
        private IAmenities iAmenities;
        private IRoom iRoom;
        private IConfiguration iConfiguration;

        public AmenitiesController(IAmenities iAmenities, IRoom iRoom, IConfiguration iConfiguration)
        {
            this.iAmenities = iAmenities;
            this.iRoom = iRoom;
            this.iConfiguration = iConfiguration;
        }

        /// <summary>
        /// Returns list of amenities
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> GetRoomFacilityGroups([FromBody]int hotelId)
        {
            BaseResult<List<RoomFacilityGroupViewModel>> roomFacilityGroupResult = new BaseResult<List<RoomFacilityGroupViewModel>>();
            if (hotelId <= default(int))
            {
                roomFacilityGroupResult.IsError = true;
                roomFacilityGroupResult.Message = string.Format(Constants.ErrorMessage.InvalidId);
                return BadRequest(roomFacilityGroupResult);
            }
            BaseResult<List<RoomFacilityRelation>> amenitiesSelected = await iAmenities.GetSelectedAmenities(hotelId).ConfigureAwait(false);
            BaseResult<List<Room>> roomsForHotel = await iRoom.GetRoomsByHotelId(hotelId);
            if ((amenitiesSelected.IsError && amenitiesSelected.ExceptionMessage != null) || (roomsForHotel.IsError && roomsForHotel.ExceptionMessage != null))
            {
                return StatusCode(500);
            }
            BaseResult<List<RoomFacilityGroup>> roomFacilityGroup = await iAmenities.GetRoomFacilityGroup().ConfigureAwait(false);
            BaseResult<List<RoomFacilityType>> roomFacilityType = await iAmenities.GetRoomFacilityType().ConfigureAwait(false);
            BaseResult<List<RoomFacility>> roomFacility = await iAmenities.GetRoomFacility().ConfigureAwait(false);
            if ((roomFacilityGroup.IsError && roomFacilityGroup.ExceptionMessage != null) || (roomFacilityType.IsError && roomFacilityType.ExceptionMessage != null) || (roomFacility.IsError && roomFacility.ExceptionMessage != null))
            {
                return StatusCode(500);
            }
            else if (roomFacilityGroup.Result == null || roomFacilityGroup.Result.Count == 0 || roomFacility.Result == null || roomFacility.Result.Count == 0)
            {
                return NoContent(); //204
            }
            else
            {
                var amenities = AmenitiesResponseMapper.MapRoomFacilitiesToRoomFacilityViewModel(roomFacility.Result, roomsForHotel.Result);//maps to facilityViewModel
                var result = AmenitiesResponseMapper.MapRoomFacilityTypeToRoomFacilityViewModel(amenities, roomFacilityType.Result); //maps to HotelFacilityTypeViewModel
                roomFacilityGroupResult = AmenitiesResponseMapper.MapRoomFacilityGroupToRoomFacilityGroupViewModel(amenities, roomFacilityGroup.Result, result);  //Maps to HotelFacilityGroupViewModel
            }
            if (amenitiesSelected.Result == null || !amenitiesSelected.Result.Any())
            {
                return this.Ok(roomFacilityGroupResult);
            }
            else
            {
                var mappedFacilities = AmenitiesResponseMapper.MapSelectedRoomFacilities(roomFacilityGroupResult, amenitiesSelected.Result);
                return this.Ok(mappedFacilities); ////200
            }
        }

        /// <summary>
        /// To Save and Update room facilities
        /// </summary>
        /// <param name="roomFacilityViewModel"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRoomFacilityRelation([FromBody] RoomFacilityGroupListViewModel roomFacilityViewModel)
        {
            BaseResult<long> result = new BaseResult<long>();
            if (roomFacilityViewModel != null)
            {
                var validateResponse = ValidateCreateRoomFacilityRelationRequest(roomFacilityViewModel);
                if (validateResponse.Message != null)
                {
                    return this.BadRequest(validateResponse);
                }
                result = await this.iAmenities.InsertAndUpdateRoomFacilityRelation(roomFacilityViewModel, base.LoggedInUserName);
                if(result.Message!=null)
                {
                    return this.BadRequest(result);
                }
                if(result.IsError || result.ExceptionMessage != null)
                {
                    return StatusCode(500, result);
                }
                return this.Ok(result); //200
            }
            else
            {
                return this.BadRequest(result);
            }
        }

        /// <summary>
        /// Returns true if amenities exits
        /// </summary>
        /// <param name="hotelId">hotelId</param>
        /// <returns>Boolean value weather amenities exist for hotel or not</returns>
        [HttpPost]
        public async Task<IActionResult> IsAmenitiesExits([FromBody]int hotelId)
        {
            if (hotelId <=default(int))
            {
                return this.BadRequest();
            }
            BaseResult<bool> result = new BaseResult<bool>();
            result = await this.iAmenities.IsAmenitiesExits(hotelId);
            if (result.IsError && result.ExceptionMessage != null)
            {
                return  StatusCode(500,result);
            }
            return this.Ok(result);
        }

        /// <summary>
        /// Validation for Save and update request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private BaseResult<bool> ValidateCreateRoomFacilityRelationRequest(RoomFacilityGroupListViewModel request)
        {
            BaseResult<bool> validationResponse = new BaseResult<bool>() { Result=true};
            foreach (var item in request.FacilityGroupList)
            {
                foreach (var facilityType in item.RoomFacilityTypes)
                {
                    foreach (var facility in facilityType.FacilityList)
                    {
                        if (facility.FacilitiesRoomList.Any())
                        {
                            if (facility.IsSelected == true)
                            {
                                var count = facility.FacilitiesRoomList.Count(a => a.IsSelected == true);
                                if (count < 0)
                                {
                                    validationResponse.Result = false;
                                    validationResponse.Message = Constants.ErrorMessage.RoomsForSelectedAmenitiesMissing;
                                    return validationResponse;
                                }
                            }
                        }
                        else
                        {
                            validationResponse.Result = false;
                            validationResponse.Message = Constants.ErrorMessage.NoRooms;
                            return validationResponse;
                        }
                    }
                }
            }
            return validationResponse;
        }
    }
}
