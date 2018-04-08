using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
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
    public class CurrencyControllerTest
    {
        #region private variable
        private CurrenciesController mockCurrencyController;
        private Mock<IMasterData<Currency,int>> currencyMock;
        private Mock<ILogger> loggerMock;
        #endregion Private Variables

        public CurrencyControllerTest()
        {
            currencyMock = new Mock<IMasterData<Currency, int>>();
            loggerMock = new Mock<ILogger>();
            mockCurrencyController = new CurrenciesController(currencyMock.Object, loggerMock.Object);
        }

        #region OldCode
        //[Test]
        //public void TestCurrencyControllerGetCurrenciesNoContentResponse()
        //{
        //    currencyMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Currency>>()));

        //    var result = currencyController.Get().Result;
        //    Assert.IsTrue(result is NoContentResult);
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestCurrencyControllerGetCurrenciesExecptionInternalServerError()
        //{
        //    currencyMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Currency>> { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = currencyController.Get().Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCurrencyControllerGetCurrenciesOKResponse()
        //{
        //    Func<Currency, bool> func = x => x.IsDeleted == false;

        //    List<Currency> mockCurrencyList = new List<Currency>
        //    {
        //         new Currency {
        //            Code = "USD",                   
        //            Name = "US Doller",
        //            IsActive = true,
        //            IsDeleted = false }
        //    };

        //    currencyMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<Currency>>() { Result = mockCurrencyList, IsError = false }));

        //    var result = currencyController.Get().Result;
        //    BaseResult<List<Currency>> resultList = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<Currency>>;

        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(!resultList.IsError);
        //    Assert.IsTrue(resultList.Result != null);
        //    Assert.IsTrue(resultList.Result.Count > 0);
        //}        

        //[Test]
        //public void TestCurrencyControllerAddCurrencySuccessResponse()
        //{
        //    Currency currency = new Currency
        //    {
        //        Code = "USD",                
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.InsertEntity(currency)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Code = "XYZ", Name = "New Currency", Symbol ="@", IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = currencyController.Create(currency).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCurrencyControllerAddCurrencyFailedInvalidInputForNullObject()
        //{
        //    var result = currencyController.Create(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCurrencyControllerAddCurrencyFailedInvalidInputForEmptyCurrencyCode()
        //{
        //    var result = currencyController.Create(new Currency() { Code = string.Empty }).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Currency"));
        //}

        //[Test]
        //public void TestCurrencyControllerAddCurrencyFailedInvalidInputForDuplicateCurrency()
        //{
        //    Currency currency = new Currency
        //    {
        //        Code = "USD",               
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.InsertEntity(currency)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Code = "USD", Name = "US Doller", Symbol = "$", IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = currencyController.Create(currency).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestCurrencyControllerAddCurrencySuccessNoRecordToCheckDuplicacy()
        //{
        //    Currency currency = new Currency
        //    {
        //        Code = "USD",                
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.InsertEntity(currency)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()));

        //    var result = currencyController.Create(currency).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCurrencyControllerAddCurrencyExceptionInternalServerError()
        //{
        //    Currency currency = new Currency
        //    {
        //        Code = "USD",                
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.InsertEntity(currency))
        //        .Returns(Task.FromResult(
        //            new BaseResult<long>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()));

        //    var result = currencyController.Create(currency).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCurrencyControllerUpdateCurrencySuccessResponse()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 1,
        //        Code = "USD",               
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 1, Code = "USD", Name = "US Doller", Symbol = "$", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyController.Update(currency).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCurrencyControllerUpdateCurrencyFailedInvalidInputRecordNotExists()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 2,
        //        Code = "XYZ",              
        //        Name = "XYZ",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 1, Code = "USD", Name = "US Doller", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyController.Update(currency).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Currency"));
        //}

        //[Test]
        //public void TestCurrencyControllerUpdateCurrencyFailedInvalidInputForNullObject()
        //{
        //    var result = currencyController.Update(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCurrencyControllerUpdateCurrencyFailedInvalidInputForEmptyCurrencyCode()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 2,
        //        Code = string.Empty, //Empty Code               
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 2, Code = "XYZ", Name = "US Doller", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = currencyController.Update(currency).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Currency"));
        //}

        //[Test]
        //public void TestCurrencyControllerUpdateCurrencyFailedInvalidInputForMissingID()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 0, //Missing ID
        //        Code = "USD",
        //        Symbol = "$",
        //        Name = "US Doller",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 2, Code = "USD", Name = "US Doller", Symbol = "$", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = currencyController.Update(currency).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Currency"));
        //}

        //[Test]
        //public void TestCurrencyControllerUpdateCurrencyFailedInvalidInputForDuplicateCurrency()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 1,
        //        Code = "XYZ", //Duplicate code              
        //        Name = "XYZ",
        //        Symbol = "@",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() {
        //            new Currency { Id=1, Code = "USD", Name = "US Doller", Symbol = "$",IsActive = true, IsDeleted = false },
        //            new Currency { Id=2, Code = "XYZ", Name = "Indoneshia",Symbol = "$", IsActive = true, IsDeleted = false }
        //        }
        //    }));

        //    var result = currencyController.Update(currency).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.DuplicateCodeExists, "Currency"));
        //}

        //[Test]
        //public void TestCurrencyControllerUpdateCurrencyExceptionInternalServerError()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 1,
        //        Code = "USD",                
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 1, Code = "USD", Name = "US Doller", Symbol = "$", IsActive = false, IsDeleted = false } }
        //    }));
        //    currencyMock.Setup(x => x.UpdateEntity(currency))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = currencyController.Update(currency).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCurrencyControllerDeleteCurrencySuccessResponse()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 1,
        //        Code = "USD",             
        //        Name = "US Doller",
        //        Symbol = "$",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 1, Code = "USD", Name = "US Doller", Symbol = "$", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyController.Delete(currency).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCurrencyControllerDeleteCurrencyFailedInvalidInputRecordNotExists()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 2,
        //        Code = "XYZ",               
        //        Name = "Indoneshia",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 1, Code = "USD", Name = "US Doller", IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyController.Delete(currency).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Currency"));
        //}

        //[Test]
        //public void TestCurrencyControllerDeleteCurrencyFailedInvalidInputForNullObject()
        //{
        //    var result = currencyController.Delete(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCurrencyControllerDeleteCurrencyFailedInvalidInputForMissingID()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 0, //Missing ID
        //        Code = "XYZ",            
        //        Name = "US Doller",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 2, Code = "XYZ", Name = "US Doller", IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = currencyController.Delete(currency).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((MG.Jarvis.Core.Model.BaseResult<bool>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Currency"));
        //}

        //[Test]
        //public void TestCurrencyControllerDeleteCurrencyExceptionInternalServerError()
        //{
        //    Currency currency = new Currency
        //    {
        //        Id = 1,
        //        Code = "USD",             
        //        Name = "US Doller",
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Currency>>()
        //    {
        //        Result = new List<Currency>() { new Currency { Id = 1, Code = "USD", Name = "US Doller", IsActive = false, IsDeleted = false } }
        //    }));
        //    currencyMock.Setup(x => x.UpdateEntity(currency))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = currencyController.Delete(currency).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}
        #endregion OldCode

        [Test]

        public void TestCurrencyControllerUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            Currency currency = new Currency
            {
                Code = "INR",
                Name = "Rupees",
                IsActive = true,
                IsDeleted = false
            };

            currencyMock.Setup(x => x.UpdateEntity(currency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

            var result = mockCurrencyController.Update(currency).Result;
            Assert.That(result is BadRequestObjectResult);
        }

    }
}
