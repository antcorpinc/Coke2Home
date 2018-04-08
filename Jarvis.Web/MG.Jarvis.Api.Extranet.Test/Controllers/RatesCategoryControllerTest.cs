using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.RatesCategory;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class RatesCategoryControllerTest: BaseTestFixture
    {
     
        #region Private Variables
        private IRatesCategory ratesCategoryRepository;

        private IConnection<Market> iMarketConnectionLibrary;

        private RatesCategoryController mockRatesCategoryController;
        private Mock<IRatesCategory> mockRatesCategoryRepository;
        #endregion Private Variables

        #region Settings
        public RatesCategoryControllerTest()
        {
            mockRatesCategoryRepository = new Moq.Mock<IRatesCategory>();
            mockRatesCategoryController = new RatesCategoryController(mockRatesCategoryRepository.Object);
        }

        #endregion Settings

        #region GetMarkets
        #region Negative Test Cases
        [Test]
        public void TestGetMarkets_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MarketList);
            mockRatesCategoryRepository.Setup(a => a.GetMarkets()).Returns(Task.FromResult(new BaseResult<List<Market>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockRatesCategoryController.GetMarkets();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetMarkets_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MarketList);
            mockRatesCategoryRepository.Setup(a => a.GetMarkets()).Returns(Task.FromResult(new BaseResult<List<Market>> { Result = new List<Market>() }));
            mockRatesCategoryRepository.Setup(a => a.GetMarkets()).Returns(Task.FromResult(new BaseResult<List<Market>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockRatesCategoryController.GetMarkets();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
        public async Task TestGetMarkets_Success_OkResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MarketList);
            mockRatesCategoryRepository.Setup(a => a.GetMarkets()).Returns(Task.FromResult(new BaseResult<List<Market>>() { Result = new List<Market> { new Market { Id = 1, Name = "India", IsActive = true } } }));
            Task<IActionResult> actionResult = mockRatesCategoryController.GetMarkets();
            BaseResult<List<MarketViewModel>> marketList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<MarketViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(marketList);
            Assert.IsTrue(!marketList.IsError);
            Assert.IsTrue(marketList.Result != null);
            Assert.IsTrue(marketList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<Market>>(Constants.CacheKeys.MarketList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MarketList);
        }
        #endregion Postive Test Cases
        #endregion

        #region GetRateCategoryById
        #region Negative Test Cases
        [Test]
        public void TestGetRateCategoryById_Exception_ByRateCategory_InternalServerError()
        {
            int rateCategoryId = 7;
            mockRatesCategoryRepository.Setup(a => a.GetRateCategoryById(rateCategoryId)).Returns(Task.FromResult(new BaseResult<List<RateCategory>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockRatesCategoryController.GetRateCategoryById(rateCategoryId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetRateCategoryById_Exception_ByRatePlans_InternalServerError()
        {
            //Arrange
            int rateCategoryId = 7;
            List<RateCategory> rateCategoryList = new List<RateCategory>();
            RateCategory rateCategoryModel = new RateCategory()
            {
                Id = 1,
                Name = "RC1",
                IsActive = true
            };
            rateCategoryList.Add(rateCategoryModel);
            mockRatesCategoryRepository.Setup(a => a.GetRateCategoryById(rateCategoryId)).Returns(Task.FromResult(new BaseResult<List<RateCategory>> { Result = rateCategoryList }));
            mockRatesCategoryRepository.Setup(a => a.GetRatePlansById(rateCategoryId)).Returns(Task.FromResult(new BaseResult<List<RatePlans>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));

            //Act
            Task<IActionResult> actionResult = mockRatesCategoryController.GetRateCategoryById(rateCategoryId);

            //Assert
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetRateCategoryById_EmptyResult_NoContentResponse()
        {
            int rateCategoryId = 7;
            mockRatesCategoryRepository.Setup(a => a.GetRateCategoryById(rateCategoryId)).Returns(Task.FromResult(new BaseResult<List<RateCategory>> { Result = new List<RateCategory>() }));
            mockRatesCategoryRepository.Setup(a => a.GetRateCategoryById(rateCategoryId)).Returns(Task.FromResult(new BaseResult<List<RateCategory>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockRatesCategoryController.GetRateCategoryById(rateCategoryId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        
        [Test]
        public void TestGetRateCategoryById_Failed_BadRequest()
        {
            int rateCategoryId = 0;
            //Act
            var result = mockRatesCategoryController.GetRateCategoryById(rateCategoryId);
            //Assert
            mockRatesCategoryRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result.Result).StatusCode, 400);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
        public async Task TestGetRateCategoryById_Success_OkResponse()
        {
            //Arrange
            int rateCategoryId = 7;
            RateCategory rateCategoryModel = new RateCategory()
            {
                HotelId=1061,
                Id = 1,
                Name = "RC1",
                CancellationPolicyId=5,
                MarketId=2,
                HotelMealId=2,
                IsDeleted=false,
                IsActive = true
            };
            RatePlans ratePlansModel = new RatePlans()
            {
                Id = 1,
                RoomId=322,
                RateCategoryId=7,
                IsDeleted=false,
                IsActive = true
            };
            mockRatesCategoryRepository.Setup(a => a.GetRateCategoryById(rateCategoryId)).Returns(Task.FromResult(new BaseResult<List<RateCategory>>() { Result = new List<RateCategory> { rateCategoryModel } }));
            mockRatesCategoryRepository.Setup(a => a.GetRatePlansById(rateCategoryId)).Returns(Task.FromResult(new BaseResult<List<RatePlans>> { Result = new List<RatePlans> { ratePlansModel } }));
            //Act
            Task<IActionResult> actionResult = mockRatesCategoryController.GetRateCategoryById(rateCategoryId);
            var rateCategory = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<RateCategoryViewModel>;

            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(rateCategory);
            Assert.IsTrue(!rateCategory.IsError);
            Assert.IsTrue(rateCategory.Result != null);
        }
        #endregion Postive Test Cases
        #endregion GetRateCategoryById

        #region CreateRateCategory
        #region Negative Test Cases
        [Test]
        public void TestCreateRateCategory_Exception_InternalServerError()
        {
            RateCategoryViewModel rateCategoryViewModel = new RateCategoryViewModel();
            mockRatesCategoryRepository.Setup(a => a.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<RateCategory> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockRatesCategoryController.CreateRateCategory(rateCategoryViewModel);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestCreateRateCategory_EmptyResult_NoContentResponse()
        {
            RateCategoryViewModel rateCategoryViewModel = new RateCategoryViewModel();
            mockRatesCategoryRepository.Setup(a => a.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<RateCategory> { Result = new RateCategory() }));
            mockRatesCategoryRepository.Setup(a => a.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<RateCategory> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockRatesCategoryController.CreateRateCategory(rateCategoryViewModel);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        [Test]
        public void TestCreateRateCategory_Failed_BadRequest()
        {
            //Arrange
            RateCategoryViewModel rateCategoryViewModel = null;
            //Act
            var result = mockRatesCategoryController.CreateRateCategory(rateCategoryViewModel);
            //Assert
            mockRatesCategoryRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result.Result).StatusCode, 400);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
        public async Task TestCreateRateCategory_Success_OkResponse()
        {
            //Arrange
            RateCategoryViewModel rateCategoryViewModel = new RateCategoryViewModel();
            
            RateCategory rateCategory = new RateCategory();
            mockRatesCategoryRepository.Setup(a => a.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<RateCategory> { Result = rateCategory }));
            //Act
            Task<IActionResult> actionResult = mockRatesCategoryController.CreateRateCategory(rateCategoryViewModel);
            var createRateCategoryResult = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<RateCategory>;

            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(createRateCategoryResult);
            Assert.IsTrue(!createRateCategoryResult.IsError);
            Assert.IsTrue(createRateCategoryResult.Result != null);
        }
        #endregion Postive Test Cases
        #endregion CreateRateCategory
    }
}
