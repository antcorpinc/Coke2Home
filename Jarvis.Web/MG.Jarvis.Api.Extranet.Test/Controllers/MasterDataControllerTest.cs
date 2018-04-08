using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class MasterDataControllerTest
    {
        #region Private Variables
        private MasterDataController mockMasterDataController;
        private Mock<IMasterData> mockMasterDataRepository;
        public IConfigurationRoot Configuration { get; }
        #endregion Private Variables

        #region Settings
        public MasterDataControllerTest()
        {
            bool isTestMode = false;
            mockMasterDataRepository = new Moq.Mock<IMasterData>();
            mockMasterDataController = new MasterDataController(mockMasterDataRepository.Object);

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

        #region HotelTypes

        #region Negative Test Cases
        [Test]
        public void TestGetHotelTypes_Exception_InternalServerError()
        {
            var mockAction = new Moq.Mock<IMasterData>();

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelTypeList);
            mockAction.Setup(a => a.GetHotelTypes()).Returns(Task.FromResult(new BaseResult<List<HotelType>> { IsError = true, ExceptionMessage = new Exception() }));
            MasterDataController mockMasterDataController = new MasterDataController(mockAction.Object);
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelTypes();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetHotelTypes_EmptyResult_NoContentResponse()
        {
            var mockAction = new Moq.Mock<IMasterData>();

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelTypeList);
            mockAction.Setup(a => a.GetHotelTypes()).Returns(Task.FromResult(new BaseResult<List<HotelType>>()));
            MasterDataController mockMasterDataController = new MasterDataController(mockAction.Object);
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelTypes();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetHotelTypes_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var mockAction = new Moq.Mock<IMasterData>();
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelTypeList);
            mockAction.Setup(a => a.GetHotelTypes()).Returns(Task.FromResult(new BaseResult<List<HotelType>>() { Result = new List<HotelType> { new HotelType { Id = 1, Name = "Hayat" } } }));
            MasterDataController mockMasterDataController = new MasterDataController(mockAction.Object);
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelTypes();
            BaseResult<List<HotelTypeViewModel>> hotelTypeListList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<HotelTypeViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(hotelTypeListList);
            Assert.IsTrue(!hotelTypeListList.IsError);
            Assert.IsTrue(hotelTypeListList.Result != null);
            Assert.IsTrue(hotelTypeListList.Result.Count > 0);
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelTypeList);
        }

        #endregion Postive Test Cases

        #endregion HotelTypes

        #region GetHotelChains

        #region Negative Test Cases
        [Test]
        public void TestHotelChains_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelChainList);
            mockMasterDataRepository.Setup(a => a.GetHotelChains()).Returns(Task.FromResult(new BaseResult<List<HotelChain>> { IsError = true, ExceptionMessage = new Exception() }));
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelChains();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestHotelChains_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelChainList);
            mockMasterDataRepository.Setup(a => a.GetHotelChains()).Returns(Task.FromResult(new BaseResult<List<HotelChain>>()));
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelChains();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestHotelChains_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelChainList);
            mockMasterDataRepository.Setup(a => a.GetHotelChains()).Returns(Task.FromResult(new BaseResult<List<HotelChain>>() { Result = new List<HotelChain> { new HotelChain { Id = 1, Code = "1" } } }));
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelChains();
            BaseResult<List<HotelChainViewModel>> hotelChainList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<HotelChainViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(hotelChainList);
            Assert.IsTrue(!hotelChainList.IsError);
            Assert.IsTrue(hotelChainList.Result != null);
            Assert.IsTrue(hotelChainList.Result.Count > 0);
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelChainList);
        }

        #endregion Postive Test Cases

        #endregion GetHotelChains

        #region GetHotelBrands

        #region Negative Test Cases
        [Test]
        public void TestGetHotelBrands_Exception_InternalServerError()
        {
            int id = 1;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelBrandList);
            mockMasterDataRepository.Setup(a => a.GetHotelBrands()).Returns(Task.FromResult(new BaseResult<List<HotelBrand>> { IsError = true, ExceptionMessage = new Exception() }));
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelBrands(id);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetHotelBrands_EmptyResult_NoContentResponse()
        {
            int id = 1;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelBrandList);
            mockMasterDataRepository.Setup(a => a.GetHotelBrands()).Returns(Task.FromResult(new BaseResult<List<HotelBrand>>()));
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelBrands(id);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetHotelBrands_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            int id = 1;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelBrandList);
            mockMasterDataRepository.Setup(a => a.GetHotelBrands()).Returns(Task.FromResult(new BaseResult<List<HotelBrand>>() { Result = new List<HotelBrand> { new HotelBrand { Id = 4, Name = "Ibis Budget", HotelChainId = 1 } } }));
            Task<IActionResult> actionResult = mockMasterDataController.GetHotelBrands(id);
            BaseResult<List<HotelBrandViewModel>> hotelBrandsList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<HotelBrandViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(hotelBrandsList);
            Assert.IsTrue(!hotelBrandsList.IsError);
            Assert.IsTrue(hotelBrandsList.Result != null);
            Assert.IsTrue(hotelBrandsList.Result.Count > 0);
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelBrandList);
        }

        #endregion Postive Test Cases

        #endregion GetHotelBrands



        #region GetCountries

        #region Negative Test Cases
        [Test]
        public void TestGetCountries_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CountryList);
            mockMasterDataRepository.Setup(a => a.GetCountries()).Returns(Task.FromResult(new BaseResult<List<Country>> { IsError = true, ExceptionMessage = new Exception() }));

            Task<IActionResult> actioResult = mockMasterDataController.GetCountries();
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetCountries_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CountryList);
            mockMasterDataRepository.Setup(a => a.GetCountries()).Returns(Task.FromResult(new BaseResult<List<Country>> { Result = new List<Country>() }));
            mockMasterDataRepository.Setup(a => a.GetCountries()).Returns(Task.FromResult(new BaseResult<List<Country>> { Result = null })).Verifiable();

            Task<IActionResult> actioResult = mockMasterDataController.GetCountries();
            mockMasterDataRepository.VerifyAll();
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult.Result).StatusCode, 204);
        }

        [Test]
        public void TestGetCountries_EmptyResult_NoContentResponse2()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CountryList);
            mockMasterDataRepository.Setup(a => a.GetCountries()).Returns(Task.FromResult(new BaseResult<List<Country>> { Result = null }));
            Task<IActionResult> actioResult = mockMasterDataController.GetCountries();
            Assert.IsTrue(actioResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult.Result).StatusCode, 204);

        }



        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetCountries_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CountryList);
            mockMasterDataRepository.Setup(a => a.GetCountries()).Returns(Task.FromResult(new BaseResult<List<Country>>() { Result = new List<Country> { new Country { Id = 14, Code = "WSNABS", ContinentId = 1 } } }));
            Task<IActionResult> actioResult = mockMasterDataController.GetCountries();
            Assert.IsTrue(actioResult != null);
            BaseResult<List<CountryViewModel>> counryList = (actioResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<CountryViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult.Result).StatusCode, 200);
            Assert.IsNotNull(counryList);
            Assert.IsTrue(!counryList.IsError);
            Assert.IsTrue(counryList.Result != null);
            Assert.IsTrue(counryList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<Currency>>(Constants.CacheKeys.CountryList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CountryList);

        }

        #endregion Postive Test Cases

        #endregion GetCountries

        #region GetCities

        #region Negative Test Cases
        [Test]
        public void TestGetCities_Exception_InternalServerError()
        {
            int id = 1;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CityList);
            mockMasterDataRepository.Setup(a => a.GetCities()).Returns(Task.FromResult(new BaseResult<List<City>> { IsError = true, ExceptionMessage = new Exception() }));
            Task<IActionResult> actionResult = mockMasterDataController.GetCities(id);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetCities_EmptyResult_NoContentResponse()
        {
            int id = 1;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CityList);
            mockMasterDataRepository.Setup(a => a.GetCities()).Returns(Task.FromResult(new BaseResult<List<City>>()));
            Task<IActionResult> actionResult = mockMasterDataController.GetCities(id);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetCities_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            int CountryId = 11;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CityList);
            mockMasterDataRepository.Setup(a => a.GetCities()).Returns(Task.FromResult(new BaseResult<List<City>>() { Result = new List<City> { new City { Id = 318, CountryId = 11, IsActive = true } } }));
            Task<IActionResult> actioResult = mockMasterDataController.GetCities(CountryId);
            BaseResult<List<CityViewModel>> citiesList = (actioResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<CityViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult.Result).StatusCode, 200);
            Assert.IsNotNull(citiesList);
            Assert.IsTrue(!citiesList.IsError);
            Assert.IsTrue(citiesList.Result != null);
            Assert.IsTrue(citiesList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<CityViewModel>>(Constants.CacheKeys.CityList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CityList);
        }

        #endregion Postive Test Cases

        #endregion GetCities

        #region GetStarRating
        #region Negative Test Cases
        [Test]
        public async Task TestGetStarRating_Exception_InternalServerError()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.StarRatingList);
            mockMasterDataRepository.Setup(a => a.GetStarRating()).Returns(Task.FromResult(new BaseResult<List<StarRating>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockMasterDataController.GetStarRating();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 500);
        }

        [Test]
        public async Task TestGetStarRating_EmptyResult_NoContentResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.StarRatingList);
            mockMasterDataRepository.Setup(a => a.GetStarRating()).Returns(Task.FromResult(new BaseResult<List<StarRating>>()));
            IActionResult actionResult = await mockMasterDataController.GetStarRating();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetStarRating_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.StarRatingList);
            mockMasterDataRepository.Setup(a => a.GetStarRating()).Returns(Task.FromResult(new BaseResult<List<StarRating>>() { Result = new List<StarRating> { new StarRating { Id = 2, Name = "0 Star" } } }));
            IActionResult actionResult = await mockMasterDataController.GetStarRating();
            BaseResult<List<StarRatingViewModel>> starRatingList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<StarRatingViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(starRatingList.Result.Count > 0);
            Assert.IsNotNull(starRatingList);
            Assert.IsTrue(!starRatingList.IsError);

            Assert.IsTrue(starRatingList.Result != null);

            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<StarRatingViewModel>>(Constants.CacheKeys.StarRatingList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.StarRatingList);
        }
        #endregion Postive Test Cases
        #endregion GetStarRating
    }
}


