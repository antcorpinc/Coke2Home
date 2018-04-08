using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
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
    public class MarketControllerTest
    {
        #region Private Variables
        //private MarketController marketController;
        //private IMarket marketDataRepository;

        private MarketController mockMarketontroller;
        private Mock<IMarket> mockMarketRepository;
        #endregion Private Variables
        #region Settings
        public MarketControllerTest()
        {
            var host = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();

            mockMarketRepository = new Moq.Mock<IMarket>();
            mockMarketontroller = new MarketController(mockMarketRepository.Object);
        }
        #endregion Settings

        #region Market
        
        #region GetMarketIncludedAndExcludedCountries
        #region Negative Test Cases
        [Test]
        public void TestGetMarketIncludedAndExcludedCountries_Exception_InternalServerError()
        {
            int marketId = 12;
            mockMarketRepository.Setup(a => a.GetMarketIncludedAndExcludedCountries(marketId)).Returns(Task.FromResult(new BaseResult<List<MarketIncludedAndExcludedCountries>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockMarketontroller.GetMarketIncludedAndExcludedCountries(marketId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetMarketIncludedAndExcludedCountries_EmptyResult_NoContentResponse()
        {
            int marketId = 12;
            mockMarketRepository.Setup(a => a.GetMarketIncludedAndExcludedCountries(marketId)).Returns(Task.FromResult(new BaseResult<List<MarketIncludedAndExcludedCountries>> { Result = new List<MarketIncludedAndExcludedCountries>() }));
            mockMarketRepository.Setup(a => a.GetMarketIncludedAndExcludedCountries(marketId)).Returns(Task.FromResult(new BaseResult<List<MarketIncludedAndExcludedCountries>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockMarketontroller.GetMarketIncludedAndExcludedCountries(marketId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        [Test]
        public void TestGetMarketIncludedAndExcludedCountries_Failed_BadRequest()
        {
            int marketId = 0;
            //Act
            var result = mockMarketontroller.GetMarketIncludedAndExcludedCountries(marketId);
            //Assert
            mockMarketRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result.Result).StatusCode, 400);
        }
        #endregion Negative Test Cases

        #region Positive Test Cases
        [Test]
        public async Task TestGetMarketIncludedAndExcludedCountries_Success_OkResponse()
        {
            int marketId = 12;
            mockMarketRepository.Setup(a => a.GetMarketIncludedAndExcludedCountries(marketId)).Returns(Task.FromResult(new BaseResult<List<MarketIncludedAndExcludedCountries>>()
            {
                Result = new List<MarketIncludedAndExcludedCountries> { new MarketIncludedAndExcludedCountries { MarketId = 12, CountryId = 7, CountryName = "India", IsIncluded = true } }
            }));

            Task<IActionResult> actionResult = mockMarketontroller.GetMarketIncludedAndExcludedCountries(marketId);
            BaseResult<List<MarketIncludedAndExcludedCountriesViewModel>> marketIncludedAndExcludedCountriesList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<MarketIncludedAndExcludedCountriesViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(marketIncludedAndExcludedCountriesList);
            Assert.IsTrue(!marketIncludedAndExcludedCountriesList.IsError);
            Assert.IsTrue(marketIncludedAndExcludedCountriesList.Result != null);
            Assert.IsTrue(marketIncludedAndExcludedCountriesList.Result.Count > 0);
        }
        #endregion Positive Test Cases
        #endregion GetMarketIncludedAndExcludedCountries

        #region CreateMarket
        #region Negative Test Cases
        [Test]
        public void TestCreateMarket_Exception_InternalServerError()
        {
            MarketDetailsViewModel marketDetailsViewModel = new MarketDetailsViewModel();
            marketDetailsViewModel.MarketId = 12;
            marketDetailsViewModel.MarketName = "market1";
            mockMarketRepository.Setup(a => a.CreateMarket(marketDetailsViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<Market> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockMarketontroller.CreateMarket(marketDetailsViewModel);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestCreateMarket_EmptyResult_NoContentResponse()
        {
            MarketDetailsViewModel marketDetailsViewModel = new MarketDetailsViewModel();
            marketDetailsViewModel.MarketId = 12;
            marketDetailsViewModel.MarketName = "market1";
            mockMarketRepository.Setup(a => a.CreateMarket(marketDetailsViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<Market> { Result = new Market() }));
            mockMarketRepository.Setup(a => a.CreateMarket(marketDetailsViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<Market> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockMarketontroller.CreateMarket(marketDetailsViewModel);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        [Test]
        public void TestCreateMarket_Failed_BadRequest()
        {
            MarketDetailsViewModel marketDetailsViewModel = null;
            //Act
            var result = mockMarketontroller.CreateMarket(marketDetailsViewModel);
            //Assert
            mockMarketRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result.Result).StatusCode, 400);
        }
        #endregion Negative Test Cases

        #region Positive Test Cases
        [Test]
        public async Task TestCreateMarket_Success_OkResponse()
        {
            MarketDetailsViewModel marketDetailsViewModel = new MarketDetailsViewModel();
            marketDetailsViewModel.MarketId = 12;
            marketDetailsViewModel.MarketName = "market1";
            mockMarketRepository.Setup(a => a.CreateMarket(marketDetailsViewModel, It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<Market>()
            {
                Result = new Market { Id = 12, Name = "India", IsActive = true, IsDeleted = false }
            }));

            Task<IActionResult> actionResult = mockMarketontroller.CreateMarket(marketDetailsViewModel);
            BaseResult<Market> marketIncludedAndExcludedCountriesList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<Market>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(marketIncludedAndExcludedCountriesList);
            Assert.IsTrue(!marketIncludedAndExcludedCountriesList.IsError);
            Assert.IsTrue(marketIncludedAndExcludedCountriesList.Result != null);
        }
        #endregion Positive Test Cases
        #endregion CreateMarket
        #endregion Market
    }
}
