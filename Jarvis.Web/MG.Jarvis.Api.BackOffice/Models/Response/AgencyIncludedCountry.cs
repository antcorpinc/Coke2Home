using MG.Jarvis.Core.Model.Agency;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class AgencyIncludedCountry : IncludedCountryRelation
    {
        public string CountryCode { get; set; }
    }
}
