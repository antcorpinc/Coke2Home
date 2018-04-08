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
    public class HotelControllerTest
    {
        #region private variable
        private HotelController mockHotelController;
        private Mock<ILogger> loggerMock;
        private Mock<IMapping<Hotel>> iMappingMock;
        #endregion Private Variables

        public HotelControllerTest()
        {
            iMappingMock = new Mock<IMapping<Hotel>>();
            loggerMock = new Mock<ILogger>();
            mockHotelController = new HotelController(loggerMock.Object, iMappingMock.Object);
        }

        [Test]
        public void TestHotelControllerMappingReturnResultIsNullFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockHotelController.Mapping().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestHotelControllerMappingReturnResultThrowsExceptionFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockHotelController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestHotelControllerMappingReturnOKSuccess()
        {
            IEnumerable<dynamic> fakeHotelMappingList = this.GetHotelMappingList();


            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeHotelMappingList }));

            var result = mockHotelController.Mapping().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestHotelControllerGetMappingFromNullTable()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new MyException("No columns were selected"));
            var result = mockHotelController.Mapping().Result;
            Assert.That(((NoContentResult)result).StatusCode is 204);
        }

        [Test]
        public void TestHotelControllerGetMappingThrowsException()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new Exception());
            var result = mockHotelController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestHotelControllerCreateMappingNullRequestFail()
        {
            var result = mockHotelController.CreateMapping(null).Result;
            Assert.That(((BadRequestObjectResult)result).StatusCode is 400);
        }

        [Test]
        public void TestHotelControllerCreateMappingDapperFail()
        {
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierHotelCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = false, IsError = true }));

            var result = mockHotelController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestHotelControllerCreateMappingSystemException()
        {
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierHotelCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Throws(new Exception());

            var result = mockHotelController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestHotelControllerCreateMappingSuccess()
        {
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierHotelCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true, IsError = false }));

            var result = mockHotelController.CreateMapping(model).Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }


        private IEnumerable<dynamic> GetHotelMappingList()
        {
            dynamic hotelMappingList = new List<Dictionary<string, dynamic>>();

            hotelMappingList.Add(new Dictionary<string, dynamic>());
            
            hotelMappingList[0]["MgHotelId"] = 1001;
            hotelMappingList[0]["MgHotelCode"] = "ES10000001";
            hotelMappingList[0]["MgHotelName"] = "Flamero";
            hotelMappingList[0]["MgCityCode"] = "WSMA02021982";
            hotelMappingList[0]["SupplierCityCode"] = "LUS";

            return hotelMappingList;
        }
    }
}
