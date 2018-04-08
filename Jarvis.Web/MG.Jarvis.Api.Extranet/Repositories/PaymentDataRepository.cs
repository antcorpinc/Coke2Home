using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class PaymentDataRepository : IPayment
    {
        private IConnection<Currency> iCurrencyConnectionLibrary;
        private IConnection<PaymentMethod> iPaymentMethodLibrary;
        private IConnection<RateType> iRateTypeLibrary;
        private IConnection<TaxType> iTaxTypeLibrary;
        private IConnection<TaxApplicability> iTaxApplicabilityLibrary;

        public PaymentDataRepository(IConnection<Currency> iCurrencyConnectionLibrary
                                 ,IConnection<PaymentMethod> iPaymentMethodLibrary
                                 ,IConnection<RateType> iRateTypeLibrary
                                 ,IConnection<TaxType> iTaxTypeLibrary
                                 ,IConnection<TaxApplicability> iTaxApplicabilityLibrary)
        {
            this.iCurrencyConnectionLibrary = iCurrencyConnectionLibrary;
            this.iPaymentMethodLibrary = iPaymentMethodLibrary;
            this.iRateTypeLibrary = iRateTypeLibrary;
            this.iTaxTypeLibrary = iTaxTypeLibrary;
            this.iTaxApplicabilityLibrary = iTaxApplicabilityLibrary;
        }

        /// <summary>
        /// Retrun all Currencies
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<Currency>>> GetCurrency()
        {
            return await iCurrencyConnectionLibrary.GetListByPredicate(id => id.IsActive == true && !id.IsDeleted).ConfigureAwait(false);
        }

        /// <summary>
        /// Return Currency details of particular hotel
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<Currency>>> GetCurrencyByHotelId(int hotelId)
        {
            BaseResult<List<Currency>> currencyList = new BaseResult<List<Currency>>();
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add("@hotelid", hotelId);
            currencyList = await iCurrencyConnectionLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelCurrency, paramCollection).ConfigureAwait(false);
            return currencyList;
        }
        /// <summary>
        /// Return list of Payment methods
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<PaymentMethod>>> GetPaymentMethod()
        {
            return await iPaymentMethodLibrary.GetListByPredicate(id => id.IsActive == true && !id.IsDeleted).ConfigureAwait(false);
        }

        /// <summary>
        /// Return list of Rate types
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<RateType>>> GetRateType()
        {
            return await iRateTypeLibrary.GetListByPredicate(id => id.IsActive == true && !id.IsDeleted).ConfigureAwait(false);
        }

        /// <summary>
        /// Return list of Tax types
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<TaxType>>> GetTaxType()
        {
            return await iTaxTypeLibrary.GetListByPredicate(id =>id.IsDeleted==false).ConfigureAwait(false);
        }

        /// <summary>
        /// Return Tax applicability
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<TaxApplicability>>> GetTaxApplicability()
        {
            return await iTaxApplicabilityLibrary.GetListByPredicate(id =>id.IsDeleted==false).ConfigureAwait(false);
        }
    }
}
