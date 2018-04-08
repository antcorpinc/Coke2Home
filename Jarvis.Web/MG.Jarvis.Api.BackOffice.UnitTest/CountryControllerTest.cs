using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class CountryControllerTest
    {
        #region private variable
        private CountriesController mockCountryController;
        private Mock<IMasterData<Country,int>> countryMock;
        private Mock<IMapping<Core.Model.Mappings.Country>> iMappingMock;
        private Mock<ILogger> loggerMock;
        #endregion Private Variables

        public CountryControllerTest()
        {
            countryMock = new Mock<IMasterData<Country,int>>();
            iMappingMock = new Mock<IMapping<Core.Model.Mappings.Country>>();
            loggerMock = new Mock<ILogger>();
            mockCountryController = new CountriesController(countryMock.Object, loggerMock.Object, iMappingMock.Object);
        }

        //[Test]
        //public void TestCountryControllerGetCountriesNoContentResponse()
        //{
        //    countryMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Country>>()));

        //    var result = countryController.Get().Result;
        //    Assert.IsTrue(result is NoContentResult);
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestCountryControllerGetCountriesExecptionInternalServerError()
        //{
        //    countryMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Country>> { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = countryController.Get().Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCountryControllerGetCountriesOKResponse()
        //{           
        //    List<Country> mockCountryList = new List<Country>
        //    {
        //         new Country {
        //            Code = "IND",
        //            ContinentId = 1,
        //            NameItemId = 1,
        //            Name = "India",
        //            IsActive = true,
        //            IsDeleted = false }
        //    };

        //    countryMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Country>>() { Result = mockCountryList, IsError = false }));

        //    var result = countryController.Get().Result;
        //    BaseResult<List<Country>> resultList = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<Country>>;

        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(!resultList.IsError);
        //    Assert.IsTrue(resultList.Result != null);
        //    Assert.IsTrue(resultList.Result.Count > 0);
        //}

        ////[Test]
        ////public void TestCountryControllerGetCountryByCodeWithEmptyCode()
        ////{
        ////    countryMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<Country>>()));

        ////    var result = countryController.GetCountryByCode(string.Empty).Result;
        ////    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        ////}

        ////[Test]
        ////public void TestCountryControllerGetCountryByCodeNoContentResponse()
        ////{
        ////    countryMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<Country>>()));

        ////    var result = countryController.GetCountryByCode("Test").Result;
        ////    Assert.IsTrue(result is NoContentResult);
        ////    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        ////}

        ////[Test]
        ////public void TestCountryControllerGetCountryByCodeExecptionInternalServerError()
        ////{
        ////    countryMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<Country>> { IsError = true, ExceptionMessage = new Exception() }));

        ////    var result = countryController.GetCountryByCode("Test").Result;
        ////    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        ////}

        ////[Test]
        ////public void TestCountryControllerGetCountryByCodeOKResponse()
        ////{
        ////    Func<Country, bool> func = x => x.IsDeleted == false;

        ////    List<Country> mockCountryList = new List<Country>
        ////    {
        ////         new Country {
        ////            Code = "IND",
        ////            ContinentId = 1,
        ////            NameItemId = 1,
        ////            Name = "India",
        ////            IsActive = true,
        ////            IsDeleted = false }
        ////    };

        ////    countryMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<Country>>() { Result = mockCountryList, IsError = false }));

        ////    var result = countryController.GetCountryByCode("IND").Result;
        ////    BaseResult<List<Country>> resultList = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<Country>>;

        ////    Assert.IsTrue(result is OkObjectResult);
        ////    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        ////    Assert.IsNotNull(result);
        ////    Assert.IsTrue(!resultList.IsError);
        ////    Assert.IsTrue(resultList.Result != null);
        ////    Assert.IsTrue(resultList.Result.Count == 1);
        ////}

        ////[Test]
        ////public void TestCountryControllerGetCountryByCodeNoRecordFound()
        ////{
        ////    Func<Country, bool> func = x => x.IsDeleted == false;

        ////    List<Country> mockCountryList = new List<Country>
        ////    {
        ////         new Country {
        ////            Code = "IND",
        ////            ContinentId = 1,
        ////            NameItemId = 1,
        ////            Name = "India",
        ////            IsActive = true,
        ////            IsDeleted = false }
        ////    };

        ////    countryMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<Country>>() { Result = mockCountryList, IsError = false }));

        ////    var result = countryController.GetCountryByCode("XYZ").Result;
        ////    Assert.IsTrue(result is NoContentResult);
        ////    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        ////}

        //[Test]
        //public void TestCountryControllerAddCountrySuccessResponse()
        //{
        //    Country country = new Country
        //    {
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.InsertEntity(country)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Code = "XYZ", ContinentId = 1, NameItemId = 1, Name = "India", IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = countryController.Create(country).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCountryControllerAddCountryFailedInvalidInputForNullObject()
        //{            
        //    var result = countryController.Create(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCountryControllerAddCountryFailedInvalidInputForEmptyCountryCode()
        //{
        //    var result = countryController.Create(new Country() { Code =string.Empty }).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Country"));
        //}

        //[Test]
        //public void TestCountryControllerAddCountryFailedInvalidInputForDuplicateCountry()
        //{
        //    Country country = new Country
        //    {
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.InsertEntity(country)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Code = "IND", ContinentId = 1, NameItemId = 1, Name = "India", IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = countryController.Create(country).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestCountryControllerAddCountrySuccessNoRecordToCheckDuplicacy()
        //{
        //    Country country = new Country
        //    {
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.InsertEntity(country)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()));

        //    var result = countryController.Create(country).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCountryControllerAddCountryExceptionInternalServerError()
        //{
        //    Country country = new Country
        //    {
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.InsertEntity(country))
        //        .Returns(Task.FromResult(
        //            new BaseResult<long>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()));

        //    var result = countryController.Create(country).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCountryControllerUpdateCountrySuccessResponse()
        //{
        //    Country country = new Country
        //    {
        //        Id =1,
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 1 , Code = "IND", Name = "India", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = countryController.Update(country).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCountryControllerUpdateCountryFailedInvalidInputRecordNotExists()
        //{
        //    Country country = new Country
        //    {
        //        Id = 2,
        //        Code = "XYZ",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "Indoneshia",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 1, Code = "IND", Name = "India", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = countryController.Update(country).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Country"));           
        //}

        //[Test]
        //public void TestCountryControllerUpdateCountryFailedInvalidInputForNullObject()
        //{
        //    var result = countryController.Update(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCountryControllerUpdateCountryFailedInvalidInputForEmptyCountryCode()
        //{
        //    Country country = new Country
        //    {
        //        Id = 2,
        //        Code = string.Empty, //Empty Code
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 2, Code = "XYZ", Name = "India", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = countryController.Update(country).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Country"));
        //}

        //[Test]
        //public void TestCountryControllerUpdateCountryFailedInvalidInputForMissingID()
        //{
        //    Country country = new Country
        //    {
        //        Id = 0, //Missing ID
        //        Code = "XYZ",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 2, Code = "XYZ", Name = "India", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = countryController.Update(country).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Country"));
        //}

        //[Test]
        //public void TestCountryControllerUpdateCountryFailedInvalidInputForDuplicateCountry()
        //{
        //    Country country = new Country
        //    {
        //        Id = 1,
        //        Code = "XYZ", //Duplicate code
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() {
        //            new Country { Id=1, Code = "IND", ContinentId = 1, NameItemId = 1, Name = "India", IsActive = true, IsDeleted = false },
        //            new Country { Id=2, Code = "XYZ", ContinentId = 2, NameItemId = 1, Name = "Indoneshia", IsActive = true, IsDeleted = false }
        //        }
        //    }));

        //    var result = countryController.Update(country).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.DuplicateCodeExists, "Country"));
        //}

        //[Test]
        //public void TestCountryControllerUpdateCountryExceptionInternalServerError()
        //{
        //    Country country = new Country
        //    {
        //        Id = 1,
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 1, Code = "IND", Name = "India", IsActive = false, IsDeleted = false } }
        //    }));
        //    countryMock.Setup(x => x.UpdateEntity(country))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));          

        //    var result = countryController.Update(country).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCountryControllerDeleteCountrySuccessResponse()
        //{
        //    Country country = new Country
        //    {
        //        Id = 1,
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 1, Code = "IND", Name = "India", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = countryController.Delete(country).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCountryControllerDeleteCountryFailedInvalidInputRecordNotExists()
        //{
        //    Country country = new Country
        //    {
        //        Id = 2,
        //        Code = "XYZ",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "Indoneshia",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 1, Code = "IND", Name = "India", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = countryController.Delete(country).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Country"));
        //}

        //[Test]
        //public void TestCountryControllerDeleteCountryFailedInvalidInputForNullObject()
        //{
        //    var result = countryController.Delete(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCountryControllerDeleteCountryFailedInvalidInputForMissingID()
        //{
        //    Country country = new Country
        //    {
        //        Id = 0, //Missing ID
        //        Code = "XYZ",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 2, Code = "XYZ", Name = "India", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = countryController.Delete(country).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Country"));
        //}

        //[Test]
        //public void TestCountryControllerDeleteCountryExceptionInternalServerError()
        //{
        //    Country country = new Country
        //    {
        //        Id = 1,
        //        Code = "IND",
        //        ContinentId = 1,
        //        NameItemId = 1,
        //        Name = "India",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    countryMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
        //    {
        //        Result = new List<Country>() { new Country { Id = 1, Code = "IND", Name = "India", IsActive = false, IsDeleted = false } }
        //    }));
        //    countryMock.Setup(x => x.UpdateEntity(country))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = countryController.Delete(country).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        [Test]

        public void TestCountryControllerUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            Country country = new Country
            {
                Code = "IN",
                Name = "India",
                IsActive = true,
                NameItemId = 1,
                IsDeleted = false
            };

            countryMock.Setup(x => x.UpdateEntity(country)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

            var result = mockCountryController.Update(country).Result;
            Assert.That(result is BadRequestObjectResult);
        }

        [Test]
        public void TestCountryControllerMappingReturnResultIsNullFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockCountryController.Mapping().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestCountryControllerMappingReturnResultThrowsExceptionFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockCountryController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCountryControllerMappingReturnOKSuccess()
        {
            IEnumerable<dynamic> fakeCountryMappingList = this.GetCountryMappingList();


            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeCountryMappingList }));

            var result = mockCountryController.Mapping().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestCountryControllerGetMappingFromNullTable()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new MyException("No columns were selected"));
            var result = mockCountryController.Mapping().Result;
            Assert.That(((NoContentResult)result).StatusCode is 204);
        }

        [Test]
        public void TestCountryControllerGetMappingThrowsException()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new Exception());
            var result = mockCountryController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCountryControllerCreateMappingNullRequestFail()
        {
            var result = mockCountryController.CreateMapping(null).Result;
            Assert.That(((BadRequestObjectResult)result).StatusCode is 400);
        }

        [Test]
        public void TestCountryControllerCreateMappingDapperFail()
        {            
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierCountryCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = false, IsError = true }));

            var result = mockCountryController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCountryControllerCreateMappingSystemException()
        {            
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierCountryCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Throws(new Exception());

            var result = mockCountryController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCountryControllerCreateMappingSuccess()
        {            
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierCountryCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true, IsError = false }));

            var result = mockCountryController.CreateMapping(model).Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }
                
        private IEnumerable<dynamic> GetCountryMappingList()
        {
            dynamic countryMappingList = new List<Dictionary<string, string>>();

            countryMappingList.Add(new Dictionary<string, string>());
            
            countryMappingList[0]["MgCountryId"] = "1";
            countryMappingList[0]["MgCountryCode"] = "IN";
            countryMappingList[0]["MgCountryName"] = "INDIA";

            return countryMappingList;
        }

    }
}
