using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class AmenitiesRepository : IAmenities
    {
        private IConnection<RoomFacilityGroup> iRoomFacilityGroupLibrary;
        private IConnection<RoomFacilityType> iRoomFacilityTypeLibrary;
        private IConnection<RoomFacility> iRoomFacilityLibrary;
        private IConnection<RoomFacilityRelation> iRoomFacilityRelationLibrary;
        public AmenitiesRepository(IConnection<RoomFacilityGroup> iRoomFacilityGroupLibrary, IConnection<RoomFacilityType> iRoomFacilityTypeLibrary,
                                   IConnection<RoomFacilityRelation> iRoomFacilityRelationLibrary, IConnection<RoomFacility> iRoomFacilityLibrary)
        {
            this.iRoomFacilityGroupLibrary = iRoomFacilityGroupLibrary;
            this.iRoomFacilityTypeLibrary = iRoomFacilityTypeLibrary;
            this.iRoomFacilityLibrary = iRoomFacilityLibrary;
            this.iRoomFacilityRelationLibrary = iRoomFacilityRelationLibrary;
        }
        /// <summary>
        /// Returns list of Room Facility Group list
        /// </summary>
        /// <returns>List<RoomFacilityGroup></returns>
        public async Task<BaseResult<List<RoomFacilityGroup>>> GetRoomFacilityGroup()
        {
            return await iRoomFacilityGroupLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }
        /// <summary>
        /// Returns list of Room Facility type list
        /// </summary>
        /// <returns>List<RoomFacilityType></returns>
        public async Task<BaseResult<List<RoomFacilityType>>> GetRoomFacilityType()
        {
            return await iRoomFacilityTypeLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }
        /// <summary>
        /// Returns list of Room Facility list
        /// </summary>
        /// <returns>List<RoomFacility></returns>
        public async Task<BaseResult<List<RoomFacility>>> GetRoomFacility()
        {
            return await iRoomFacilityLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }
        /// <summary>
        /// Returns list of facilities for rooms
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<RoomFacilityRelation>>> GetSelectedAmenities(int hotelId)
        {
            return await iRoomFacilityRelationLibrary.GetListByPredicate(x => x.IsDeleted == false && x.IsProvisioned == true && x.HotelId == hotelId).ConfigureAwait(false);
        }
        /// <summary>
        /// Save and update the room facilities
        /// </summary>
        /// <param name="hotelFacilityViewModel">hotel Facility View Model</param>
        /// <returns>long</returns>
        public async Task<BaseResult<long>> InsertAndUpdateRoomFacilityRelation(RoomFacilityGroupListViewModel roomFacilityViewModel, string userName)
        {
            BaseResult<long> result = new BaseResult<long>();
            foreach (var item in roomFacilityViewModel.FacilityGroupList)
            {
                foreach (var facilityType in item.RoomFacilityTypes)
                {
                    foreach (var facility in facilityType.FacilityList)
                    {
                        if (facility.ObjectState == ObjectState.Added)
                        {
                            result = await AddRoomFacilityRelation(facility, userName, roomFacilityViewModel.HotelId);
                            continue;
                        }
                        if (facility.ObjectState == ObjectState.Deleted)
                        {
                            result = await DeleteRoomFacilityRelation(facility, userName);
                            continue;
                        }
                        if (facility.ObjectState == ObjectState.Unchanged)
                        {
                            result = await UnchangedRoomFacilityRelation(facility, userName, roomFacilityViewModel.HotelId);
                            continue;
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Adds thr room facility Relation if object state is added
        /// </summary>
        /// <param name="facility"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<long>></returns>
        public async Task<BaseResult<long>> AddRoomFacilityRelation(RoomFacilityViewModel facility, string userName, int hotelId)
        {
            var result = new BaseResult<long>();
            var list = new List<RoomFacilityRelation>();
            if (facility.IsSelected == true && facility.FacilitiesRoomList.Any())
            {
                foreach (var facilityRoom in facility.FacilitiesRoomList)
                {
                    if (facilityRoom.IsSelected == true)
                    {
                        RoomFacilityRelation roomFacilityRelation = new RoomFacilityRelation
                        {
                            HotelId = hotelId,
                            FacilityId = facility.Id,
                            FacilityTypeId = facility.FacilityTypeId,
                            FacilityGroupId = facility.FacilityGroupId,
                            IsDeleted = false,
                            IsProvisioned = facility.IsSelected,
                            CreatedBy = userName,
                            UpdatedBy = userName,
                            HotelRoomTypeId = facilityRoom.RoomTypeId
                        };
                        list.Add(roomFacilityRelation);
                    }
                }
                result = await this.iRoomFacilityRelationLibrary.InsertEntityList(list);
                if (result.IsError || result.ExceptionMessage != null)
                {
                    return result;
                }
            }

            else
            {
                result.Message = coreHelper.Constants.ErrorMessage.NoRooms;
                return result;
            }

            return result;
        }
        /// <summary>
        /// Deletes the room facility relation if object state is deleted
        /// </summary>
        /// <param name="facility"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<long>></returns>
        public async Task<BaseResult<long>> DeleteRoomFacilityRelation(RoomFacilityViewModel facility, string userName)
        {
            var updateResult = new BaseResult<bool>();
            var result = new BaseResult<long>();
            var list = new List<RoomFacilityRelation>();
            var facilities = await this.iRoomFacilityRelationLibrary.GetListByPredicate(x => x.FacilityId == facility.Id && !x.IsDeleted);
            if (facilities.Result.Any())
            {
                foreach (var roomFacility in facilities.Result)
                {
                    roomFacility.IsDeleted = true;
                    roomFacility.UpdatedBy = userName;
                    roomFacility.UpdatedDate = DateTime.Now.JakartaOffset();
                }
                updateResult = await this.iRoomFacilityRelationLibrary.UpdateEntityList(facilities.Result);
                if (updateResult.IsError || updateResult.ExceptionMessage != null)
                {
                    result.IsError = updateResult.IsError;
                    result.ExceptionMessage = updateResult.ExceptionMessage;
                    return result;
                }
                result.Result = 1;
                return result;
            }
            return result;
        }
        /// <summary>
        /// Handles the object state unchanged of room facility
        /// </summary>
        /// <param name="facility"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<long>></returns>
        public async Task<BaseResult<long>> UnchangedRoomFacilityRelation(RoomFacilityViewModel facility, string userName, int hotelId)
        {
            var result = new BaseResult<long>();
            var updateResult = new BaseResult<bool>();
            var list = new List<RoomFacilityRelation>();
            if (facility.IsSelected == true && facility.FacilitiesRoomList != null)
            {
                foreach (var roomFacility in facility.FacilitiesRoomList)
                {
                    if (roomFacility.ObjectState == ObjectState.Added)
                    {
                        if (roomFacility.IsSelected == true)
                        {
                            RoomFacilityRelation roomFacilityRelation = new RoomFacilityRelation
                            {
                                HotelId = hotelId,
                                FacilityId = facility.Id,
                                FacilityTypeId = facility.FacilityTypeId,
                                FacilityGroupId = facility.FacilityGroupId,
                                IsDeleted = false,
                                IsProvisioned = facility.IsSelected,
                                CreatedBy = userName,
                                UpdatedBy = userName,
                                HotelRoomTypeId = roomFacility.RoomTypeId
                            };
                            result = await this.iRoomFacilityRelationLibrary.InsertEntity(roomFacilityRelation);
                            if (result.IsError || result.ExceptionMessage != null)
                            {
                                return result;
                            }
                            result.Result = result.Result;
                        }
                    }
                    else if (roomFacility.ObjectState == ObjectState.Deleted)
                    {
                        var roomFacilityItem = this.iRoomFacilityRelationLibrary.GetListByPredicate(x => x.FacilityId == facility.Id && !x.IsDeleted && x.Id == roomFacility.RoomFacilityRelationId).Result.Result.SingleOrDefault();
                        if (roomFacilityItem != null)
                        {
                            roomFacilityItem.IsDeleted = true;
                            roomFacilityItem.UpdatedBy = userName;
                            roomFacilityItem.UpdatedDate = DateTime.Now.JakartaOffset();
                            updateResult = await this.iRoomFacilityRelationLibrary.UpdateEntityByDapper(roomFacilityItem);
                            if (updateResult.IsError || updateResult.ExceptionMessage != null)
                            {
                                result.IsError = updateResult.IsError;
                                result.ExceptionMessage = updateResult.ExceptionMessage;
                                return result;
                            }
                        }
                    }
                }
            }
            result.Result = 1;
            return result;
        }

        /// <summary>
        /// returns Whether amenities exits
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Task<BaseResult<bool>></returns>
        public async Task<BaseResult<bool>> IsAmenitiesExits(int hotelId)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            result.Result = false;
            var selectedFacilities = await this.GetSelectedAmenities(hotelId);
            if (selectedFacilities.ExceptionMessage != null || selectedFacilities.IsError)
            {
                result.IsError = selectedFacilities.IsError;
                result.ExceptionMessage = selectedFacilities.ExceptionMessage;
                return result;
            }
            if (selectedFacilities != null && selectedFacilities.Result.Any())
            {
                result.Result = true;
            }
            return result;
        }
    }
}
