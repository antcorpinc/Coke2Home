using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public class PaymentDataResponseMapper
    {
        /// <summary>
        /// Return the mapped Currency viewmodel
        /// </summary>
        /// <param name="currencyListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<CurrencyViewModel>> MapCurrency(BaseResult<List<Currency>> currencyListDetail)
        {
            BaseResult<List<CurrencyViewModel>> currencyViewModelList = new BaseResult<List<CurrencyViewModel>>();
            List<CurrencyViewModel> modelList = new List<CurrencyViewModel>();
            foreach (var item in currencyListDetail.Result)
            {
                CurrencyViewModel model = new CurrencyViewModel
                {
                    CurrencyId = item.Id,
                    CurrencyName = string.Concat(item.Code + "-" + item.Name),
                    CurrencyCode = item.Code
                };
                modelList.Add(model);
            }
            currencyViewModelList.Result = modelList;
            return currencyViewModelList;
        }

        /// <summary>
        /// Return the mapped PaymentMethod viewmodel
        /// </summary>
        /// <param name="paymentMethodListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<PaymentMethodViewModel>> MapPaymentMethod(BaseResult<List<PaymentMethod>> paymentMethodListDetail)
        {
            BaseResult<List<PaymentMethodViewModel>> paymentMethodViewModelList = new BaseResult<List<PaymentMethodViewModel>>();
            List<PaymentMethodViewModel> modelList = new List<PaymentMethodViewModel>();
            foreach (var item in paymentMethodListDetail.Result)
            {
                PaymentMethodViewModel model = new PaymentMethodViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            paymentMethodViewModelList.Result = modelList;
            return paymentMethodViewModelList;
        }

        /// <summary>
        /// Return the mapped TaxType viewmodel
        /// </summary>
        /// <param name="taxTypeListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<TaxTypeViewModel>> MapTaxType(BaseResult<List<TaxType>> taxTypeListDetail)
        {
            BaseResult<List<TaxTypeViewModel>> taxTypeViewModelList = new BaseResult<List<TaxTypeViewModel>>();
            List<TaxTypeViewModel> modelList = new List<TaxTypeViewModel>();
            foreach (var item in taxTypeListDetail.Result)
            {
                TaxTypeViewModel model = new TaxTypeViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            taxTypeViewModelList.Result = modelList;
            return taxTypeViewModelList;
        }

        /// <summary>
        /// Return the mapped RateType viewmodel
        /// </summary>
        /// <param name="rateTypeListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<RateTypeViewModel>> MapRateType(BaseResult<List<RateType>> rateTypeListDetail)
        {
            BaseResult<List<RateTypeViewModel>> rateTypeViewModelList = new BaseResult<List<RateTypeViewModel>>();
            List<RateTypeViewModel> modelList = new List<RateTypeViewModel>();
            foreach (var item in rateTypeListDetail.Result)
            {
                RateTypeViewModel model = new RateTypeViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            rateTypeViewModelList.Result = modelList;
            return rateTypeViewModelList;
        }

        /// <summary>
        /// Return the mapped TaxApplicability viewmodel
        /// </summary>
        /// <param name="taxApplicabilityListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<TaxApplicabilityViewModel>> MapTaxApplicability(BaseResult<List<TaxApplicability>> taxApplicabilityListDetail)
        {
            BaseResult<List<TaxApplicabilityViewModel>> taxApplicabilityViewModelList = new BaseResult<List<TaxApplicabilityViewModel>>();
            List<TaxApplicabilityViewModel> modelList = new List<TaxApplicabilityViewModel>();
            foreach (var item in taxApplicabilityListDetail.Result)
            {
                TaxApplicabilityViewModel model = new TaxApplicabilityViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(model);
            }
            taxApplicabilityViewModelList.Result = modelList;
            return taxApplicabilityViewModelList;
        }

    }
}
