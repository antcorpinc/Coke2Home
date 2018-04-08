using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using ER = MG.Jarvis.Api.Extranet.Repositories;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class MealPlanControllerTest
    {
        #region Private Variables
        private MealPlanController mealPlanController;
        private IMealPlan mealPlanRepository;

        private IConnection<Meals> iMealsConnectionLibrary;
        private IConnection<CuisineType> iCuisineTypeConnectionLibrary;

        private IConnection<HotelMeal> iHotelMealConnectionLibrary;
        private IConnection<HotelMealType> iHotelMealTypeConnectionLibrary;

        private MealPlanController mockMealPlanController;
        private Mock<IMealPlan> mockMealPlanRepository;
        public IConfigurationRoot Configuration { get; }
        #endregion Private Variables

        #region Settings
        public MealPlanControllerTest()
        {
            mockMealPlanRepository = new Moq.Mock<IMealPlan>();
            mockMealPlanController = new MealPlanController(mockMealPlanRepository.Object);

            mealPlanRepository = new ER.MealPlanRepository(iMealsConnectionLibrary, iCuisineTypeConnectionLibrary, iHotelMealConnectionLibrary, iHotelMealTypeConnectionLibrary);
            mealPlanController = new MealPlanController(mealPlanRepository);
        }
        #endregion Settings

        #region GetMeals
        #region Negative Test Cases
        [Test]
        public void TestGetMeals_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MealList);
            mockMealPlanRepository.Setup(a => a.GetMeals()).Returns(Task.FromResult(new BaseResult<List<Meals>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockMealPlanController.GetMeals();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetMeals_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MealList);
            mockMealPlanRepository.Setup(a => a.GetMeals()).Returns(Task.FromResult(new BaseResult<List<Meals>> { Result = new List<Meals>() }));
            mockMealPlanRepository.Setup(a => a.GetMeals()).Returns(Task.FromResult(new BaseResult<List<Meals>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockMealPlanController.GetMeals();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
        public async Task TestGetMeals_Success_OkResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MealList);
            mockMealPlanRepository.Setup(a => a.GetMeals()).Returns(Task.FromResult(new BaseResult<List<Meals>>() { Result = new List<Meals> { new Meals { Id = 1, Meal = "Bed & BreakFast", IsActive = true } } }));
            Task<IActionResult> actionResult = mockMealPlanController.GetMeals();
            BaseResult<List<MealsViewModel>> mealsList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<MealsViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(mealsList);
            Assert.IsTrue(!mealsList.IsError);
            Assert.IsTrue(mealsList.Result != null);
            Assert.IsTrue(mealsList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<Meals>>(Constants.CacheKeys.MealList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MealList);
        }
        #endregion Postive Test Cases
        #endregion GetMeals

        #region GetCuisineType
        #region Negative Test Cases
        [Test]
        public void TestGetCuisineTypes_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CuisineTypeList);
            mockMealPlanRepository.Setup(a => a.GetCuisineType()).Returns(Task.FromResult(new BaseResult<List<CuisineType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockMealPlanController.GetCuisineType();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetCuisineTypes_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CuisineTypeList);
            mockMealPlanRepository.Setup(a => a.GetCuisineType()).Returns(Task.FromResult(new BaseResult<List<CuisineType>> { Result = new List<CuisineType>() }));
            mockMealPlanRepository.Setup(a => a.GetCuisineType()).Returns(Task.FromResult(new BaseResult<List<CuisineType>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockMealPlanController.GetCuisineType();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
        public async Task TestGetCuisineTypes_Success_OkResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CuisineTypeList);
            mockMealPlanRepository.Setup(a => a.GetCuisineType()).Returns(Task.FromResult(new BaseResult<List<CuisineType>>() { Result = new List<CuisineType> { new CuisineType { Id = 1, Cusine = "Indian", IsActive = true } } }));
            Task<IActionResult> actioResult = mockMealPlanController.GetCuisineType();
            BaseResult<List<CuisineTypeViewModel>> cuisineTypeList = (actioResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<CuisineTypeViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult.Result).StatusCode, 200);
            Assert.IsNotNull(cuisineTypeList);
            Assert.IsTrue(!cuisineTypeList.IsError);
            Assert.IsTrue(cuisineTypeList.Result != null);
            Assert.IsTrue(cuisineTypeList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<CuisineType>>(Constants.CacheKeys.CuisineTypeList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CuisineTypeList);
        }
        #endregion Postive Test Cases
        #endregion GetCuisineType

        #region GetMealPlan
        #region Negative Test Cases
        [Test]
        public void TestGetMealPlan_Exception_ByHotelMeal_InternalServerError()
        {
            int hotelId = 5;
            mockMealPlanRepository.Setup(a => a.GetHotelMeal(hotelId)).Returns(Task.FromResult(new BaseResult<List<HotelMeal>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockMealPlanController.GetMealPlan(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetMealPlan_Exception_ByHotelMealType_InternalServerError()
        {
            int hotelId = 5;
            mockMealPlanRepository.Setup(a => a.GetHotelMeal(hotelId)).Returns(Task.FromResult(new BaseResult<List<HotelMeal>>() { Result = new List<HotelMeal> { new HotelMeal { Id = 1, HotelId = 5, MealId = 2, Price = 10000, CurrencyId = 7, IsDeleted = false } } }));
            mockMealPlanRepository.Setup(a => a.GetHotelMealType(hotelId)).Returns(Task.FromResult(new BaseResult<List<HotelMealType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockMealPlanController.GetMealPlan(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetMealPlan_EmptyResult_ByHotelMeal_NoContentResponse()
        {
            int hotelId = 5;
            mockMealPlanRepository.Setup(a => a.GetHotelMeal(hotelId)).Returns(Task.FromResult(new BaseResult<List<HotelMeal>> { Result = new List<HotelMeal>() }));
            mockMealPlanRepository.Setup(a => a.GetHotelMeal(hotelId)).Returns(Task.FromResult(new BaseResult<List<HotelMeal>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockMealPlanController.GetMealPlan(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }

        [Test]
        public void TestGetMealPlan_Failed_BadRequest()
        {
            int hotelId = 0;
            //Act
            var result = mockMealPlanController.GetMealPlan(hotelId);
            //Assert
            mockMealPlanRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestResult);
            Assert.AreEqual(((BadRequestResult)result.Result).StatusCode, 400);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
        public async Task TestGetMealPlan_Success_OkResponse()
        {
            int hotelId = 5;
            mockMealPlanRepository.Setup(a => a.GetHotelMeal(hotelId)).Returns(Task.FromResult(new BaseResult<List<HotelMeal>>() { Result = new List<HotelMeal> { new HotelMeal { Id = 1, HotelId = 5, MealId = 2, Price = 10000, CurrencyId = 7, IsDeleted = false } } }));
            mockMealPlanRepository.Setup(a => a.GetHotelMealType(hotelId)).Returns(Task.FromResult(new BaseResult<List<HotelMealType>>() { Result = new List<HotelMealType> { new HotelMealType { Id = 1, HotelId = 5, MealId = 2, CuisineTypeId = 2, Code = "HotelId_CusisineId", IsActive = true, IsDeleted = false } } }));
            Task<IActionResult> actionResult = mockMealPlanController.GetMealPlan(hotelId);
            BaseResult<List<MealPlanViewModel>> mealPlanList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<MealPlanViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(mealPlanList);
            Assert.IsTrue(mealPlanList.Result != null);
            Assert.IsTrue(mealPlanList.Result.Count > 0);
        }
        #endregion Postive Test Cases
        #endregion GetMealPlan

        #region CreateMealPlan
        #region Negative Test Cases

        [Test]
        public void TestCreateMealPlan_Exception_Failed_Error()
        {
            //Arrange
            List<MealPlanViewModel> mealPlanViewModelList = new List<MealPlanViewModel>();

            List<CuisineTypeViewModel> cuisineTypeViewModelList = new List<CuisineTypeViewModel>();
            CuisineTypeViewModel cuisine1 = new CuisineTypeViewModel()
            {
                Id = 1,
                Cusine = "Indian",
                IsSelected = true,
                ObjectState = ObjectState.Added
            };
            CuisineTypeViewModel cuisine2 = new CuisineTypeViewModel()
            {
                Id = 2,
                Cusine = "Asian",
                IsSelected = true,
                ObjectState = ObjectState.Added
            };
            cuisineTypeViewModelList.Add(cuisine1);
            cuisineTypeViewModelList.Add(cuisine2);

            MealPlanViewModel mealPlanViewModel = new MealPlanViewModel()
            {
                HotelId = 1103,
                MealId = 1,
                IsSelected = true,
                ObjectState = ObjectState.Added,
                MealPlanOptions = new MealOptionViewModel()
                {
                    CurrencyId = 1,
                    Price = 1000,
                    ObjectState = ObjectState.Added,

                }
            };
            mealPlanViewModel.MealPlanOptions.CuisineOptions.AddRange(cuisineTypeViewModelList);
            mealPlanViewModelList.Add(mealPlanViewModel);

            mockMealPlanRepository.Setup(x => x.SaveAndUpdateHotelMealAndMealType(It.IsAny<List<MealPlanViewModel>>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<HotelMealType>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockMealPlanController.CreateMealPlan(mealPlanViewModelList);

            //Assert
            mockMealPlanRepository.Verify();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestCreateMealPlan_Exception_Failed_NoContentResponse()
        {
            //Arrange
            List<MealPlanViewModel> mealPlanViewModelList = new List<MealPlanViewModel>();

            List<CuisineTypeViewModel> cuisineTypeViewModelList = new List<CuisineTypeViewModel>();
            CuisineTypeViewModel cuisine1 = new CuisineTypeViewModel()
            {
                Id = 1,
                Cusine = "Indian",
                IsSelected = true,
                ObjectState = ObjectState.Added
            };
            CuisineTypeViewModel cuisine2 = new CuisineTypeViewModel()
            {
                Id = 2,
                Cusine = "Asian",
                IsSelected = true,
                ObjectState = ObjectState.Added
            };
            cuisineTypeViewModelList.Add(cuisine1);
            cuisineTypeViewModelList.Add(cuisine2);

            MealPlanViewModel mealPlanViewModel = new MealPlanViewModel()
            {
                HotelId = 1103,
                MealId = 1,
                IsSelected = true,
                ObjectState = ObjectState.Added,
                MealPlanOptions = new MealOptionViewModel()
                {
                    CurrencyId = 1,
                    Price = 1000,
                    ObjectState = ObjectState.Added,

                }
            };
            mealPlanViewModel.MealPlanOptions.CuisineOptions.AddRange(cuisineTypeViewModelList);
            mealPlanViewModelList.Add(mealPlanViewModel);

            mockMealPlanRepository.Setup(a => a.SaveAndUpdateHotelMealAndMealType(It.IsAny<List<MealPlanViewModel>>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<HotelMealType> { Result = new HotelMealType() }));
            mockMealPlanRepository.Setup(a => a.SaveAndUpdateHotelMealAndMealType(It.IsAny<List<MealPlanViewModel>>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<HotelMealType> { Result = null })).Verifiable();

            //Act
            Task<IActionResult> actionResult = mockMealPlanController.CreateMealPlan(mealPlanViewModelList);

            //Assert
            mockMealPlanRepository.Verify();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        
        [Test]
        public void TestCreateMealPlan_Failed_BadRequest()
        {
            //Arrange
            var mealPlanViewModelList = new List<MealPlanViewModel>()
            {

            };
            //Act
            var result = mockMealPlanController.CreateMealPlan(mealPlanViewModelList);
            //Assert
            mockMealPlanRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestResult);
            Assert.AreEqual(((BadRequestResult)result.Result).StatusCode, 400);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
        public void TestCreateMealPlan_Success_OKResponse()
        {
            //Arrange
            BaseResult<HotelMealType> baseResult = new BaseResult<HotelMealType>();
            baseResult.Result = new HotelMealType() { Id = 1 };
            List<MealPlanViewModel> mealPlanViewModelList = new List<MealPlanViewModel>();

            List<CuisineTypeViewModel> cuisineTypeViewModelList = new List<CuisineTypeViewModel>();
            CuisineTypeViewModel cuisine1 = new CuisineTypeViewModel()
            {
                Id = 1,
                Cusine = "Indian",
                IsSelected = true,
                ObjectState = ObjectState.Added
            };
            CuisineTypeViewModel cuisine2 = new CuisineTypeViewModel()
            {
                Id = 2,
                Cusine = "Asian",
                IsSelected = true,
                ObjectState = ObjectState.Added
            };
            cuisineTypeViewModelList.Add(cuisine1);
            cuisineTypeViewModelList.Add(cuisine2);

            MealPlanViewModel mealPlanViewModel = new MealPlanViewModel()
            {
                HotelId = 1103,
                MealId = 1,
                IsSelected = true,
                ObjectState = ObjectState.Added,
                MealPlanOptions = new MealOptionViewModel()
                {
                    CurrencyId = 1,
                    Price = 1000,
                    ObjectState = ObjectState.Added,

                }
            };
            mealPlanViewModel.MealPlanOptions.CuisineOptions.AddRange(cuisineTypeViewModelList);
            mealPlanViewModelList.Add(mealPlanViewModel);

            mockMealPlanRepository.Setup(x => x.SaveAndUpdateHotelMealAndMealType(It.IsAny<List<MealPlanViewModel>>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<HotelMealType>()
            {
                Result = baseResult.Result
            })).Verifiable();

            //Act
            var result = mockMealPlanController.CreateMealPlan(mealPlanViewModelList);

            //Assert
            mockMealPlanRepository.Verify();
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
        }
        #endregion Postive Test Cases
        #endregion CreateMealPlan
    }
}
