using Dapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    public class MarketRepositoryTest
    {
        #region private variables
        private IMarket marketRepository;
        private Mock<IConnection<Market>> iMarketLibrary;
        private Mock<IConnection<MarketIncludedCountryRelation>> iMarketIncludedCountryRelationLibrary;
        private Mock<IConnection<MarketExcludedCountryRelation>> iMarketExcludedCountryRelationLibrary;
        private Mock<IConnection<MarketIncludedAndExcludedCountries>> iMarketIncludedAndExcludedCountriesLibrary;
        #endregion private variables

        public MarketRepositoryTest()
        {
            var host = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();

            iMarketLibrary = new Mock<IConnection<Market>>();
            iMarketIncludedCountryRelationLibrary = new Mock<IConnection<MarketIncludedCountryRelation>>();
            iMarketExcludedCountryRelationLibrary = new Mock<IConnection<MarketExcludedCountryRelation>>();
            iMarketIncludedAndExcludedCountriesLibrary = new Mock<IConnection<MarketIncludedAndExcludedCountries>>();

            marketRepository = new MarketRepository(iMarketLibrary.Object,
                                                            iMarketIncludedCountryRelationLibrary.Object,
                                                            iMarketExcludedCountryRelationLibrary.Object,
                                                            iMarketIncludedAndExcludedCountriesLibrary.Object
                                                            );
        }
        #region CreateMarket
        #region negative test cases
        [Test]
        public async Task TestCreateMarket_Failed_Error()
        {
            //Arrange
            var marketDetailsViewModel = new MarketDetailsViewModel()
            {
                MarketId = 1,
                MarketName = "market",

            };
            var market = new Market() { Id = 1, Name = "Market1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Market>>() { Result = new List<Market>() { market } };
            iMarketLibrary.Setup(x => x.InsertEntity(It.IsAny<Market>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<BaseResult<Market>> actionResult = marketRepository.CreateMarket(marketDetailsViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestAddIncludedAndExcludedCountriesList_Failed_ByIncludedCountries_Error()
        {
            //Arrange
            MarketCountriesViewModel marketIncludedCountry = new MarketCountriesViewModel { CountryId = 7 };
            MarketCountriesViewModel marketExcludedCountry = new MarketCountriesViewModel { CountryId = 45 };
            var marketDetailsViewModel = new MarketDetailsViewModel()
            {
                MarketId = 1,
                MarketName = "market"
            };
            marketDetailsViewModel.IncludedMarketList.Add(marketIncludedCountry);
            marketDetailsViewModel.ExcludedMarketList.Add(marketExcludedCountry);

            var market = new Market() { Id = 1, Name = "Market1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Market>>() { Result = new List<Market>() { market } };
            iMarketLibrary.Setup(x => x.InsertEntity(It.IsAny<Market>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 2 })).Verifiable();
            iMarketIncludedCountryRelationLibrary.Setup(x => x.InsertEntityList(It.IsAny<List<MarketIncludedCountryRelation>>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            //Act
            Task<BaseResult<Market>> actionResult = marketRepository.CreateMarket(marketDetailsViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestAddIncludedAndExcludedCountriesList_Failed_ByExcludedCountries_Error()
        {
            //Arrange
            MarketCountriesViewModel marketIncludedCountry = new MarketCountriesViewModel { CountryId = 7 };
            MarketCountriesViewModel marketExcludedCountry = new MarketCountriesViewModel { CountryId = 45 };
            var marketDetailsViewModel = new MarketDetailsViewModel()
            {
                MarketId = 1,
                MarketName = "market"
            };
            marketDetailsViewModel.IncludedMarketList.Add(marketIncludedCountry);
            marketDetailsViewModel.ExcludedMarketList.Add(marketExcludedCountry);

            var market = new Market() { Id = 1, Name = "Market1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Market>>() { Result = new List<Market>() { market } };
            iMarketLibrary.Setup(x => x.InsertEntity(It.IsAny<Market>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 2 })).Verifiable();
            iMarketIncludedCountryRelationLibrary.Setup(x => x.InsertEntityList(It.IsAny<List<MarketIncludedCountryRelation>>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                Result = 2
            })).Verifiable();
            iMarketExcludedCountryRelationLibrary.Setup(x => x.InsertEntityList(It.IsAny<List<MarketExcludedCountryRelation>>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            //Act
            Task<BaseResult<Market>> actionResult = marketRepository.CreateMarket(marketDetailsViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }
        #endregion negative test cases

        #region positive test cases
        [Test]
        public async Task TestCreateMarket_Pass_Success()
        {
            //Arrange
            MarketCountriesViewModel marketIncludedCountry = new MarketCountriesViewModel { CountryId = 7 };
            MarketCountriesViewModel marketExcludedCountry = new MarketCountriesViewModel { CountryId = 45 };
            var marketDetailsViewModel = new MarketDetailsViewModel()
            {
                MarketId = 1,
                MarketName = "market"
            };
            marketDetailsViewModel.IncludedMarketList.Add(marketIncludedCountry);
            marketDetailsViewModel.ExcludedMarketList.Add(marketExcludedCountry);

            var market = new Market() { Id = 1, Name = "Market1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Market>>() { Result = new List<Market>() { market } };
            iMarketLibrary.Setup(x => x.InsertEntity(It.IsAny<Market>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 2 })).Verifiable();
            iMarketIncludedCountryRelationLibrary.Setup(x => x.InsertEntityList(It.IsAny<List<MarketIncludedCountryRelation>>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                Result = 2
            })).Verifiable();
            iMarketExcludedCountryRelationLibrary.Setup(x => x.InsertEntityList(It.IsAny<List<MarketExcludedCountryRelation>>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                Result = 2
            })).Verifiable();
            //Act
            Task<BaseResult<Market>> actionResult = marketRepository.CreateMarket(marketDetailsViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result != null);
            Assert.IsTrue(actionResult.Result is BaseResult<Market>);
        }
        #endregion positive test cases
        #endregion CreateMarket

        #region GetMarketIncludedAndExcludedCountries
        [Test]
        public async Task TestGetMarketIncludedAndExcludedCountries_Pass_Success()
        {
            //Arrange
            int marketId = 12;
            List<MarketIncludedAndExcludedCountries> marketIncludedAndExcludedCountriesList = new List<MarketIncludedAndExcludedCountries>();
            MarketIncludedAndExcludedCountries marketIncludedAndExcludedCountries=new MarketIncludedAndExcludedCountries() { MarketId = 12, CountryId = 1, CountryName = "India", IsIncluded = true };
            marketIncludedAndExcludedCountriesList.Add(marketIncludedAndExcludedCountries);
            iMarketIncludedAndExcludedCountriesLibrary.Setup(x => x.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<List<MarketIncludedAndExcludedCountries>>()
            {
               Result= marketIncludedAndExcludedCountriesList
            })).Verifiable();
            //Act
            Task<BaseResult<List<MarketIncludedAndExcludedCountries>>> actionResult = marketRepository.GetMarketIncludedAndExcludedCountries(marketId);
            //Assert
            Assert.IsTrue(actionResult.Result != null);
            Assert.IsTrue(actionResult.Result is BaseResult<List<MarketIncludedAndExcludedCountries>>);
        }
        #endregion GetMarketIncludedAndExcludedCountries
    }
}
