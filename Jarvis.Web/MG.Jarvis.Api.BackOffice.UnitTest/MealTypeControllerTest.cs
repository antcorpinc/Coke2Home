using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Mappings;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class MealTypeControllerTest
    {
        #region private variable
        private MealTypeController mockMealTypeController;
        private Mock<ILogger> loggerMock;
        private Mock<IMapping<MealTypes>> iMappingMock;
        #endregion Private Variables

        public MealTypeControllerTest()
        {
            iMappingMock = new Mock<IMapping<MealTypes>>();
            loggerMock = new Mock<ILogger>();
            mockMealTypeController = new MealTypeController(loggerMock.Object, iMappingMock.Object);
        }

        [Test]
        public void TestMealTypeControllerMappingReturnResultIsNullFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockMealTypeController.Mapping().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestMealTypeControllerMappingReturnResultThrowsExceptionFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockMealTypeController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestMealTypeControllerMappingReturnOKSuccess()
        {
            IEnumerable<dynamic> fakeMealTypeMappingList = this.GetMealTypeMappingList();


            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeMealTypeMappingList }));

            var result = mockMealTypeController.Mapping().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestMealTypeControllerGetMappingFromNullTable()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new MyException("No columns were selected"));
            var result = mockMealTypeController.Mapping().Result;
            Assert.That(((NoContentResult)result).StatusCode is 204);
        }

        [Test]
        public void TestMealTypeControllerGetMappingThrowsException()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new Exception());
            var result = mockMealTypeController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        private IEnumerable<dynamic> GetMealTypeMappingList()
        {
            dynamic mealTypeMappingList = new List<Dictionary<string, dynamic>>();

            mealTypeMappingList.Add(new Dictionary<string, dynamic>());
            
            mealTypeMappingList[0]["MgMealTypeId"] = 1;
            mealTypeMappingList[0]["MgMealTypeCode"] = "Room Only";
            mealTypeMappingList[0]["MgMealTypeName"] = "Room Only";
            mealTypeMappingList[0]["MgHotelId"] = 1001;
            mealTypeMappingList[0]["HotelBeds"] = "SC";

            return mealTypeMappingList;
        }
    }
}
