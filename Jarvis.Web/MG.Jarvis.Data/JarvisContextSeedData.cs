using MG.Jarvis.Model;
using MG.Jarvis.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Data
{
   public class JarvisContextSeedData
    {
        private JarvisContext _context;
        private UserManager<JarvisUser> _userManager;
        private RoleManager<JarvisRole> _roleManager;

        public JarvisContextSeedData(JarvisContext context,
            UserManager<JarvisUser> userManager, RoleManager<JarvisRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {

            // Adding Roles 
            // For now add MGIT role -- Has access to all applications except Manage Users 

            if (await _roleManager.FindByNameAsync("MGIT") == null)
            {
                var role = new JarvisRole()
                {
                    Id = new Guid("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    Name = "MGIT",

                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted =false
                };

                var result1 = await _roleManager.CreateAsync(role);

                if (!result1.Succeeded) throw new InvalidProgramException("Failed to create seed role");
            }

            if (await _roleManager.FindByNameAsync("HOTELADMIN") == null)
            {
                var role = new JarvisRole()
                {
                    Id = new Guid("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    Name = "HOTELADMIN",

                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };

                var result1 = await _roleManager.CreateAsync(role);

                if (!result1.Succeeded) throw new InvalidProgramException("Failed to create seed role");
            }

            // Adding Users
            //Adding Users 
            // For now add the MGIT User and Hotel Admin
            if (await _userManager.FindByNameAsync("MGITUser") == null)
            {
                var user = new JarvisUser()
                {
                    Id = new Guid("7430DD69-3F53-4471-A621-E1E3BB582D45"),
                    Disabled = false,
                    Email = "ronit@cybage.com",
                    FirstName = "Peter",
                    IsSuperUser = false,
                    LastName = "Clark",
                    PhoneNumber = "214-529-2634",
                    UserName = "MGITUser",
                    UserType = UserType.MG,
                    IsDeleted =false,
                };
                await _userManager.CreateAsync(user, "Cybage@123");
            }

         

            if (await _userManager.FindByNameAsync("HotelAdmin") == null)
            {
                var user = new JarvisUser()
                {
                    Id = new Guid("55772CD4-3FB6-448A-BA98-A0AF35613F8A"),
                    Disabled = false,
                    Email = "ronit@cybage.com",
                    FirstName = "Lord",
                    IsSuperUser = false,
                    LastName = "Meer",
                    PhoneNumber = "214-529-2634",
                    UserName = "HotelAdmin",
                    UserType = UserType.Hotel,
                    IsDeleted = false,
                };
                await _userManager.CreateAsync(user, "Cybage@123");
            }

              

            // Adding Applications
            // For now add Extranet and Back Office application
            if (_context.Application.Find(Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717")) == null)
            {
                Application extranet = new Application()
                {
                    Id = new Guid("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    Name = "Extranet",
                    Description = "Application for Hotel Management",
                    IsDeleted=false
                };
                _context.Add(extranet);

            }

            if (_context.Application.Find(Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97")) == null)
            {
                Application backoffice = new Application()
                {
                    Id = new Guid("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    Name = "BackOffice",
                    Description = "Application User Management",
                    IsDeleted = false
                };
                _context.Add(backoffice);
            }

            // Add  Feature List - Starting with the Extranet Features
            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.ExtranetDashboard) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.ExtranetDashboard,
                    TypeName = "ExtranetDashboard",
                    Description = "Dashboard",
                    Order = 1,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.Contract) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.Contract,
                    TypeName = "Contract",
                    Description = "Contract",
                    Order = 2,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false

                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.HotelManagement) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.HotelManagement,
                    TypeName = "HotelManagement",
                    Description = "HotelManagement",
                    Order = 3,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.MasterData) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.MasterData,
                    TypeName = "MasterData",
                    Description = "MasterData",
                    Order = 4,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.Reports) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.Reports,
                    TypeName = "Reports",
                    Description = "Reports",
                    Order = 5,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }


            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.ContractDashboard) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.ContractDashboard,
                    ParentFeatureId = (int)FeatureTypes.ExtranetFeature.Contract,
                    TypeName = "ContractDashboard",
                    Description = "Dashboard",
                    Order = 1,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.Contracts) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.Contracts,
                    ParentFeatureId = (int)FeatureTypes.ExtranetFeature.Contract,
                    TypeName = "Contracts",
                    Description = "Contracts",
                    Order = 2,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.ClauseLibrary) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.ClauseLibrary,
                    ParentFeatureId = (int)FeatureTypes.ExtranetFeature.Contract,
                    TypeName = "ClauseLibrary",
                    Description = "ClauseLibrary",
                    Order = 3,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.Templates) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.Templates,
                    ParentFeatureId = (int)FeatureTypes.ExtranetFeature.Contract,
                    TypeName = "Templates",
                    Description = "Templates",
                    Order = 4,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.HotelProfile) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.HotelProfile,
                    ParentFeatureId = (int)FeatureTypes.ExtranetFeature.HotelManagement,
                    TypeName = "HotelProfile",
                    Description = "HotelProfile",
                    Order = 1,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.ExtranetFeature.Reservations) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.ExtranetFeature.Reservations,
                    ParentFeatureId = (int)FeatureTypes.ExtranetFeature.HotelManagement,
                    TypeName = "Reservations",
                    Description = "Reservations",
                    Order = 2,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }


            // Add  Feature List - Starting with the BackOffice Features

            if (_context.FeatureType.Find((int)FeatureTypes.BackOfficeFeature.BackOfficeDashboard) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.BackOfficeDashboard,
                    TypeName = "BackOfficeDashboard",
                    Description = "Dashboard",
                    Order = 1,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.BackOfficeFeature.AgencyManagement) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.AgencyManagement,
                    TypeName = "AgencyManagement",
                    Description = "AgencyManagement",
                    Order = 2,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }


            if (_context.FeatureType.Find((int)FeatureTypes.BackOfficeFeature.SupplierManagement) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.SupplierManagement,
                    TypeName = "SupplierManagement",
                    Description = "SupplierManagement",
                    Order = 3,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            if (_context.FeatureType.Find((int)FeatureTypes.BackOfficeFeature.UserManagement) == null)
            {
                FeatureType feature = new FeatureType()
                {
                    Id = (int)FeatureTypes.BackOfficeFeature.UserManagement,
                    TypeName = "UserManagement",
                    Description = "UserManagement",
                    Order = 4,
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(feature);
            }

            // Map FeatureType to Privilege for a Role MGIT
            // Top Level Extranet Features

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("10EC1E87-4328-4AD6-A573-C84EE8999580")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("10EC1E87-4328-4AD6-A573-C84EE8999580"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ExtranetDashboard,
                    Privileges = "VW",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("CB26E629-52F8-429A-A495-81593BFD64A3")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("CB26E629-52F8-429A-A495-81593BFD64A3"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Contract,
                    Privileges = "",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("376B18FC-2373-4294-BA91-0A68B04DD89B")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("376B18FC-2373-4294-BA91-0A68B04DD89B"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.HotelManagement,
                    Privileges = "",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            ////  ToDO: Add the Masters and Reports for this Role later

            //// Sub Features of Extranet - Contract and Hotel -- Todo - Need to add others

            // Contract Sub Features

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("5226C8C9-B550-4EC1-8796-90D30BFBDE60")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("5226C8C9-B550-4EC1-8796-90D30BFBDE60"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ContractDashboard,
                    Privileges = "VW",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }
            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("9E033E3B-E1B0-493C-B53D-E990AE8B34FD")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("9E033E3B-E1B0-493C-B53D-E990AE8B34FD"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Contracts,
                    Privileges = "VW|CR|AP",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }
            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("3117703C-8E87-40F5-945F-B8F281092A37")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("3117703C-8E87-40F5-945F-B8F281092A37"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ClauseLibrary,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("FEF3886B-7A49-4E58-A1CB-EFE36B73CEF8")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("FEF3886B-7A49-4E58-A1CB-EFE36B73CEF8"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Templates,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            // HOtelMgmt Sub Features
            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("E5F43C69-4281-4DBB-8657-7FDBACFBD59C")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("E5F43C69-4281-4DBB-8657-7FDBACFBD59C"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.HotelProfile,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("65E25330-A653-4806-A0E1-BEAE4023105C")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("65E25330-A653-4806-A0E1-BEAE4023105C"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Reservations,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }



            // Extranet Fearures for Hotel Admin

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("95DCFF18-017F-4214-A088-57632C5E58C0")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("95DCFF18-017F-4214-A088-57632C5E58C0"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ExtranetDashboard,
                    Privileges = "VW",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("6DD10434-F1E0-47E6-A9DB-540C1E7CD0E5")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("6DD10434-F1E0-47E6-A9DB-540C1E7CD0E5"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Contract,
                    Privileges = "",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("DD32AE4C-F434-40C5-8970-BC609978A3DA")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("DD32AE4C-F434-40C5-8970-BC609978A3DA"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.HotelManagement,
                    Privileges = "",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }

            ////  ToDO: Add the Masters and Reports for this Role later

            //// Sub Features of Extranet - Contract and Hotel -- Todo - Need to add others

            // Contract Sub Features

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("98A970EA-8E68-47E1-8ABC-A28F5A125586")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("98A970EA-8E68-47E1-8ABC-A28F5A125586"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ContractDashboard,
                    Privileges = "VW",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }
            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("E5193C20-7D32-49F6-A82E-5354098DB6E0")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("E5193C20-7D32-49F6-A82E-5354098DB6E0"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Contracts,
                    Privileges = "VW|CR|AP",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }
            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("5AACDFBD-A424-42AB-8D6B-18F507B4C119")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("5AACDFBD-A424-42AB-8D6B-18F507B4C119"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ClauseLibrary,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("DD058000-7861-4F37-87CF-A6CC437BFB6F")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("DD058000-7861-4F37-87CF-A6CC437BFB6F"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Templates,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }

            // HOtelMgmt Sub Features
            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("7DEAD56E-9979-44D4-9102-D5E0BD9BFC17")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("7DEAD56E-9979-44D4-9102-D5E0BD9BFC17"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.HotelProfile,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("25BB3260-73B0-47ED-97DD-1ECF553667CA")) == null)
            {
                FeatureTypeRolePrivilege hotelAdmin = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("25BB3260-73B0-47ED-97DD-1ECF553667CA"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Reservations,
                    Privileges = "VW|CR",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(hotelAdmin);
            }




            // ~ Extranet Features for Hotel Admin
            // Back Office features

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("84CB52F8-4EBC-4E24-8260-EFBA6E883B2E")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("84CB52F8-4EBC-4E24-8260-EFBA6E883B2E"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.BackOfficeFeature.BackOfficeDashboard,
                    Privileges = "VW",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            if (_context.FeatureTypeRolePrivilege.Find(Guid.Parse("2F0762E5-D975-41DC-9449-02C4A29846C6")) == null)
            {
                FeatureTypeRolePrivilege mgit = new FeatureTypeRolePrivilege()
                {
                    Id = new Guid("2F0762E5-D975-41DC-9449-02C4A29846C6"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    FeatureTypeId = (int)FeatureTypes.BackOfficeFeature.AgencyManagement,
                    Privileges = "",
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false
                };
                _context.Add(mgit);
            }

            // Add to   UserRoleMapping -- MGITUSER to BackOffice & Extranet

            if (_context.UserAppRoleMapping.Find(Guid.Parse("061B3DDA-593A-48B9-9018-FAF023265D65")) == null)
            {
                UserAppRoleMapping userapprole = new UserAppRoleMapping()
                {
                    Id = new Guid("061B3DDA-593A-48B9-9018-FAF023265D65"),
                    UserId = Guid.Parse("7430DD69-3F53-4471-A621-E1E3BB582D45"),
                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false

                };
                _context.Add(userapprole);
            }

            if (_context.UserAppRoleMapping.Find(Guid.Parse("4A002A10-1214-429E-A03E-75200B7F4DF6")) == null)
            {
                UserAppRoleMapping userapprole = new UserAppRoleMapping()
                {
                    Id = new Guid("4A002A10-1214-429E-A03E-75200B7F4DF6"),
                    UserId = Guid.Parse("7430DD69-3F53-4471-A621-E1E3BB582D45"),
                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    RoleId = Guid.Parse("B3411B31-45E8-44F6-BAFB-B65AE7948187"),
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false

                };
                _context.Add(userapprole);
            }

            // Add to   UserRoleMapping -- HotelAdmin to BackOffice & Extranet

            if (_context.UserAppRoleMapping.Find(Guid.Parse("5B258FA9-2676-4EE0-805D-FEE3E19BF551")) == null)
            {
                UserAppRoleMapping userapprole = new UserAppRoleMapping()
                {
                    Id = new Guid("5B258FA9-2676-4EE0-805D-FEE3E19BF551"),
                    UserId = Guid.Parse("55772CD4-3FB6-448A-BA98-A0AF35613F8A"),
                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    RoleId = Guid.Parse("84A02A58-AC68-4F45-8284-68561E9A36F6"),
                    CreatedBy = "SystemAdmin",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedBy = "SystemAdmin",
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false

                };
                _context.Add(userapprole);
            }


            // ~ Add to   UserRoleMapping -- HotelAdmin to BackOffice & Extranet


            // Adding Application Features
            // Adding Extranet Features
            if (_context.ApplicationFeature.Find(Guid.Parse("C5AFB341-C5B9-4A73-A0B9-C3BB97AF32CC")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("C5AFB341-C5B9-4A73-A0B9-C3BB97AF32CC"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ExtranetDashboard,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("FC2CC9D4-FF01-47C2-A012-08C069066303")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("FC2CC9D4-FF01-47C2-A012-08C069066303"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Contract,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("727CB4D0-F2DC-4323-8A32-26A7E46ADAD8")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("727CB4D0-F2DC-4323-8A32-26A7E46ADAD8"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.HotelManagement,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("85F5387E-1388-4D88-B8E4-00332CFC76E5")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("85F5387E-1388-4D88-B8E4-00332CFC76E5"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.MasterData,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("4F8AC249-026E-4D88-BAA3-FD6029A9B9EF")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("4F8AC249-026E-4D88-BAA3-FD6029A9B9EF"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Reports,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("2F56F68A-51DF-4584-9791-33D8F2270A3C")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("2F56F68A-51DF-4584-9791-33D8F2270A3C"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ContractDashboard,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("798DFE59-BE8A-4F46-B3CE-0EE330B6B207")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("798DFE59-BE8A-4F46-B3CE-0EE330B6B207"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Contracts,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("5E5A4C8C-6E6C-4826-80C0-B787C9C13DB7")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("5E5A4C8C-6E6C-4826-80C0-B787C9C13DB7"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.ClauseLibrary,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("82183EE1-889B-4667-8735-9EEB63501751")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("82183EE1-889B-4667-8735-9EEB63501751"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Templates,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("924A226A-70A5-4146-9C0C-0E670E955377")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("924A226A-70A5-4146-9C0C-0E670E955377"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.HotelProfile,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("A691616A-CC15-4F7F-B8E8-EFAD54613D08")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("A691616A-CC15-4F7F-B8E8-EFAD54613D08"),

                    ApplicationId = Guid.Parse("FED2D832-10AC-4F3A-BD2D-9026A465C717"),
                    FeatureTypeId = (int)FeatureTypes.ExtranetFeature.Reservations,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            // Add BackOffice Features
            if (_context.ApplicationFeature.Find(Guid.Parse("841C65FE-073D-4AD0-A84B-3327C0FFD5BE")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("841C65FE-073D-4AD0-A84B-3327C0FFD5BE"),

                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureTypeId = (int)FeatureTypes.BackOfficeFeature.BackOfficeDashboard,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("C706F10B-18BE-4E54-AE9F-4C14C5E0EC2D")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("C706F10B-18BE-4E54-AE9F-4C14C5E0EC2D"),

                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureTypeId = (int)FeatureTypes.BackOfficeFeature.AgencyManagement,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("91A22F7B-A21D-45E8-AFB0-034B24ED45E9")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("91A22F7B-A21D-45E8-AFB0-034B24ED45E9"),

                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureTypeId = (int)FeatureTypes.BackOfficeFeature.SupplierManagement,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }

            if (_context.ApplicationFeature.Find(Guid.Parse("15A56A1B-F9BF-4C50-B230-B0F0D513AE46")) == null)
            {
                ApplicationFeature appfeature = new ApplicationFeature()
                {
                    Id = new Guid("15A56A1B-F9BF-4C50-B230-B0F0D513AE46"),

                    ApplicationId = Guid.Parse("C2FA60FF-4B56-42B5-B6D3-08BA2AFA7D97"),
                    FeatureTypeId = (int)FeatureTypes.BackOfficeFeature.UserManagement,
                    IsDeleted = false
                };
                _context.Add(appfeature);
            }


            _context.SaveChanges();


        }
    }
}
