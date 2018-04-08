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
    public class CurrencyConversionControllerTest
    {
        #region private variable
        private CurrencyConversionController mockCurrencyConversionController;
        private Mock<IMasterData<CurrencyConversion,int>> currencyConversionMock;
        private Mock<ILogger> iLoggerMock;
        #endregion Private Variables

        public CurrencyConversionControllerTest()
        {
            currencyConversionMock = new Mock<IMasterData<CurrencyConversion,int>>();
            iLoggerMock = new Mock<ILogger>();
            mockCurrencyConversionController = new CurrencyConversionController(currencyConversionMock.Object, iLoggerMock.Object);
        }

        #region OldCode
        //[Test]
        //public void TestCurrencyConversionControllerGetCurrencyConversionsNoContentResponse()
        //{
        //    currencyConversionMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()));

        //    var result = currencyConversionController.Get().Result;
        //    Assert.IsTrue(result is NoContentResult);
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerGetCurrencyConversionsExecptionInternalServerError()
        //{
        //    currencyConversionMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>> { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = currencyConversionController.Get().Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerGetCurrencyConversionsOKResponse()
        //{ 
        //    List<CurrencyConversion> mockCurrencyConversionList = new List<CurrencyConversion>
        //    {
        //         new CurrencyConversion {
        //            SourceCurrencyId = 1,
        //            TargetCurrencyId = 2,
        //            BuyingRate = 16.0f,
        //            SellingRate =18.8f,
        //            IsActive = true,
        //            IsDeleted = false }
        //    };

        //    currencyConversionMock.Setup(x => x.GetList())
        //        .Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>() { Result = mockCurrencyConversionList, IsError = false }));

        //    var result = currencyConversionController.Get().Result;
        //    BaseResult<List<CurrencyConversion>> resultList = (result as OkObjectResult).Value as BaseResult<List<CurrencyConversion>>;

        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    Assert.IsNotNull(result);
        //    Assert.IsTrue(!resultList.IsError);
        //    Assert.IsTrue(resultList.Result != null);
        //    Assert.IsTrue(resultList.Result.Count > 0);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerAddCurrencyConversionSuccessResponse()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.InsertEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { SourceCurrencyId = 2, TargetCurrencyId=1, BuyingRate = 11.6f, SellingRate = 12.8f, IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = currencyConversionController.Create(currencyConversion).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerAddCurrencyConversionFailedInvalidInputForNullObject()
        //{
        //    var result = currencyConversionController.Create(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerAddCurrencyConversionFailedInvalidInputForSameSourceAndTargetID()
        //{
        //    var result = currencyConversionController.Create(new CurrencyConversion() { SourceCurrencyId =1,TargetCurrencyId =1 }).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerAddCurrencyConversionFailedInvalidInputForDuplicateCurrencyConversion()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.InsertEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = true, IsDeleted = false } }
        //    }));

        //    var result = currencyConversionController.Create(currencyConversion).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerAddCurrencyConversionSuccessNoRecordToCheckDuplicacy()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.InsertEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()));

        //    var result = currencyConversionController.Create(currencyConversion).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerAddCurrencyConversionExceptionInternalServerError()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.InsertEntity(currencyConversion))
        //        .Returns(Task.FromResult(
        //            new BaseResult<long>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()));

        //    var result = currencyConversionController.Create(currencyConversion).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerUpdateCurrencyConversionSuccessResponse()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 1,
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id =1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyConversionController.Update(currencyConversion).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerUpdateCurrencyConversionFailedInvalidInputRecordNotExists()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 2,
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id=1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyConversionController.Update(currencyConversion).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "CurrencyConversion"));
        //}

        //[Test]
        //public void TestCurrencyConversionControllerUpdateCurrencyConversionFailedInvalidInputForNullObject()
        //{
        //    var result = currencyConversionController.Update(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}       

        //[Test]
        //public void TestCurrencyConversionControllerUpdateCurrencyConversionFailedInvalidInputForMissingID()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 0, //Missing ID
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id=1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = currencyConversionController.Update(currencyConversion).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "CurrencyConversion"));
        //}

        //[Test]
        //public void TestCurrencyConversionControllerUpdateCurrencyConversionFailedInvalidInputForDuplicateCurrencyConversion()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 1, //Trying to update existing records
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 3,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() {                   
        //            new CurrencyConversion { Id = 1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = true, IsDeleted = false },
        //            new CurrencyConversion { Id = 2, SourceCurrencyId = 1, TargetCurrencyId = 3, BuyingRate = 10.0f, SellingRate = 11.8f, IsActive = true, IsDeleted = false }
        //        }
        //    }));

        //    var result = currencyConversionController.Update(currencyConversion).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.DuplicateCodeExists, "CurrencyConversion"));
        //}

        //[Test]
        //public void TestCurrencyConversionControllerUpdateCurrencyConversionExceptionInternalServerError()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 1,
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = false
        //    };
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id=1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = false, IsDeleted = false } }
        //    }));
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = currencyConversionController.Update(currencyConversion).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerDeleteCurrencyConversionSuccessResponse()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 1,
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id=1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyConversionController.Delete(currencyConversion).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Result, true);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerDeleteCurrencyConversionFailedInvalidInputRecordNotExists()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 2, // Id =2 not exists
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id = 1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = false, IsDeleted = false } }
        //    }));

        //    var result = currencyConversionController.Delete(currencyConversion).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "CurrencyConversion"));
        //}

        //[Test]
        //public void TestCurrencyConversionControllerDeleteCurrencyConversionFailedInvalidInputForNullObject()
        //{
        //    var result = currencyConversionController.Delete(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
        //}

        //[Test]
        //public void TestCurrencyConversionControllerDeleteCurrencyConversionFailedInvalidInputForMissingID()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 0, //Missing ID
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id=0, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = true, IsDeleted = false } }
        //    }));
        //    var result = currencyConversionController.Delete(currencyConversion).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //    var resultValue = ((BaseResult<bool>)(((ObjectResult)result).Value));
        //    Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "CurrencyConversion"));
        //}

        //[Test]
        //public void TestCurrencyConversionControllerDeleteCurrencyConversionExceptionInternalServerError()
        //{
        //    CurrencyConversion currencyConversion = new CurrencyConversion
        //    {
        //        Id = 1,
        //        SourceCurrencyId = 1,
        //        TargetCurrencyId = 2,
        //        BuyingRate = 16.0f,
        //        SellingRate = 18.8f,
        //        IsActive = true,
        //        IsDeleted = true
        //    };
        //    currencyConversionMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<CurrencyConversion>>()
        //    {
        //        Result = new List<CurrencyConversion>() { new CurrencyConversion { Id =1, SourceCurrencyId = 1, TargetCurrencyId = 2, BuyingRate = 16.0f, SellingRate = 18.8f, IsActive = false, IsDeleted = false } }
        //    }));
        //    currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion))
        //        .Returns(Task.FromResult(
        //            new BaseResult<bool>()
        //            { IsError = true, ExceptionMessage = new Exception() }));

        //    var result = currencyConversionController.Delete(currencyConversion).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}
        #endregion OldCode

        [Test]

        public void TestCurrencyConversionControllerUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            CurrencyConversion currencyConversion = new CurrencyConversion
            {
               SourceCurrencyId = 1,
               TargetCurrencyId = 2,
               BuyingRate = 12.22,
               SellingRate = 13,
               IsActive = true,
               IsDeleted = false
            };

            currencyConversionMock.Setup(x => x.UpdateEntity(currencyConversion)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

            var result = mockCurrencyConversionController.Update(currencyConversion).Result;
            Assert.That(result is BadRequestObjectResult);
        }

        [Test]
        public void TestCurrencyConversionControllerGetReturnsResultNullFail()
        {
            currencyConversionMock.Setup(x => x.GetByProcedure(It.IsAny<string>(), null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null }));

            var result = mockCurrencyConversionController.Get().Result;
            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestCurrencyConversionControllerGetThrowsExceptionFail()
        {
            currencyConversionMock.Setup(x => x.GetByProcedure(It.IsAny<string>(), null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = mockCurrencyConversionController.Get().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestCurrencyConversionControllerGetReturnOkSuccess()
        {
            IEnumerable<dynamic> fakeCurrencyConversionList = this.GetCurrencyConversionList();

            currencyConversionMock.Setup(x => x.GetByProcedure(It.IsAny<string>(), null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = fakeCurrencyConversionList }));

            var result = mockCurrencyConversionController.Get().Result;
            Assert.That(((OkObjectResult)result).StatusCode is 200);
        }

        private IEnumerable<dynamic> GetCurrencyConversionList()
        {
            dynamic currencyConversionList = new List<Dictionary<string, dynamic>>();

            currencyConversionList.Add(new Dictionary<string, dynamic>());
            
            currencyConversionList[0]["SourceCurrencyId"] = 1;
            currencyConversionList[0]["SourceCurrencyCode"] = "INR";
            currencyConversionList[0]["TargetCurrencyId"] = "2";
            currencyConversionList[0]["TargetCurrencyCode"] = "IDR";
            currencyConversionList[0]["BuyingRate"] = 12.22;
            currencyConversionList[0]["SellingRate"] = 13;

            return currencyConversionList;
        }
    }
}
