using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    internal class RoomRepositoryTest:BaseTestFixture
    {
        private IRoom roomRepository;
        private Mock<IConnection<SizeMeasure>> iSizeMeasureLibrary;
        private Mock<IConnection<Occupancy>> iOccupancyLibrary;
        private Mock<IConnection<RoomType>> iRoomTypeLibrary;
        private Mock<IConnection<Bed>> iBedLibrary;
        private Mock<IConnection<Room>> iRoomLibrary;
        private Mock<IConnection<RoomBedRelation>> iRoomBedRelationLibrary;
        private Mock<IConnection<SmokingPolicy>> iSmokingPolicyLibrary;
        public RoomRepositoryTest()
        {
          
            iSizeMeasureLibrary = new Mock<IConnection<SizeMeasure>>();
            iOccupancyLibrary = new Mock<IConnection<Occupancy>>();
            iRoomBedRelationLibrary = new Mock<IConnection<RoomBedRelation>>();
            iRoomTypeLibrary = new Mock<IConnection<RoomType>>();
            iBedLibrary = new Mock<IConnection<Bed>>();
            iRoomLibrary = new Mock<IConnection<Room>>();
            iSmokingPolicyLibrary = new Mock<IConnection<SmokingPolicy>>();
            roomRepository = new RoomRepository(iRoomTypeLibrary.Object, iRoomLibrary.Object, iOccupancyLibrary.Object, iSmokingPolicyLibrary.Object, iBedLibrary.Object, iSizeMeasureLibrary.Object, iRoomBedRelationLibrary.Object);
        }
        [Test]
        public void TestGetRoomType_ListOfRoomTypes()
        {
            //Arrange
            int id = 1;
            var roomTypes = new RoomType() { Id = id, Name = "Group1", IsDeleted = false };
            var baseResult = new BaseResult<List<RoomType>>() { Result = new List<RoomType>() { roomTypes } };
            iRoomTypeLibrary.Setup(a => a.GetList()).Returns(Task.FromResult(baseResult));
            //Act
            var roomList = roomRepository.GetRoomType();
            //Assert
            Assert.IsTrue(roomList != null);
            Assert.IsTrue(roomList.Result is BaseResult<List<RoomType>>);
            Assert.IsTrue(roomList.Result.Result.Exists(x=>x.Id==id));

        }
  
         [Test]
        public void TestGetRoomsByHotelId_ListOfRooms()
        {
            //Arrange
            int id = 1;
            var room = new Room() { Id = id, Name = "Room1",HotelId=id, IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            var pred = new Func<Room, bool>(x => x.IsActive && !x.IsDeleted);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            var roomList = roomRepository.GetRoomsByHotelId(id);
            //Assert
            Assert.IsTrue(roomList != null);
            Assert.IsTrue(roomList.Result is BaseResult<List<Room>>);
            Assert.IsTrue(roomList.Result.Result.Exists(x=>x.Id==id));

        }
        [Test]
        public void TestGetBed_ListOfBed()
        {
            //Arrange
            int id = 1;
            var bed = new Bed() { Id = id, Name = "bed1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Bed>>() { Result = new List<Bed>() { bed } };
            var pred = new Func<Bed, bool>(x => x.IsActive && !x.IsDeleted);
            iBedLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Bed, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            var bedList = roomRepository.GetBed();
            //Assert
            Assert.IsTrue(bedList != null);
            Assert.IsTrue(bedList.Result is BaseResult<List<Bed>>);
            Assert.IsTrue(bedList.Result.Result.Exists(x=>x.Id==id));

        }
       
        [Test]
        public void TestGetSizeMeasure_ListOfSizeMeasures()
        {
            //Arrange
            int id = 1;
            var sizeMeasure = new SizeMeasure() { Id = id, Name = "sizemeasure1", IsActive = true };
            var baseResult = new BaseResult<List<SizeMeasure>>() { Result = new List<SizeMeasure>() { sizeMeasure } };
            var pred = new Func<SizeMeasure, bool>(x => x.IsActive);
            iSizeMeasureLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<SizeMeasure, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            var sizeMeasureList = roomRepository.GetSizeMeasure();
            //Assert
            Assert.IsTrue(sizeMeasureList != null);
            Assert.IsTrue(sizeMeasureList.Result is BaseResult<List<SizeMeasure>>);
            Assert.IsTrue(sizeMeasureList.Result.Result.Exists(x=>x.Id==id));

        }

        [Test]
        public void TestGetRoomDetailsByRoomId_Failed_Error()
        {
            //Arrange
            int id = 1;
            var baseResult = new BaseResult<List<Room>>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() };
            var pred = new Func<Room, bool>(x => x.Id == id && x.IsDeleted == false);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            var baseResult1 = new BaseResult<List<RoomBedRelation>>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() };
            var pred1 = new Func<RoomBedRelation, bool>(x => x.HotelRoomId == id && x.IsDeleted == false);
            iRoomBedRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomBedRelation, bool>>(x => x.GetType() == pred1.GetType()))).Returns(Task.FromResult(baseResult1)).Verifiable();
            //Act
            var room = roomRepository.GetRoomDetailsByRoomId(id);
            //Assert
            iRoomLibrary.Verify();
            Assert.IsTrue(room.Result.IsError);
            Assert.IsTrue(room.Result.ExceptionMessage != null);
        }
        [Test]
        public void TestGetRoomDetailsByRoomId_Success_Room()
        {
            //Arrange
            int id = 1;
            var baseResult = new BaseResult<List<Room>>() { Result=new List<Room> { new Room() {Id=1,IsDeleted=false } } };
            var pred = new Func<Room, bool>(x => x.Id == id && x.IsDeleted == false);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            var baseResult1 = new BaseResult<List<RoomBedRelation>>() {Result=new List<RoomBedRelation>() { new RoomBedRelation() { HotelRoomId=id,ID=1,IsDeleted=false} } };
            var pred1 = new Func<RoomBedRelation, bool>(x => x.HotelRoomId == id && x.IsDeleted == false);
            iRoomBedRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomBedRelation, bool>>(x => x.GetType() == pred1.GetType()))).Returns(Task.FromResult(baseResult1)).Verifiable();
            //Act
            var room = roomRepository.GetRoomDetailsByRoomId(id);
            //Assert
            iRoomLibrary.Verify();
            Assert.IsTrue(room != null);
            Assert.IsTrue(room.Result is BaseResult<HotelRoomTypeViewModel>);
            Assert.IsTrue(room.Result.Result.RoomId == id);
        }

        [Test]
        public void TestCreateRoomType_RoomSavePassed_Success()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 0,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Added
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Added
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Added
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            var room = new Room() { Id = 1 };
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            iRoomLibrary.Setup(a => a.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(baseResult));
            //Act
            var result = roomRepository.SaveAndUpdateRoom(hotelRoomObject,userName);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result is BaseResult<List<Room>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.Id == id));
        }
        [Test]
        public void TestCreateRoomType_RoomEditPassed_Success()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 1,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Modified
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Modified
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                RoomId=1,
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Modified
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            var room = new Room() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            var pred = new Func<Room, bool>(x => x.Id == id && x.IsDeleted == false);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Room>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true })).Verifiable();
            //Act
            var result = roomRepository.SaveAndUpdateRoom(hotelRoomObject, userName);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result is BaseResult<List<Room>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.Id == id));
        }
        [Test]
        public void TestCreateRoomType_SaveRoom_Failed()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 0,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Added
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Added
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Added
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            var room = new Room() { Id = 1 };
            var baseResult = new BaseResult<List<Room>>() { IsError=true,ExceptionMessage=Helper.Common.GetMockException()};
            iRoomLibrary.Setup(a => a.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(baseResult));
            //Act
            var result = roomRepository.SaveAndUpdateRoom(hotelRoomObject, userName);
            //Assert
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result.IsError);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }
        [Test]
        public void TestCreateRoomType_EditRoom_Failed()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 1,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Modified
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Modified
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                RoomId=id,
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Modified
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            var room = new Room() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            var pred = new Func<Room, bool>(x => x.Id == id && x.IsDeleted == false);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Room>())).Returns(Task.FromResult(new BaseResult<bool> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() })).Verifiable();
            //Act
            var result = roomRepository.SaveAndUpdateRoom(hotelRoomObject, userName);
            //Assert
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result.IsError);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }

        [Test]
        public void TestDeleteRoomById_Success_True()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var room = new Room() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            var pred = new Func<Room, bool>(x => x.Id == id && x.IsDeleted == false);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Room>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true })).Verifiable();
            //Act
            var result = roomRepository.DeleteRoomById(id, userName);
            //Assert 
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.Result == true);
        }
        
        [Test]
        public void TestDeleteRoomById_Failed_Error()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var room = new Room() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            var pred = new Func<Room, bool>(x => x.Id == id && x.IsDeleted == false);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Room>())).Returns(Task.FromResult(new BaseResult<bool> { IsError=true,ExceptionMessage=Helper.Common.GetMockException() })).Verifiable();
            //Act
            var result = roomRepository.DeleteRoomById(id, userName);
            //Assert 
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.IsError == true);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }

        [Test]
        public void TestDeleteRoomBedRelationById_Success_True()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var room = new RoomBedRelation() {ID=id, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<RoomBedRelation>>() { Result = new List<RoomBedRelation>() { room } };
            var pred = new Func<RoomBedRelation, bool>(x => x.ID == id && x.IsDeleted == false);
            iRoomBedRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomBedRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomBedRelationLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<RoomBedRelation>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true })).Verifiable();
            //Act
            var result = roomRepository.DeleteRoomBedRelationById(id, userName);
            //Assert 
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.Result == true);
        }

        [Test]
        public void TestDeleteRoomBedRelationById_Failed_Error()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var room = new RoomBedRelation() { ID = id, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<RoomBedRelation>>() { Result = new List<RoomBedRelation>() { room } };
            var pred = new Func<RoomBedRelation, bool>(x => x.ID == id && x.IsDeleted == false);
            iRoomBedRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomBedRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomBedRelationLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<RoomBedRelation>())).Returns(Task.FromResult(new BaseResult<bool> { IsError=true,ExceptionMessage=Helper.Common.GetMockException() })).Verifiable();
            //Act
            var result = roomRepository.DeleteRoomBedRelationById(id, userName);
            //Assert 
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.IsError == true);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }

        [Test]
        public void TestSaveAndUpdateRoomBedRelation_SavePassed_Success()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 0,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Added
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Added
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Added
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            iRoomBedRelationLibrary.Setup(a => a.InsertEntityList(It.IsAny<List<RoomBedRelation>>())).Returns(Task.FromResult( new BaseResult<long>{ Result=id}));
            //Act
            var result = roomRepository.SaveAndUpdateRoomBedRelation(hotelRoomObject,id, userName);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result is BaseResult<RoomBedRelation>);
            Assert.IsTrue(result.Result.Result.ID == id);
        }
        [Test]
        public void TestSaveAndUpdateRoomBedRelation_RoomEditPassed_Success()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 1,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Modified
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Modified
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                RoomId = 1,
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Modified
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            var room = new Room() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            var pred = new Func<Room, bool>(x => x.Id == id && x.IsDeleted == false);
            iRoomLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Room, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Room>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true })).Verifiable();
            //Act
            var result = roomRepository.SaveAndUpdateRoom(hotelRoomObject, userName);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result is BaseResult<List<Room>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.Id == id));
        }
        [Test]
        public void TestSaveAndUpdateRoomBedRelation_SaveRoom_Failed()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 0,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Added
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Added
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Added
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            iRoomBedRelationLibrary.Setup(a => a.InsertEntityList(It.IsAny<List<RoomBedRelation>>())).Returns(Task.FromResult(new BaseResult<long> {IsError=true,ExceptionMessage=Helper.Common.GetMockException() }));
            //Act
            var result = roomRepository.SaveAndUpdateRoomBedRelation(hotelRoomObject, id, userName);
            //Assert
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result.IsError);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }
        [Test]
        public void TestSaveAndUpdateRoomBedRelation_EditRoom_Failed()
        {
            //Arrange
            var userName = "MGUSER";
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID = 1,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Modified
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState = ObjectState.Modified
            };
            roomBedOptionObject.RoomBedList.Add(roombedObject);
            var hotelRoomObject = new HotelRoomTypeViewModel()
            {
                RoomId = id,
                IsActive = true,
                HotelId = 1,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 2,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Unchanged
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            var room = new RoomBedRelation() { ID = id, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<RoomBedRelation>>() { Result = new List<RoomBedRelation>() { room } };
            var pred = new Func<RoomBedRelation, bool>(x => x.ID == id && x.IsDeleted == false);
            iRoomBedRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomBedRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iRoomBedRelationLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<RoomBedRelation>())).Returns(Task.FromResult(new BaseResult<bool> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() })).Verifiable();
            //Act
            var result = roomRepository.SaveAndUpdateRoomBedRelation(hotelRoomObject,id, userName);
            //Assert
            iRoomLibrary.Verify();
            Assert.IsTrue(result.Result.IsError);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }
    }
}
