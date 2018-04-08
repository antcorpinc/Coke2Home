using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Models;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Helper;
using MG.Jarvis.Core.Model.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    public class ChannelMangerControllerTest
    {
        #region Private Variables
        private ChannelManagerController mockChannelManagerController;

        private Mock<IChannelManager> mockChannelManagerRepository;
        public IConfigurationRoot Configuration { get; }

        #region Integration Test
        private ChannelManagerController channelManagerController;
        private ChannelManagerController fakeChannelManagerController;
        private IChannelManager iChannelManagerRepository;
        private IChannelManager channelManagerFakeRepository;
        private IConnection<ChannelManagerRequestValidationResponse> iChannelManagerConnection;
        private IConnection<RoomTypesRatePlan> iRoomTypeConnection;
        #endregion Integration Test

        #endregion Private Variables

        #region Settings
        public ChannelMangerControllerTest()
        {
            mockChannelManagerRepository = new Moq.Mock<IChannelManager>();
            mockChannelManagerController = new ChannelManagerController(mockChannelManagerRepository.Object);

            bool isTestMode = false;

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("bin")))
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            // .AddEnvironmentVariables();
            Configuration = builder.Build();

         //   if (isTestMode)
            {
                //ichannelManagerFakeRepository = new Core.DAL.Fakes.MasterDataDALRepository<BaseModel>();
                channelManagerFakeRepository = new Fakes.ChannelManagerRepository();
                fakeChannelManagerController = new ChannelManagerController(channelManagerFakeRepository);
            }
           // else
            {

                iChannelManagerConnection = new Core.DAL.Repositories.DapperConnection<ChannelManagerRequestValidationResponse>(Configuration);
                iRoomTypeConnection = new Core.DAL.Repositories.DapperConnection<RoomTypesRatePlan>(Configuration);
                iChannelManagerRepository = new ChannelManagerRepository(iChannelManagerConnection, iRoomTypeConnection);
                channelManagerController = new ChannelManagerController(iChannelManagerRepository);
            }
        }
        #endregion Settings

        #region GetRoomTypesAndRatePlans
        #region Negative Test Cases
        [Test]
        public async Task TestGetRoomTypesAndRatePlans_NullRequest_RequiredFieldMissingResponse()
        {
            RoomTypeByHotelAndChannelManger request = null;
            mockChannelManagerRepository.Setup(c=>c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypeRatePlanResponse>>()));
            IActionResult actioResult =  await mockChannelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe Manager Id "));
        }

        [Test]
        public async Task TestGetRoomTypesAndRatePlans_HotelCodeNull_RequiredFieldMissingResponse()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = string.Empty
            };
            mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypeRatePlanResponse>>()));
            IActionResult actioResult = await mockChannelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe Manager Id "));
        }
        [Test]
        public async Task TestGetRoomTypesAndRatePlans_ChannelManagerIdNull_RequiredFieldMissingResponse()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "Tets Code"
            };
            mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypeRatePlanResponse>>()));
            IActionResult actioResult = await mockChannelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe Manager Id "));
        }

        [Test]
        public async Task TestGetRoomTypesAndRatePlans_InvalidHotel_InvalidHotelCodeResponse()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "Test Code",
                ChannelManagerId = 1
            };
            //  mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypesRatePlan>>()));
            //mockChannelManagerRepository.Setup(a => a.ValidateRoomTypeRatePlanRequest(request)).Returns(Task.FromResult(new BaseResult<bool> { ErrorCode=101}));
            IActionResult actioResult = await channelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.InvalidHotelCode);
            Assert.IsTrue(String.Compare(response.Message, string.Format(Constants.ErrorMessage.InvalidHotelCode, request.HotelCode),StringComparison.InvariantCultureIgnoreCase) ==0);
        }
        [Test]
        public async Task TestGetRoomTypesAndRatePlans_InactiveHotel_HotelNotActiveResponse()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "IN10000008",
                ChannelManagerId = 1
            };
            //  mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypesRatePlan>>()));
            //mockChannelManagerRepository.Setup(a => a.ValidateRoomTypeRatePlanRequest(request)).Returns(Task.FromResult(new BaseResult<bool> { ErrorCode=101}));
            IActionResult actioResult = await channelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.InactiveHotel);
            Assert.IsTrue(String.Compare(response.Message, string.Format(Constants.ErrorMessage.InactiveHotel, request.HotelCode), StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        [Test]
        public async Task TestGetRoomTypesAndRatePlans_RoomsAreNotPresent_NoRoomResponse()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "IN10000002",
                ChannelManagerId = 1
            };
            //  mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypesRatePlan>>()));
            //mockChannelManagerRepository.Setup(a => a.ValidateRoomTypeRatePlanRequest(request)).Returns(Task.FromResult(new BaseResult<bool> { ErrorCode=101}));
            IActionResult actioResult = await channelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.NoRoom);
            Assert.IsTrue(String.Compare(response.Message, string.Format(Constants.ErrorMessage.NoRooms, request.HotelCode), StringComparison.InvariantCultureIgnoreCase) == 0);

        }

        [Test]
        public async Task TestGetRoomTypesAndRatePlans_ValidationRequest_Exception_InternalServerError()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "IN10000002",
                ChannelManagerId = 1
            };
            mockChannelManagerRepository.Setup(a => a.ValidateRoomTypeRatePlanRequest(request)).Returns(Task.FromResult(new BaseResult<bool> { IsError = true, ExceptionMessage = Common.GetMockException() }));
            // mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypesRatePlan>> { IsError = true, ExceptionMessage = Common.GetMockException() }));
            // mockChannelManagerRepository.VerifyAll();
            IActionResult actioResult = await mockChannelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 500);
        }

        [Test]
        public async Task TestGetRoomTypesAndRatePlans_Exception_InternalServerError()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "IN10000002",
                ChannelManagerId = 1
            };
            mockChannelManagerRepository.Setup(a => a.ValidateRoomTypeRatePlanRequest(request)).Returns(Task.FromResult(new BaseResult<bool> { Result = true }));
            mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypeRatePlanResponse>> { IsError = true, ExceptionMessage = Common.GetMockException() }));
           // mockChannelManagerRepository.VerifyAll();
            IActionResult actioResult = await mockChannelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 500);
        }

        [Test]
        public async Task TestGetRoomTypesAndRatePlans_RatesAreNotPresent_NoRateResponse()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "IN10000002",
                ChannelManagerId = 1
            };
            mockChannelManagerRepository.Setup(a => a.ValidateRoomTypeRatePlanRequest(request)).Returns(Task.FromResult(new BaseResult<bool> { Result = true }));
            mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypeRatePlanResponse>> ()));
            mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypeRatePlanResponse>> { Result = null}));
            // mockChannelManagerRepository.VerifyAll();
            IActionResult actioResult = await mockChannelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 204);
        }

        #endregion Negative Test Cases

        #region Positive Test Cases
        [Test]
        public async Task TestGetRoomTypesAndRatePlans_RatesArePresent_OkResponse()
        {
            RoomTypeByHotelAndChannelManger request = new RoomTypeByHotelAndChannelManger
            {
                HotelCode = "IN10000002",
                ChannelManagerId = 1
            };
            mockChannelManagerRepository.Setup(a => a.ValidateRoomTypeRatePlanRequest(request)).Returns(Task.FromResult(new BaseResult<bool> { Result = true }));

            mockChannelManagerRepository.Setup(c => c.GetRoomTypesAndRatePlans(request)).Returns(Task.FromResult(new BaseResult<List<RoomTypeRatePlanResponse>> { Result = new List<RoomTypeRatePlanResponse>
            { new RoomTypeRatePlanResponse { RatePlanCode="1",RatePlanDescription="Tets Rate PLAN DESC",RatePlanName="test Rate Plan", RoomTypeCode="Test Room Type Code", RoomTypeDescription="Test Room Tyep Desc", RoomTypeName="Tets Room Tyep Neame"} } }));

            IActionResult actioResult = await mockChannelManagerController.GetRoomTypesAndRatePlans(request);
            Assert.IsTrue(actioResult != null);
            Assert.IsTrue(actioResult is Microsoft.AspNetCore.Mvc.ObjectResult);
        }

        #endregion Positive Test Cases
        #region Integration Testing
        #endregion Integration Testing
        #endregion GetRoomTypesAndRatePlans


        #region UpdateAllocations
        #region Negative Test Cases
        [Test]
        public async Task TestUpdateAllocations_NullRequest_RequiredFieldMissingResponse()
        {
            UpdateAllocationBaseRequest baseRequest = null;
            UpdateAllocationsRequest request = null;
            mockChannelManagerRepository.Setup(c => c.UpdateAllocations(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }

        [Test]
        public async Task TestUpdateAllocations_HotelCodeNull_RequiredFieldMissingResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = String.Empty;
            IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }
        [Test]
        public async Task TestUpdateAllocations_ChannelManagerIdNull_RequiredFieldMissingResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "Test Code";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 0;

            IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }

        [Test]
        public async Task TestUpdateAllocations_RoomTypeRatePlanNull_RequiredFieldMissingResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "Test Code";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add( new RoomTypeRatePlan());
            IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }
        #region Integration Testing
        [Test]
        public async Task TestUpdateAllocations_InvalidHotel_InvalidHotelCodeResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "Test Code";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode ="Test Rate Plan Code", RoomTypeCode="Test Room Type Code"});

            // mockChannelManagerRepository.Setup(c => c.UpdateAllocations(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.InvalidHotelCode);
            Assert.IsTrue(String.Compare(response.Message, string.Format(Constants.ErrorMessage.InvalidHotelCode, baseRequest.UpdateAllocationsValidationRequest.HotelCode), StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        [Test]
        public async Task TestUpdateAllocations_InactiveHotel_HotelNotActiveResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocations(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.InactiveHotel);
            Assert.IsTrue(String.Compare(response.Message, string.Format(Constants.ErrorMessage.InactiveHotel, baseRequest.UpdateAllocationsValidationRequest.HotelCode),
                StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        [Test]
        public async Task TestUpdateAllocations_RoomsAreNotPresent_NoRoomResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocations(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.NoRoom);
            Assert.IsTrue(String.Compare(response.Message, Constants.ErrorMessage.NoRooms, StringComparison.InvariantCultureIgnoreCase) == 0);

        }
        [Test]
        public async Task TestUpdateAllocations_RatesAreNotPresent_NoRateResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocations(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.NoRate);
            Assert.IsTrue(String.Compare(response.Message, Constants.ErrorMessage.NoRates, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        [Test]
        public async Task TestUpdateAllocations_RoomTypesRatesCombinationAreNotPresent_RoomAndRateNotFound()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocations(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.NoRate);
            Assert.IsTrue(String.Compare(response.Message, Constants.ErrorMessage.NoRates, StringComparison.InvariantCultureIgnoreCase) == 0);
        }


        [Test]
        public async Task TestUpdateAllocationsRequestValidationResponse_Exception_InternalServerError()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest(),

            };
            baseRequest.UpdateAllocationsRequest.Add(new UpdateAllocationsRequest());
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "TestCaseForException";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;

            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });

            //mockChannelManagerRepository.Setup(m => m.ValidateUpdateAllocationRequest(baseRequest.UpdateAllocationsValidationRequest)).Returns(Task.FromResult(new BaseResult<bool> {Result = false,ExceptionMessage =Common.GetMockException(),IsError = true }));
            //mockChannelManagerRepository.Setup(c => c.UpdateAllocations(baseRequest.UpdateAllocationsRequest[0])).Returns(Task.FromResult(new BaseResult<bool>()));
            IActionResult actioResult = await fakeChannelManagerController.UpdateAllocations(baseRequest);
            //IActionResult actioResult = await channelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 500);

        }

        #endregion Integration Testing
        #endregion Negative Test Cases
        #region Postive Test Cases
        [Test]
        public async Task Test_ValidateUpdateAllocationRequest_Success_OkResponse()
        {
            UpdateAllocationBaseRequest baseRequest = new UpdateAllocationBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "TestCaseForOkResponse";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            //mockChannelManagerRepository.Setup(m => m.ValidateUpdateAllocationRequest(baseRequest.UpdateAllocationsValidationRequest)).Returns(Task.FromResult(new BaseResult<bool> { Result = true }));
            //mockChannelManagerRepository.Setup(c => c.UpdateAllocations(baseRequest.UpdateAllocationsRequest)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocations(baseRequest);
            IActionResult actioResult = await fakeChannelManagerController.UpdateAllocations(baseRequest);
            Assert.IsTrue(actioResult != null);
            Assert.IsTrue(actioResult is Microsoft.AspNetCore.Mvc.ObjectResult);
        }
        #endregion Postive Test Cases
        #endregion UpdateAllocations


        #region Update Rates
        #region Negative Test Cases
        [Test]
        public async Task TestUpdateAllocationRatesRates_NullRequest_RequiredFieldMissingResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = null;
            UpdateAllocationRatesRequest request = null;
            mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }

        [Test]
        public async Task TestUpdateAllocationRatesRates_HotelCodeNull_RequiredFieldMissingResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = String.Empty;
            IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }
        [Test]
        public async Task TestUpdateAllocationRatesRates_ChannelManagerIdNull_RequiredFieldMissingResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "Test Code";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 0;

            IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }

        [Test]
        public async Task TestUpdateAllocationRatesRates_RoomTypeRatePlanNull_RequiredFieldMissingResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "Test Code";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan());
            IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.RequiredFieldMissing);
            Assert.AreEqual(response.Message, string.Format(Constants.ErrorMessage.RequiredFieldMissing, "Hotel Code, Channe manger Id, Room Types and Rate Plans "));
        }
        #region Integration Testing
        [Test]
        public async Task TestUpdateAllocationRatesRates_InvalidHotel_InvalidHotelCodeResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "Test Code";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });

            // mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.InvalidHotelCode);
            Assert.IsTrue(String.Compare(response.Message, string.Format(Constants.ErrorMessage.InvalidHotelCode, baseRequest.UpdateAllocationsValidationRequest.HotelCode), StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        [Test]
        public async Task TestUpdateAllocationRatesRates_InactiveHotel_HotelNotActiveResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.InactiveHotel);
            Assert.IsTrue(String.Compare(response.Message, string.Format(Constants.ErrorMessage.InactiveHotel, baseRequest.UpdateAllocationsValidationRequest.HotelCode),
                StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        [Test]
        public async Task TestUpdateAllocationRatesRates_RoomsAreNotPresent_NoRoomResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.NoRoom);
            Assert.IsTrue(String.Compare(response.Message, Constants.ErrorMessage.NoRooms, StringComparison.InvariantCultureIgnoreCase) == 0);

        }
        [Test]
        public async Task TestUpdateAllocationRatesRates_RatesAreNotPresent_NoRateResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.NoRate);
            Assert.IsTrue(String.Compare(response.Message, Constants.ErrorMessage.NoRates, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        [Test]
        public async Task TestUpdateAllocationRatesRates_RoomTypesRatesCombinationAreNotPresent_RoomAndRateNotFound()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "IN10000008";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            // mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(request)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            IActionResult actioResult = await channelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
            var result = actioResult as BadRequestObjectResult;
            BaseResult<bool> response = result.Value as BaseResult<bool>;
            Assert.AreEqual(response.ErrorCode, (int)Constants.ErrorCodes.NoRate);
            Assert.IsTrue(String.Compare(response.Message, Constants.ErrorMessage.NoRates, StringComparison.InvariantCultureIgnoreCase) == 0);
        }


        [Test]
        public async Task TestUpdateAllocationRatesRatesRequestValidationResponse_Exception_InternalServerError()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest(),

            };
            baseRequest.UpdateAllocationsRateRequest.Add(new UpdateAllocationRatesRequest());
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "TestCaseForException";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;

            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });

            //mockChannelManagerRepository.Setup(m => m.ValidateUpdateAllocationRequest(baseRequest.UpdateAllocationsValidationRequest)).Returns(Task.FromResult(new BaseResult<bool> {Result = false,ExceptionMessage =Common.GetMockException(),IsError = true }));
            //mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(baseRequest.UpdateAllocationRatesRequest[0])).Returns(Task.FromResult(new BaseResult<bool>()));
            IActionResult actioResult = await fakeChannelManagerController.UpdateAllocationRates(baseRequest);
            //IActionResult actioResult = await channelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 500);

        }

        #endregion Integration Testing
        #endregion Negative Test Cases
        #region Postive Test Cases
        [Test]
        public async Task Test_UpdateAllocationRateRequest_Success_OkResponse()
        {
            UpdateAllocationRatesBaseRequest baseRequest = new UpdateAllocationRatesBaseRequest
            {
                UpdateAllocationsValidationRequest = new UpdateAllocationsValidationRequest()
            };
            baseRequest.UpdateAllocationsValidationRequest.HotelCode = "TestCaseForOkResponse";
            baseRequest.UpdateAllocationsValidationRequest.ChannelManagerId = 1;
            baseRequest.UpdateAllocationsValidationRequest.RoomTypeRatePlanList.Add(new RoomTypeRatePlan { RatePlanCode = "Test Rate Plan Code", RoomTypeCode = "Test Room Type Code" });
            //mockChannelManagerRepository.Setup(m => m.ValidateUpdateAllocationRequest(baseRequest.UpdateAllocationsValidationRequest)).Returns(Task.FromResult(new BaseResult<bool> { Result = true }));
            //mockChannelManagerRepository.Setup(c => c.UpdateAllocationRates(baseRequest.UpdateAllocationRatesRequest)).Returns(Task.FromResult(new BaseResult<bool>()));
            //  IActionResult actioResult = await mockChannelManagerController.UpdateAllocationRates(baseRequest);
            IActionResult actioResult = await fakeChannelManagerController.UpdateAllocationRates(baseRequest);
            Assert.IsTrue(actioResult != null);
            Assert.IsTrue(actioResult is Microsoft.AspNetCore.Mvc.ObjectResult);
        }
        #endregion Postive Test Cases
        #endregion Update Rates
    }
}
