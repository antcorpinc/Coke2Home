using Dapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ER = MG.Jarvis.Api.Extranet.Repositories;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    public class PaymentDataRepositoryTest
    {
        #region private variables
        private IPayment paymentDataRepository;

        private Mock<IConnection<Currency>> iCurrencyConnectionLibrary;
        private Mock<IConnection<PaymentMethod>> iPaymentMethodLibrary;
        private Mock<IConnection<RateType>> iRateTypeLibrary;
        private Mock<IConnection<TaxType>> iTaxTypeLibrary;
        private Mock<IConnection<TaxApplicability>> iTaxApplicabilityLibrary;
        #endregion private variables

        #region settings
        public PaymentDataRepositoryTest()
        {
            iCurrencyConnectionLibrary = new Mock<IConnection<Currency>>();
            iPaymentMethodLibrary = new Mock<IConnection<PaymentMethod>>();
            iRateTypeLibrary = new Mock<IConnection<RateType>>();
            iTaxTypeLibrary = new Mock<IConnection<TaxType>>();
            iTaxApplicabilityLibrary = new Mock<IConnection<TaxApplicability>>();
            paymentDataRepository = new ER.PaymentDataRepository(iCurrencyConnectionLibrary.Object, iPaymentMethodLibrary.Object, iRateTypeLibrary.Object, iTaxTypeLibrary.Object, iTaxApplicabilityLibrary.Object);

        }
        #endregion settings

        [Test]
        public async Task TestGetCurrency_Positive_Predicate()
        {
            //Arrange
            var currency = new Currency() { Id = 1, Name = "RS", IsActive = true, Code="IND", IsDeleted=false };
            var baseResult = new BaseResult<List<Currency>>() { Result = new List<Currency>() { currency } };
            var pred = new Func<Currency, bool>(x => x.IsActive && !x.IsDeleted);

            iCurrencyConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<Currency, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<Currency>>> result = paymentDataRepository.GetCurrency();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<Currency>>);
        }

        [Test]
        public async Task TestGetCurrencyByHotelId_Positive_Success()
        {
            //Arrange
            int hotelId = 5;
            var currency = new Currency() { Id = 1, Name = "RS", IsActive = true, Code = "IND", IsDeleted = false };
            var baseResult = new BaseResult<List<Currency>>() { Result = new List<Currency>() { currency } };
            iCurrencyConnectionLibrary.Setup(x => x.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<Currency>>> result = paymentDataRepository.GetCurrencyByHotelId(hotelId);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<Currency>>);
        }

        [Test]
        public async Task TestGetPaymentMethod_Positive_Predicate()
        {
            //Arrange
            var paymentMethod = new PaymentMethod() { Id = 1, Name = "RS", IsActive = true, IsDeleted = false, NameItemId =1};
            var baseResult = new BaseResult<List<PaymentMethod>>() { Result = new List<PaymentMethod>() { paymentMethod } };
            var pred = new Func<PaymentMethod, bool>(x => x.IsActive && !x.IsDeleted);

            iPaymentMethodLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<PaymentMethod, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<PaymentMethod>>> result = paymentDataRepository.GetPaymentMethod();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<PaymentMethod>>);
        }

        [Test]
        public async Task TestGetRateType_Positive_Predicate()
        {
            //Arrange
            var rateType = new RateType() { Id = 1, Name = "Net", IsActive = true, IsDeleted = false, NameItemId = 1 };
            var baseResult = new BaseResult<List<RateType>>() { Result = new List<RateType>() { rateType } };
            var pred = new Func<RateType, bool>(x => x.IsActive && !x.IsDeleted);

            iRateTypeLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<RateType, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<RateType>>> result = paymentDataRepository.GetRateType();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<RateType>>);
        }

        [Test]
        public async Task TestGetTaxType_Positive_Predicate()
        {
            //Arrange
            var taxType = new TaxType() { Id = 1, Name = "VAT",IsDeleted = false, NameItemId = 1 };
            var baseResult = new BaseResult<List<TaxType>>() { Result = new List<TaxType>() { taxType } };
            var pred = new Func<TaxType, bool>(x => x.IsDeleted==false);

            iTaxTypeLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<TaxType, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<TaxType>>> result = paymentDataRepository.GetTaxType();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<TaxType>>);
        }

        [Test]
        public async Task TestGetTaxApplicability_Positive_Predicate()
        {
            //Arrange
            var taxApplicability = new TaxApplicability() { Id = 1, Name = "Per Room", IsDeleted = false, NameItemId = 1 };
            var baseResult = new BaseResult<List<TaxApplicability>>() { Result = new List<TaxApplicability>() { taxApplicability } };
            var pred = new Func<TaxApplicability, bool>(x => x.IsDeleted == false);

            iTaxApplicabilityLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<TaxApplicability, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<TaxApplicability>>> result = paymentDataRepository.GetTaxApplicability();
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<TaxApplicability>>);
        }
    }
}
