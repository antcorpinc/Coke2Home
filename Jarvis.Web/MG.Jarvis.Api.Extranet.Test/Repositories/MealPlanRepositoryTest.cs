using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
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
using System.Threading.Tasks;
using ER = MG.Jarvis.Api.Extranet.Repositories;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    public class MealPlanRepositoryTest:BaseTestFixture
    {
        #region private variables
        private IMealPlan mealPlanRepository;

        private Mock<IConnection<Meals>> iMealsConnectionLibrary;
        private Mock<IConnection<CuisineType>> iCuisineTypeConnectionLibrary;
        private Mock<IConnection<HotelMeal>> iHotelMealConnectionLibrary;
        private Mock<IConnection<HotelMealType>> iHotelMealTypeConnectionLibrary;
        #endregion private variables

        #region settings
        public MealPlanRepositoryTest()
        {

            iMealsConnectionLibrary = new Mock<IConnection<Meals>>();
            iCuisineTypeConnectionLibrary = new Mock<IConnection<CuisineType>>();
            iHotelMealConnectionLibrary = new Mock<IConnection<HotelMeal>>();
            iHotelMealTypeConnectionLibrary = new Mock<IConnection<HotelMealType>>();
            mealPlanRepository = new ER.MealPlanRepository(iMealsConnectionLibrary.Object, iCuisineTypeConnectionLibrary.Object, iHotelMealConnectionLibrary.Object, iHotelMealTypeConnectionLibrary.Object);
            
        }
        #endregion settings

        [Test]
        public async Task TestGetMeals_positive_Predicate_sample()
        {
            //Arrange
            var meal = new Meals() { Id = 1, Meal = "Breakfast", IsActive = true };
            var baseResult = new BaseResult<List<Meals>>() { Result = new List<Meals>() { meal } };
            var pred = new Func<Meals, bool>(x => x.IsActive && !x.IsDeleted);

            iMealsConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<Meals, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<Meals>>> result = mealPlanRepository.GetMeals();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<Meals>>);
        }

        [Test]
        public async Task TestGetCuisineType_positive_Predicate_sample()
        {
            //Arrange
            var cusine = new CuisineType() { Id = 1, Cusine = "Italian", IsActive = true };
            var baseResult = new BaseResult<List<CuisineType>>() { Result = new List<CuisineType>() { cusine } };
            var pred = new Func<CuisineType, bool>(x => x.IsActive && !x.IsDeleted);

            iCuisineTypeConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<CuisineType, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<CuisineType>>> result = mealPlanRepository.GetCuisineType();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<CuisineType>>);
        }

        [Test]
        public async Task TestGetHotelMeal_positive_Predicate_sample()
        {
            //Arrange
            int hotelId = 5;
            var hotelMeal = new HotelMeal() { Id = 1, HotelId = 5, MealId = 1, Price = 1000, CurrencyId = 7, IsDeleted=false };
            var baseResult = new BaseResult<List<HotelMeal>>() { Result = new List<HotelMeal>() { hotelMeal } };
            var pred = new Func<HotelMeal, bool>(x => x.HotelId==hotelMeal.HotelId && !x.IsDeleted);

            iHotelMealConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<HotelMeal, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<HotelMeal>>> result = mealPlanRepository.GetHotelMeal(hotelId);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<HotelMeal>>);
        }

        [Test]
        public async Task TestGetHotelMealType_positive_Predicate_sample()
        {
            //Arrange
            int hotelId = 5;
            var hotelMealType = new HotelMealType() { Id = 1, HotelId = 5, MealId=1, CuisineTypeId=1, Name ="Breakfast", Code="BFC" };
            var baseResult = new BaseResult<List<HotelMealType>>() { Result = new List<HotelMealType>() { hotelMealType } };
            var pred = new Func<HotelMealType, bool>(x => x.IsActive && !x.IsDeleted);

            iHotelMealTypeConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<HotelMealType, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<HotelMealType>>> result = mealPlanRepository.GetHotelMealType(hotelId);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<HotelMealType>>);
        }

        #region SaveAndUpdateHotelMealAndMealType

        #region Negative Test Cases
        [Test]
        public async Task TestSaveAndUpdateHotelMeal_Save_Failed_Error()
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
            iHotelMealConnectionLibrary.Setup(x => x.InsertEntity(It.IsAny<HotelMeal>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<BaseResult<HotelMealType>> actionResult = mealPlanRepository.SaveAndUpdateHotelMealAndMealType(mealPlanViewModelList, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestSaveAndUpdateHotelMeal_Update_ByHotelMeal_Failed_Error()
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
                ObjectState = ObjectState.Modified,
                MealPlanOptions = new MealOptionViewModel()
                {
                    CurrencyId = 1,
                    Price = 1000,
                    ObjectState = ObjectState.Modified,

                }
            };
            mealPlanViewModel.MealPlanOptions.CuisineOptions.AddRange(cuisineTypeViewModelList);
            mealPlanViewModelList.Add(mealPlanViewModel);

            //var hotelMealModel = new HotelMeal()
            //{
            //    Id = 1,
            //    HotelId = 5,
            //    MealId = 2,
            //    Code = "Meal_2",
            //    IsDeleted = false,
            //    Price = 1000,
            //    CurrencyId = 1
            //};
            //var hotelMealModelList = new List<HotelMeal>();
            //hotelMealModelList.Add(hotelMealModel);
            //var baseResult = new BaseResult<List<HotelMeal>>() { Result = hotelMealModelList };

            var hotelMeal = new HotelMeal() { Id = 1, HotelId = 5, MealId = 1, Price = 1000, CurrencyId = 7, IsDeleted = false };
            var hotelMealbaseResult = new BaseResult<List<HotelMeal>>() { Result = new List<HotelMeal>() { hotelMeal } };
            var pred = new Func<HotelMeal, bool>(x => x.HotelId == hotelMeal.HotelId && !x.IsDeleted);

            iHotelMealConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<HotelMeal, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(hotelMealbaseResult));

            iHotelMealConnectionLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<HotelMeal>())).Returns(Task.FromResult(new BaseResult<bool>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();


            //Act
            Task<BaseResult<HotelMealType>> actionResult = mealPlanRepository.SaveAndUpdateHotelMealAndMealType(mealPlanViewModelList, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestSaveAndUpdateHotelMeal_Update_ByHotelMealPredicate_Failed_Error()
        {
            //Arrange
            BaseResult<HotelMealType> baseResult = new BaseResult<HotelMealType>();
            baseResult.Result = new HotelMealType() { };
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
                ObjectState = ObjectState.Modified,
                MealPlanOptions = new MealOptionViewModel()
                {
                    CurrencyId = 1,
                    Price = 1000,
                    ObjectState = ObjectState.Modified,

                }
            };
            mealPlanViewModel.MealPlanOptions.CuisineOptions.AddRange(cuisineTypeViewModelList);
            mealPlanViewModelList.Add(mealPlanViewModel);

            var hotelMeal = new HotelMeal() {  };
            var hotelMealbaseResult = new BaseResult<List<HotelMeal>>() { Result = new List<HotelMeal>() { hotelMeal } };
            var pred = new Func<HotelMeal, bool>(x => x.HotelId == hotelMeal.HotelId && !x.IsDeleted);

            iHotelMealConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<HotelMeal, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(hotelMealbaseResult));

            //Act
            Task<BaseResult<HotelMealType>> actionResult = mealPlanRepository.SaveAndUpdateHotelMealAndMealType(mealPlanViewModelList, It.IsAny<string>());

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }
        #endregion Negative Test Cases
        
        #endregion SaveAndUpdateHotelMealAndMealType
    }
}
