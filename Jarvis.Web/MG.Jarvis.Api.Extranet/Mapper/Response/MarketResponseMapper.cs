using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public class MarketResponseMapper
    {
        /// <summary>
        /// Map MarketIncludedAndExcludedCountries to MarketIncludedAndExcludedCountriesViewModel
        /// </summary>
        /// <param name="marketIncludedAndExcludedCountriesDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<MarketIncludedAndExcludedCountriesViewModel>> MapMarketIncludedAndExcludedCountries(BaseResult<List<MarketIncludedAndExcludedCountries>> marketIncludedAndExcludedCountriesDetail)
        {
            BaseResult<List<MarketIncludedAndExcludedCountriesViewModel>> marketIncludedAndExcludedCountriesList = new BaseResult<List<MarketIncludedAndExcludedCountriesViewModel>>();
            List<MarketIncludedAndExcludedCountriesViewModel> modelList = new List<MarketIncludedAndExcludedCountriesViewModel>();
            MarketIncludedAndExcludedCountriesViewModel model = new MarketIncludedAndExcludedCountriesViewModel();
            foreach (var item in marketIncludedAndExcludedCountriesDetail.Result)
            {
                //Map
                model = AutoMapper.Mapper.Map<MarketIncludedAndExcludedCountries, MarketIncludedAndExcludedCountriesViewModel>(item);
                modelList.Add(model);
            }
            marketIncludedAndExcludedCountriesList.Result = modelList;
            return marketIncludedAndExcludedCountriesList;
        }
    }
}
