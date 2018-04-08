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
    public class PromotionControllerTest
    {
        #region private variable
        private PromotionController mockPromotionController;
        private Mock<ILogger> loggerMock;
        private Mock<IMapping<Promotions>> iMappingMock;
        #endregion Private Variables

        public PromotionControllerTest()
        {
            iMappingMock = new Mock<IMapping<Promotions>>();
            loggerMock = new Mock<ILogger>();
            mockPromotionController = new PromotionController(loggerMock.Object, iMappingMock.Object);
        }

        [Test]
        public void TestPromotionControllerMappingReturnResultIsNullFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockPromotionController.Mapping().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestPromotionControllerMappingReturnResultThrowsExceptionFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockPromotionController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestPromotionControllerMappingReturnOKSuccess()
        {
            IEnumerable<dynamic> fakePromotionMappingList = this.GetPromotionMappingList();


            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakePromotionMappingList }));

            var result = mockPromotionController.Mapping().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestPromotionsControllerGetMappingFromNullTable()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new MyException("No columns were selected"));
            var result = mockPromotionController.Mapping().Result;
            Assert.That(((NoContentResult)result).StatusCode is 204);
        }

        [Test]
        public void TestPromotionsControllerGetMappingThrowsException()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new Exception());
            var result = mockPromotionController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        private IEnumerable<dynamic> GetPromotionMappingList()
        {
            dynamic PromotionMappingList = new List<Dictionary<string, dynamic>>();

            PromotionMappingList.Add(new Dictionary<string, dynamic>());

            PromotionMappingList[0]["MgPromotionId"] = 1;
            PromotionMappingList[0]["MgPromotionCode"] = "Room Only";
            PromotionMappingList[0]["MgPromotionName"] = "Room Only";
            PromotionMappingList[0]["MgHotelId"] = 1001;
            PromotionMappingList[0]["HotelBeds"] = "SC";

            return PromotionMappingList;
        }
    }
}
