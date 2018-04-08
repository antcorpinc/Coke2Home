namespace MG.Jarvis.Api.BackOffice.Helper
{
    public static class Constants
    {
        internal const string JakartaTimeZone = "SE Asia Standard Time";
        internal const string InvalidRequest = "Input Request is Invalid.";
        internal const string EntityNotExists = "{0} does not exists.";
        internal const string DuplicateCodeExists = "{0} code already exists.";
        internal const string IsNullOrEmpty = "{0} is null or empty.";
        internal const string MappingSuccessMessage = "Mapping has been done successfully.";
        internal const string PartialMappingSuccessMsg = "Some of the mapping has been failed.Result contains the Failed Mapping List.";
        internal const string ApplicationName = "MG.Jarvis.Api.BackOffice.Controllers - BackOffice";
        internal const string HotelObjectNull = "Hotel object was Null";
        internal const string SupplierCodeDuplication = "Supplier code duplication found";
        internal const string MappingFailed = "May be some mappings are done or May be none please check list";
        internal const string MappingSuccessful = "Mapping Done Successfully";
        internal const string SqlServerError = "SQL server error Occurred. ";
        internal const string ExceptionCountered = "Caught an exception";
        internal const string AppName = "MG.Jarvis.Api.BackOffice";
        internal const string NoContentExceptionMessage = "No columns were selected";
        internal const string UpdateMethodName = "UpdateAgent";
        internal const string DeleteMethodName = "DeleteAgent";
        internal const string InternalErrorStatusCode = "500";
        internal const string DulpicateMarkupPresent = "Markup already present";

        internal struct StoredProcedure
        {
            internal const string GetNationalityCodeMappings = "usp_GetNationalityCodeMappings";
            internal const string GetPromotionCodeMappings = "usp_GetPromotionCodeMappings";
            internal const string GetRoomTypeCodeMappings = "usp_GetRoomTypeCodeMappings";
            internal const string GetHotelCodeMappings = "usp_GetHotelCodeMappings";
            internal const string GetCityCodeMappings = "usp_GetCityCodeMappings";
            internal const string GetCountryCodeMappings = "usp_GetCountryCodeMappings";
            internal const string GetMealTypeCodeMappings = "usp_GetMealTypeCodeMappings";

            internal const string InsertAgent = "[dbo].[usp_InsertAgent]";
            internal const string GetAllAgents = "[dbo].[usp_GetAgents]";
            internal const string GetAgentDetails = "[dbo].[usp_GetAgentDetails]";
            internal const string UpdateAgent = "[dbo].[usp_UpdateAgent]";
            internal const string GetAgencyDetails = "usp_GetAgency";
            internal const string GetAllAgencies = "usp_GetAllAgencies";
            internal const string GetSupplierDetails = "usp_GetSupplierById";
            internal const string GetAllSuppliers = "usp_GetAllSuppliers";
            internal const string AddSupplier = "usp_InsertSupplier";
            internal const string UpdateSupplier = "usp_UpdateSupplier";
            internal const string AddBranch = "usp_InsertBranch";
            internal const string UpdateBranch = "usp_UpdateBranch";
            internal const string GetAllBranches = "[dbo].[usp_GetBranches]";
            internal const string GetBranchDetails = "[dbo].[usp_GetBranchDetails]";
            internal const string InsertAgency = "usp_InsertAgency";
            internal const string UpdateAgency = "usp_UpdateAgency";
            internal const string InsertRevenueMarkupRules = "[dbo].[usp_InsertRevenueMarkupRules]";
            internal const string UpdateRevenueMarkupRules = "[dbo].[usp_UpdateRevenueMarkupRules]";
            internal const string InsertAgencyMarkupRules = "[dbo].[usp_InsertAgencyMarkupRules]";
            internal const string UpdateAgencyMarkupRules = "[dbo].[usp_UpdateAgencyMarkupRules]";
            internal const string SoftDeleteMarkupWithRules = "[dbo].[usp_SoftDeleteMarkupWithRules]";
            internal const string GetMarkups = "[dbo].[usp_GetMarkups]";
            internal const string InsertChannelManager = "[dbo].[usp_InsertChannelManager]";
            internal const string GetCurrencyConversionRates = "[dbo].[usp_GetCurrencyConversionRates]";
            internal const string InsertCitySupplierMapping = "usp_insertCitySupplierMapping";
            internal const string InsertCountrySupplierMapping = "[dbo].[usp_insertCountrySupplierMapping]";
            internal const string InsertHotelSupplierMapping = "[dbo].[usp_insertHotelSupplierMapping]";
            internal const string InsertNationalitySupplierMapping = "[dbo].[usp_insertNationalitySupplierMapping]";
            internal const string InsertPromotionsSupplierMapping = "[dbo].[usp_insertPromotionsSupplierMapping]";
            internal const string InsertRoomTypeSupplierMapping = "[dbo].[usp_insertRoomTypeSupplierMapping]";
            internal const string InsertMealTypeSupplierMapping = "[dbo].[usp_insertMealTypeSupplierMapping]";
            internal const string GetCitySuppliersCacheDays = "[dbo].[usp_GetCitySuppliersCacheDays]";            
        }

        internal struct StoredProcedureParameters
        {
            //Common
            internal const string UT_SupplierContacts = "UT_SupplierContacts";
            internal const string UT_SupplierBanks = "UT_SupplierBanks";
            internal const string SupplierContacts = "SupplierContacts";
            internal const string SupplierBanks = "SupplierBanks";
            internal const string RevenueMarkupRules = "RevenueMarkupRules";
            internal const string AgencyMarkupRules = "AgencyMarkupRules";
            internal const string UT_RevenueMarkupRules = "UT_RevenueMarkupRules";
            internal const string UT_AgencyMarkupRules = "UT_AgencyMarkupRules";
            internal const string UT_AgencyBranchContacts = "UT_Contacts";
            internal const string AgencyContacts = "agencycontact";
            internal const string BranchContacts = "branchcontacts";
            internal const string UT_AgencyIncludedCountry = "UT_AgencyIncludedCountry";
            internal const string AgencyIncludedCountry = "agencyincludedcountries";
            internal const string UT_AgencyExcludedCountry = "UT_AgencyExcludedCountry";
            internal const string AgencyExcludedCountry = "agencyexcludedcountries";
            internal const string UT_AgencySuppliers = "UT_AgencySuppliers";
            internal const string AgencySuppliers = "agencysuppliers";

            internal const string UT_ChannelManagerContacts = "UT_ChannelManagerContacts";
            internal const string UT_ChannelManagerBanks = "UT_ChannelManagerBanks";
            internal const string ChannelManagerContacts = "ChannelManagerContacts";
            internal const string ChannelManagerBanks = "ChannelManagerBanks";
            internal const string UT_ChannelManagerEmailAddresses = "UT_ChannelManagerEmailAddresses";
            internal const string ChannelManagerEmailAddresses = "ChannelManagerEmailAddresses";
            internal const string UT_ChannelManagerFunctions = "UT_ChannelManagerFunctions";
            internal const string ChannelManagerFunctions = "ChannelManagerFunctions";
            internal const string UT_FunctionChannelManagerRelation = "UT_FunctionChannelManagerRelation";
            internal const string FunctionChannelManagerRelation = "FunctionChannelManagerRelation";
            internal const string UT_ChannelManagerUserRelation = "UT_ChannelManagerUserRelation";
            internal const string ChannelManagerUserRelation = "ChannelManagerUserRelation";
            internal const string UT_EntityMapping = "UT_EntityMapping";

            internal const string MarkupType = "markupType";
            internal const string MarkupName = "markupName";
            internal const string Mapping = "mapping";
            internal const string SupplierCode = "suppliercode";

        }

    }
}
