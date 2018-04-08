using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class MarketRepository: IMarket
    {
        #region Private Variables
        
        private IConnection<Market> iMarketLibrary;
        private IConnection<MarketIncludedCountryRelation> iMarketIncludedCountryRelationLibrary;
        private IConnection<MarketExcludedCountryRelation> iMarketExcludedCountryRelationLibrary;
        private IConnection<MarketIncludedAndExcludedCountries> iMarketIncludedAndExcludedCountriesLibrary;
        #endregion Private Variables

        #region settings
        public MarketRepository(IConnection<Market> iMarketLibrary,
                                    IConnection<MarketIncludedCountryRelation> iMarketIncludedCountryRelationLibrary,
                                    IConnection<MarketExcludedCountryRelation> iMarketExcludedCountryRelationLibrary,
                                    IConnection<MarketIncludedAndExcludedCountries> iMarketIncludedAndExcludedCountriesLibrary)
        {
            this.iMarketLibrary = iMarketLibrary;
            this.iMarketIncludedCountryRelationLibrary = iMarketIncludedCountryRelationLibrary;
            this.iMarketExcludedCountryRelationLibrary = iMarketExcludedCountryRelationLibrary;
            this.iMarketIncludedAndExcludedCountriesLibrary = iMarketIncludedAndExcludedCountriesLibrary;
        }
        #endregion settings
      
        /// <summary>
        /// Method to create new market
        /// </summary>
        /// <param name="marketDetailsViewModel"></param>
        /// <returns></returns>
        public async Task<BaseResult<Market>> CreateMarket(MarketDetailsViewModel marketDetailsViewModel, string userName)
        {
            BaseResult<Market> result = new BaseResult<Market>();
            result.Result = new Market();
            Market market = null;

            MarketRequestMapper.MapForCreateMarket(ref market, marketDetailsViewModel, userName);

            if (market != null)
            {
                //Add Market
                var insertResult = await iMarketLibrary.InsertEntity(market).ConfigureAwait(false);
                if (insertResult.IsError || insertResult.ExceptionMessage != null)
                {
                    result.IsError = true;
                    result.ExceptionMessage = insertResult.ExceptionMessage;
                    return result;
                }
                else if (insertResult.Result > default(long))
                {
                    //Assign Market Id
                    marketDetailsViewModel.MarketId = (int)insertResult.Result;
                    //Add Included and Excluded countries list
                    result = await AddIncludedAndExcludedCountriesList(marketDetailsViewModel, userName).ConfigureAwait(false);
                }
            }
            else
            {
                result.IsError = true;
                result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.EmptyModel;
                result.Message = string.Format(coreHelper.Constants.ErrorMessage.EmptyModel);
                return result;
            }
            return result;
        }

        /// <summary>
        /// Method to insert included and excluded countries 
        /// </summary>
        /// <param name="marketDetailsViewModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<BaseResult<Market>> AddIncludedAndExcludedCountriesList(MarketDetailsViewModel marketDetailsViewModel, string userName)
        {
            BaseResult<Market> result = new BaseResult<Market>();
            result.Result = new Market();
            List<MarketIncludedCountryRelation> marketIncludedCountryRelationList = null;
            List<MarketExcludedCountryRelation> marketExcludedCountryRelationList = null;

            MarketRequestMapper.MapMarketIncludedAndExcludedCountryRelation(ref marketIncludedCountryRelationList, ref marketExcludedCountryRelationList, marketDetailsViewModel, userName);

            if (marketIncludedCountryRelationList != null && marketIncludedCountryRelationList.Any())
            {
                var includedCountryInsertResult = await iMarketIncludedCountryRelationLibrary.InsertEntityList(marketIncludedCountryRelationList).ConfigureAwait(false);
                if (includedCountryInsertResult.IsError || includedCountryInsertResult.ExceptionMessage != null)
                {
                    result.IsError = true;
                    result.ExceptionMessage = includedCountryInsertResult.ExceptionMessage;
                    return result;
                }
                else if (includedCountryInsertResult.Result > default(long))
                {
                    var excludedCountryInsertResult = await iMarketExcludedCountryRelationLibrary.InsertEntityList(marketExcludedCountryRelationList).ConfigureAwait(false);
                    if (excludedCountryInsertResult.IsError || excludedCountryInsertResult.ExceptionMessage != null)
                    {
                        result.IsError = true;
                        result.ExceptionMessage = excludedCountryInsertResult.ExceptionMessage;
                        return result;
                    }
                    else if (excludedCountryInsertResult.Result > default(long))
                    {
                        result.Result.Id = marketDetailsViewModel.MarketId;
                    }
                }
            }
            else
            {
                result.IsError = true;
                result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.EmptyModel;
                result.Message = string.Format(coreHelper.Constants.ErrorMessage.EmptyModel);
                return result;
            }
            return result;
        }

        /// <summary>
        /// GetMarketIncludedAndExcludedCountries by market id
        /// </summary>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public async Task<BaseResult<List<MarketIncludedAndExcludedCountries>>> GetMarketIncludedAndExcludedCountries(int marketId)
        {
            BaseResult<List<MarketIncludedAndExcludedCountries>> marketIncludedAndExcludedCountriesList = new BaseResult<List<MarketIncludedAndExcludedCountries>>();
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.MarketId, marketId);
            marketIncludedAndExcludedCountriesList = await iMarketIncludedAndExcludedCountriesLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetMarketIncludedAndExcludedCountries, paramCollection).ConfigureAwait(false);
            return marketIncludedAndExcludedCountriesList;
        }
    }
}
