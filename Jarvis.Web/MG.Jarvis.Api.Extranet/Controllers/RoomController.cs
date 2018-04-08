using MG.Jarvis.Api.Extranet.Attributes;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class RoomController : BaseController
    {
        private IRoom iRoom;
        private IMasterData iMasterData;

        public RoomController(IRoom iRoom, IMasterData iMasterData)
        {
            this.iRoom = iRoom;
            this.iMasterData = iMasterData;
        }

        /// <summary>
        /// Returns the list of Room types
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> GetRoomType()
        {
            BaseResult<List<RoomTypeViewModel>> roomTypeViewModelResult = new BaseResult<List<RoomTypeViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<RoomTypeViewModel>>(Helper.Constants.CacheKeys.RoomTypeList)
            };

            if (roomTypeViewModelResult.Result == null || !roomTypeViewModelResult.Result.Any())
            {
                var roomTypeResult = await iRoom.GetRoomType().ConfigureAwait(false);

                if (roomTypeResult.IsError && roomTypeResult.ExceptionMessage != null)
                {
                    return StatusCode(500,roomTypeResult);
                }
                else if (roomTypeResult.Result == null || !roomTypeResult.Result.Any())
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = RoomResponseMapper.MapRoomType(roomTypeResult);//maps to RoomTypeViewModel
                    RedisCacheHelper.Instance.Set<List<RoomTypeViewModel>>(Helper.Constants.CacheKeys.RoomTypeList, result.Result);
                    return Ok(result);
                }
            }

            return Ok(roomTypeViewModelResult); //200
        }

        /// <summary>
        /// Get the list of rooms of particular hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> GetRoomsByHotelId([FromBody]int hotelId)
        {
            if (hotelId <= default(int))
            {
                return new BadRequestResult();
            }
            BaseResult<List<Room>> roomsResult = new BaseResult<List<Room>>();
            roomsResult = await iRoom.GetRoomsByHotelId(hotelId).ConfigureAwait(false);
            if (roomsResult.IsError && roomsResult.ExceptionMessage != null)
            {
                return StatusCode(500,roomsResult);
            }
            else if (roomsResult.Result == null || !roomsResult.Result.Any())
            {
                return NoContent(); //204
            }
            var result = RoomResponseMapper.MapRoomsByHotelId(roomsResult); //maps to RoomTypeViewModel
            return Ok(result);
        }

   
        /// <summary>
        /// Gets details of particular room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetRoomDetailsByRoomId([FromBody]int roomId)
        {
            if (roomId<=default(int))
            {
                return new BadRequestResult();
            }
            BaseResult<HotelRoomTypeViewModel> roomResult = new BaseResult<HotelRoomTypeViewModel>();

            roomResult = await iRoom.GetRoomDetailsByRoomId(roomId);
            if (roomResult.IsError && roomResult.ExceptionMessage != null)
            {
                return  StatusCode(500,roomResult);
            }
            if (roomResult.Message != null)
            {
                return BadRequest(roomResult);
            }
            else if (roomResult.Result == null)
            {
                return NoContent(); //204
            }
            return Ok(roomResult);
        }

        /// <summary>
        /// Return list of Smoking Policy
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> GetSmokingPolicy()
        {
            BaseResult<List<SmokingPolicyViewModel>> SmokingPolicyResult = new BaseResult<List<SmokingPolicyViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<SmokingPolicyViewModel>>(Helper.Constants.CacheKeys.SmokingPolicyList)
            };
            if (SmokingPolicyResult.Result == null || !SmokingPolicyResult.Result.Any())
            {
                BaseResult<List<SmokingPolicy>> smokingPolicy = await iRoom.GetSmokingPolicy().ConfigureAwait(false);

                if (smokingPolicy.IsError && smokingPolicy.ExceptionMessage != null)
                {
                    return StatusCode(500,smokingPolicy);
                }
                else if (smokingPolicy.Result == null || !smokingPolicy.Result.Any())
                {
                    return NoContent(); //204
                }
                else
                {
                    var smokingPolicyVm = DbMapperMasterdata.MapSmokingPolicyList(smokingPolicy); //mapping to SmokingPolicyViewModel
                    RedisCacheHelper.Instance.Set<List<SmokingPolicyViewModel>>(Helper.Constants.CacheKeys.SmokingPolicyList, smokingPolicyVm.Result);
                    return Ok(smokingPolicyVm);
                }
            }
            return Ok(SmokingPolicyResult);//200
        }

        /// <summary>
        /// Return list of Beds
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> GetBed()
        {
            BaseResult<List<BedViewModel>> BedResult = new BaseResult<List<BedViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<BedViewModel>>(Helper.Constants.CacheKeys.BedList)
            };
            if (BedResult.Result == null || !BedResult.Result.Any())
            {
                BaseResult<List<Bed>> Bed = await iRoom.GetBed().ConfigureAwait(false);

                if (Bed.IsError && Bed.ExceptionMessage != null)
                {
                    return StatusCode(500,Bed);
                }
                else if (Bed.Result == null || !Bed.Result.Any())
                {
                    return NoContent(); //204
                }
                else
                {
                    var bedVm = DbMapperMasterdata.MapBedList(Bed); //mapping to BedViewModel
                    RedisCacheHelper.Instance.Set<List<BedViewModel>>(Helper.Constants.CacheKeys.BedList, bedVm.Result);
                    return Ok(bedVm);//200
                }
            }
            return Ok(BedResult);//200
        }

        /// <summary>
        /// Return list of Size Measures
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        public async Task<IActionResult> GetSizeMeasure()
        {
            BaseResult<List<SizeMeasureViewModel>> SizeMeasureResult = new BaseResult<List<SizeMeasureViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<SizeMeasureViewModel>>(Helper.Constants.CacheKeys.SizeMeasureList)
            };
            if (SizeMeasureResult.Result == null || !SizeMeasureResult.Result.Any())
            {
                BaseResult<List<SizeMeasure>> sizeMeasure = await iRoom.GetSizeMeasure().ConfigureAwait(false);

                if (sizeMeasure.IsError && sizeMeasure.ExceptionMessage != null)
                {
                    return StatusCode(500,sizeMeasure);
                }
                else if (sizeMeasure.Result == null || !sizeMeasure.Result.Any())
                {
                    return NoContent(); //204
                }
                else
                {
                    var sizeMeasureVm = DbMapperMasterdata.MapSizeMeasureList(sizeMeasure); //mapping to SizeMeasureViewModel
                    RedisCacheHelper.Instance.Set<List<SizeMeasureViewModel>>(Helper.Constants.CacheKeys.SizeMeasureList, sizeMeasureVm.Result);
                    return Ok(sizeMeasureVm);//200
                }
            }
            return Ok(SizeMeasureResult);//200
        }
        /// <summary>
        /// Return the list of No of guests
        /// </summary>
        /// <returns>list of guests</returns>
        public async Task<IActionResult> GetOccupancy()
        {
            BaseResult<List<OccupancyViewModel>> occupancyListResult = new BaseResult<List<OccupancyViewModel>>();
            occupancyListResult = await iRoom.GetOccupancy();
            return Ok(occupancyListResult);
        }
       
        /// <summary>
        /// Create new room type or updates the existing one
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRoomType([FromBody]HotelRoomTypeViewModel request)
        {
            BaseResult<List<Room>> createRoomTypeResponse = new BaseResult<List<Room>>();
            BaseResult<RoomBedRelation> createRoomBedRelationResponse = new BaseResult<RoomBedRelation>();
            if (request != null)
            { 
                createRoomTypeResponse = await iRoom.SaveAndUpdateRoom(request, base.LoggedInUserName);
                if (createRoomTypeResponse.Message != null)
                {
                    return BadRequest(createRoomTypeResponse);
                }
                if (createRoomTypeResponse.IsError && createRoomTypeResponse.ExceptionMessage != null)
                {
                    return StatusCode(500,createRoomTypeResponse);
                }
                createRoomBedRelationResponse = await iRoom.SaveAndUpdateRoomBedRelation(request, createRoomTypeResponse.Result[0].Id, base.LoggedInUserName);
                if (createRoomBedRelationResponse.Message != null)
                {
                    return BadRequest(createRoomBedRelationResponse);
                }
                if (createRoomBedRelationResponse.IsError && createRoomBedRelationResponse.ExceptionMessage != null)
                {
                    return StatusCode(500,createRoomBedRelationResponse);
                }
                return Ok(createRoomTypeResponse); //200
            }
            else
            {
                createRoomTypeResponse.IsError = true;
                createRoomTypeResponse.Message = coreHelper.Constants.ErrorMessage.EmptyModel;
                return BadRequest(createRoomTypeResponse);
            }
        }
        /// <summary>
        /// Deletes the room bed entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteRoomBedRelationById([FromBody]int id)
        {
            BaseResult<bool> response = new BaseResult<bool>();
            if (id <= default(int))
            {
                response.IsError = true;
                response.Message = coreHelper.Constants.ErrorMessage.InvalidId;
                return  BadRequest(response);
            }           
            response = await iRoom.DeleteRoomBedRelationById(id, base.LoggedInUserName);
            if (response.Message != null)
            {
                return BadRequest(response);
            }
            if (response.IsError && response.ExceptionMessage != null)
            {
                return  StatusCode(500,response);
            }
            return Ok(response); //200

        }
        /// <summary>
        /// Deletes the room by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteRoomById([FromBody]int id)
        {
            BaseResult<bool> response = new BaseResult<bool>();
            if (id <= default(int))
            {
                response.IsError = true;
                response.Message = coreHelper.Constants.ErrorMessage.InvalidId;
                return BadRequest(response);
            }           
            response = await iRoom.DeleteRoomById(id, base.LoggedInUserName);
            if (response.Message != null)
            {
                return BadRequest(response);
            }
            if (response.IsError && response.ExceptionMessage != null)
            {
                return StatusCode(500, response);
            }
            return Ok(response); //200
        }

    }
}