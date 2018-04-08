using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.RatesCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IRatesCategory
    {
        Task<BaseResult<List<Market>>> GetMarkets();
        Task<BaseResult<List<RateCategoryList>>> GetRateCategory(int hotelId);
        Task<BaseResult<List<RateCategory>>> GetRateCategoryById(int rateCategoryById);
        Task<BaseResult<List<RatePlans>>> GetRatePlansById(int rateCategoryById);
        Task<BaseResult<RateCategory>> SaveAndUpdateRateCategory(RateCategoryViewModel rateCategoryViewModel, string userName);
    }
}
