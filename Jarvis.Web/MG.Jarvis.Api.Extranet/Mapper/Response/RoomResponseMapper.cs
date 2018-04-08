using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class RoomResponseMapper
    {
        /// <summary>
        /// Maps list of room type to RoomTypeViewModel
        /// </summary>
        /// <param name="roomTypeList"></param>
        /// <returns>List<RoomTypeViewModel></returns>
        public static BaseResult<List<RoomTypeViewModel>> MapRoomType(BaseResult<List<RoomType>> roomTypeList)
        {
            BaseResult<List<RoomTypeViewModel>> responseModelList = new BaseResult<List<RoomTypeViewModel>>();
            List<RoomTypeViewModel> modelList = new List<RoomTypeViewModel>();
            foreach (var item in roomTypeList.Result)
            {

                RoomTypeViewModel roomTypeModel = new RoomTypeViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(roomTypeModel);
            }
            responseModelList.Result = modelList;

            return responseModelList;
        }

        /// <summary>
        /// Maps list of room type to RoomTypeViewModel
        /// </summary>
        /// <param name="roomTypeList"></param>
        /// <returns>List of GetRoomViewModel></returns>
        public static BaseResult<List<GetRoomViewModel>> MapRoomsByHotelId(BaseResult<List<Room>> roomList)
        {
            BaseResult<List<GetRoomViewModel>> responseModelList = new BaseResult<List<GetRoomViewModel>>();
            List<GetRoomViewModel> modelList = new List<GetRoomViewModel>();
            foreach (var item in roomList.Result)
            {
                GetRoomViewModel roomModel = new GetRoomViewModel
                {
                    RoomId = item.Id,
                    HotelId = item.HotelId,
                    RoomName = item.Name,
                    NoOfRooms = item.NoOfRooms,
                    IsFreeSale = item.IsFreeSale,
                    NoOfGuests = item.NoOfGuests,
                    IsActive = item.IsActive,
                    RoomCode=item.Code

                };
                modelList.Add(roomModel);
            }
            responseModelList.Result = modelList;
            return responseModelList;
        }
        #region room
        /// <summary>
        /// Maps to Hotelroom view model
        /// </summary>
        /// <param name="room"></param>
        /// <param name="roomBed"></param>
        /// <returns>BaseResult<HotelRoomTypeViewModel></returns>
        public static BaseResult<HotelRoomTypeViewModel> MapRoomDetails(Room room, List<RoomBedRelation> roomBed)
        {
            BaseResult<HotelRoomTypeViewModel> model = new BaseResult<HotelRoomTypeViewModel>();
            List<RoomBedListViewModel> roomBedList = new List<RoomBedListViewModel>();
            HotelRoomTypeViewModel roomModel = new HotelRoomTypeViewModel
            {
                RoomId=room.Id,
                HotelId = room.HotelId,
                IsActive = room.IsActive,
                IsFreeSale = room.IsFreeSale,
                IsSmoking = room.IsSmoking,
                NoOfRooms = room.NoOfRooms,    
                Description = room.Description,
                Name = room.Name,
                Size = room.Size,
                RoomTypeId = room.RoomTypeId,
                SizeMeasureId = room.SizeMeasureId,
            };
            foreach (var item in roomBed)
            {
                RoomBedListViewModel roomBedModel = new RoomBedListViewModel
                {
                    ID = item.ID,
                    BedId = item.BedId,
                    NoOfBeds = item.NoOfBeds
                };
                roomBedList.Add(roomBedModel);
            }
            RoomBedOptionViewModel roomBedOptionModel = new RoomBedOptionViewModel
            {
                OccupancyId = room.NoOfGuests,
            };
            roomBedOptionModel.RoomBedList = roomBedList;
            roomModel.RoomBedOptions = roomBedOptionModel;
            model.Result = roomModel;
            return model;
        }
        #endregion
    }
}
