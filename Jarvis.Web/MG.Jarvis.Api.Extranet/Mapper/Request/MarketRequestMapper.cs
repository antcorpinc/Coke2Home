using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public class MarketRequestMapper
    {
        /// <summary>
        /// Method to Map Market, MarketIncludedCountryRelation and MarketExcludedCountryRelation
        /// </summary>
        /// <param name="marketModel"></param>
        /// <param name="marketIncludedCountryRelationModel"></param>
        /// <param name="marketExcludedCountryRelationModel"></param>
        /// <param name="marketDetailsViewModel"></param>
        public static void MapForCreateMarket(ref Market marketModel, MarketDetailsViewModel marketDetailsViewModel, string userName)
        {
            marketModel = new Market();
            //Map Market
            marketModel = AutoMapper.Mapper.Map<MarketDetailsViewModel, Market>(marketDetailsViewModel);
            marketModel.IsActive = true;
            marketModel.IsDeleted = false;
            marketModel.CreatedBy = userName;
            marketModel.CreatedDate = DateTime.Now.JakartaOffset(); ;
            marketModel.UpdatedBy = userName;
            marketModel.UpdatedDate = DateTime.Now.JakartaOffset(); ;
        }

        /// <summary>
        /// Method to MapMarketIncludedAndExcludedCountryRelation
        /// </summary>
        /// <param name="marketIncludedCountryRelationList"></param>
        /// <param name="marketExcludedCountryRelationList"></param>
        /// <param name="marketDetailsViewModel"></param>
        /// <param name="userName"></param>
        public static void MapMarketIncludedAndExcludedCountryRelation(ref List<MarketIncludedCountryRelation> marketIncludedCountryRelationList, ref List<MarketExcludedCountryRelation> marketExcludedCountryRelationList, MarketDetailsViewModel marketDetailsViewModel, string userName)
        {
            marketIncludedCountryRelationList = new List<MarketIncludedCountryRelation>();
            marketExcludedCountryRelationList = new List<MarketExcludedCountryRelation>();
            
            //Map MarketIncludedCountryRelation
            foreach (var inCountry in marketDetailsViewModel.IncludedMarketList)
            {
                MarketIncludedCountryRelation marketIncludedCountryRelationModel = new MarketIncludedCountryRelation();
                //Map Market
                marketIncludedCountryRelationModel = AutoMapper.Mapper.Map<MarketCountriesViewModel, MarketIncludedCountryRelation>(inCountry);
                marketIncludedCountryRelationModel.MarketId = marketDetailsViewModel.MarketId;
                marketIncludedCountryRelationModel.IsActive = true;
                marketIncludedCountryRelationModel.IsDeleted = false;
                marketIncludedCountryRelationModel.CreatedBy = userName;
                marketIncludedCountryRelationModel.CreatedDate = DateTime.Now.JakartaOffset();
                marketIncludedCountryRelationModel.UpdatedBy = userName;
                marketIncludedCountryRelationModel.UpdatedDate = DateTime.Now.JakartaOffset();

                marketIncludedCountryRelationList.Add(marketIncludedCountryRelationModel);
            }

            //Map MarketExcludedCountryRelation
            foreach (var exCountry in marketDetailsViewModel.ExcludedMarketList)
            {
                MarketExcludedCountryRelation marketExcludedCountryRelationModel = new MarketExcludedCountryRelation();
                marketExcludedCountryRelationModel = AutoMapper.Mapper.Map<MarketCountriesViewModel, MarketExcludedCountryRelation>(exCountry);
                marketExcludedCountryRelationModel.MarketId = marketDetailsViewModel.MarketId;
                marketExcludedCountryRelationModel.IsActive = true;
                marketExcludedCountryRelationModel.IsDeleted = false;
                marketExcludedCountryRelationModel.CreatedBy = userName;
                marketExcludedCountryRelationModel.CreatedDate = DateTime.Now.JakartaOffset();
                marketExcludedCountryRelationModel.UpdatedBy = userName;
                marketExcludedCountryRelationModel.UpdatedDate = DateTime.Now.JakartaOffset();

                marketExcludedCountryRelationList.Add(marketExcludedCountryRelationModel);
            }
        }
    }
}
