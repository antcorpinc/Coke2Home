using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    public class MiscellaneousControllerTest
    {
        #region Private Variables
        private MiscellaneousController miscellaneousController;
        private IMiscellaneous miscellaneousDataRepository;

        private MiscellaneousController mockMiscellaneousController;
        private Mock<IMiscellaneous> mockMiscellaneousDataRepository;
        public IConfigurationRoot Configuration { get; }
        #endregion Private Variables

        #region Settings
        public MiscellaneousControllerTest()
        {
            var host = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();

            bool isTestMode = false;
            mockMiscellaneousDataRepository = new Moq.Mock<IMiscellaneous>();
            mockMiscellaneousController = new MiscellaneousController(mockMiscellaneousDataRepository.Object);

            //var builder = new ConfigurationBuilder()
            //   .SetBasePath(Directory.GetCurrentDirectory())
            //   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //// .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //// .AddEnvironmentVariables();
            //Configuration = builder.Build();

            if (isTestMode)
            {
                ////iConnection = new Core.DAL.Fakes.MasterDataDALRepository<BaseModel>();
                //masterDataRepository = new Fakes.MasterDataRepository(iHotelLibrary, iCurrencyConnectionLibrary, iMarketConnectionLibrary,
                //                                                                      iOccupancyConnectionLibrary, iSupplierConnectionLibrary, iRoomTypeLibrary,
                //                                                                      iLanguageLibrary, iHotelFacilityGroupLibrary,
                //                                                                      iHotelFacilityTypeLibrary, iHotelFacilityLibrary,
                //                                                                      iPaymentMethodLibrary, iRateTypeLibrary, iTaxTypeLibrary, iTaxApplicabilityLibrary);
                //masterDataController = new MasterDataController(masterDataRepository);
            }
            else
            {

                //// iCountryLibrary = new Core.DAL.Repositories.DapperConnection<Country>();
                // iHotelLibrary = new Core.DAL.Repositories.DapperConnection<Hotel>(Configuration);
                // iHotelTypeLibary = new Core.DAL.Repositories.DapperConnection<HotelType>(Configuration);
                // masterDataRepository = new Repositories.MasterDataRepository(iHotelLibrary, iHotelTypeLibary, iDesignationLibrary, iCityLibrary, iCountryLibrary, iCurrencyConnectionLibrary,
                //                                                          iMarketConnectionLibrary, iOccupancyConnectionLibrary, iSupplierConnectionLibrary, iChannelManagerConnectionLibrary,
                //                                                           iHotelBrandLibrary, iHotelChainLibrary, iLanguageLibrary,
                //                                                         iPaymentMethodLibrary, iRateTypeLibrary, iTaxTypeLibrary, iTaxApplicabilityLibrary, iMealsConnectionLibrary, iCuisineTypeConnectionLibrary);
                // masterDataController = new MasterDataController(masterDataRepository);
            }
        }

        #endregion Settings


        #region GetChannelManager
        #region Negative Test Cases
        [Test]
        public void TestGetChannelManager_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.ChannelManagerList);
            mockMiscellaneousDataRepository.Setup(a => a.GetChannelManager()).Returns(Task.FromResult(new BaseResult<List<ChannelManagers>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockMiscellaneousController.GetChannelManager();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetChannelManager_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.ChannelManagerList);
            mockMiscellaneousDataRepository.Setup(a => a.GetChannelManager()).Returns(Task.FromResult(new BaseResult<List<ChannelManagers>>()));
            Task<IActionResult> actionResult = mockMiscellaneousController.GetChannelManager();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetChannelManager_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.ChannelManagerList);
            mockMiscellaneousDataRepository.Setup(a => a.GetChannelManager()).Returns(Task.FromResult(new BaseResult<List<ChannelManagers>>() { Result = new List<ChannelManagers> { new ChannelManagers { Id = 1, ChannelManager = "MG", IsActive = true } } }));
            Task<IActionResult> actionResult = mockMiscellaneousController.GetChannelManager();
            BaseResult<List<ChannelManagerViewModel>> channelManagersList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<ChannelManagerViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(channelManagersList);
            Assert.IsTrue(!channelManagersList.IsError);
            Assert.IsTrue(channelManagersList.Result != null);
            Assert.IsTrue(channelManagersList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<ChannelManagers>>(Constants.CacheKeys.ChannelManagerList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.ChannelManagerList);
        }

        #endregion Postive Test Cases
        #endregion GetChannelManager

        #region GetDesignations

        #region Negative Test Cases
       
        [Test]
        public void TestGetDesignations_Exception_ByUserType_InternalServerError()
        {
            mockMiscellaneousDataRepository.Setup(a => a.GetDesignationByUserType(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<List<Designation>> { IsError = true, ExceptionMessage = new Exception() }));
            Task<IActionResult> actionResult = mockMiscellaneousController.GetDesignation(It.IsAny<string>());
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        
        [Test]
        public void TestGetDesignations_EmptyResult_ByUserType_NoContentResponse()
        {
            mockMiscellaneousDataRepository.Setup(a => a.GetDesignationByUserType(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<List<Designation>>()));
            Task<IActionResult> actionResult = mockMiscellaneousController.GetDesignation(It.IsAny<string>());
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Casess

        #region Postive Test Cases
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetDesignations_Success_ByUserType_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            mockMiscellaneousDataRepository.Setup(a => a.GetDesignationByUserType(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<List<Designation>>() { Result = new List<Designation> { new Designation { Id = 1, Title = "Manager", IsActive = true } } }));
            Task<IActionResult> actionResult = mockMiscellaneousController.GetDesignation(It.IsAny<string>());
            BaseResult<List<DesignationViewModel>> designationList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<DesignationViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(designationList);
            Assert.IsTrue(!designationList.IsError);
            Assert.IsTrue(designationList.Result != null);
            Assert.IsTrue(designationList.Result.Count > 0);
        }
        #endregion Postive Test Cases

        #endregion GetDesignations

        #region GetLanguages

        #region Negative Test Cases
        [Test]
        public async Task TestGetLanguages_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.LanguageList);
            mockMiscellaneousDataRepository.Setup(a => a.GetLanguages()).Returns(Task.FromResult(new BaseResult<List<Langauges>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockMiscellaneousController.GetLanguages();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 500);
        }

        [Test]
        public async Task TestGetLanguages_EmptyResult_NoContentResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.LanguageList);
            mockMiscellaneousDataRepository.Setup(a => a.GetLanguages()).Returns(Task.FromResult(new BaseResult<List<Langauges>>()));
            IActionResult actionResult = await mockMiscellaneousController.GetLanguages();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetLanguages_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.LanguageList);
            mockMiscellaneousDataRepository.Setup(a => a.GetLanguages()).Returns(Task.FromResult(new BaseResult<List<Langauges>>() { Result = new List<Langauges> { new Langauges { Id = 1, Code = "En", IsActive = true } } }));
            IActionResult actionResult = await mockMiscellaneousController.GetLanguages();
            BaseResult<List<LanguageViewModel>> languageList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<LanguageViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(languageList.Result.Count > 0);
            Assert.IsNotNull(languageList);
            Assert.IsTrue(!languageList.IsError);

            Assert.IsTrue(languageList.Result != null);

            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<Langauges>>(Constants.CacheKeys.LanguageList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.LanguageList);

        }
        #endregion Postive Test Cases

        #endregion GetLanguages
    }
}
