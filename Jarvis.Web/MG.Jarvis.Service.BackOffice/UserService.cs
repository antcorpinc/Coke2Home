using MG.Jarvis.Service.BackOffice.Contracts;
using System;
using MG.Jarvis.Model.DTOs;
using MG.Jarvis.Data.Contracts;
using System.Collections.Generic;

namespace MG.Jarvis.Service.BackOffice
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, 
            IRoleRepository roleRepository
        )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;                     
        }

        public bool ActiveUsersByDate(DateTime activationDate)
        {
            try
            {
                _userRepository.ExecuteStoredProcedure("ActivateUsersByDate @p0", new object[] { activationDate.ToShortDateString() });
                return true;
            }
            catch(Exception ex)
            {
                //todo: Log exception
                return false;
            }
          
        }

       

        public bool DeactiveUsersByDate(DateTime activationDate)
        {
            try
            {
                _userRepository.ExecuteStoredProcedure("DeactivateUsersByDate @p0", new object[] { activationDate.ToShortDateString() });
                return true;
            }
            catch(Exception ex)
            {
                //todo: Log exception
                return false;
            }
            
        }

        public UserDetails GetUserDetails(Guid id)
        {            
            var jarvisUser = _userRepository.Get(id);
            // ToDO: Add with validation - Need a View Model -- UserDetailsViewModel....
            var userDetails = new UserDetails()
            {
                Id = jarvisUser.Id,
                Email = jarvisUser.Email,
                UserName = jarvisUser.UserName,
                Disabled = jarvisUser.Disabled,
                UserType = jarvisUser.UserType,
                IsSuperUser = jarvisUser.IsSuperUser,
                FirstName = jarvisUser.FirstName,
                LastName = jarvisUser.LastName
            };
            // Todo:If Super User then no need to check the below
            var applicationPermissions = new List<ApplicationPermission>();
            foreach (var userAppRole in jarvisUser.UserAppRoleMappings)
            {
                    // Use this Join roleDetails -- It has all required details
                var roleDetails = _roleRepository.GetRelatedPrivilegesForRoleAndApp(userAppRole.RoleId,
                    userAppRole.ApplicationId);               
                if (roleDetails.Count > 0)
                {
                    var applicationPermission = new ApplicationPermission();
                    applicationPermission.Id = userAppRole.ApplicationId;
                    applicationPermission.Name = roleDetails[0].ApplicationName;
                    applicationPermission.RoleId = userAppRole.Role.Id;
                    applicationPermission.Role = roleDetails[0].RoleName;

                    Dictionary<int, FeaturePermission> featurePermissions = new Dictionary<int, FeaturePermission>();
                    foreach (var roleDetail in roleDetails)
                    {
                        FeaturePermission featurePermission = new FeaturePermission();
                        featurePermission.FeatureTypeId = roleDetail.FeatureTypeId;
                        featurePermission.TypeName = roleDetail.FeatureTypeName;
                        featurePermission.Label = roleDetail.FeatureLabel;
                        featurePermission.ParentFeatureId = roleDetail.ParentFeatureId;
                        featurePermission.Order = roleDetail.Order;
                        featurePermission.Privileges = roleDetail.Privileges;

                        // Todo: May be no need to add the Dictionary -- The below array should be OK
                        applicationPermission.FeaturePermissions.Add(featurePermission.FeatureTypeId, featurePermission);

                        // Added if we need the fearures as an array
                        applicationPermission.FeaturesList.Add(featurePermission);
                    }

                    applicationPermissions.Add(applicationPermission);
                }
            }
            userDetails.ApplicationPermissions = applicationPermissions;
            return userDetails;
        }
    }
}
