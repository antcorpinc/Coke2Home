using Dapper.Contrib.Extensions;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.CustomAttributes;
using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class Agency
    {
        public Agency()
        {
            this.AgencyContacts = new List<Core.Model.Agency.AgencyContacts>();
            this.IncludedCountryRelation = new List<Core.Model.Agency.IncludedCountryRelation>();
            this.ExcludedCountryRelation = new List<Core.Model.Agency.ExcludedCountryRelation>();
            this.AgencySupplierRelation = new List<Core.Model.Agency.AgencySupplierRelation>();

        }
        [ChildParameter(true)]
        public Core.Model.Agency.Agency MGAgency { get; set; }
        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.AgencyContacts, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_AgencyBranchContacts)]
        public List<Core.Model.Agency.AgencyContacts> AgencyContacts { get; set; }
        [ChildParameter(true)]
        public Core.Model.Agency.Payment Payment { get; set; }
        [ChildParameter(true)]
        public Core.Model.Agency.Bank Bank { get; set; }
        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.AgencyIncludedCountry, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_AgencyIncludedCountry)]
        public List<Core.Model.Agency.IncludedCountryRelation> IncludedCountryRelation { get; set; }
        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.AgencyExcludedCountry, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_AgencyExcludedCountry)]
        public List<Core.Model.Agency.ExcludedCountryRelation> ExcludedCountryRelation { get; set; }
        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.AgencySuppliers, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_AgencySuppliers)]
        public List<Core.Model.Agency.AgencySupplierRelation> AgencySupplierRelation { get; set; }
        // public CreditLimit CreditLimit { get; set; }
        [ChildParameter(true)]
        public Core.Model.Agency.Agents SuperUserAgent { get; set; }
      
    }
}
