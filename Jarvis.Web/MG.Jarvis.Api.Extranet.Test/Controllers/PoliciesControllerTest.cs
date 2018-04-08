using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.Room;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using ER = MG.Jarvis.Api.Extranet.Repositories;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    public class PoliciesControllerTest
    {
        #region Private Variables
        private PoliciesController policiesController;
        private IPolicies policiesRepository;

        private IConnection<ChildrenAndExtraBedPolicies> iChildrenAndExtraBedPoliciesConnectionLibrary;
        private IConnection<MaxChildAndExtraBedPerRoom> iMaxChildAndExtraBedPerRoomConnectionLibrary;
        private IConnection<CancellationCharges> iCancellationChargesConnectionLibrary;
        private IConnection<CancellationPolicy> iCancellationPolicyConnectionLibrary;
        private IConnection<CancellationPolicyClauses> iCancellationPolicyClausesConnectionLibrary;
        private IConnection<CancellationPolicyType> iCancellationPolicyTypeConnectionLibrary;
        private IConnection<Room> iRoomConnectionLibrary;


        private PoliciesController mockPoliciesController;
        private Mock<IPolicies> mockPoliciesRepository;
        public IConfigurationRoot Configuration { get; }
        #endregion Private Variables

        #region Settings
        public PoliciesControllerTest()
        {
            mockPoliciesRepository = new Moq.Mock<IPolicies>();
            mockPoliciesController = new PoliciesController(mockPoliciesRepository.Object);

            policiesRepository = new ER.PoliciesRepository(iChildrenAndExtraBedPoliciesConnectionLibrary, iMaxChildAndExtraBedPerRoomConnectionLibrary, iCancellationChargesConnectionLibrary, iCancellationPolicyConnectionLibrary,
                                     iCancellationPolicyClausesConnectionLibrary, iCancellationPolicyTypeConnectionLibrary, iRoomConnectionLibrary);

            policiesController = new PoliciesController(policiesRepository);
        }
        #endregion Settings

        #region ChildAndExtraBedPolicy

        #region GetChildrenAndExtraBedPolicyListingByHotelId
        #region Negative Test Cases
        [Test]
        public void TestGetChildrenAndExtraBedPolicyListingByHotelId_Exception_InternalServerError()
        {
            int hotelId = 5;
            mockPoliciesRepository.Setup(a => a.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<ChildrenAndExtraBedPolicies>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPoliciesController.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetChildrenAndExtraBedPolicyListingByHotelId_EmptyResult_NoContentResponse()
        {
            int hotelId = 5;
            mockPoliciesRepository.Setup(a => a.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<ChildrenAndExtraBedPolicies>> { Result = new List<ChildrenAndExtraBedPolicies>() }));
            mockPoliciesRepository.Setup(a => a.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<ChildrenAndExtraBedPolicies>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockPoliciesController.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Positive Test Cases
        [Test]
        public async Task TestGetChildrenAndExtraBedPolicyListingByHotelId_Success_OkResponse()
        {
            int hotelId = 5;
            mockPoliciesRepository.Setup(a => a.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<ChildrenAndExtraBedPolicies>>()
            {
                Result = new List<ChildrenAndExtraBedPolicies> { new ChildrenAndExtraBedPolicies { Id = 1, IsChildrenAllowed = true, MinChildAge=0, MaxChildAge=4, IsExtraCotAllowed=true,
                MinInfantAge =2, MaxInfantAge=10, IsExtraBedAllowed=true, CotPrice=1000, CotPriceTypeId=2, HotelId=5, IsDeleted=false, IsActive = true } }
            }));

            Task<IActionResult> actionResult = mockPoliciesController.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId);
            BaseResult<List<ChildAndExraBedPolicyListViewModel>> ChildAndExraBedPolicyList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<ChildAndExraBedPolicyListViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(ChildAndExraBedPolicyList);
            Assert.IsTrue(!ChildAndExraBedPolicyList.IsError);
            Assert.IsTrue(ChildAndExraBedPolicyList.Result != null);
            Assert.IsTrue(ChildAndExraBedPolicyList.Result.Count > 0);
        }

        [Test]
        public void TestGetChildrenAndExtraBedPolicyListingByHotelId_Failed_BadRequest()
        {
            int hotelId = 0;
            //Act
            var result = mockPoliciesController.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId);
            //Assert
            mockPoliciesRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestResult);
            Assert.AreEqual(((BadRequestResult)result.Result).StatusCode, 400);
        }
        #endregion Positive Test Cases
        #endregion GetChildrenAndExtraBedPolicyListingByHotelId

        #region GetChildrenAndExtraBedPolicy
        #region Negative Test Cases
        [Test]
        public void TestGetChildrenAndExtraBedPolicy_Exception_ByGetChildrenAndExtraBedPolicyListingByHotelId_InternalServerError()
        {
            int hotelId = 5;
            mockPoliciesRepository.Setup(a => a.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<ChildrenAndExtraBedPolicies>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPoliciesController.GetChildrenAndExtraBedPolicy(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetChildrenAndExtraBedPolicy_Exception_ByGetMaxChildAndExtraBedPerRoom_InternalServerError()
        {
            int hotelId = 5;
            mockPoliciesRepository.Setup(a => a.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<ChildrenAndExtraBedPolicies>>()
            {
                Result = new List<ChildrenAndExtraBedPolicies> { new ChildrenAndExtraBedPolicies { Id = 1, IsChildrenAllowed = true, MinChildAge=0, MaxChildAge=4, IsExtraCotAllowed=true,
                MinInfantAge =2, MaxInfantAge=10, IsExtraBedAllowed=true, CotPrice=1000, CotPriceTypeId=2, HotelId=5, IsDeleted=false, IsActive = true } }
            }));
            mockPoliciesRepository.Setup(a => a.GetMaxChildAndExtraBedPerRoom(hotelId)).Returns(Task.FromResult(new BaseResult<List<MaxChildAndExtraBedPerRoom>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPoliciesController.GetChildrenAndExtraBedPolicy(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetChildrenAndExtraBedPolicy_Failed_BadRequest()
        {
            int hotelId = 0;
            //Act
            var result = mockPoliciesController.GetChildrenAndExtraBedPolicy(hotelId);
            //Assert
            mockPoliciesRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestResult);
            Assert.AreEqual(((BadRequestResult)result.Result).StatusCode, 400);
        }
        #endregion Negative Test Cases

        #region Positive Test Cases
        [Test]
        public async Task TestGetChildrenAndExtraBedPolicy_Success_OkResponse()
        {
            int hotelId = 5;
            mockPoliciesRepository.Setup(a => a.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<ChildrenAndExtraBedPolicies>>()
            {
                Result = new List<ChildrenAndExtraBedPolicies> { new ChildrenAndExtraBedPolicies { Id = 1, IsChildrenAllowed = true, MinChildAge=0, MaxChildAge=4, IsExtraCotAllowed=true,
                MinInfantAge =2, MaxInfantAge=10, IsExtraBedAllowed=true, CotPrice=1000, CotPriceTypeId=2, HotelId=5, IsDeleted=false, IsActive = true} }
            }));
            mockPoliciesRepository.Setup(a => a.GetMaxChildAndExtraBedPerRoom(hotelId)).Returns(Task.FromResult(new BaseResult<List<MaxChildAndExtraBedPerRoom>>() { Result = new List<MaxChildAndExtraBedPerRoom> { new MaxChildAndExtraBedPerRoom { HotelId = 5, RoomId = 332, RoomName = "Large", BedCount = 2, NoOfGuest = 2, MaxChildren = 2, ExtraBedCount = 1 } } }));
            Task<IActionResult> actionResult = mockPoliciesController.GetChildrenAndExtraBedPolicy(hotelId);
            BaseResult<List<ChildrenAndExtraBedPoliciesViewModel>> childrenAndExtraBedPoliciesList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<ChildrenAndExtraBedPoliciesViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(childrenAndExtraBedPoliciesList);
            Assert.IsTrue(childrenAndExtraBedPoliciesList.Result != null);
            Assert.IsTrue(childrenAndExtraBedPoliciesList.Result.Count > 0);
        }
        #endregion Positive Test Cases

        #endregion GetChildrenAndExtraBedPolicy

        #region CreateChildrenAndExtraBedPolicy
        #region Negative Test Cases
        [Test]
        public async Task TestCreateChildrenAndExtraBedPolicy_Exception_ByGetRoomsById_InternalServerError()
        {
            //Arrange
            //var maxChildAndExtraBedPerRoomList = new List<MaxChildAndExtraBedPerRoomViewModel>();
            MaxChildAndExtraBedPerRoomViewModel maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoomViewModel()
            {
                HotelId = 5,
                RoomId = 332,
                RoomName = "Large",
                BedCount = 2,
                ExtraBedCount = 1,
                MaxChildren = 2,
                NoOfGuest = 4
            };
            // maxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);
            ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel = new ChildrenAndExtraBedPoliciesViewModel()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2
            };
            childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);

            mockPoliciesRepository.Setup(x => x.GetRoomsById(It.IsAny<List<MaxChildAndExtraBedPerRoomViewModel>>())).Returns(Task.FromResult(new BaseResult<List<Room>>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockPoliciesController.CreateChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesViewModel);

            //Assert
            mockPoliciesRepository.Verify();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public async Task TestCreateChildrenAndExtraBedPolicy_Exception_BySaveAndUpdateChildAndExtraBedPolicy_InternalServerError()
        {
            //Arrange
            List<Room> roomList = new List<Room>();
            MaxChildAndExtraBedPerRoomViewModel maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoomViewModel()
            {
                HotelId = 5,
                RoomId = 332,
                RoomName = "Large",
                BedCount = 2,
                ExtraBedCount = 1,
                MaxChildren = 2,
                NoOfGuest = 4
            };
            ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel = new ChildrenAndExtraBedPoliciesViewModel()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
            };
            childrenAndExtraBedPoliciesViewModel.ObjectState = ObjectState.Added;
            childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);
            ObjectState objectState = ObjectState.Added;
            mockPoliciesRepository.Setup(x => x.GetRoomsById(It.IsAny<List<MaxChildAndExtraBedPerRoomViewModel>>())).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = roomList })).Verifiable();
            mockPoliciesRepository.Setup(x => x.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockPoliciesController.CreateChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesViewModel);

            //Assert
            mockPoliciesRepository.Verify();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public async Task TestCreateChildrenAndExtraBedPolicy_EmptyResult_BySaveAndUpdateChildAndExtraBedPolicy_NoContentResponse()
        {
            //Arrange
            List<Room> roomList = new List<Room>();
            MaxChildAndExtraBedPerRoomViewModel maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoomViewModel()
            {
                HotelId = 5,
                RoomId = 332,
                RoomName = "Large",
                BedCount = 2,
                ExtraBedCount = 1,
                MaxChildren = 2,
                NoOfGuest = 4
            };
            ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel = new ChildrenAndExtraBedPoliciesViewModel()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
            };
            childrenAndExtraBedPoliciesViewModel.ObjectState = ObjectState.Added;
            childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);
            ObjectState objectState = ObjectState.Added;
            mockPoliciesRepository.Setup(x => x.GetRoomsById(It.IsAny<List<MaxChildAndExtraBedPerRoomViewModel>>())).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = roomList })).Verifiable();
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = new ChildrenAndExtraBedPolicies() }));
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = null })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockPoliciesController.CreateChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesViewModel);

            //Assert
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        [Test]
        public async Task TestCreateChildrenAndExtraBedPolicy_Failed_BySaveAndUpdateChildAndExtraBedPolicy_BadRequest()
        {
            //Arrange
            List<Room> roomList = new List<Room>();
            MaxChildAndExtraBedPerRoomViewModel maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoomViewModel()
            {
                HotelId = 5,
                RoomId = 332,
                RoomName = "Large",
                BedCount = 2,
                ExtraBedCount = 1,
                MaxChildren = 2,
                NoOfGuest = 4
            };
            ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel = new ChildrenAndExtraBedPoliciesViewModel()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
            };
            ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
            };

            childrenAndExtraBedPoliciesViewModel.ObjectState = ObjectState.Added;
            childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);
            ObjectState objectState = ObjectState.Added;
            mockPoliciesRepository.Setup(x => x.GetRoomsById(It.IsAny<List<MaxChildAndExtraBedPerRoomViewModel>>())).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = roomList })).Verifiable();
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = new ChildrenAndExtraBedPolicies() }));
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = childrenAndExtraBedPoliciesModel, Message = " Child And Extra Bed Policy for Id 1 not found" })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockPoliciesController.CreateChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesViewModel);

            //Assert
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.BadRequestObjectResult)actionResult.Result).StatusCode, 400);
        }

        [Test]
        public async Task TestCreateChildrenAndExtraBedPolicy_Exception_ByUpdateRoomList_InternalServerError()
        {
            //Arrange
            List<Room> roomList = new List<Room>();
            Room room = new Room()
            {
                HotelId = 5,
                Id = 332,
                Name = "Large",
                ExtraBedCount = 1,
                MaxChildren = 2
            };
            roomList.Add(room);
            MaxChildAndExtraBedPerRoomViewModel maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoomViewModel()
            {
                HotelId = 5,
                RoomId = 332,
                RoomName = "Large",
                BedCount = 2,
                ExtraBedCount = 1,
                MaxChildren = 2,
                NoOfGuest = 4,
            };
            maxChildAndExtraBedPerRoomModel.ObjectState = ObjectState.Modified;
            ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel = new ChildrenAndExtraBedPoliciesViewModel()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
            };
            ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies();
            childrenAndExtraBedPoliciesViewModel.ObjectState = ObjectState.Added;
            childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);
            ObjectState objectState = ObjectState.Added;
            mockPoliciesRepository.Setup(x => x.GetRoomsById(It.IsAny<List<MaxChildAndExtraBedPerRoomViewModel>>())).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = roomList })).Verifiable();
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = new ChildrenAndExtraBedPolicies() }));
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = childrenAndExtraBedPoliciesModel })).Verifiable();
            mockPoliciesRepository.Setup(x => x.UpdateRoomList(It.IsAny<List<Room>>())).Returns(Task.FromResult(new BaseResult<bool>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            //Act
            Task<IActionResult> actionResult = mockPoliciesController.CreateChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesViewModel);

            //Assert
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public async Task TestCreateChildrenAndExtraBedPolicy_Failed_ByUpdateRoomList_NotFoundResult()
        {
            //Arrange
            List<Room> roomList = new List<Room>();
            Room room = new Room()
            {
                HotelId = 5,
                Id = 332,
                Name = "Large",
                ExtraBedCount = 1,
                MaxChildren = 2
            };
            roomList.Add(room);
            MaxChildAndExtraBedPerRoomViewModel maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoomViewModel()
            {
                HotelId = 5,
                RoomId = 332,
                RoomName = "Large",
                BedCount = 2,
                ExtraBedCount = 1,
                MaxChildren = 2,
                NoOfGuest = 4,
            };
            maxChildAndExtraBedPerRoomModel.ObjectState = ObjectState.Modified;
            ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel = new ChildrenAndExtraBedPoliciesViewModel()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
            };
            ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies();
            childrenAndExtraBedPoliciesViewModel.ObjectState = ObjectState.Added;
            childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);
            ObjectState objectState = ObjectState.Added;
            mockPoliciesRepository.Setup(x => x.GetRoomsById(It.IsAny<List<MaxChildAndExtraBedPerRoomViewModel>>())).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = roomList })).Verifiable();
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = new ChildrenAndExtraBedPolicies() }));
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = childrenAndExtraBedPoliciesModel })).Verifiable();
            mockPoliciesRepository.Setup(a => a.UpdateRoomList(It.IsAny<List<Room>>())).Returns(Task.FromResult(new BaseResult<bool> { Result = false })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockPoliciesController.CreateChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesViewModel);

            //Assert
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 404);
        }
        #endregion Negative Test Cases 

        #region Positive Test Cases
        [Test]
        public async Task TestCreateChildrenAndExtraBedPolicy_Success_OkResponse()
        {
            //Arrange
            List<Room> roomList = new List<Room>();
            MaxChildAndExtraBedPerRoomViewModel maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoomViewModel()
            {
                HotelId = 5,
                RoomId = 332,
                RoomName = "Large",
                BedCount = 2,
                ExtraBedCount = 1,
                MaxChildren = 2,
                NoOfGuest = 4
            };
            ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel = new ChildrenAndExtraBedPoliciesViewModel()
            {
                HotelId = 5,
                IsChildrenAllowed = true,
                MinChildAge = 0,
                MaxChildAge = 4,
                IsExtraCotAllowed = true,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
            };
            ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies();
            childrenAndExtraBedPoliciesViewModel.ObjectState = ObjectState.Added;
            childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList.Add(maxChildAndExtraBedPerRoomModel);
            ObjectState objectState = ObjectState.Added;
            mockPoliciesRepository.Setup(x => x.GetRoomsById(It.IsAny<List<MaxChildAndExtraBedPerRoomViewModel>>())).Returns(Task.FromResult(new BaseResult<List<Room>>() { Result = roomList })).Verifiable();
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = new ChildrenAndExtraBedPolicies() }));
            mockPoliciesRepository.Setup(a => a.SaveAndUpdateChildAndExtraBedPolicy(It.IsAny<ChildrenAndExtraBedPolicies>(), objectState)).Returns(Task.FromResult(new BaseResult<ChildrenAndExtraBedPolicies> { Result = childrenAndExtraBedPoliciesModel })).Verifiable();
            mockPoliciesRepository.Setup(a => a.UpdateRoomList(It.IsAny<List<Room>>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockPoliciesController.CreateChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesViewModel);

            //Assert
            BaseResult<ChildrenAndExtraBedPolicies> saveOrUpdatechildrenAndExtraBedPolicies = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<ChildrenAndExtraBedPolicies>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(saveOrUpdatechildrenAndExtraBedPolicies);
            Assert.IsTrue(saveOrUpdatechildrenAndExtraBedPolicies.Result != null);
        }
        #endregion Positive Test Cases 
        #endregion CreateChildrenAndExtraBedPolicy

        #endregion ChildAndExtraBedPolicy
    }
}
