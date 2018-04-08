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
    public class NationalityControllerTest
    {
        #region private variable
        private NationalitiesController mockNationalityController;
        private Mock<IMasterData<Nationality, int>> nationalityMock;
        private Mock<ILogger> loggerMock;
        private Mock<IMapping<Core.Model.Mappings.Nationality>> iMappingMock;
        #endregion Private Variables

        public NationalityControllerTest()
        {
            nationalityMock = new Mock<IMasterData<Nationality, int>>();
            iMappingMock = new Mock<IMapping<Core.Model.Mappings.Nationality>>();
            loggerMock = new Mock<ILogger>();
            mockNationalityController = new NationalitiesController(nationalityMock.Object, loggerMock.Object, iMappingMock.Object);
        }

        #region OldCode
        //[Test]
        //public void TestNationalityControllerGetNationalitiesNoContentResponse()
        //{
        //    nationalityMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Nationality>>()));

        //    var result = nationalityController.Get().Result;
        //    Assert.IsTrue(result is NoContentResult);
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestNationalityControllerGetNationalitiesExecptionInternalServerError()
        //{
        //    nationalityMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Nationality>> { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = nationalityController.Get().Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestNationalityControllerGetNationalitiesOKResponse()
        //{
        //    Func<Nationality, bool> func = x => x.IsDeleted == false;

        //    List<Nationality> mockNationalityList = new List<Nationality>
        //    {
        //         new Nationality {
        //            Code = "IND",
        //            Name = "Indian",
        //            IsActive = true,
        //            IsDeleted = false }
        //    };

        //    nationalityMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Nationality>>() { Result = mockNationalityList, IsError = false }));

        //    var result = nationalityController.Get().Result;
        //    BaseResult<List<Nationality>> resultList = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<Nationality>>;

        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(!resultList.IsError);
        //    Assert.IsTrue(resultList.Result != null);
        //    Assert.IsTrue(resultList.Result.Count > 0);
        //}

        //[Test]
        //public void TestNationalityControllerAddNationalitySuccessResponse()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Code = "IND",
        //        Name = "Indian",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.InsertEntity(nationality)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Code = "XYZ", Name = "New Nationality", IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = nationalityController.Create(nationality).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestNationalityControllerAddNationalityFailedInvalidInputForNullObject()
        //{
        //    var result = nationalityController.Create(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestNationalityControllerAddNationalityFailedInvalidInputForEmptyNationalityCode()
        //{
        //    var result = nationalityController.Create(new Nationality() { Code = string.Empty }).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Nationality"));
        //}

        //[Test]
        //public void TestNationalityControllerAddNationalityFailedInvalidInputForDuplicateNationality()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Code = "IND",
        //        Name = "Indian",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.InsertEntity(nationality)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Code = "IND", Name = "Indian", IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = nationalityController.Create(nationality).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestNationalityControllerAddNationalitySuccessNoRecordToCheckDuplicacy()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Code = "IND",
        //        Name = "Indian",               
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.InsertEntity(nationality)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()));

        //    var result = nationalityController.Create(nationality).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestNationalityControllerAddNationalityExceptionInternalServerError()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Code = "IND",
        //        Name = "Indian",              
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.InsertEntity(nationality))
        //        .Returns(Task.FromResult(
        //            new BaseResult<long>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()));

        //    var result = nationalityController.Create(nationality).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestNationalityControllerUpdateNationalitySuccessResponse()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 1,
        //        Code = "IND",
        //        Name = "Indian",              
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 1, Code = "IND", Name = "Indian", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = nationalityController.Update(nationality).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestNationalityControllerUpdateNationalityFailedInvalidInputRecordNotExists()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 2,
        //        Code = "XYZ",
        //        Name = "XYZ",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 1, Code = "IND", Name = "Indian", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = nationalityController.Update(nationality).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Nationality"));
        //}

        //[Test]
        //public void TestNationalityControllerUpdateNationalityFailedInvalidInputForNullObject()
        //{
        //    var result = nationalityController.Update(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestNationalityControllerUpdateNationalityFailedInvalidInputForEmptyNationalityCode()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 2,
        //        Code = string.Empty, //Empty Code               
        //        Name = "Indian",             
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 2, Code = "XYZ", Name = "Indian", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = nationalityController.Update(nationality).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Nationality"));
        //}

        //[Test]
        //public void TestNationalityControllerUpdateNationalityFailedInvalidInputForMissingID()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 0, //Missing ID
        //        Code = "IND",           
        //        Name = "Indian",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 2, Code = "IND", Name = "Indian", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = nationalityController.Update(nationality).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Nationality"));
        //}

        //[Test]
        //public void TestNationalityControllerUpdateNationalityFailedInvalidInputForDuplicateNationality()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 1,
        //        Code = "XYZ", //Duplicate code              
        //        Name = "XYZ",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() {
        //            new Nationality { Id=1, Code = "IND", Name = "Indian", IsActive = true, IsDeleted = false },
        //            new Nationality { Id=2, Code = "XYZ", Name = "Indoneshia", IsActive = true, IsDeleted = false }
        //        }
        //    }));

        //    var result = nationalityController.Update(nationality).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.DuplicateCodeExists, "Nationality"));
        //}

        //[Test]
        //public void TestNationalityControllerUpdateNationalityExceptionInternalServerError()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 1,
        //        Code = "IND",
        //        Name = "Indian",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 1, Code = "IND", Name = "Indian", IsActive = false, IsDeleted = false } }
        //    }));
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = nationalityController.Update(nationality).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestNationalityControllerDeleteNationalitySuccessResponse()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 1,
        //        Code = "IND",
        //        Name = "Indian",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 1, Code = "IND", Name = "Indian", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = nationalityController.Delete(nationality).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestNationalityControllerDeleteNationalityFailedInvalidInputRecordNotExists()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 2,
        //        Code = "XYZ",
        //        Name = "Indoneshia",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 1, Code = "IND", Name = "Indian", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = nationalityController.Delete(nationality).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Nationality"));
        //}

        //[Test]
        //public void TestNationalityControllerDeleteNationalityFailedInvalidInputForNullObject()
        //{
        //    var result = nationalityController.Delete(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestNationalityControllerDeleteNationalityFailedInvalidInputForMissingID()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 0, //Missing ID
        //        Code = "XYZ",
        //        Name = "Indian",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 2, Code = "XYZ", Name = "Indian", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = nationalityController.Delete(nationality).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Nationality"));
        //}

        //[Test]
        //public void TestNationalityControllerDeleteNationalityExceptionInternalServerError()
        //{
        //    Nationality nationality = new Nationality
        //    {
        //        Id = 1,
        //        Code = "IND",
        //        Name = "Indian",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    nationalityMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
        //    {
        //        Result = new List<Nationality>() { new Nationality { Id = 1, Code = "IND", Name = "Indian", IsActive = false, IsDeleted = false } }
        //    }));
        //    nationalityMock.Setup(x => x.UpdateEntity(nationality))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = nationalityController.Delete(nationality).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);            
        //}
        #endregion OldCode

        [Test]

        public void TestNationalityControllerUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            Nationality nationality = new Nationality
            {
                Code = "IN",
                Name = "Indian",
                IsDeleted = false
            };

            nationalityMock.Setup(x => x.UpdateEntity(nationality)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

            var result = mockNationalityController.Update(nationality).Result;
            Assert.That(result is BadRequestObjectResult);
        }

        [Test]
        public void TestNationalityControllerMappingReturnResultIsNullFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockNationalityController.Mapping().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestNationalityControllerMappingReturnResultThrowsExceptionFail()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockNationalityController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestNationalityControllerMappingReturnOKSuccess()
        {
            IEnumerable<dynamic> fakeNationalityMappingList = this.GetNationalityMappingList();


            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeNationalityMappingList }));

            var result = mockNationalityController.Mapping().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        [Test]
        public void TestNationalityControllerGetMappingFromNullTable()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new MyException("No columns were selected"));
            var result = mockNationalityController.Mapping().Result;
            Assert.That(((NoContentResult)result).StatusCode is 204);
        }

        [Test]
        public void TestNationalityControllerGetMappingThrowsException()
        {
            iMappingMock.Setup(x => x.Mapping(It.IsAny<string>())).Throws(new Exception());
            var result = mockNationalityController.Mapping().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestNationalityControllerCreateMappingNullRequestFail()
        {
            var result = mockNationalityController.CreateMapping(null).Result;
            Assert.That(((BadRequestObjectResult)result).StatusCode is 400);
        }

        [Test]
        public void TestNationalityControllerCreateMappingDapperFail()
        {
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierNationalityCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = false, IsError = true }));

            var result = mockNationalityController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestNationalityControllerCreateMappingSystemException()
        {
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierNationalityCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Throws(new Exception());

            var result = mockNationalityController.CreateMapping(model).Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestNationalityControllerCreateMappingSuccess()
        {
            Models.Request.Mapping model = new Models.Request.Mapping()
            {
                SupplierCode = "TEST",
                //SupplierNationalityCodeMapping = a
            };

            iMappingMock.Setup(x => x.InsertOrUpdateMapping(It.IsAny<string>(), It.IsAny<Dapper.DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true, IsError = false }));

            var result = mockNationalityController.CreateMapping(model).Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }


        private IEnumerable<dynamic> GetNationalityMappingList()
        {
            dynamic nationalityMappingList = new List<Dictionary<string, dynamic>>();

            nationalityMappingList.Add(new Dictionary<string, dynamic>());
            
            nationalityMappingList[0]["MgNationalityId"] = 11;
            nationalityMappingList[0]["MgNationalityCode"] = "IN";
            nationalityMappingList[0]["MgNationalityName"] = "Indian";

            return nationalityMappingList;
        }
    }
}
