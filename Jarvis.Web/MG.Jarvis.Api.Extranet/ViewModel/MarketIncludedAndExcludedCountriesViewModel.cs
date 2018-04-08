using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class MarketIncludedAndExcludedCountriesViewModel
    {
        public int MarketId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsIncluded { get; set; }
    }
}
