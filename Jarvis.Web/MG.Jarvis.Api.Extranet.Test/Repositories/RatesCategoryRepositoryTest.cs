using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.RatesCategory;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    class RatesCategoryRepositoryTest
    {

        private IRatesCategory rateCategoryRepository;
        private Mock<IConnection<RateCategoryList>> iRateCategoryListLibrary;
        private Mock<IConnection<RateCategory>> iRateCategoryLibrary;
        private Mock<IConnection<RatePlans>> iRatePlansLibrary;
        private Mock<IConnection<Market>> iMarketLibrary;

        public RatesCategoryRepositoryTest()
        {
            var host = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();

            iRateCategoryListLibrary = new Mock<IConnection<RateCategoryList>>();
            iRateCategoryLibrary = new Mock<IConnection<RateCategory>>();
            iRatePlansLibrary = new Mock<IConnection<RatePlans>>();
            iMarketLibrary = new Mock<IConnection<Market>>();
            rateCategoryRepository = new RatesCategoryRepository(iMarketLibrary.Object, iRateCategoryListLibrary.Object, iRatePlansLibrary.Object, iRateCategoryLibrary.Object);
        }

        #region Market
        [Test]
        public async Task TestGetMarkets_Success_ListOfMarkets()
        {
            //Arrange
            var market = new Market() { Id = 1, Name = "India", IsActive = true };
            var baseResult = new BaseResult<List<Market>>() { Result = new List<Market>() { market } };
            var pred = new Func<Market, bool>(x => x.IsActive);

            iMarketLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<Market, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            var roomList = rateCategoryRepository.GetMarkets();
            //Assert
            Assert.IsTrue(roomList != null);
            Assert.IsTrue(roomList.Result is BaseResult<List<Market>>);
        }
        #endregion Market

        #region GetRateCategory
        [Test]
        public void TestGetRateCategory_ListOfRateCategory()
        {
            //Arrange
            int id = 1;
            var rateCategory = new RateCategoryList() { Id = id, Name = "Category1", IsActive = true, RoomTypeName = "Type1", Markets = "XYX" };
            var baseResult = new BaseResult<List<RateCategoryList>>() { Result = new List<RateCategoryList>() { rateCategory } };
            iRateCategoryListLibrary.Setup(a => a.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(baseResult));
            //Act
            var ratecategoryList = rateCategoryRepository.GetRateCategory(id);
            //Assert
            Assert.IsTrue(ratecategoryList != null);
            Assert.IsTrue(ratecategoryList.Result is BaseResult<List<RateCategoryList>>);
            Assert.IsTrue(ratecategoryList.Result.Result.Exists(x => x.Id == id));

        }

        #endregion GetRateCategory

        #region GetRateCategoryById
        [Test]
        public async Task TestGetRateCategoryById_positive_Predicate_sample()
        {
            //Arrange
            int rateCategoryId = 1;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            var pred = new Func<RateCategory, bool>(x => x.Id == rateCategoryId && !x.IsDeleted);

            iRateCategoryLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RateCategory, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<RateCategory>>> result = rateCategoryRepository.GetRateCategoryById(rateCategoryId);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<RateCategory>>);
        }
        #endregion GetRateCategoryById

        #region GetRatePlansById
        [Test]
        public async Task TestGetRatePlansById_positive_Predicate_sample()
        {
            //Arrange
            int ratePlanId = 1, rateCategoryId = 1;
            var ratePlan = new RatePlans() { Id = 1, RateCategoryId = 1, IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RatePlans>>() { Result = new List<RatePlans>() { ratePlan } };
            var pred = new Func<RatePlans, bool>(x => x.RateCategoryId == rateCategoryId);

            iRatePlansLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RatePlans, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<RatePlans>>> result = rateCategoryRepository.GetRatePlansById(ratePlanId);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<RatePlans>>);
        }
        #endregion GetRatePlansById

        #region SaveAndUpdateRateCategory
        #region Positive Test Cases
        [Test]
        public async Task TestAddRateCategory_Pass_Success()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            var ratePlan = new RatePlansViewModel()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322
            };
            var ratePlansList = new List<RatePlansViewModel>();
            ratePlansList.Add(ratePlan);
            rateCategoryViewModel.RoomTypeList.AddRange(ratePlansList);
            rateCategoryViewModel.ObjectState = ObjectState.Added;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            iRateCategoryLibrary.Setup(x => x.InsertEntity(It.IsAny<RateCategory>())).Returns(Task.FromResult(new BaseResult<long>()
            { Result = 2 })).Verifiable();
            iRatePlansLibrary.Setup(x => x.InsertEntityList(It.IsAny<List<RatePlans>>())).Returns(Task.FromResult(new BaseResult<long>()
            { Result = 2 })).Verifiable();
            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result != null);
            Assert.IsTrue(actionResult.Result is BaseResult<RateCategory>);
        }

        [Test]
        public async Task TestUpdateRatePlans_Passed_Success()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            var ratePlanViewModel = new RatePlansViewModel()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322,
                ObjectState = ObjectState.Modified
            };
            var ratePlansList = new List<RatePlansViewModel>();
            ratePlansList.Add(ratePlanViewModel);
            rateCategoryViewModel.RoomTypeList.AddRange(ratePlansList);
            rateCategoryViewModel.ObjectState = ObjectState.Modified;
            int rateCategoryId = 1;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            var pred = new Func<RateCategory, bool>(x => x.Id == rateCategoryId && !x.IsDeleted);

            iRateCategoryLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RateCategory, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            iRateCategoryLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<RateCategory>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true })).Verifiable();

            var ratePlan = new RatePlans()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322
            };

            var ratePlanbaseResult = new BaseResult<List<RatePlans>>() { Result = new List<RatePlans>() { ratePlan } };
            var ratePlanPred = new Func<RatePlans, bool>(x => x.RateCategoryId == rateCategoryId && x.IsActive);
            iRatePlansLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RatePlans, bool>>(y => y.GetType() == ratePlanPred.GetType()))).Returns(Task.FromResult(ratePlanbaseResult));
            iRatePlansLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<RatePlans>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true })).Verifiable();
            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result != null);
            Assert.IsTrue(actionResult.Result is BaseResult<RateCategory>);
        }
        #endregion Positive Test Cases

        #region Negative Test Cases
        [Test]
        public async Task TestAddRateCategory_Failed_Error()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            rateCategoryViewModel.ObjectState = ObjectState.Added;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            iRateCategoryLibrary.Setup(x => x.InsertEntity(It.IsAny<RateCategory>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestAddRatePlans_Failed_Error()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            var ratePlanViewModel = new RatePlansViewModel()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322
            };
            var ratePlansViewModelList = new List<RatePlansViewModel>();
            ratePlansViewModelList.Add(ratePlanViewModel);
            rateCategoryViewModel.RoomTypeList.AddRange(ratePlansViewModelList);
            rateCategoryViewModel.ObjectState = ObjectState.Added;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            iRateCategoryLibrary.Setup(x => x.InsertEntity(It.IsAny<RateCategory>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 2 })).Verifiable();

            var ratePlan = new RatePlans()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322
            };
            int rateCategoryId = 2;
            var ratePlanbaseResult = new BaseResult<List<RatePlans>>() { Result = new List<RatePlans>() { ratePlan } };
            var pred = new Func<RatePlans, bool>(x => x.RateCategoryId == rateCategoryId && x.IsActive);
            iRatePlansLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RatePlans, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(ratePlanbaseResult));
            iRatePlansLibrary.Setup(x => x.InsertEntityList(It.IsAny<List<RatePlans>>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }
       
        [Test]
        public async Task TestUpdateRateCategory_Failed_ByUpdateEntityByDapper_Error()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            rateCategoryViewModel.ObjectState = ObjectState.Modified;
            int rateCategoryId = 1;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            var pred = new Func<RateCategory, bool>(x => x.Id == rateCategoryId && !x.IsDeleted);

            iRateCategoryLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RateCategory, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            iRateCategoryLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<RateCategory>())).Returns(Task.FromResult(new BaseResult<bool>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestUpdateRateCategory_Failed_ByGetListByPredicate_Error()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            rateCategoryViewModel.ObjectState = ObjectState.Modified;
            int rateCategoryId = 1;
            BaseResult<List<RateCategory>> baseResult = new BaseResult<List<RateCategory>>();
            baseResult.Result = null;
            var pred = new Func<RateCategory, bool>(x => x.Id == rateCategoryId && !x.IsDeleted);

            iRateCategoryLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RateCategory, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));

            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.Message != null);
        }

        [Test]
        public async Task TestUpdateRatePlans_Failed_ByUpdateEntityByDapper_Error()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            var ratePlanViewModel = new RatePlansViewModel()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322,
                ObjectState=ObjectState.Modified
            };
            var ratePlansList = new List<RatePlansViewModel>();
            ratePlansList.Add(ratePlanViewModel);
            rateCategoryViewModel.RoomTypeList.AddRange(ratePlansList);
            rateCategoryViewModel.ObjectState = ObjectState.Modified;
            int rateCategoryId = 1;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            var pred = new Func<RateCategory, bool>(x => x.Id == rateCategoryId && !x.IsDeleted);

            iRateCategoryLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RateCategory, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            iRateCategoryLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<RateCategory>())).Returns(Task.FromResult(new BaseResult<bool>() { Result=true })).Verifiable();

            var ratePlan = new RatePlans()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322
            };

            var ratePlanbaseResult = new BaseResult<List<RatePlans>>() { Result = new List<RatePlans>() { ratePlan } };
            var ratePlanPred = new Func<RatePlans, bool>(x => x.RateCategoryId == rateCategoryId && x.IsActive);
            iRatePlansLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RatePlans, bool>>(y => y.GetType() == ratePlanPred.GetType()))).Returns(Task.FromResult(ratePlanbaseResult));
            iRatePlansLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<RatePlans>())).Returns(Task.FromResult(new BaseResult<bool>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestUpdateRatePlans_Failed_ByGetListByPredicate_Error()
        {
            //Arrange
            var rateCategoryViewModel = new RateCategoryViewModel()
            {
                Id = 1,
                Name = "RC1",
                MarketId = 2,
                CancellationPolicyId = 2,
                HotelMealId = 2,
                IsActive = true
            };
            var ratePlanViewModel = new RatePlansViewModel()
            {
                Id = 1,
                RateCategoryId = 2,
                RoomId = 322,
                ObjectState = ObjectState.Modified
            };
            var ratePlansList = new List<RatePlansViewModel>();
            ratePlansList.Add(ratePlanViewModel);
            rateCategoryViewModel.RoomTypeList.AddRange(ratePlansList);
            rateCategoryViewModel.ObjectState = ObjectState.Modified;
            int rateCategoryId = 1;
            var rateCategory = new RateCategory() { Id = 1, Name = "RateCategory1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<RateCategory>>() { Result = new List<RateCategory>() { rateCategory } };
            var pred = new Func<RateCategory, bool>(x => x.Id == rateCategoryId && !x.IsDeleted);

            iRateCategoryLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RateCategory, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            iRateCategoryLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<RateCategory>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true })).Verifiable();
            
            var ratePlanbaseResult = new BaseResult<List<RatePlans>>();
            ratePlanbaseResult.Result = null;
            var ratePlanPred = new Func<RatePlans, bool>(x => x.RateCategoryId == rateCategoryId && x.IsActive);
            iRatePlansLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RatePlans, bool>>(y => y.GetType() == ratePlanPred.GetType()))).Returns(Task.FromResult(ratePlanbaseResult));
            
            //Act
            Task<BaseResult<RateCategory>> actionResult = rateCategoryRepository.SaveAndUpdateRateCategory(rateCategoryViewModel, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.Message != null);
        }

        #endregion Negative Test Cases
        #endregion SaveAndUpdateRateCategory
    }
}
