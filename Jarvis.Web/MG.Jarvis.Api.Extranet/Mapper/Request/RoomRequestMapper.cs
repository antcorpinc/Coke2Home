using AutoMapper;
using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Room;
using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public static class RoomRequestMapper
    {
        
        /// <summary>
        /// Parameters for CreateRoomType Stored Procedure
        /// </summary>
        /// <param name="request"></param>
        /// <param name="occupancyId"></param>
        /// <returns></returns>
        public static DynamicParameters CreateRoomTypeParameters(HotelRoomTypeViewModel request, string userName)
        {
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.HotelId, request.HotelId);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomTypeId, request.RoomTypeId);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomName, request.Name);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomSize, request.Size);
            paramCollection.Add(Constants.StoredProcedureParameters.SizeMeasureId, request.SizeMeasureId);
            paramCollection.Add(Constants.StoredProcedureParameters.NoOfRooms, request.NoOfRooms);
            paramCollection.Add(Constants.StoredProcedureParameters.IsSmoking, request.IsSmoking);
            paramCollection.Add(Constants.StoredProcedureParameters.IsFreeSale, request.IsFreeSale);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomDescription, request.Description);
            paramCollection.Add(Constants.StoredProcedureParameters.OccupancyId, request.RoomBedOptions.OccupancyId);
            paramCollection.Add(Constants.StoredProcedureParameters.IsActive, request.IsActive);
            paramCollection.Add(Constants.StoredProcedureParameters.CreatedBy, userName);
            paramCollection.Add(Constants.StoredProcedureParameters.UpdatedBy, userName);
            return paramCollection;
        }

        public static DynamicParameters UpdateRoomTypeParameters(HotelRoomTypeViewModel request,string userName)
        {
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.RoomId, request.RoomId);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomTypeId, request.RoomTypeId);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomName, request.Name);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomSize, request.Size);
            paramCollection.Add(Constants.StoredProcedureParameters.SizeMeasureId, request.SizeMeasureId);
            paramCollection.Add(Constants.StoredProcedureParameters.NoOfRooms, request.NoOfRooms);
            paramCollection.Add(Constants.StoredProcedureParameters.IsSmoking, request.IsSmoking);
            paramCollection.Add(Constants.StoredProcedureParameters.IsFreeSale, request.IsFreeSale);
            paramCollection.Add(Constants.StoredProcedureParameters.RoomDescription, request.Description);
            paramCollection.Add(Constants.StoredProcedureParameters.OccupancyId, request.RoomBedOptions.OccupancyId);
            paramCollection.Add(Constants.StoredProcedureParameters.IsActive, request.IsActive);
            paramCollection.Add(Constants.StoredProcedureParameters.UpdatedBy, userName);
            paramCollection.Add(Constants.StoredProcedureParameters.UpdatedDate, Common.JakartaOffset(DateTime.Now));
            return paramCollection;
        }
        /// <summary>
        /// maps the model to RoomBedRelation Entity
        /// </summary>
        /// <param name="request"></param>
        /// <param name="hotelRoomId"></param>
        /// <returns></returns>
        public static BaseResult<List<RoomBedRelation>> CreateRoomBedRelation(HotelRoomTypeViewModel request, int hotelRoomId, string userName)
        {
            BaseResult<List<RoomBedRelation>> responseModel = new BaseResult<List<RoomBedRelation>>();
            var list = new List<RoomBedRelation>();
            foreach (var item in request.RoomBedOptions.RoomBedList)
            {
                RoomBedRelation roomBedRelation = new RoomBedRelation()
                {
                    HotelId = (int)request.HotelId,
                    BedId =(int) item.BedId,
                    NoOfBeds = (int)item.NoOfBeds,
                    HotelRoomId = hotelRoomId,
                    IsDeleted = false,
                    UpdatedBy = userName,
                    CreatedBy = userName
                };
                list.Add(roomBedRelation);

            }
            responseModel.Result = list;
            return responseModel;

        }
        /// <summary>
        /// maps the model to RoomBedRelation Entity
        /// </summary>
        /// <param name = "request" ></ param >
        /// < param name="hotelRoomId"></param>
        /// <returns></returns>
        public static BaseResult<RoomBedRelation> MapRoomBedRelationEntity(HotelRoomTypeViewModel request,RoomBedListViewModel item, int hotelRoomId, string userName)
        {
            BaseResult<RoomBedRelation> responseModel = new BaseResult<RoomBedRelation>();
            RoomBedRelation roomBedRelation = new RoomBedRelation()
            { 
                HotelId =(int) request.HotelId,
                BedId =(int) item.BedId,
                NoOfBeds = (int)item.NoOfBeds,
                HotelRoomId = hotelRoomId,
                IsDeleted = false,
                UpdatedBy = userName,
                CreatedBy=userName             
            };
            responseModel.Result = roomBedRelation;
            return responseModel;
        }
        /// <summary>
        /// Maps the HotelRooomViewModel to room
        /// </summary>
        /// <param name = "request" ></ param >
        /// < param name="roomFromDb"></param>
        /// <param name = "userName" ></ param >
        /// < returns ></ returns >
        public static Room AutoMapperRoom(HotelRoomTypeViewModel request, Room roomFromDb, string userName)
        {
            var roomMapped = AutoMapper.Mapper.Map<Room>(request);
            ResolveRemainingRoomParamters(roomMapped, roomFromDb, userName,(int)request.RoomBedOptions.OccupancyId);
            return roomMapped;
        }
        /// <summary>
        /// Resolve remaining parameters of room
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingRoomParamters(Room destination, Room source, string userName,int occupancyId)
        {
            destination.Code = source.Code;
            destination.CreatedBy = source.CreatedBy;
            destination.UpdatedBy = userName;
            destination.IsDeleted = source.IsDeleted;
            destination.DescriptionItemId = source.DescriptionItemId;
            destination.ExtraBedCount = source.ExtraBedCount;
            destination.LanguageID = source.LanguageID;
            destination.NameItemId = source.NameItemId;
            destination.NoOfGuests = occupancyId;
            destination.UpdatedDate = Common.JakartaOffset(DateTime.Now);
            destination.CreatedDate = source.CreatedDate;
        }
        /// <summary>
        /// Maps thr RoomBedlistViewModel to RoomBedRelation
        /// </summary>
        /// <param name="request"></param>
        /// <param name="roomFromDb"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static RoomBedRelation AutoMapperRoomBedRelation(RoomBedListViewModel request, RoomBedRelation roomFromDb, string userName)
        {
            var roomBedMapped = AutoMapper.Mapper.Map<RoomBedRelation>(request);
            ResolveRemainingParamters(roomBedMapped, roomFromDb, userName);
            return roomBedMapped;
        }
        /// <summary>
        /// Resolve remaining parameters of room bed relation
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamters(RoomBedRelation destination, RoomBedRelation source, string userName)
        {
           
            destination.CreatedBy = source.CreatedBy;
            destination.UpdatedBy = userName;
            destination.IsDeleted = source.IsDeleted;
            destination.HotelId = source.HotelId;
            destination.LanguageID = source.LanguageID;
            destination.HotelRoomId = source.HotelRoomId;
            destination.UpdatedDate = Common.JakartaOffset(DateTime.Now);
            destination.CreatedDate = source.CreatedDate;
            
        }
    }
    public class RoomIdResolver : IValueResolver<HotelRoomTypeViewModel, Room, int>
    {
        public int Resolve(HotelRoomTypeViewModel source, Room destination, int destMember, ResolutionContext context)
        {
            return source.RoomId;
        }
    }
  

}
