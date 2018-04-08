using Dapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    internal class MasterDataRepositoryTest
    {
        private IMasterData masterDataRepository;
        private Mock<IConnection<HotelType>> iHotelTypeLibrary;
        private Mock<IConnection<City>> iCityLibrary;
        private Mock<IConnection<Country>> iCountryLibrary;
        private Mock<IConnection<HotelBrand>> iHotelBrandLibrary;
        private Mock<IConnection<HotelChain>> iHotelChainLibrary;
        private Mock<IConnection<StarRating>> iStarRatingLibrary;
        private Mock<IConnection<Continent>> iContinentLibrary;
        public MasterDataRepositoryTest()
        {
            var host = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();

            iHotelTypeLibrary = new Mock<IConnection<HotelType>>();
            iCityLibrary = new Mock<IConnection<City>>();
            iCountryLibrary = new Mock<IConnection<Country>>();
            iHotelBrandLibrary = new Mock<IConnection<HotelBrand>>();
            iHotelChainLibrary = new Mock<IConnection<HotelChain>>();
            iStarRatingLibrary = new Mock<IConnection<StarRating>>();
            iContinentLibrary = new Mock<IConnection<Continent>>();

            masterDataRepository = new MasterDataRepository(
                                                            iHotelTypeLibrary.Object, iCityLibrary.Object,
                                                            iCountryLibrary.Object, iHotelBrandLibrary.Object,
                                                            iHotelChainLibrary.Object, iStarRatingLibrary.Object,
                                                            iContinentLibrary.Object);
        }
        [Test]
        public void TestGetCity_positive_sample()
        {
            //Arrange
            var CountryId = 1;
            var city = new City() { Code = "Mum", CountryId = CountryId, IsActive = true, Name = "Mumbai", StateId = 1 };
            var baseResult = new BaseResult<List<City>>() { Result = new List<City>() { city } };
            iCityLibrary.Setup(x => x.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(baseResult));
            //Act
            var result = masterDataRepository.GetCity(CountryId);
            //Assert
            Assert.IsTrue(result.Result is BaseResult<List<City>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.CountryId == CountryId));
        }
        [Test]
        public void TestGetCity_positive_Predicate_sample()
        {
            //Arrange
            var CountryId = 1;
            var city = new City() { Code = "Mum", CountryId = CountryId, IsActive = true, Name = "Mumbai", StateId = 1 };
            var baseResult = new BaseResult<List<City>>() { Result = new List<City>() { city } };
            var pred = new Func<City, bool>(x => x.IsActive && !x.IsDeleted);

            iCityLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<City, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            var result = masterDataRepository.GetCities();
            //Assert
            Assert.IsTrue(result.Result is BaseResult<List<City>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.CountryId == CountryId));
        }

        [Test]
        public async Task TestGetCountries_Success_ListOfCountries()
        {
            var country = new Country() { Id = 1, Name = "India", Code = "IND", ContinentId = 1, IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Country>>() { Result = new List<Country>() { country } };
            var pred = new Func<Country, bool>(x => x.IsActive && !x.IsDeleted);

            iCountryLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<Country, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<Country>>> result = masterDataRepository.GetCountries();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<Country>>);
        }
    }
}
