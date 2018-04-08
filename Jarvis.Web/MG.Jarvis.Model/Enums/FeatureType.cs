using System;
using System.ComponentModel;

namespace MG.Jarvis.Model.Enums
{
    // public enum FeatureType {

    //   AddUser = 1,
    //   EditUser = 2, 
    //}

    public static class FeatureTypes {

        // Extranet Features from 1 - 1000
        public enum ExtranetFeature
        {
            // Top Level Menu Features for Extranet  Assign 1 - 10 For top level Menus
            ExtranetDashboard=1,
            Contract,
            HotelManagement,
            MasterData,
            Reports,
            
            // Each child level menus will have abucket of 10 items

            // Child Level Menu Features  for Contract  Assign 11 - 20
            ContractDashboard=11,
            Contracts,
            ClauseLibrary,
            Templates,

            // Child Level Menu Features  for HotelManagement  Assign 21 - 30
            HotelProfile=21,
            Reservations,

            // Todo: Add others

            // Each Grand Child will have a bucket of 10(5?) items

        }

        // BackOffice Features from 1001 - 2000
        public enum BackOfficeFeature
        {
            // Top Level Menu Features For BackOffice - Assign 1001 - 1015 For top level Menus
            BackOfficeDashboard = 1001,
            AgencyManagement,
            FinanceManagement,
            ReservationManagement,
            RevenueManagement,
            SupplierManagement,
            UserManagement,
            ToolsManagement,
            ReportsManagement,

            // Todo Add Child Level Menus

            // Each Child Level Menus will have a bucket of 10 items

            // Child Level Menus For Agency -- 1021 - 1030

            // Child Level menus for Finance -- 1031 - 1040

            // Child Level menus for Reservations -- 1041 - 1050

            // Child Level menus for Revenue  -- 1051 - 1060

            // Child Level menus for Suppliers -- 1061 - 1070

            // Child Level Menus for Users -- 1071 - 1080
            MGUser,
            HotelSupplierUser,
            AgentsUser,
            RolesPermissions

            // Child Level Menus for Tools -- 1081 - 1090

            // Child Level Menus For Reports -- Add more for this may be 20 ??
            // 1091 - 1110


        }
    }

}