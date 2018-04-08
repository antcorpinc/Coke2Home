using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class MarketDetailsViewModel
    {
        public MarketDetailsViewModel()
        {
            this.IncludedMarketList = new List<MarketCountriesViewModel>();
            this.ExcludedMarketList = new List<MarketCountriesViewModel>();
        }
        //public MarketViewModel MarketViewModel { get; set; }
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public List<MarketCountriesViewModel> IncludedMarketList { get; }
        public List<MarketCountriesViewModel> ExcludedMarketList { get; }
    }
}
