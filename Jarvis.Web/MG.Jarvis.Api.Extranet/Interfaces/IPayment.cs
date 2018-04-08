using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IPayment
    {
        Task<BaseResult<List<Currency>>> GetCurrency();
        Task<BaseResult<List<Currency>>> GetCurrencyByHotelId(int hotelId);
        Task<BaseResult<List<PaymentMethod>>> GetPaymentMethod();
        Task<BaseResult<List<RateType>>> GetRateType();
        Task<BaseResult<List<TaxType>>> GetTaxType();
        Task<BaseResult<List<TaxApplicability>>> GetTaxApplicability();
    }
}
