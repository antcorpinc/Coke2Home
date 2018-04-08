using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class PaymentDataController : Controller
    {
        IPayment iPayment;
        public PaymentDataController(IPayment iPayment)
        {
            this.iPayment = iPayment;
        }

        /// <summary>
        /// Return the list of Currency
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetCurrency()
        {
            BaseResult<List<CurrencyViewModel>> currencyResultFromCache = new BaseResult<List<CurrencyViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<CurrencyViewModel>>(Constants.CacheKeys.CurrencyList)
            };

            if (currencyResultFromCache.Result == null || currencyResultFromCache.Result.Count == 0)
            {
                BaseResult<List<Currency>> currencyResult = await iPayment.GetCurrency().ConfigureAwait(false);

                if (currencyResult.IsError && currencyResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (currencyResult.Result == null || currencyResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = PaymentDataResponseMapper.MapCurrency(currencyResult);
                    RedisCacheHelper.Instance.Set<List<CurrencyViewModel>>(Constants.CacheKeys.CurrencyList, result.Result);
                    return Ok(result); //200
                }
            }

            return Ok(currencyResultFromCache); //200
        }

        /// <summary>
        /// Get Currency By HotelId
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetCurrencyByHotelId([FromBody]int hotelId)
        {
            BaseResult<List<Currency>> currencyResult = new BaseResult<List<Currency>>();
            if (hotelId <= default(int))
            {
                currencyResult.IsError = true;
                currencyResult.Message = "Invalid Hotel Id";
                return BadRequest(currencyResult);
            }
            currencyResult = await iPayment.GetCurrencyByHotelId(hotelId).ConfigureAwait(false);

            if (currencyResult.IsError && currencyResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (currencyResult.Result == null || currencyResult.Result.Count == 0)
            {
                return NoContent(); //204
            }
            var result = PaymentDataResponseMapper.MapCurrency(currencyResult);
            return Ok(result); //200
        }

        /// <summary>
        ///  Return the list of PaymentMethods
        /// </summary>
        /// <returns>PaymentMethodList</returns>
        public async Task<IActionResult> GetPaymentMethod()
        {
            BaseResult<List<PaymentMethodViewModel>> paymentMethodResultFromCache = new BaseResult<List<PaymentMethodViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<PaymentMethodViewModel>>(Constants.CacheKeys.PaymentMethodList)
            };

            if (paymentMethodResultFromCache.Result == null || paymentMethodResultFromCache.Result.Count == 0)
            {
                BaseResult<List<PaymentMethod>> paymentMethodResult = await iPayment.GetPaymentMethod().ConfigureAwait(false);

                if (paymentMethodResult.IsError && paymentMethodResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (paymentMethodResult.Result == null || paymentMethodResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = PaymentDataResponseMapper.MapPaymentMethod(paymentMethodResult);
                    RedisCacheHelper.Instance.Set<List<PaymentMethodViewModel>>(Constants.CacheKeys.PaymentMethodList, result.Result);
                    return Ok(result); //200
                }
            }
            return Ok(paymentMethodResultFromCache); //200
        }

        /// <summary>
        ///  Return the list of RateTypes
        /// </summary>
        /// <returns>RateTypeList</returns>
        public async Task<IActionResult> GetRateType()
        {
            BaseResult<List<RateTypeViewModel>> rateTypeResultFromCache = new BaseResult<List<RateTypeViewModel>>()
            {
                Result = RedisCacheHelper.Instance.Get<List<RateTypeViewModel>>(Constants.CacheKeys.RateTypeList)
            };

            if (rateTypeResultFromCache.Result == null || rateTypeResultFromCache.Result.Count == 0)
            {
                BaseResult<List<RateType>> rateTypeResult = await iPayment.GetRateType().ConfigureAwait(false);

                if (rateTypeResult.IsError && rateTypeResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (rateTypeResult.Result == null || rateTypeResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = PaymentDataResponseMapper.MapRateType(rateTypeResult);
                    RedisCacheHelper.Instance.Set<List<RateTypeViewModel>>(Constants.CacheKeys.RateTypeList, result.Result);
                    return Ok(result); //200
                }
            }
            return Ok(rateTypeResultFromCache); //200
        }

        /// <summary>
        ///  Return the list of TaxTypes
        /// </summary>
        /// <returns>TaxTypeList</returns>
        public async Task<IActionResult> GetTaxType()
        {
            BaseResult<List<TaxTypeViewModel>> taxTypeResultFromCache = new BaseResult<List<TaxTypeViewModel>>()
            {
                Result = RedisCacheHelper.Instance.Get<List<TaxTypeViewModel>>(Constants.CacheKeys.TaxTypeList)
            };

            if (taxTypeResultFromCache.Result == null || taxTypeResultFromCache.Result.Count == 0)
            {
                BaseResult<List<TaxType>> taxTypeResult = await iPayment.GetTaxType().ConfigureAwait(false);

                if (taxTypeResult.IsError && taxTypeResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (taxTypeResult.Result == null || taxTypeResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = PaymentDataResponseMapper.MapTaxType(taxTypeResult);
                    RedisCacheHelper.Instance.Set<List<TaxTypeViewModel>>(Constants.CacheKeys.TaxTypeList, result.Result);
                    return Ok(result); //200
                }
            }
            return Ok(taxTypeResultFromCache); //200
        }

        /// <summary>
        ///  Return the list of TaxApplicability
        /// </summary>
        /// <returns>TaxApplicabilityList</returns>
        public async Task<IActionResult> GetTaxApplicability()
        {
            BaseResult<List<TaxApplicabilityViewModel>> taxApplicabilityResultFromCache = new BaseResult<List<TaxApplicabilityViewModel>>()
            {
                Result = RedisCacheHelper.Instance.Get<List<TaxApplicabilityViewModel>>(Constants.CacheKeys.TaxApplicabilityList)
            };

            if (taxApplicabilityResultFromCache.Result == null || taxApplicabilityResultFromCache.Result.Count == 0)
            {
                BaseResult<List<TaxApplicability>> taxApplicabilityResult = await iPayment.GetTaxApplicability().ConfigureAwait(false);

                if (taxApplicabilityResult.IsError && taxApplicabilityResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (taxApplicabilityResult.Result == null || taxApplicabilityResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = PaymentDataResponseMapper.MapTaxApplicability(taxApplicabilityResult);
                    RedisCacheHelper.Instance.Set<List<TaxApplicabilityViewModel>>(Constants.CacheKeys.TaxApplicabilityList, result.Result);
                    return Ok(result); //200
                }
            }
            return Ok(taxApplicabilityResultFromCache); //200
        }
    }
}