using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ER = MG.Jarvis.Api.Extranet.Repositories;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class PaymentDataControllerTest
    {
        #region Private Variables
        private PaymentDataController paymentDataController;
        private IPayment paymentDataRepository;

        private IConnection<Currency> iCurrencyConnectionLibrary;
        private IConnection<PaymentMethod> iPaymentMethodConnectionLibrary;
        private IConnection<RateType> iRateTypeConnectionLibrary;
        private IConnection<TaxType> iTaxTypeConnectionLibrary;
        private IConnection<TaxApplicability> iTaxApplicabilityConnectionLibrary;

        private PaymentDataController mockPaymentDataController;
        private Mock<IPayment> mockPaymentDataRepository;
        public IConfigurationRoot Configuration { get; }
        #endregion Private Variables

        #region Settings
        public PaymentDataControllerTest()
        {
            mockPaymentDataRepository = new Moq.Mock<IPayment>();
            mockPaymentDataController = new PaymentDataController(mockPaymentDataRepository.Object);

            paymentDataRepository = new ER.PaymentDataRepository(iCurrencyConnectionLibrary, iPaymentMethodConnectionLibrary, iRateTypeConnectionLibrary, iTaxTypeConnectionLibrary, iTaxApplicabilityConnectionLibrary);
            paymentDataController = new PaymentDataController(paymentDataRepository);
        }

        #endregion Settings

        #region GetCurrency
        #region Negative Test Cases
        [Test]
        public void TestGetCurrency_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CurrencyList);
            mockPaymentDataRepository.Setup(a => a.GetCurrency()).Returns(Task.FromResult(new BaseResult<List<Currency>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetCurrency();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public async Task TestGetCurrency_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CurrencyList);
            mockPaymentDataRepository.Setup(a => a.GetCurrency()).Returns(Task.FromResult(new BaseResult<List<Currency>> { Result = new List<Currency>() }));
            mockPaymentDataRepository.Setup(a => a.GetCurrency()).Returns(Task.FromResult(new BaseResult<List<Currency>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockPaymentDataController.GetCurrency();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetCurrency_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CurrencyList);
            mockPaymentDataRepository.Setup(a => a.GetCurrency()).Returns(Task.FromResult(new BaseResult<List<Currency>>() { Result = new List<Currency> { new Currency { Id = 1, Name = "INR", IsActive = true, Code="INDR"} } }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetCurrency();
            BaseResult<List<CurrencyViewModel>> currencyList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<CurrencyViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(currencyList);
            Assert.IsTrue(!currencyList.IsError);
            Assert.IsTrue(currencyList.Result != null);
            Assert.IsTrue(currencyList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<Currency>>(Constants.CacheKeys.CurrencyList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.CurrencyList);
        }
        #endregion Postive Test Cases
        #endregion

        #region GetCurrencyByHotelId
        #region Negative Test Cases
        [Test]
        public void TestGetCurrencyByHotelId_Exception_InternalServerError()
        {
            int hotelId = 5;
            mockPaymentDataRepository.Setup(a => a.GetCurrencyByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<Currency>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetCurrencyByHotelId(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetCurrencyByHotelId_EmptyResult_NoContentResponse()
        {
            int hotelId = 5;
            mockPaymentDataRepository.Setup(a => a.GetCurrencyByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<Currency>> { Result = new List<Currency>() }));
            mockPaymentDataRepository.Setup(a => a.GetCurrencyByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<Currency>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockPaymentDataController.GetCurrencyByHotelId(hotelId);
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Positive Test Cases
        [Test]
        public async Task TestGetCurrencyByHotelId_Success_OkResponse()
        {
            int hotelId = 5;
            mockPaymentDataRepository.Setup(a => a.GetCurrencyByHotelId(hotelId)).Returns(Task.FromResult(new BaseResult<List<Currency>>()
            {
                Result = new List<Currency> { new Currency { Id = 1, Name = "Rs", Code="IDR", IsDeleted=false, IsActive = true } }
            }));

            Task<IActionResult> actionResult = mockPaymentDataController.GetCurrencyByHotelId(hotelId);
            BaseResult<List<CurrencyViewModel>> currencyList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<CurrencyViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(currencyList);
            Assert.IsTrue(!currencyList.IsError);
            Assert.IsTrue(currencyList.Result != null);
            Assert.IsTrue(currencyList.Result.Count > 0);
        }

        [Test]
        public void TestGetCurrencyByHotelId_Failed_BadRequest()
        {
            int hotelId = 0;
            //Act
            var result = mockPaymentDataController.GetCurrencyByHotelId(hotelId);
            //Assert
            mockPaymentDataRepository.Verify();
            Assert.IsTrue(result.Result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result.Result).StatusCode, 400);
        }
        #endregion Positive Test Cases
        #endregion GetCurrencyByHotelId

        #region GetPaymentMethod
        #region Negative Test Cases
        [Test]
        public void TestGetPaymentMethod_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.PaymentMethodList);
            mockPaymentDataRepository.Setup(a => a.GetPaymentMethod()).Returns(Task.FromResult(new BaseResult<List<PaymentMethod>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult =  mockPaymentDataController.GetPaymentMethod();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetPaymentMethod_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.PaymentMethodList);
            mockPaymentDataRepository.Setup(a => a.GetPaymentMethod()).Returns(Task.FromResult(new BaseResult<List<PaymentMethod>> { Result = new List<PaymentMethod>() }));
            mockPaymentDataRepository.Setup(a => a.GetPaymentMethod()).Returns(Task.FromResult(new BaseResult<List<PaymentMethod>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult =  mockPaymentDataController.GetPaymentMethod();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion

        #region Postive Test Cases
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetPaymentMethod_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.PaymentMethodList);
            mockPaymentDataRepository.Setup(a => a.GetPaymentMethod()).Returns(Task.FromResult(new BaseResult<List<PaymentMethod>>() { Result = new List<PaymentMethod> { new PaymentMethod { Id = 1, Name = "Credit", IsActive = true } } }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetPaymentMethod();
            BaseResult<List<PaymentMethodViewModel>> paymentMethodList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<PaymentMethodViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(paymentMethodList);
            Assert.IsTrue(!paymentMethodList.IsError);
            Assert.IsTrue(paymentMethodList.Result != null);
            Assert.IsTrue(paymentMethodList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<PaymentMethod>>(Constants.CacheKeys.PaymentMethodList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.PaymentMethodList);
        }
        #endregion Postive Test Cases
        #endregion GetPaymentMethod

        #region GetRateType
        #region Negative Test Cases
        [Test]
        public void TestGetRateType_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RateTypeList);
            mockPaymentDataRepository.Setup(a => a.GetRateType()).Returns(Task.FromResult(new BaseResult<List<RateType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetRateType();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetRateType_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RateTypeList);
            mockPaymentDataRepository.Setup(a => a.GetRateType()).Returns(Task.FromResult(new BaseResult<List<RateType>> { Result = new List<RateType>() }));
            mockPaymentDataRepository.Setup(a => a.GetRateType()).Returns(Task.FromResult(new BaseResult<List<RateType>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockPaymentDataController.GetRateType();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetRateType_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RateTypeList);
            mockPaymentDataRepository.Setup(a => a.GetRateType()).Returns(Task.FromResult(new BaseResult<List<RateType>>() { Result = new List<RateType> { new RateType { Id = 1, Name = "Net", IsActive = true } } }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetRateType();
            BaseResult<List<RateTypeViewModel>> rateTypeList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<RateTypeViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(rateTypeList);
            Assert.IsTrue(!rateTypeList.IsError);
            Assert.IsTrue(rateTypeList.Result != null);
            Assert.IsTrue(rateTypeList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<RateType>>(Constants.CacheKeys.RateTypeList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.RateTypeList);
        }
        #endregion Postive Test Cases
        #endregion GetRateType

        #region GetTaxType
        #region Negative Test Cases
        [Test]
        public void TestGetTaxType_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxTypeList);
            mockPaymentDataRepository.Setup(a => a.GetTaxType()).Returns(Task.FromResult(new BaseResult<List<TaxType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetTaxType();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetTaxType_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxTypeList);
            mockPaymentDataRepository.Setup(a => a.GetTaxType()).Returns(Task.FromResult(new BaseResult<List<TaxType>> { Result = new List<TaxType>() }));
            mockPaymentDataRepository.Setup(a => a.GetTaxType()).Returns(Task.FromResult(new BaseResult<List<TaxType>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockPaymentDataController.GetTaxType();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion

        #region Postive Test Cases
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetTaxType_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxTypeList);
            mockPaymentDataRepository.Setup(a => a.GetTaxType()).Returns(Task.FromResult(new BaseResult<List<TaxType>>() { Result = new List<TaxType> { new TaxType { Id = 1, Name = "VAT" } } }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetTaxType();
            BaseResult<List<TaxTypeViewModel>> taxTypeList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<TaxTypeViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(taxTypeList);
            Assert.IsTrue(!taxTypeList.IsError);
            Assert.IsTrue(taxTypeList.Result != null);
            Assert.IsTrue(taxTypeList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<TaxType>>(Constants.CacheKeys.TaxTypeList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxTypeList);
        }
        #endregion Postive Test Cases
        #endregion GetTaxType

        #region GetTaxApplicability
        #region Negative Test Cases
        [Test]
        public void TestGetTaxApplicability_Exception_InternalServerError()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxApplicabilityList);
            mockPaymentDataRepository.Setup(a => a.GetTaxApplicability()).Returns(Task.FromResult(new BaseResult<List<TaxApplicability>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetTaxApplicability();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 500);
        }
        [Test]
        public void TestGetTaxApplicability_EmptyResult_NoContentResponse()
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxApplicabilityList);
            mockPaymentDataRepository.Setup(a => a.GetTaxApplicability()).Returns(Task.FromResult(new BaseResult<List<TaxApplicability>> { Result = new List<TaxApplicability>() }));
            mockPaymentDataRepository.Setup(a => a.GetTaxApplicability()).Returns(Task.FromResult(new BaseResult<List<TaxApplicability>> { Result = null })).Verifiable();
            Task<IActionResult> actionResult = mockPaymentDataController.GetTaxApplicability();
            Assert.IsTrue(actionResult != null);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult.Result).StatusCode, 204);
        }
        #endregion Negative Test Cases

        #region Postive Test Cases
        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task TestGetTaxApplicability_Success_OkResponse()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxApplicabilityList);
            mockPaymentDataRepository.Setup(a => a.GetTaxApplicability()).Returns(Task.FromResult(new BaseResult<List<TaxApplicability>>() { Result = new List<TaxApplicability> { new TaxApplicability { Id = 1, Name = "Per Person" } } }));
            Task<IActionResult> actionResult = mockPaymentDataController.GetTaxApplicability();
            BaseResult<List<TaxApplicabilityViewModel>> taxApplicabilityList = (actionResult.Result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<TaxApplicabilityViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult.Result).StatusCode, 200);
            Assert.IsNotNull(taxApplicabilityList);
            Assert.IsTrue(!taxApplicabilityList.IsError);
            Assert.IsTrue(taxApplicabilityList.Result != null);
            Assert.IsTrue(taxApplicabilityList.Result.Count > 0);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<Occupancy>>(Constants.CacheKeys.TaxApplicabilityList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.TaxApplicabilityList);
        }
        #endregion Postive Test Cases
        #endregion GetTaxApplicability
    }
}
