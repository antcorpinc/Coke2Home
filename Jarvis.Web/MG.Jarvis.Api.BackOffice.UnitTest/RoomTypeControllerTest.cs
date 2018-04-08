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
    public class RoomTypeControllerTest
    {
        #region private variable
        private RoomTypeController mockRoomTypeController;
        private Mock<ILogger> loggerMock;
        private Mock<IMapping<RoomTypes>> iMappingMock;
        #endregion Private Variables

        public RoomTypeControllerTest()
        {
            iMappingMock = new Mock<IMapping<RoomTypes>>();
            loggerMock = new Mock<ILogger>();
            mockRoomTypeController = new RoomTypeController(loggerMock.Object, iMappingMock.Object);
        }

        [Test]
        public void TestRoomTypeControllerMappingReturnResultIsNullFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockRoomTypeController.Mapping().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestRoomTypeControllerMappingReturnResultThrowsExceptionFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockRoomTypeController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestRoomTypeControllerMappingReturnOKSuccess()
        {
            IEnumerable<dynamic> fakeRoomTypeMappingList = this.GetRoomTypeMappingList();


            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeRoomTypeMappingList }));

            var result = mockRoomTypeController.Mapping().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestRoomTypeControllerGetMappingFromNullTable()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new MyException("No columns were selected"));
            var result = mockRoomTypeController.Mapping().Result;
            Assert.That(((NoContentResult)result).StatusCode is 204);
        }

        [Test]
        public void TestRoomTypeControllerGetMappingThrowsException()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new Exception());
            var result = mockRoomTypeController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        private IEnumerable<dynamic> GetRoomTypeMappingList()
        {
            dynamic roomTypeMappingList = new List<Dictionary<string, dynamic>>();

            roomTypeMappingList.Add(new Dictionary<string, dynamic>());
            
            roomTypeMappingList[0]["MgRoomId"] = 1;
            roomTypeMappingList[0]["OccupancyId"] = 1;
            roomTypeMappingList[0]["MgHotelId"] = 1001;
            roomTypeMappingList[0]["MgRoomCategCode"] = "STD.DBL";
            roomTypeMappingList[0]["MgRoomCategName"] = "Double or Twin STANDARD 2 ADULTS";
            roomTypeMappingList[0]["HotelBeds"] = "DBT.ST";

            return roomTypeMappingList;
        }
    }
}
