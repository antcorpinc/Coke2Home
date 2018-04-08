using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class HotelManagementControllerTest
    {
        private HotelManagementController hotelManagementController;
        private Mock<IHotels> iHotelMock;
        private Mock<IMasterData> iMasterDataMock;
        public HotelManagementControllerTest()
        {
            iHotelMock = new Mock<IHotels>();
            iMasterDataMock = new Mock<IMasterData>();
            hotelManagementController = new HotelManagementController(iHotelMock.Object);
        }
        //[Test]
        //public void TestGetAllHotels_Success_OKResponse()
        //{
        //    //Arrange
        //    var dataRow = new Dictionary<string, object>()
        //    {
        //        {"HotelId",1 },{ "HotelCode","HTL01"},
        //        //{"CityName","chip"},{"CountryName","del"},
        //        {"HotelLocation","Chip,Dell" },
        //        {"ContactPerson","Jayesh Kalal"},{"EmailAddress","jayeshk@cybage.com"},
        //        {"PhoneNumber","1234123412"},{"IsActive",true},{"HotelName","Novotel"},
        //        {"HotelBrandId",1},{"HotelBrandName","testBrand"}
        //    };
        //    iHotelMock.Setup(x => x.GetAllHotels()).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()
        //    {
        //        Result = new List<dynamic>()
        //        {
        //            dataRow
        //        }

        //    })).Verifiable();

        //    //Act
        //    var result = hotelManagementController.GetAllHotels();
        //    //Assert
        //    iHotelMock.Verify();
        //    Assert.IsTrue(result.Result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
        //}

        [Test]
        public void TestGetAllHotels_Failed_Error()
        {
            //Arrange
            //iHotelMock.Setup(x => x.GetAllHotels()).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()
            //{
            //    IsError=true,
            //    Message="error"
            //})).Verifiable();

            //Act
            var result = hotelManagementController.GetAllHotels();
            //Assert
            iHotelMock.Verify();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetAllHotels_Success_NoContent()
        {
            //Arrange
            //iHotelMock.Setup(x => x.GetAllHotels()).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()
            //{
            //    Result = new List<dynamic>() { }
            //})).Verifiable();

            //Act
            var result = hotelManagementController.GetAllHotels();
            //Assert
            iHotelMock.Verify();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);
        }

        [Test]
        public void TestGetHotel_Success_OKResponse()
        {
            var dataRow = new Dictionary<string, object>()
            {
                {"Id",1 },
                {"Code","HTL01"},
                {"CityName","Kansas City"},
                {"CountryName","Kentucky"},
                {"IsActive",true },
                {"Name","Cobra" },
                {"HotelChainId",100 },
                {"HotelBrandId",200 },
                {"HotelTypeId",111 },
                {"CountryId",101 },
                {"CityId",501 },
                {"Latitude",100.001 },
                {"Longitude",200.002 },
                {"ShortDescription","Nice hotel to stay in weekends" },
                {"LongDescription","Nice hotel to stay in weekends" },
                {"Website","qwerty@yahoo.com" },
                {"Email","aswerty@gmail.com" },
                {"Telephone","1231231232" },
                {"Address1","Address1" },
                {"Address2","Address2" },
                {"ZipCode","123123" },
                {"PaymentMethodId",123 },
                {"CurrencyId",789 },
                {"RateTypeId",567 },
                {"IsExtranetAccess",false },
                {"IsChannelManagerConnectivity",false },
                {"ChannelManagerId",1122 },
                {"StarRating",89 },
                {"ContactId",111 },
                {"IsPrimary",false },
                {"ContactPerson","ContactPerson" },
                {"DesignationId",789 },
                {"EmailAddress","aswerty@gmail.com" },
                {"ContactNumber","1231231233" },
                {"TaxApplicabilityId",334 },
                {"TaxTypeId",67 },
                {"TaxesType","Income" },
                {"Amount",100.50 },
                {"IsIncludedInRates",true },

            };
            //iHotelMock.Setup(x => x.GetHotel(5)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()
            //{
            //    Result = new List<dynamic>()
            //    {
            //        dataRow
            //    }

            //})).Verifiable();
            var result = hotelManagementController.GetHotel(5);
            iHotelMock.Verify();
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
        }

        [Test]
        public void TestGetHotel_Failed_Error()
        {
//            iHotelMock.Setup(x => x.GetHotel(5)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()
//            {
//                IsError = true,
//#pragma warning disable CA2201 // Do not raise reserved exception types
//                ExceptionMessage = new Exception("null"),
//#pragma warning restore CA2201 // Do not raise reserved exception types
//            })).Verifiable();

            var result = hotelManagementController.GetHotel(5);
            iHotelMock.Verify();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetHotel_Success_NoContent()
        {
            //iHotelMock.Setup(x => x.GetHotel(0)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()
            //{
            //    Result = new List<dynamic>() { }
            //})).Verifiable();

            //Act
            var result = hotelManagementController.GetHotel(0);
            //Assert
            iHotelMock.Verify();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);
        }

        #region DeleteHotelByHotelId
        #region Positive Test Case
        [Test]
        public async Task TestDeleteHotelByHotelId_Success_OkResponse()
        {
            // Arrange
            var id = 1;
            iHotelMock.Setup(a => a.DeleteHotelByHotelId(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));
            //Act
            var result = await hotelManagementController.DeleteHotelByHotelId(id);
            BaseResult<bool> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<bool>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
        }
        #endregion
        #region Negative Test Case
        [Test]
        public async Task TestDeleteHotelByHotelId_Failed_BadRequest()
        {
            // Arrange
            var id = -1;
            iHotelMock.Setup(a => a.DeleteHotelByHotelId(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));
            //Act
            var result = await hotelManagementController.DeleteHotelByHotelId(id);
            //Assert
            iHotelMock.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 400);
        }
        [Test]
        public async Task TestDeleteHotelByHotelId_Failed_Error()
        {
            // Arrange
            var id = 1;
            iHotelMock.Setup(a => a.DeleteHotelByHotelId(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));        
            //Act
            var result = await hotelManagementController.DeleteHotelByHotelId(id);
            //Assert
            iHotelMock.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);
        }

        [Test]
        public async Task TestDeleteHotelByHotelId_UpdateFailed_Error()
        {
            // Arrange
            var id = 1;
            iHotelMock.Setup(a => a.DeleteHotelByHotelId(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result=false }));
            //Act
            var result = await hotelManagementController.DeleteHotelByHotelId(id);
            //Assert
            iHotelMock.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);
        }
        #endregion
        #endregion


    }
}
