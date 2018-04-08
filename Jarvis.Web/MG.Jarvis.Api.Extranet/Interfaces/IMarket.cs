using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IMarket
    {
        Task<BaseResult<Market>> CreateMarket(MarketDetailsViewModel marketDetailsViewModel, string userName);
        Task<BaseResult<List<MarketIncludedAndExcludedCountries>>> GetMarketIncludedAndExcludedCountries(int marketId);
    }
}
