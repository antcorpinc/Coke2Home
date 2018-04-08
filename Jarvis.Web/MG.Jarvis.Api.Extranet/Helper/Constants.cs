namespace MG.Jarvis.Api.Extranet.Helper
{
    public static class Constants
    {
        internal struct StoredProcedure
        {
            internal const string ActivateContracts = "usp_ActivateContract";
            internal const string ExpriedContracts = "usp_GetContractdetails_ForExpiryNotification";
            /// <summary>
            /// for updating the status of contract as deactive
            /// </summary>
            internal const string DeActivateContracts = "usp_DeactivateContract";
            internal const string GetHotelDetails = "usp_GetHotelById";
            internal const string GetHotelsByCityId = "usp_GetAllHotelsByCityId";
            internal const string GetCity = "usp_GetCity";
            internal const string AddHotel = "usp_InsertHotel";
            internal const string GetAllHotels = "usp_GetAllHotels";
            internal const string ValidateChannelMangerRequest = "usp_ValidateChannelManagerRequest";
            internal const string GetRoomTypesAndRatePlans = "usp_GetRoomTypesAndRatePlans";
            internal const string ValidateAllocationsRequest = "usp_ValidateUpdateAllocationRequest";
            internal const string UpdateAllocations = "usp_ValidateUpdateAllocationRequest";
            internal const string UpdateAllocationRates = "usp_ValidateUpdateAllocationRates";
            internal const string GetProfileCompletenessByHotelID = "usp_GetProfileCompletenessByHotelID";
            internal const string SaveUpdateHotelTaxRelation = "usp_UpdateHotelTaxRelation";
            internal const string UpdateReservationEmail = "usp_UpdateReservationEmail";
            internal const string UpdateReservationTelephone = "usp_UpdateReservationTelephone";
            internal const string CreateRoomType = "usp_InsertRoomType";
            internal const string GetAllContracts = "usp_GetAllContracts";
            internal const string GetChildrenAndExtraBedPolicyByHotelId = "usp_GetMaxChildrenAndExtraBedsPerRoom";
            internal const string GetHotelFieldsByTemplateId = "usp_GetHotelFieldsByTemplateId";
            internal const string GetRooomFieldsByTemplateId = "usp_GetRoomFieldsByTemplateId";
           //internal const string GetHotelFacilityFieldsByTemplateId = "usp_GetHotelFacilityFieldsByTemplateId";
            internal const string GetRateCategoryList = "usp_GetRateCategory";
            internal const string GetClauseLibraryFieldsByTemplateId = "usp_GetClauseLibraryFieldsByTemplateId";
            internal const string UpdateClauseLibraryFieldsByTemplateId = "usp_UpdateClauseLibraryFieldsByTemplateId";
            internal const string UpdateHotelFields = "usp_UpdateTemplateHotelProperties";
            internal const string UpdateRooomFields = "usp_UpdateTemplateRoomProperties";
            internal const string UpdateContractTemplateName = "usp_UpdateContractTemplateName";
            internal const string GetHotelCurrency = "usp_GetHotelCurrency";
            internal const string GetReservationDetails = "usp_GetReservationDetail";
            internal const string GetHotelDetailsDataForXMLServices = "usp_GetHotelDetailsDataForXMLServices";
            internal const string CreateTemplateCopy = "usp_InsertTemplateCopy";
            internal const string GetMarketIncludedAndExcludedCountries = "usp_GetMarketIncludedAndExcludedCountries";
            internal const string GetAllHotelByBrandId = "usp_GetAllHotelsByBrandId";
            internal const string GetDesignationByUserType = "usp_GetDesignationByUserType";
            internal const string GetHotelFieldsByTemplateId_HotelContract = "usp_GetHotelFieldsByTemplateId_HotelContract";
            internal const string GetRoomFieldsByTemplateId_RoomContract = "usp_GetRoomFieldsByTemplateId_RoomContract";


        }
        /// <summary>
        /// For Parameters of stored procedure
        /// </summary>
        internal struct StoredProcedureParameters
        {
            /// <summary>
            /// End date for deactivating contract
            /// </summary>
            internal const string EndDate = "@EndDate";
            internal const string StartDate = "@StartDate";
            internal const string Name = "@name";
            internal const string CityId = "@CityId";
            internal const string CityCode = "@citycode";
            internal const string Longitude = "@Longitude";
            internal const string Latitude = "@Latitude";
            internal const string StarRating = "@StarRating";
            internal const string IsActive = "@IsActive";
            internal const string HotelBrandId = "@HotelBrandId";
            internal const string ShortDescription = "@ShortDescription";
            internal const string LongDescription = "@LongDescription";
            internal const string CreatedBy = "@CreatedBy";
            internal const string CreatedDate = "@CreatedDate";
            internal const string UpdatedBy = "@UpdatedBy";
            internal const string UpdatedDate = "@UpdatedDate";
            internal const string CheckInTo = "@CheckInTo";
            internal const string CheckInFrom = "@CheckInFrom";
            internal const string CheckOutTo = "@CheckOutTo";
            internal const string CheckOutFrom = "@CheckOutFrom";
            internal const string Website = "@Website";
            internal const string HotelTypeId = "@HotelTypeId";
            internal const string IsExtranetAccess = "@IsExtranetAccess";
            internal const string IsChannelManagerConnectivity = "@IsChannelManagerConnectivity";
            internal const string ChannelManagerId = "@ChannelManagerId";
            internal const string CountryId = "@CountryId";
            internal const string Address1 = "@Address1";
            internal const string Address2 = "@Address2";
            internal const string ZipCode = "@ZipCode";
            internal const string HotelCode = "@HotelCode";
            internal const string RoomTypeRatePlanList = "@RoomTypeRatePlan";
            internal const string MGPoints = "@MGPoints";
            internal const string HotelId = "@HotelId";
            internal const string TaxTypeId = "@taxTypeId";
            internal const string Amount = "@amount";
            internal const string IsIncludedInRates = "@isIncludedInRates";
            internal const string IsDeleted = "@isDeleted";
            internal const string RoomTypeId = "@RoomTypeId";
            internal const string RoomName = "@RoomName";
            internal const string RoomSize = "@RoomSize";
            internal const string SizeMeasureId = "@SizeMeasureId";
            internal const string NoOfRooms = "@NoOfRooms";
            internal const string IsSmoking = "@IsSmoking";
            internal const string IsFreeSale = "@IsFreeSale";
            internal const string NoOfGuests = "@NoOfGuests";
            internal const string OccupancyId = "@OccupancyId";
            internal const string DescriptionItemId = "@DescriptionItemId";
            internal const string BedId = "@BedId";
            internal const string NoOfBeds = "@NoOfBeds";
            internal const string RoomDescription = "@RoomDescription";
            internal const string NoOfTwinRooms = "@NoOfTwinRooms";
            internal const string NoOfDoubleRooms = "@NoOfDoubleRooms";
            internal const string TaxApplicabilityId = "@taxApplicabilityId";
            internal const string Email = "@Email";
            internal const string Telephone = "@Telephone";
            internal const string LanguageId = "@languageid";
            internal const string TemplateId = "@templateid";
            internal const string IsFacility = "@isfacility";
            internal const string ReservationId = "@ReservationId";
            internal const string RoomId = "@RoomId";
            internal const string ClauseLibraryId = "@clauseLibraryId";
            internal const string FieldId = "@fieldId";
            internal const string IsSelected = "@isSelected";
            internal const string TemplateName = "@TemplateName";
            internal const string IsPublished = "@IsPublished";
            internal const string MarketId = "@marketid";
            internal const string UserType = "@usertype";
        }

        public const string JakartaTimeZone = "SE Asia Standard Time";
        public struct CacheKeys
        {
            public const string CountryList = "CountryList";
            public const string ContinentList = "ContinentList";
            public const string CityList = "CityList";
            public const string LanguageList = "LanguageList";
            public const string RoomTypeList = "RoomTypeList";
            public const string HotelFacilityGroupList = "HotelFacilityGroupList";
            public const string HotelFacilityTypeList = "HotelFacilityTypeList";
            public const string HotelFacilityList = "HotelFacilityList";
            public const string CurrencyList = "CurrencyList";
            public const string MarketList = "MarketList";
            public const string OccupancyList = "OccupancyList";
            public const string SupplierList = "SupplierList";
            public const string HotelTypeList = "HotelTypeList";
            public const string PaymentMethodList = "PaymentMethodList";
            public const string RateTypeList = "RateTypeList";
            public const string TaxTypeList = "TaxTypeList";
            public const string TaxApplicabilityList = "TaxApplicabilityList";
            public const string HotelBrandList = "HotelBrandList";
            public const string HotelList = "HotelList";
            public const string HotelChainList = "HotelChainList";
            public const string DesignationList = "DesignationList";
            public const string HotelBrandExtendedList = "HotelBrandExtendedList";
            public const string MealList = "MealList";
            public const string CuisineTypeList = "CuisineTypeList";
            public const string ChannelManagerList = "ChannelManagerList";
            public const string StarRatingList = "StarRatingList";
            public const string RoomFacilityGroupList = "RoomFacilityGroupList";
            public const string RoomFacilityTypeList = "RoomFacilityTypeList";
            public const string RoomFacilityList = "RoomFacilityList";
            public const string SmokingPolicyList = "SmokingPolicyList";
            public const string SizeMeasureList = "SizeMeasureList";
            public const string BedList = "BedList";
            public const string RoomList = "RoomList";
            public const string MessageTypeList = "MessageTypeList";
            public const string HotelFieldList = "HotelFieldList";
            public const string RoomFieldList = "RoomFieldList";
            public const string HotelNameList = "HotelNameList";
            public const string CancellationPolicyTypeList = "CancellationPolicyTypeList";
            public const string CancellationChargesList = "CancellationChargesList";
            public const string ContractStatusList = "ContractStatusList";
        }
        internal struct ProfileCompletenessConfigurationKeys
        {
            public const string MinPhotosUpload = "Minimum_Photos_Upload";
            public const string AllPhotosHighQuality = "All_Photos_High_Quality";
            public const string AllPhotosTagged = "All_Photos_Tagged";
        }

        internal struct BadRequestErrorMessage
        {
            public const string InvalidRequest = "Input Request is Invalid.";
            public const string InvalidCityRequest = "City Id is not valid.";
            public const string InvalidCountyRequest = "County Id is not valid.";
            public const string InvalidChainRequest = "Chain Id is not valid.";
            public const string InvalidTemplateId= "Template Id is not valid.";
            public const string InvalidReservationId = "Reservation Id is not valid.";
        }
        internal struct ContractStatuses
        {
            public const string Draft = "Draft";
            public const string Accept = "Accept";
            public const string Reject = "Reject";
            public const string Active = "Active";
            public const string Inactive = "Inactive";
            public const string Terminated = "Terminated";
            public const string Freeze = "Freeze";
            public const string Expired = "Expired";
        }

        public const string LanguageIdHeader = "LanguageId";
        public const string AppSettingSection = "AppSettings";
        public const string DocumentStorePathSection = "DocumentStorePath";
    }
}
