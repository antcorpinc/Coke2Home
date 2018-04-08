using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class Agency
    {
        public Agency()
        {
            this.AgencyContacts = new List<Core.Model.Agency.AgencyContacts>();
            this.IncludedCountryRelation = new List<AgencyIncludedCountry>();
            this.ExcludedCountryRelation = new List<AgencyExcludedCountry>();
            this.AgencySupplierRelation = new List<Core.Model.Agency.AgencySupplierRelation>();
        }
        public AgencyViewModel MGAgency { get; set; }
        public List<Core.Model.Agency.AgencyContacts> AgencyContacts { get; set; }
        public Core.Model.Agency.Payment Payment { get; set; }
        public Core.Model.Agency.Bank Bank { get; set; }
        public List<AgencyIncludedCountry> IncludedCountryRelation { get; set; }
        public List<AgencyExcludedCountry> ExcludedCountryRelation { get; set; }
        public List<Core.Model.Agency.AgencySupplierRelation> AgencySupplierRelation { get; set; }
        public Core.Model.Agency.Agents SuperUserAgent { get; set; }

        public Core.Model.Agency.Branch Branch { get; set; }
    }
}
