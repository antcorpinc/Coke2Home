using MG.Jarvis.Core.Model.Agency;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class AgencyExcludedCountry : ExcludedCountryRelation
    {
        public string CountryCode { get; set; }
    }
}
