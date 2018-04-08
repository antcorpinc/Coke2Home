using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    internal class RoomControllerTest
    {
        private RoomController mockRoomController;
        private Mock<IRoom> mockRoomRepository;
        private Mock<IMasterData> mockMasterDataRepository;

        public RoomControllerTest()
        {
            mockRoomRepository = new Moq.Mock<IRoom>();
            mockMasterDataRepository = new Moq.Mock<IMasterData>();
            mockRoomController = new RoomController(mockRoomRepository.Object, mockMasterDataRepository.Object);
        }

        #region GetRoomType

        #region Negative Test Cases
        [Test]
        public async Task TestGetRoomType_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RoomTypeList);
            mockRoomRepository.Setup(a => a.GetRoomType()).Returns(Task.FromResult(new BaseResult<List<RoomType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockRoomController.GetRoomType();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);
        }

        [Test]
        public async Task TestGetRoomType_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RoomTypeList);
            mockRoomRepository.Setup(a => a.GetRoomType()).Returns(Task.FromResult(new BaseResult<List<RoomType>>()));
            IActionResult actionResult = await mockRoomController.GetRoomType();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetRoomType_Success_OkResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RoomTypeList);
            mockRoomRepository.Setup(a => a.GetRoomType()).Returns(Task.FromResult(new BaseResult<List<RoomType>>() { Result = new List<RoomType> { new RoomType { Id = 1, Name = "Single" } } }));
            IActionResult actionResult = await mockRoomController.GetRoomType();
            BaseResult<List<RoomTypeViewModel>> roomTypeList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<RoomTypeViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(roomTypeList.Result.Count > 0);
            Assert.IsNotNull(roomTypeList);
            Assert.IsTrue(!roomTypeList.IsError);
            Assert.IsTrue(roomTypeList.Result != null);

            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<RoomTypeViewModel>>(Constants.CacheKeys.RoomTypeList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RoomTypeList);

        }
        
        #endregion Postive Test Cases

        #endregion GetRoomType

        #region GetBed

        #region Negative Test Cases
        [Test]
        public async Task TestGetBed_Exception_InternalServerError()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.BedList);
            mockRoomRepository.Setup(a => a.GetBed()).Returns(Task.FromResult(new BaseResult<List<Bed>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockRoomController.GetBed();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetBed_EmptyResult_NoContentResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.BedList);
            mockRoomRepository.Setup(a => a.GetBed()).Returns(Task.FromResult(new BaseResult<List<Bed>>()));
            IActionResult actionResult = await mockRoomController.GetBed();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);

        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetBed_Success_OkResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.BedList);
            mockRoomRepository.Setup(a => a.GetBed()).Returns(Task.FromResult(new BaseResult<List<Bed>>() { Result = new List<Bed> { new Bed { Id = 1, Name = "Bed1", IsActive = true } } }));
            IActionResult actionResult = await mockRoomController.GetBed();
            BaseResult<List<BedViewModel>> BedList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<BedViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(BedList.Result.Count > 0);
            Assert.IsNotNull(BedList);
            Assert.IsTrue(!BedList.IsError);

            Assert.IsTrue(BedList.Result != null);

            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<Bed>>(Constants.CacheKeys.BedList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.BedList);

        }
        #endregion Postive Test Cases

        #endregion GetBed

        #region GetSizeMeasure

        #region Negative Test Cases
        [Test]
        public async Task TestGetSizeMeasure_Exception_InternalServerError()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SizeMeasureList);
            mockRoomRepository.Setup(a => a.GetSizeMeasure()).Returns(Task.FromResult(new BaseResult<List<SizeMeasure>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockRoomController.GetSizeMeasure();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetSizeMeasure_EmptyResult_NoContentResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SizeMeasureList);
            mockRoomRepository.Setup(a => a.GetSizeMeasure()).Returns(Task.FromResult(new BaseResult<List<SizeMeasure>>()));
            IActionResult actionResult = await mockRoomController.GetSizeMeasure();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);

        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetSizeMeasure_Success_OkResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SizeMeasureList);
            mockRoomRepository.Setup(a => a.GetSizeMeasure()).Returns(Task.FromResult(new BaseResult<List<SizeMeasure>>() { Result = new List<SizeMeasure> { new SizeMeasure { Id = 1, Name = "SizeMeasure1", IsActive = true } } }));
            IActionResult actionResult = await mockRoomController.GetSizeMeasure();
            BaseResult<List<SizeMeasureViewModel>> sizeMeasureList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<SizeMeasureViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(sizeMeasureList.Result.Count > 0);
            Assert.IsNotNull(sizeMeasureList);
            Assert.IsTrue(!sizeMeasureList.IsError);

            Assert.IsTrue(sizeMeasureList.Result != null);

            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<SizeMeasure>>(Constants.CacheKeys.SizeMeasureList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SizeMeasureList);

        }
        #endregion Postive Test Cases

        #endregion GetSizeMeasure

        #region GetSmokingPolicy

        #region Negative Test Cases
        [Test]
        public async Task TestGetSmokingPolicy_Exception_InternalServerError()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SmokingPolicyList);
            mockRoomRepository.Setup(a => a.GetSmokingPolicy()).Returns(Task.FromResult(new BaseResult<List<SmokingPolicy>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockRoomController.GetSmokingPolicy();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetSmokingPolicy_EmptyResult_NoContentResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SmokingPolicyList);
            mockRoomRepository.Setup(a => a.GetSmokingPolicy()).Returns(Task.FromResult(new BaseResult<List<SmokingPolicy>>()));
            IActionResult actionResult = await mockRoomController.GetSmokingPolicy();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);

        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetSmokingPolicy_Success_OkResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SmokingPolicyList);
            mockRoomRepository.Setup(a => a.GetSmokingPolicy()).Returns(Task.FromResult(new BaseResult<List<SmokingPolicy>>() { Result = new List<SmokingPolicy> { new SmokingPolicy { Id = 1, Name = "Policy1", IsActive = true } } }));
            IActionResult actionResult = await mockRoomController.GetSmokingPolicy();
            BaseResult<List<SmokingPolicyViewModel>> SmokingPolicyList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<SmokingPolicyViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(SmokingPolicyList.Result.Count > 0);
            Assert.IsNotNull(SmokingPolicyList);
            Assert.IsTrue(!SmokingPolicyList.IsError);

            Assert.IsTrue(SmokingPolicyList.Result != null);

            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<SmokingPolicy>>(Constants.CacheKeys.SmokingPolicyList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.SmokingPolicyList);

        }
        #endregion Postive Test Cases

        #endregion GetSmokingPolicy

        #region GetRoomsByHotelId

        #region Negative Test Cases
        [Test]
        public async Task TestGetRoomsByHotelId_Exception_InternalServerError()
        {
            //Arrange
            var id = 1;
           // mockRoomRepository.Setup(a => a.GetOccupancy()).Returns(Task.FromResult(new BaseResult<List<Occupancy>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            mockRoomRepository.Setup(a => a.GetRoomsByHotelId(id)).Returns(Task.FromResult(new BaseResult<List<Room>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));

            //Act
            IActionResult actionResult = await mockRoomController.GetRoomsByHotelId(id);
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);
        }

        [Test]
        public async Task TestGetRoomsByHotelId_EmptyResult_NoContentResponse()
        {
            //Arrange
            var id = 1;
            //mockRoomRepository.Setup(a => a.GetOccupancy()).Returns(Task.FromResult(new BaseResult<List<Occupancy>>()));
            mockRoomRepository.Setup(a => a.GetRoomsByHotelId(id)).Returns(Task.FromResult(new BaseResult<List<Room>>()));
            //Act
            IActionResult actionResult = await mockRoomController.GetRoomsByHotelId(id);
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetRoomsByHotelId_Success_OkResponse()
        {
            //Arrange
            var id = 1;
           // mockRoomRepository.Setup(a => a.GetOccupancy()).Returns(Task.FromResult(new BaseResult<List<Occupancy>>() { Result = new List<Occupancy> { new Occupancy { Id = 1, NoOfGuest = 2, IsActive = true } } }));
            mockRoomRepository.Setup(a => a.GetRoomsByHotelId(id)).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = new List<Room> { new Room { Id = 1, HotelId = id, IsActive = true } } }));
            //Act
            IActionResult actionResult = await mockRoomController.GetRoomsByHotelId(id);
            BaseResult<List<GetRoomViewModel>> roomTypeList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<GetRoomViewModel>>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(roomTypeList.Result.Count > 0);
            Assert.IsNotNull(roomTypeList);
            Assert.IsTrue(!roomTypeList.IsError);
            Assert.IsTrue(roomTypeList.Result != null);
        }
        #endregion Postive Test Cases

        #endregion GetRoomsByHotelId

        #region CreateRoomType
        #region Negative test Cases
        [Test]
        public async Task TestCreateRoomType_Failed_BadRequest()
        {

            //Arrange
     
            var id = 1;
            var roombedObject = new RoomBedListViewModel()
            {
                ID=0,
                BedId = id,
                NoOfBeds = 2,
                ObjectState = ObjectState.Added
            };
            var roomBedOptionObject = new RoomBedOptionViewModel()
            {
                OccupancyId = id,
                ObjectState=ObjectState.Added
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
                ObjectState=ObjectState.Added,
                NoOfDoubleRooms=0,
                NoOfTwinRooms=0,               
            };

            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            //Act
            var result = await mockRoomController.CreateRoomType(hotelRoomObject);
            //Assert
            mockRoomRepository.Verify();
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public async Task TestCreateRoomType_Failed_Error()
        {
            //Arrange
           
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
                NoOfRooms = 4,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Added
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            mockRoomRepository.Setup(a => a.SaveAndUpdateRoom(It.IsAny<HotelRoomTypeViewModel>(),It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<List<Room>>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            mockRoomRepository.Setup(a => a.SaveAndUpdateRoomBedRelation(It.IsAny<HotelRoomTypeViewModel>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<RoomBedRelation>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
          //  mockRoomRepository.Setup(a => a.GetOccupancy()).Returns(Task.FromResult(new BaseResult<List<Occupancy>>() { Result = new List<Occupancy> { new Occupancy { Id = 1, NoOfGuest = 2, IsActive = true } } }));
            var result =await  mockRoomController.CreateRoomType(hotelRoomObject);
            //Assert
            //mockRoomRepository.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);
        }

        #endregion
        [Test]
        public async Task TestCreateRoomType_SuccessOkResponse()
        {
            //Arrange

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
                RoomId=0,
                IsActive = true,
                HotelId = id,
                IsFreeSale = true,
                IsSmoking = true,
                NoOfRooms = 4,
                Description = "Description",
                Name = "Name",
                Size = 5,
                RoomTypeId = id,
                SizeMeasureId = id,
                ObjectState = ObjectState.Added
            };
            hotelRoomObject.RoomBedOptions = roomBedOptionObject;
            mockRoomRepository.Setup(a => a.SaveAndUpdateRoom(It.IsAny<HotelRoomTypeViewModel>(),It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = new List<Room>() { new Room() { Id = id } } }));
            mockRoomRepository.Setup(a => a.SaveAndUpdateRoomBedRelation(It.IsAny<HotelRoomTypeViewModel>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<RoomBedRelation>() { Result = new RoomBedRelation { ID=id} }));
           // mockRoomRepository.Setup(a => a.GetOccupancy()).Returns(Task.FromResult(new BaseResult<List<Occupancy>>() { Result = new List<Occupancy> { new Occupancy { Id = 1, NoOfGuest = 2, IsActive = true } } }));
            //Act
            IActionResult result = await mockRoomController.CreateRoomType(hotelRoomObject);
            BaseResult<List<Room>> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<Room>>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
        }


        #endregion

        #region DeleteRoomBedRelationById
        #region Positive Test Case
        [Test]
        public async Task TestDeleteRoomBedRelationById_Success_OkResponse()
        {
            // Arrange
            var id = 1;
            mockRoomRepository.Setup(a => a.DeleteRoomBedRelationById(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true })).Verifiable();
            //Act
            var result = await mockRoomController.DeleteRoomBedRelationById(id);
            BaseResult<bool> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<bool>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
        }
        #endregion
        #region Negative Test Case
        [Test]
        public async Task TestDeleteRoomBedRelationById_Failed_BadRequest()
        {
            // Arrange
            var id = -1;
            mockRoomRepository.Setup(a => a.DeleteRoomBedRelationById(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));
            //Act
            var result = await mockRoomController.DeleteRoomBedRelationById(id);
            //Assert
        
            Assert.IsTrue(result is BadRequestResult);
            Assert.AreEqual(((BadRequestResult)result).StatusCode, 400);
        }
        [Test]
        public async Task TestDeleteRoomBedRelationById_Failed_Error()
        {
            // Arrange
            var id = 1;
            mockRoomRepository.Setup(a => a.DeleteRoomBedRelationById(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError=true,ExceptionMessage=Helper.Common.GetMockException() })).Verifiable();
            //Act
            var result = await mockRoomController.DeleteRoomBedRelationById(id);
            //Assert
            mockRoomRepository.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);
        }
        [Test]
        public async Task TestDeleteRoomBedRelationById_Failed_NoContentResponse()
        {
            // Arrange
            var id = 1;
            mockRoomRepository.Setup(a => a.DeleteRoomBedRelationById(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>())).Verifiable();
            //Act
            var result = await mockRoomController.DeleteRoomBedRelationById(id);
            //Assert
            mockRoomRepository.Verify();
            Assert.IsTrue(result is NoContentResult);
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 204);
        }
        #endregion
        #endregion

        #region DeleteRoomById
        #region Positive Test Case
        [Test]
        public async Task TestDeleteRoomById_Success_OkResponse()
        {
            // Arrange
            var id = 1;
            mockRoomRepository.Setup(a => a.DeleteRoomById (It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));
            //Act
            var result = await mockRoomController.DeleteRoomById(id);
            BaseResult<bool> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<bool>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
        }
        #endregion
        #region Negative Test Case
        [Test]
        public async Task TestDeleteRoomById_Failed_BadRequest()
        {
            // Arrange
            var id = -1;
            mockRoomRepository.Setup(a => a.DeleteRoomById(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));
            //Act
            var result = await mockRoomController.DeleteRoomById(id);
            //Assert
            mockRoomRepository.Verify();
            Assert.IsTrue(result is BadRequestResult);
            Assert.AreEqual(((BadRequestResult)result).StatusCode, 400);
        }
        [Test]
        public async Task TestDeleteRoomById_Failed_Error()
        {
            // Arrange
            var id = 1;
            mockRoomRepository.Setup(a => a.DeleteRoomById(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            //Act
            var result = await mockRoomController.DeleteRoomById(id);
            //Assert
            mockRoomRepository.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);
        }
        [Test]
        public async Task TestDeleteRoomById_Failed_NoContentResponse()
        {
            // Arrange
            var id = 1;
            mockRoomRepository.Setup(a => a.DeleteRoomById(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>()));
            //Act
            var result = await mockRoomController.DeleteRoomById(id);
            //Assert
            mockRoomRepository.Verify();
            Assert.IsTrue(result is NoContentResult);
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 204);
        }
        #endregion
        #endregion

    }
}
