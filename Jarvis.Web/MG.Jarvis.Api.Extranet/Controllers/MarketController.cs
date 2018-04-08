using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;


namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class MarketController : BaseController
    {
        IMarket iMarket;
        public MarketController(IMarket iMarket)
        {
            this.iMarket = iMarket;
        }
        
        /// <summary>
        /// API to GetIncludedAndExcludedCountriesByMarketId by marketId
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetMarketIncludedAndExcludedCountries([FromBody]int marketId)
        {
            BaseResult<List<MarketIncludedAndExcludedCountries>> marketIncludedAndExcludedCountriesResult = new BaseResult<List<MarketIncludedAndExcludedCountries>>();
            if (marketId <= default(int))
            {
                marketIncludedAndExcludedCountriesResult.IsError = true;
                marketIncludedAndExcludedCountriesResult.Message = string.Format(Core.Model.Helper.Constants.ErrorMessage.InvalidId);
                return BadRequest(marketIncludedAndExcludedCountriesResult); //400
            }

            marketIncludedAndExcludedCountriesResult = await iMarket.GetMarketIncludedAndExcludedCountries(marketId).ConfigureAwait(false);
            if (marketIncludedAndExcludedCountriesResult.IsError && marketIncludedAndExcludedCountriesResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (marketIncludedAndExcludedCountriesResult.Result == null)
            {
                return new NoContentResult();
            }
            var result = MarketResponseMapper.MapMarketIncludedAndExcludedCountries(marketIncludedAndExcludedCountriesResult);
            return Ok(result);
        }

        /// <summary>
        /// API to create new Market
        /// </summary>
        /// <param name="marketDetailsViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMarket([FromBody]MarketDetailsViewModel marketDetailsViewModel)
        {
            BaseResult<Market> createMarketResult = new BaseResult<Market>();
            if (marketDetailsViewModel == null)
            {
                createMarketResult.IsError = true;
                createMarketResult.Message = string.Format(coreHelper.Constants.ErrorMessage.EmptyModel);
                return BadRequest(createMarketResult); //400
            }
            string userName = base.LoggedInUserName;
            createMarketResult = await iMarket.CreateMarket(marketDetailsViewModel, userName).ConfigureAwait(false);
            if (createMarketResult.IsError && createMarketResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (createMarketResult.Result == null)
            {
                return new NoContentResult();
            }
            return Ok(createMarketResult);

        }
    }
}