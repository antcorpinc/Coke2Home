using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MG.Jarvis.Api.Extranet.Helper.Enums;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class RoomRepository : IRoom
    {
        private IConnection<RoomType> iRoomTypeLibrary;
        private IConnection<Room> iRoomLibrary;
        private IConnection<SmokingPolicy> iSmokingPolicyLibrary;
        private IConnection<Bed> iBedLibrary;
        private IConnection<SizeMeasure> iSizeMeasureLibrary;
        private IConnection<Occupancy> iOccupancyConnectionLibrary;
        private IConnection<RoomBedRelation> iRoomBedRelationLibrary;


        public RoomRepository(IConnection<RoomType> iRoomTypeLibrary, IConnection<Room> iRoomLibrary
             , IConnection<Occupancy> iOccupancyConnectionLibrary, IConnection<SmokingPolicy> iSmokingPolicyLibrary, IConnection<Bed> iBedLibrary, IConnection<SizeMeasure> iSizeMeasureLibrary, IConnection<RoomBedRelation> iRoomBedRelationLibrary)
        {
            this.iRoomTypeLibrary = iRoomTypeLibrary;
            this.iRoomLibrary = iRoomLibrary;
            this.iSmokingPolicyLibrary = iSmokingPolicyLibrary;
            this.iSizeMeasureLibrary = iSizeMeasureLibrary;
            this.iBedLibrary = iBedLibrary;
            this.iOccupancyConnectionLibrary = iOccupancyConnectionLibrary;
            this.iRoomBedRelationLibrary = iRoomBedRelationLibrary;
        }

        /// <summary>
        /// Return List of Room types
        /// </summary>
        /// <returns>List<RoomType></returns>
        public async Task<BaseResult<List<RoomType>>> GetRoomType()
        {
            return await iRoomTypeLibrary.GetList().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns list of rooms by hotel id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>List<Room></returns>
        public async Task<BaseResult<List<Room>>> GetRoomsByHotelId(int hotelId)
        {

            return await iRoomLibrary.GetListByPredicate(x => x.HotelId == hotelId && x.IsDeleted == false);
        }

        /// <summary>
        /// Returns list of Smoking Policies
        /// </summary>
        /// <returns>List<SmokingPolicy></returns>
        public async Task<BaseResult<List<SmokingPolicy>>> GetSmokingPolicy()
        {
            return await iSmokingPolicyLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }
        /// <summary>
        /// Retuens List of Beds
        /// </summary>
        /// <returns>List<Bed></returns>
        public async Task<BaseResult<List<Bed>>> GetBed()
        {
            return await iBedLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }

        /// <summary>
        /// Retuens List of Size Measures
        /// </summary>
        /// <returns>List<SizeMeasure></returns>
        public async Task<BaseResult<List<SizeMeasure>>> GetSizeMeasure()
        {
            return await iSizeMeasureLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrun all Occupancy
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<OccupancyViewModel>>> GetOccupancy()
        {
            // return await iOccupancyConnectionLibrary.GetListByPredicate(id => id.IsActive == true).ConfigureAwait(false);
            var occupancyVm = DbMapperMasterdata.MapOccupancy();
            return occupancyVm;
        }
        /// <summary>
        /// Creates new room type or updates the existing one
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<List<Room>>></returns>
        public async Task<BaseResult<List<Room>>> SaveAndUpdateRoom(HotelRoomTypeViewModel request, string userName)
        {
            BaseResult<List<Room>> result = new BaseResult<List<Room>>() { Result = new List<Room>() { new Room() { Id = 0 } } };
            if (request.ObjectState == ObjectState.Added)
            {
                DynamicParameters paramCollection = RoomRequestMapper.CreateRoomTypeParameters(request, userName);
                result = await iRoomLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.CreateRoomType, paramCollection).ConfigureAwait(false);
                return result;
            }
            else if (request.ObjectState == ObjectState.Modified)
            {
                if (request.RoomId <= default(int))
                {
                    result.IsError = true;
                    result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoRoomOfID;
                    result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoRoomOfID, request.RoomId);
                    return result;
                }
                var room = await iRoomLibrary.GetListByPredicate(x => x.Id == request.RoomId && x.HotelId == request.HotelId && !x.IsDeleted);
                if (room.IsError == true || room.ExceptionMessage != null)
                {
                    result.ExceptionMessage = room.ExceptionMessage;
                    result.IsError = room.IsError;
                    return result;
                }
                if (!room.Result.Any())
                {
                    result.IsError = true;
                    result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoRoomOfID;
                    result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoRoomOfID, request.RoomId);
                    return result;
                }
                var updatedRoom = RoomRequestMapper.AutoMapperRoom(request, room.Result[0], userName);
                var updateResult = await iRoomLibrary.UpdateEntityByDapper(updatedRoom).ConfigureAwait(false);
                if (updateResult.IsError || updateResult.ExceptionMessage != null)
                {
                    result.IsError = true;
                    result.ExceptionMessage = updateResult.ExceptionMessage;
                    return result;
                }
                else if (updateResult == null)
                {
                    result = null;
                    return result;
                }
                if (updateResult.Result == true)
                {
                    result.Result[0].Id = updatedRoom.Id;
                }
                return result;
            }
            else
            {
                var room = await iRoomLibrary.GetListByPredicate(x => x.Id == request.RoomId && x.HotelId == request.HotelId && !x.IsDeleted);
                return room;
            }

            return result;
        }
        /// <summary>
        /// Creates Room bed Relation or updates the existing one
        /// </summary>
        /// <param name="request"></param>
        /// <param name="hotelRoomId"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<RoomBedRelation>></returns>
        public async Task<BaseResult<RoomBedRelation>> SaveAndUpdateRoomBedRelation(HotelRoomTypeViewModel request, int hotelRoomId, string userName)
        {
            BaseResult<RoomBedRelation> result = new BaseResult<RoomBedRelation>();
            result.Result = new RoomBedRelation();
            if (request.RoomBedOptions.ObjectState == ObjectState.Added)
            {
                var list = RoomRequestMapper.CreateRoomBedRelation(request, hotelRoomId, userName);
                var insertResult = await iRoomBedRelationLibrary.InsertEntityList(list.Result).ConfigureAwait(false);
                if(insertResult.IsError && insertResult.ExceptionMessage!=null)
                {
                    result.IsError = insertResult.IsError;
                    result.ExceptionMessage = insertResult.ExceptionMessage;
                    return result;
                }
                result.Result.ID = (int)insertResult.Result;
                return result;
            }
            if (request.RoomBedOptions.ObjectState == ObjectState.Modified || request.RoomBedOptions.ObjectState == ObjectState.Unchanged)
            {
                foreach (var item in request.RoomBedOptions.RoomBedList)
                {
                    if (item.ObjectState == ObjectState.Modified && item.ID > 0)
                    {
                        var oldItem = await iRoomBedRelationLibrary.GetListByPredicate(x => x.ID == item.ID && !x.IsDeleted);
                        if (result.IsError || oldItem.ExceptionMessage != null)
                        {
                            result.IsError = true;
                            result.ExceptionMessage = oldItem.ExceptionMessage;
                            return result;
                        }
                        if (oldItem != null && oldItem.Result.Any())
                        {
                            var newRoomBed = RoomRequestMapper.AutoMapperRoomBedRelation(item, oldItem.Result[0], userName);
                            var updateResult = await iRoomBedRelationLibrary.UpdateEntityByDapper(newRoomBed).ConfigureAwait(false);
                            if (updateResult.IsError || updateResult.ExceptionMessage != null)
                            {
                                result.IsError = true;
                                result.ExceptionMessage = updateResult.ExceptionMessage;
                                return result;
                            }
                            else if (updateResult == null)
                            {
                                result = null;
                                return result;
                            }
                            if (updateResult.Result == true)
                            {
                                result.Result.ID = newRoomBed.ID;
                            }
                        }
                    }
                    else if (item.ObjectState == ObjectState.Added && item.ID == 0)
                    {
                        var list = RoomRequestMapper.MapRoomBedRelationEntity(request, item, hotelRoomId, userName);
                        var insertResult = await iRoomBedRelationLibrary.InsertEntity(list.Result).ConfigureAwait(false);
                        if (insertResult.IsError || insertResult.ExceptionMessage != null)
                        {
                            result.IsError = true;
                            result.ExceptionMessage = insertResult.ExceptionMessage;
                            return result;
                        }
                        else if (insertResult == null)
                        {
                            result = null;
                            return result;
                        }
                        result.Result.ID = (int)insertResult.Result;
                    }
                    //else
                    //{
                    //    result.IsError = true;
                    //    result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoRoomBedRelationOfID;
                    //    result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoRoomBedRelationOfID,item.ID);
                    //    return result;
                    //}
                }
                return result;
            }
            return result;
        }
        /// <summary>
        /// Gets room details by room id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>Task<BaseResult<HotelRoomTypeViewModel>></returns>
        public async Task<BaseResult<HotelRoomTypeViewModel>> GetRoomDetailsByRoomId(int roomId)
        {
            BaseResult<HotelRoomTypeViewModel> model = new BaseResult<HotelRoomTypeViewModel>();
            var room = await iRoomLibrary.GetListByPredicate(x => x.Id == roomId && !x.IsDeleted).ConfigureAwait(false);
            if (room.IsError || room.ExceptionMessage != null)
            {
                model.IsError = true;
                model.ExceptionMessage = room.ExceptionMessage;
                return model;
            }
            if (room != null && room.Result.Count > 0)
            {
                var roomBed = await iRoomBedRelationLibrary.GetListByPredicate(x => x.HotelRoomId == roomId && !x.IsDeleted);
                if (roomBed.IsError || roomBed.ExceptionMessage != null)
                {
                    model.IsError = true;
                    model.ExceptionMessage = room.ExceptionMessage;
                    return model;
                }
                model = RoomResponseMapper.MapRoomDetails(room.Result[0], roomBed.Result);
                return model;
            }
            else
            {
                model.IsError = true;
                model.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoRoomOfID;
                model.Message = string.Format(coreHelper.Constants.ErrorMessage.NoRoomOfID, roomId);
                return model;
            }
        }
        /// <summary>
        /// Delete the entity in room bed relation
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<bool>></returns>
        public async Task<BaseResult<bool>> DeleteRoomBedRelationById(int Id, string userName)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            var roomBed = await iRoomBedRelationLibrary.GetListByPredicate(x => x.ID == Id && !x.IsDeleted).ConfigureAwait(false);
            if (roomBed.IsError || roomBed.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = roomBed.ExceptionMessage;
                return result;
            }
            if (roomBed == null)
            {
                result.IsError = true;
                result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoRoomBedRelationOfID;
                result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoRoomBedRelationOfID, Id);
                return result;
            }
            roomBed.Result[0].IsDeleted = true;
            roomBed.Result[0].UpdatedBy = userName;
            roomBed.Result[0].UpdatedDate = Common.JakartaOffset(DateTime.Now);
            result = await iRoomBedRelationLibrary.UpdateEntityByDapper(roomBed.Result[0]);
            return result;
        }

        /// <summary>
        /// Delete room by id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<bool>></returns>
        public async Task<BaseResult<bool>> DeleteRoomById(int Id, string userName)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            var roomBed = await iRoomLibrary.GetListByPredicate(x => x.Id == Id && !x.IsDeleted).ConfigureAwait(false);
            if (roomBed.IsError || roomBed.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = roomBed.ExceptionMessage;
                return result;
            }
            if (roomBed == null)
            {
                result.IsError = true;
                result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoRoomOfID;
                result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoRoomOfID, Id);
                return result;
            }
            roomBed.Result[0].IsDeleted = true;
            roomBed.Result[0].UpdatedBy = userName;
            roomBed.Result[0].UpdatedDate = Common.JakartaOffset(DateTime.Now);
            result = await iRoomLibrary.UpdateEntityByDapper(roomBed.Result[0]);

            return result;
        }
    }
}
