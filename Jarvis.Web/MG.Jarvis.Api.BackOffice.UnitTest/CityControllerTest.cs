
using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models.Request;
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
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class CityControllerTest
    {
        #region private variable
        private CitiesController mockCityController;
        private Mock<IMasterData<City,int>> cityMock;
        private Mock<ILogger> loggerMock;
        private Mock<IMapping<Core.Model.Mappings.City>> iMappingMock;
        
        #endregion Private Variables

        public CityControllerTest()
        {
            cityMock = new Mock<IMasterData<City, int>>();
            iMappingMock = new Mock<IMapping<Core.Model.Mappings.City>>();
            loggerMock = new Mock<ILogger>();
            mockCityController = new CitiesController(cityMock.Object, loggerMock.Object, iMappingMock.Object);
        }


        //[Test]
        //public void TestCityControllerGetCitiesNoContentResponse()
        //{
        //    cityMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<City>>()));

        //    var result = mockCityController.Get().Result;
        //    Assert.IsTrue(result is NoContentResult);
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestCityControllerGetCitiesExceptionInternalServerError()
        //{
        //    cityMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<City>> { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = mockCityController.Get().Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCityControllerGetCitiesOKResponse()
        //{
        //    Func<City, bool> func = x => x.IsDeleted == false;

        //    List<City> mockCityList = new List<City>
        //    {
        //         new City {
        //            Code = "HYD",
        //            CountryId = 8,
        //            NameItemId = 1,
        //            Name = "Hyderabad",
        //            IsActive = true,
        //            IsDeleted = false }
        //    };

        //    cityMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<City>>() { Result = mockCityList, IsError = false }));

        //    var result = mockCityController.Get().Result;
        //    BaseResult<List<City>> resultList = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<City>>;

        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(!resultList.IsError);
        //    Assert.IsTrue(resultList.Result != null);
        //    Assert.IsTrue(resultList.Result.Count > 0);
        //}

        ////[Test]
        ////public void TestCityControllerGetCityByCodeWithEmptyCode()
        ////{
        ////    cityMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<City>>()));

        ////    var result = mockCityController.GetCityByCode(string.Empty).Result;
        ////    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        ////}

        ////[Test]
        ////public void TestCityControllerGetCityByCodeNoContentResponse()
        ////{
        ////    cityMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<City>>()));

        ////    var result = mockCityController.GetCityByCode("OOO").Result;
        ////    Assert.IsTrue(result is NoContentResult);
        ////    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        ////}

        ////[Test]
        ////public void TestCityControllerGetCityByCodeExceptionInternalServerError()
        ////{
        ////    cityMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<City>> { IsError = true, ExceptionMessage = new Exception() }));

        ////    var result = mockCityController.GetCityByCode("OOO").Result;
        ////    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        ////}

        ////[Test]
        ////public void TestCityControllerGetCityByCodeOKResponse()
        ////{
        ////    Func<City, bool> func = x => x.IsDeleted == false;

        ////    List<City> mockCityList = new List<City>
        ////    {
        ////         new City {
        ////            Code = "BBSR",
        ////            Name = "Bhubhaneshwar",
        ////            Region = null,
        ////            State = "Orissa",
        ////            Longitude = 0,
        ////            Latitude = 0,
        ////            CountryId = 8,
        ////            StateId = null,
        ////            IsActive = true,
        ////            NameItemId = 1,
        ////            IsDeleted = false }
        ////    };

        ////    cityMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<City>>() { Result = mockCityList, IsError = false }));

        ////    var result = mockCityController.GetCityByCode("BBSR").Result;
        ////    BaseResult<List<City>> resultList = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<City>>;

        ////    Assert.IsTrue(result is OkObjectResult);
        ////    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        ////    Assert.IsNotNull(result);
        ////    Assert.IsTrue(!resultList.IsError);
        ////    Assert.IsTrue(resultList.Result != null);
        ////    Assert.IsTrue(resultList.Result.Count == 1);
        ////}

        ////[Test]
        ////public void TestCityControllerGetCityByCodeNoRecordFound()
        ////{
        ////    Func<City, bool> func = x => x.IsDeleted == false;

        ////    List<City> mockCityList = new List<City>
        ////    {
        ////         new City {
        ////            Code = "BBSR",
        ////            Name = "Bhubhaneshwar",
        ////            Region = null,
        ////            State = "Orissa",
        ////            Longitude = 0,
        ////            Latitude = 0,
        ////            CountryId = 8,
        ////            StateId = null,
        ////            IsActive = true,
        ////            NameItemId = 1,
        ////            IsDeleted = false }
        ////    };

        ////    cityMock.Setup(x => x.GetList())
        ////        .Returns(Task.FromResult(new BaseResult<List<City>>() { Result = mockCityList, IsError = false }));

        ////    var result = mockCityController.GetCityByCode("OOO").Result;
        ////    Assert.IsTrue(result is NoContentResult);
        ////    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        ////}

        //[Test]
        //public void TestCityControllerAddCitySuccessResponse()
        //{
        //    City city = new City
        //    {
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.InsertEntity(city)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Code = "OOO", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false } }
        //    }));

        //    var result = mockCityController.Create(city).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCityControllerAddCityFailedInvalidInputForNullObject()
        //{
        //    var result = mockCityController.Create(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCityControllerAddCityFailedInvalidInputForEmptyCityCode()
        //{
        //    var result = mockCityController.Create(new City() { Code = string.Empty }).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "City"));
        //}

        //[Test]
        //public void TestCityControllerAddCityFailedInvalidInputForDuplicateCity()
        //{
        //    City city = new City
        //    {
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.InsertEntity(city)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false } }
        //    }));

        //    var result = mockCityController.Create(city).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestCityControllerAddCitySuccessNoRecordToCheckDuplicacy()
        //{
        //    City city = new City
        //    {
        //        Code = "BBSR",
        //        Name = "Bhubhaneshwar",
        //        Region = null,
        //        State = "Orissa",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 4,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.InsertEntity(city)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()));

        //    var result = mockCityController.Create(city).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCityControllerAddCityExceptionInternalServerError()
        //{
        //    City city = new City
        //    {
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 4,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.InsertEntity(city))
        //        .Returns(Task.FromResult(
        //            new BaseResult<long>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()));

        //    var result = mockCityController.Create(city).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCityControllerUpdateCitySuccessResponse()
        //{
        //    City city = new City
        //    {
        //        Id = 1,
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 1, Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = false, NameItemId = 1, IsDeleted = false } }
        //    }));

        //    var result = mockCityController.Update(city).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCityControllerUpdateCityFailedInvalidInputRecordNotExists()
        //{
        //    City city = new City
        //    {
        //        Id = 1,
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 2, Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = false, NameItemId = 1, IsDeleted = false } }
        //    }));

        //    var result = mockCityController.Update(city).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "City"));
        //}

        //[Test]
        //public void TestCityControllerUpdateCityFailedInvalidInputForNullObject()
        //{
        //    var result = mockCityController.Update(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCityControllerUpdateCityFailedInvalidInputForEmptyCityCode()
        //{
        //    City city = new City
        //    {
        //        Id = 2,
        //        Code = string.Empty, //Empty Code
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 2, Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false } }
        //    }));
        //    var result = mockCityController.Update(city).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "City"));
        //}

        //[Test]
        //public void TestCityControllerUpdateCityFailedInvalidInputForMissingID()
        //{
        //    City city = new City
        //    {
        //        Id = 0, //Missing ID
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 2, Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false } }
        //    }));
        //    var result = mockCityController.Update(city).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "City"));
        //}

        //[Test]
        //public void TestCityControllerUpdateCityFailedInvalidInputForDuplicateCity()
        //{
        //    City city = new City
        //    {
        //        Id = 1,
        //        Code = "MAA", //Duplicate City Code
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() {
        //            new City { Id=1, Code = "BBSR", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false },
        //            new City { Id=2, Code = "MAA", Name = "Bhubaneshwar", Region = null, State = "Orissa", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false }
        //        }
        //    }));

        //    var result = mockCityController.Update(city).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.DuplicateCodeExists, "City"));
        //}

        //[Test]
        //public void TestCityControllerUpdateCityExceptionInternalServerError()
        //{
        //    City city = new City
        //    {
        //        Id = 1,
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 1, Code = "BBSR", Name = "Bhubhaneshwar", IsActive = false, IsDeleted = false } }
        //    }));
        //    cityMock.Setup(x => x.UpdateEntity(city))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = mockCityController.Update(city).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCityControllerDeleteCitySuccessResponse()
        //{
        //    Core.Model.Mappings.City city = new Core.Model.Mappings.City
        //    {
        //        Id = 1,
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false

        //    };
        //    cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 1, Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = false, NameItemId = 1, IsDeleted = false } }
        //    }));

        //    var result = mockCityController.Delete(city).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCityControllerDeleteCityFailedInvalidInputRecordNotExists()
        //{
        //    City city = new City
        //    {
        //        Id = 1,
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 2, Code = "BBSR", Name = "Bhubaneshwar", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false } }
        //    }));

        //    var result = mockCityController.Delete(city).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "City"));
        //}

        //[Test]
        //public void TestCityControllerDeleteCityFailedInvalidInputForNullObject()
        //{
        //    var result = mockCityController.Delete(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCityControllerDeleteCityFailedInvalidInputForMissingID()
        //{
        //    City city = new City
        //    {
        //        Id = 0, //Missing ID
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 2, Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false } }
        //    }));
        //    var result = mockCityController.Delete(city).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "City"));
        //}

        //[Test]
        //public void TestCityControllerDeleteCityExceptionInternalServerError()
        //{
        //    City city = new City
        //    {
        //        Id = 1,
        //        Code = "MAA",
        //        Name = "Chennai",
        //        Region = null,
        //        State = "Tamil Nadu",
        //        Longitude = 0,
        //        Latitude = 0,
        //        CountryId = 8,
        //        StateId = 1,
        //        IsActive = true,
        //        NameItemId = 1,
        //        IsDeleted = false
        //    };
        //    cityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<City>>()
        //    {
        //        Result = new List<City>() { new City { Id = 1, Code = "MAA", Name = "Chennai", Region = null, State = "Tamil Nadu", Longitude = 0, Latitude = 0, CountryId = 8, StateId = 1, IsActive = true, NameItemId = 1, IsDeleted = false } }
        //    }));
        //    cityMock.Setup(x => x.UpdateEntity(city))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = mockCityController.Delete(city).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        [Test]

        public void TestCityControllerUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            City city = new City
            {
                Code = "MAA",
                Name = "Chennai",
                Region = null,
                State = "Tamil Nadu",
                Longitude = 0,
                Latitude = 0,
                CountryId = 8,
                StateId = 1,
                IsActive = true,
                NameItemId = 1,
                IsDeleted = false
            };

            cityMock.Setup(x => x.UpdateEntity(city)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

           var result = mockCityController.Update(city).Result;
           Assert.That(result is BadRequestObjectResult);            
        }

        [Test]
        public void TestCityControllerMappingReturnResultIsNullFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockCityController.Mapping().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestCityControllerMappingReturnResultThrowsExceptionFail()
        {   
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockCityController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCityControllerMappingReturnOKSuccess()
        { 
            IEnumerable<dynamic> fakeCityMappingList = this.GetCityMappingList();
            
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeCityMappingList }));

            var result = mockCityController.Mapping().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestCityControllerGetMappingFromNullTable()
        {            
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new MyException("No columns were selected"));
            var result = mockCityController.Mapping().Result;
            Assert.That(((NoContentResult)result).StatusCode is 204);
        }

        [Test]
        public void TestCityControllerGetMappingThrowsException()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new Exception());
            var result = mockCityController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCityControllerCreateMappingNullRequestFail()
        {
            var result = mockCityController.CreateMapping(null).Result;
            Assert.That(((BadRequestObjectResult)result).StatusCode is 400);
        }

        [Test]
        public void TestCityControllerCreateMappingDapperFail()
        {
            List<MgAndSupplierCodeMap> a = new List<MgAndSupplierCodeMap>()
            {
                new MgAndSupplierCodeMap()
                {
                    MgEntityCode = "ABC",
                    SupplierEntityCode ="PQR",
                    SupplierHotelCityCode = "XYZ",
                    SupplierHotelCountryCode = "MNO",
                    SupplierRoomTypeHotelCode = "DBL"
                }
            };
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierCityCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = false, IsError = true }));

            var result = mockCityController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCityControllerCreateMappingSystemException()
        {
            List<MgAndSupplierCodeMap> a = new List<MgAndSupplierCodeMap>()
            {
                new MgAndSupplierCodeMap()
                {
                    MgEntityCode = "ABC",
                    SupplierEntityCode ="PQR",
                    SupplierHotelCityCode = "XYZ",
                    SupplierHotelCountryCode = "MNO",
                    SupplierRoomTypeHotelCode = "DBL"
                }
            };
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierCityCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Throws(new Exception());

            var result = mockCityController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCityControllerCreateMappingSuccess()
        {
            List<MgAndSupplierCodeMap> a = new List<MgAndSupplierCodeMap>()
            {
                new MgAndSupplierCodeMap()
                {
                    MgEntityCode = "ABC",
                    SupplierEntityCode ="PQR",
                    SupplierHotelCityCode = "XYZ",
                    SupplierHotelCountryCode = "MNO",
                    SupplierRoomTypeHotelCode = "DBL"
                }
            };
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierCityCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true, IsError = false }));

            var result = mockCityController.CreateMapping(model).Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }
        
        private IEnumerable<dynamic> GetCityMappingList()
        {
            dynamic cityMappingList = new List<Dictionary<string, dynamic>>();

            cityMappingList.Add(new Dictionary<string, dynamic>());

            cityMappingList[0]["MgCityId"] = 4554;
            cityMappingList[0]["MgCityCode"] = "WSMA06070141";
            cityMappingList[0]["MgCityName"] = "Los Angeles, CA";
            cityMappingList[0]["Expedia"] = "Los Angeles";

            return cityMappingList;
        }
    }
}