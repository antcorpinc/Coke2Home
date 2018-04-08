using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MG.Jarvis.Auth
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name="firstname",
                    UserClaims = { "firstname" }
                },
                new IdentityResource
                {
                    Name="disabled",
                    UserClaims = { "disabled" }
                }
            };
        }        

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
                {
                    new ApiResource
                   {
                       Name="mg.jarvis.api.backoffice",
                       DisplayName="BackOffice Api",
                       Scopes = new List<Scope>()
                       {
                           new Scope("mg.jarvis.api.backoffice")
                       }
                   },

                   new ApiResource
                   {
                       Name="mg.jarvis.api.extranet",
                       DisplayName="Extranet Api",
                       Scopes = new List<Scope>()
                       {
                           new Scope("mg.jarvis.api.extranet")
                       }
                   }
                };
        }
    }   

}
