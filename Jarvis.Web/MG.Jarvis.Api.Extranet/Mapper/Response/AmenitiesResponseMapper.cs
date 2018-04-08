using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class AmenitiesResponseMapper
    {
        /// <summary>
        /// Maps to room facility view model
        /// </summary>
        /// <param name="facilityList"></param>
        /// <param name="roomForHotel"></param>
        /// <returns>List<RoomFacilityViewModel></returns>
        public static List<RoomFacilityViewModel> MapRoomFacilitiesToRoomFacilityViewModel(List<RoomFacility> facilityList, List<Room> roomForHotel=null)
        {
            var modelList = new List<RoomFacilityViewModel>();
            foreach (var item in facilityList)
            {
                var roomFacility = AutoMapper.Mapper.Map<RoomFacility, RoomFacilityViewModel>(item);
                roomFacility.IsSelected = false;
                if (roomForHotel != null)
                {
                    foreach (var room in roomForHotel)
                    {
                        FacilitiesRoomList facilitiesRoomList = new FacilitiesRoomList
                        {
                            RoomTypeId = room.Id,
                            RoomName = room.Name,
                            IsSelected = false
                        };
                        roomFacility.FacilitiesRoomList.Add(facilitiesRoomList);
                    }
                }
                modelList.Add(roomFacility);
            }
            return modelList;
        }
        /// <summary>
        /// Maps to room facility type view model
        /// </summary>
        /// <param name="facilityList"></param>
        /// <param name="facilityTypeList"></param>
        /// <returns>List<RoomFacilityTypeViewModel></returns>
        public static List<RoomFacilityTypeViewModel> MapRoomFacilityTypeToRoomFacilityViewModel(List<RoomFacilityViewModel> facilityList, List<RoomFacilityType> facilityTypeList)
        {
            List<RoomFacilityTypeViewModel> responseModelList = new List<RoomFacilityTypeViewModel>();
            foreach (var item in facilityTypeList)
            {
                var roomFacilityType = AutoMapper.Mapper.Map<RoomFacilityType, RoomFacilityTypeViewModel>(item);
                foreach (var facilities in facilityList)
                {
                    if (facilities.FacilityTypeId == item.Id)
                        roomFacilityType.FacilityList.Add(facilities);
                }
                responseModelList.Add(roomFacilityType);
            }
            return responseModelList;
        }

        /// <summary>
        /// Maps to Room Facility group view model
        /// </summary>
        /// <param name="roomFacilityList"></param>
        /// <param name="roomFacilityGroupList"></param>
        /// <param name="roomFacilityViewModel"></param>
        /// <returns> BaseResult<List<RoomFacilityGroupViewModel>></returns>
        public static BaseResult<List<RoomFacilityGroupViewModel>> MapRoomFacilityGroupToRoomFacilityGroupViewModel(List<RoomFacilityViewModel> roomFacilityList, List<RoomFacilityGroup> roomFacilityGroupList, List<RoomFacilityTypeViewModel> roomFacilityViewModel)
        {
            var responseModel = new BaseResult<List<RoomFacilityGroupViewModel>>();
            List<RoomFacilityGroupViewModel> modelList = new List<RoomFacilityGroupViewModel>();
            List<HotelFacilityTypeViewModel> facilityTypeModelList = new List<HotelFacilityTypeViewModel>();

            foreach (var item in roomFacilityGroupList)
            {
                List<RoomFacilityViewModel> facilities = new List<RoomFacilityViewModel>();
                List<RoomFacilityTypeViewModel> facilityTypeList = new List<RoomFacilityTypeViewModel>();
                RoomFacilityTypeViewModel roomFacilityTypeModel = new RoomFacilityTypeViewModel
                {
                    FacilityGroupId = item.Id,
                };
                foreach (var facility in roomFacilityList)
                {
                    if (facility.FacilityTypeId == null && facility.FacilityGroupId == item.Id)
                    {
                        roomFacilityTypeModel.FacilityList.Add(facility);
                    }
                }
                if (roomFacilityTypeModel.FacilityList.Any())
                {
                    roomFacilityViewModel.Add(roomFacilityTypeModel);
                }
                var roomFacilityGroup = AutoMapper.Mapper.Map<RoomFacilityGroup, RoomFacilityGroupViewModel>(item);
                foreach (var facilityTypes in roomFacilityViewModel)
                {
                    if (facilityTypes.FacilityGroupId == item.Id)
                    {
                        roomFacilityGroup.RoomFacilityTypes.Add(facilityTypes);
                    }
                }
                modelList.Add(roomFacilityGroup);
            }
            responseModel.Result = modelList;
            return responseModel;
        }


        /// <summary>
        /// Maps Selected Facilities
        /// </summary>
        /// <param name="facilityGroupList"></param>
        /// <param name="selectedfacilityList"></param>
        /// <returns></returns>
        public static BaseResult<List<RoomFacilityGroupViewModel>> MapSelectedRoomFacilities(BaseResult<List<RoomFacilityGroupViewModel>> facilityGroupList, List<RoomFacilityRelation> selectedFacilityList)
        {
            foreach (var item in facilityGroupList.Result)
            {
                foreach (var type in item.RoomFacilityTypes)
                {
                    foreach (var facilities in type.FacilityList)
                    {
                        if (facilities.FacilitiesRoomList != null)
                        {
                            foreach (var room in facilities.FacilitiesRoomList)
                            {
                                var roomForFacility = selectedFacilityList.Where(x => x.HotelRoomTypeId == room.RoomTypeId && x.FacilityId == facilities.Id).FirstOrDefault();
                                if (roomForFacility != null)
                                {
                                    facilities.IsSelected = true;
                                    room.IsSelected = true;
                                    room.RoomFacilityRelationId = roomForFacility.Id;
                                }
                            }
                        }
                    }
                }
            }
            return facilityGroupList;
        }
    }
}
