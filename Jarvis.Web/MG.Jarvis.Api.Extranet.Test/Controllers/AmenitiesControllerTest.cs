
using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Room;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    internal class AmenitiesControllerTest:BaseTestFixture
    {
        #region Private Variables
        private AmenitiesController mockAmenitiesController;
        private Mock<IAmenities> mockAmenitiesRepository;
        private Mock<IConfiguration> iConfiguration;
        private Mock<IRoom> mockRoomRepository;
        #endregion Private Variables

        #region Settings
        public AmenitiesControllerTest()
        {
            mockAmenitiesRepository = new Mock<IAmenities>();
            mockRoomRepository = new Mock<IRoom>();
            iConfiguration = new Mock<IConfiguration>();
            mockAmenitiesController = new AmenitiesController(mockAmenitiesRepository.Object, mockRoomRepository.Object,iConfiguration.Object);
        }
        #endregion Settings

        #region GetRoomFacilityGroups

        #region Negative Test Cases

        [Test]

        public async Task TestGetRoomFacilityGroups_Exception_InternalServerError()
        {
            int id = 1;
            //mockMasterDataRepository.Setup(a => a.GeHotelFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityGroup>> { IsError = true, ExceptionMessage = new Exception() }));
            mockAmenitiesRepository.Setup(a => a.GetRoomFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<RoomFacilityGroup>>() { Result = new List<RoomFacilityGroup> { new RoomFacilityGroup { Id = 1, Name = "Group1" } } }));
            mockAmenitiesRepository.Setup(a => a.GetRoomFacilityType()).Returns(Task.FromResult(new BaseResult<List<RoomFacilityType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            mockAmenitiesRepository.Setup(a => a.GetRoomFacility()).Returns(Task.FromResult(new BaseResult<List<RoomFacility>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            mockAmenitiesRepository.Setup(a => a.GetSelectedAmenities(id)).Returns(Task.FromResult(new BaseResult<List<RoomFacilityRelation>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            mockRoomRepository.Setup(a => a.GetRoomsByHotelId(It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<List<Room>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockAmenitiesController.GetRoomFacilityGroups(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetRoomFacilityGroups_EmptyResult_NoContentResponse()
        {
            int id = 1;
            mockAmenitiesRepository.Setup(a => a.GetRoomFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<RoomFacilityGroup>>()));
            mockAmenitiesRepository.Setup(a => a.GetRoomFacilityType()).Returns(Task.FromResult(new BaseResult<List<RoomFacilityType>>()));
            mockAmenitiesRepository.Setup(a => a.GetRoomFacility()).Returns(Task.FromResult(new BaseResult<List<RoomFacility>>()));
            mockAmenitiesRepository.Setup(a => a.GetSelectedAmenities(id)).Returns(Task.FromResult(new BaseResult<List<RoomFacilityRelation>> ()));
            mockRoomRepository.Setup(a => a.GetRoomsByHotelId(It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<List<Room>>()));
            IActionResult actioResult = await mockAmenitiesController.GetRoomFacilityGroups(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 204);

        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetRoomFacilityGroups_Success_OkResponse()
        {
            int id = 1;            
            mockAmenitiesRepository.Setup(a => a.GetRoomFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<RoomFacilityGroup>>() { Result = new List<RoomFacilityGroup> { new RoomFacilityGroup { Id = 1, Name = "Group1", IsActive = true } } }));
            mockAmenitiesRepository.Setup(a => a.GetRoomFacilityType()).Returns(Task.FromResult(new BaseResult<List<RoomFacilityType>>() { Result = new List<RoomFacilityType> { new RoomFacilityType { Id = 1, Name = "FacilityType1", FacilityGroupId = 1, IsActive = true } } }));
            mockAmenitiesRepository.Setup(a => a.GetRoomFacility()).Returns(Task.FromResult(new BaseResult<List<RoomFacility>>() { Result = new List<RoomFacility> { new RoomFacility { Id = 1, Name = "Facility1", FacilityTypeId = 1, FacilityGroupId = 1, IsActive = true } } }));
            mockAmenitiesRepository.Setup(a => a.GetSelectedAmenities(id)).Returns(Task.FromResult(new BaseResult<List<RoomFacilityRelation>> (){Result=new List<RoomFacilityRelation> { new RoomFacilityRelation { Id = 1, HotelRoomTypeId = id, FacilityId = 1 } } }));
            mockRoomRepository.Setup(a => a.GetRoomsByHotelId(It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<List<Room>> { Result=new List<Room> { new Room { Id=id,HotelId=id} } }));
            IActionResult actioResult = await mockAmenitiesController.GetRoomFacilityGroups(id);
            BaseResult<List<RoomFacilityGroupViewModel>> comnbinedRoomFacilityGroupList = (actioResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<RoomFacilityGroupViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 200);
            Assert.IsTrue(comnbinedRoomFacilityGroupList.Result.Count > 0);
            Assert.IsNotNull(comnbinedRoomFacilityGroupList);
            Assert.IsTrue(!comnbinedRoomFacilityGroupList.IsError);
            Assert.IsTrue(comnbinedRoomFacilityGroupList.Result != null);
        }
        #endregion Postive Test Cases

        #endregion GetRoomFacilityGroups


        #region CreateRoomFacilityRelation
        #region Negative test Cases
        [Test]
        public async Task TestCreateRoomFacilityRelation_Failed_BadRequest()
        {
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = null;
            //Act
            var result = await mockAmenitiesController.CreateRoomFacilityRelation(roomFacilities);
            //Assert         
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public async Task TestCreateRoomFacilityRelation_Failed_BadRequest1()
        {
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = new RoomFacilityGroupListViewModel()
            {
                HotelId = 1,
                ObjectState = ObjectState.Added,
            };
            RoomFacilityGroupViewModel facilityGroup = new RoomFacilityGroupViewModel()
            {
                Id = 1,
                Name = "Group1",
            };
            RoomFacilityTypeViewModel facilityType = new RoomFacilityTypeViewModel()
            {
                FacilityGroupId = 1,
            };
            RoomFacilityViewModel facility = new RoomFacilityViewModel()
            {
                Id = 1,
                Name = "facility1",
            };
            FacilitiesRoomList facilityRoom = null;
            facility.FacilitiesRoomList.Add(facilityRoom);
            facilityType.FacilityList.Add(facility);
            facilityGroup.RoomFacilityTypes.Add(facilityType);
            roomFacilities.FacilityGroupList.Add(facilityGroup);
            mockAmenitiesRepository.Setup(a => a.InsertAndUpdateRoomFacilityRelation(It.IsAny<RoomFacilityGroupListViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<long>() {Message="Room must be selected"}));
            //Act
            var result = await mockAmenitiesController.CreateRoomFacilityRelation(roomFacilities);
            //Assert         
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public async Task TestCreateRoomFacilityRelation_Failed_Error()
        {
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = new RoomFacilityGroupListViewModel()
            {
                HotelId = 1,
                ObjectState = ObjectState.Added,
            };
            RoomFacilityGroupViewModel facilityGroup = new RoomFacilityGroupViewModel()
            {
                Id = 1,
                Name = "Group1",
            };
            RoomFacilityTypeViewModel facilityType = new RoomFacilityTypeViewModel()
            {
                FacilityGroupId = 1,
            };
            RoomFacilityViewModel facility = new RoomFacilityViewModel()
            {
                Id = 1,
                Name = "facility1",
            };
            FacilitiesRoomList facilityRoom = new FacilitiesRoomList()
            {
                RoomTypeId=1,
                RoomName="Room1",
                IsSelected=true,
            };
            facility.FacilitiesRoomList.Add(facilityRoom);
            facilityType.FacilityList.Add(facility);
            facilityGroup.RoomFacilityTypes.Add(facilityType);
            roomFacilities.FacilityGroupList.Add(facilityGroup);
            mockAmenitiesRepository.Setup(a => a.InsertAndUpdateRoomFacilityRelation(It.IsAny<RoomFacilityGroupListViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException(),
            })).Verifiable();
            //Act
           
            IActionResult result = await mockAmenitiesController.CreateRoomFacilityRelation(roomFacilities);
            //Assert
            mockAmenitiesRepository.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);

        }
        #endregion
        #region  Positive test cases
        [Test]
        public async Task TestCreateRoomFacilityRelation_SuccessOkResponse()
        {
            var id = 1;
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = new RoomFacilityGroupListViewModel()
            {
                HotelId = 1,
                ObjectState = ObjectState.Added,
            };
            RoomFacilityGroupViewModel facilityGroup = new RoomFacilityGroupViewModel()
            {
                Id = 1,
                Name = "Group1",
            };
            RoomFacilityTypeViewModel facilityType = new RoomFacilityTypeViewModel()
            {
                FacilityGroupId = 1,
            };
            RoomFacilityViewModel facility = new RoomFacilityViewModel()
            {
                Id = 1,
                Name = "facility1",
                ObjectState=ObjectState.Added,
                FacilityGroupId=1,
                 IsSelected=true   

            };
            FacilitiesRoomList facilityRoom = new FacilitiesRoomList()
            {
                RoomTypeId = 1,
                RoomName = "Room1",
                IsSelected = true,
                ObjectState=ObjectState.Added
            };
            facility.FacilitiesRoomList.Add(facilityRoom);
            facilityType.FacilityList.Add(facility);
            facilityGroup.RoomFacilityTypes.Add(facilityType);
            roomFacilities.FacilityGroupList.Add(facilityGroup);
            mockAmenitiesRepository.Setup(a => a.InsertAndUpdateRoomFacilityRelation(It.IsAny<RoomFacilityGroupListViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1 }));
            //Act
            IActionResult result = await mockAmenitiesController.CreateRoomFacilityRelation(roomFacilities);
            BaseResult<long> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<long>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
            Assert.IsTrue(finalResult.Result== id);
        }
        [Test]
        public async Task TestCreateRoomFacilityRelationEdit_SuccessOkResponse()
        {
            var id = 1;
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = new RoomFacilityGroupListViewModel()
            {
                HotelId = 1,
                ObjectState = ObjectState.Added,
            };
            RoomFacilityGroupViewModel facilityGroup = new RoomFacilityGroupViewModel()
            {
                Id = 1,
                Name = "Group1",
            };
            RoomFacilityTypeViewModel facilityType = new RoomFacilityTypeViewModel()
            {
                FacilityGroupId = 1,
            };
            RoomFacilityViewModel facility = new RoomFacilityViewModel()
            {
                Id = 1,
                Name = "facility1",
                ObjectState = ObjectState.Deleted,
                FacilityGroupId = 1,
                IsSelected = true

            };
            FacilitiesRoomList facilityRoom = new FacilitiesRoomList()
            {
                RoomTypeId = 1,
                RoomName = "Room1",
                IsSelected = true,
                ObjectState = ObjectState.Deleted
            };
            facility.FacilitiesRoomList.Add(facilityRoom);
            facilityType.FacilityList.Add(facility);
            facilityGroup.RoomFacilityTypes.Add(facilityType);
            roomFacilities.FacilityGroupList.Add(facilityGroup);
            mockAmenitiesRepository.Setup(a => a.InsertAndUpdateRoomFacilityRelation(It.IsAny<RoomFacilityGroupListViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1 }));
            //Act
            IActionResult result = await mockAmenitiesController.CreateRoomFacilityRelation(roomFacilities);
            BaseResult<long> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<long>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
            Assert.IsTrue(finalResult.Result == id);
        }
        #endregion  Positive test cases

        #endregion CreateRoomFacilityRelation

        #region IsAmenitiesExits

        #region Negative Test Cases

        [Test]

        public async Task TestIsAmenitiesExits_Exception_InternalServerError()
        {
            //Arrange
            int id = 1;
            mockAmenitiesRepository.Setup(a => a.IsAmenitiesExits(It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true,ExceptionMessage=Helper.Common.GetMockException() })).Verifiable();
            //Act
            IActionResult actionResult = await mockAmenitiesController.GetRoomFacilityGroups(id);
            //Assert
            mockAmenitiesRepository.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestIsAmenitiesExits_Exception_BadRequest()
        {
            int id = -1;
            IActionResult actioResult = await mockAmenitiesController.GetRoomFacilityGroups(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 400);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestIsAmenitiesExits_Success_OkResponse()
        {
            //Arrange
            int id = 1;
            mockAmenitiesRepository.Setup(a => a.IsAmenitiesExits(It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<bool>() {Result=true})).Verifiable();
            //Act
            IActionResult actionResult = await mockAmenitiesController.GetRoomFacilityGroups(id);
            //Assert
            mockAmenitiesRepository.Verify();
            BaseResult<bool> result = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<bool>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(!result.IsError);
            Assert.AreEqual(result.Result, true);
        }
        #endregion Postive Test Cases

        #endregion IsAmenitiesExits


    }
}

