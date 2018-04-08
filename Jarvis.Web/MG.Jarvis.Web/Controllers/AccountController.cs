

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using IdentityModel.Client;
using MG.Jarvis.Web.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace MG.Jarvis.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AppSettings _appSettings;

        public AccountController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

         public async Task<IActionResult> RefreshTokens()
        {
            var client = new DiscoveryClient(_appSettings.BaserUrls.Auth);
            // For Testing require https false REfer BCu
            client.Policy.RequireHttps = false;
            // var disco = await DiscoveryClient.GetAsync(_appSettings.BaserUrls.Auth);
            var disco = await client.GetAsync();                
            if (disco.IsError) throw new Exception(disco.Error);

            var tokenClient = new TokenClient(disco.TokenEndpoint,
             _appSettings.IdentityClient.ClientId,
             _appSettings.IdentityClient.ClientSecret);
            var rt = await HttpContext.GetTokenAsync("refresh_token");
            var tokenResult = await tokenClient.RequestRefreshTokenAsync(rt);

            if (!tokenResult.IsError)
            {
                var old_id_token = await HttpContext.GetTokenAsync("id_token");
                var new_access_token = tokenResult.AccessToken;
                var new_refresh_token = tokenResult.RefreshToken;

                var tokens = new List<AuthenticationToken>();
                tokens.Add(new AuthenticationToken { Name = OpenIdConnectParameterNames.IdToken, Value = old_id_token });
                tokens.Add(new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = new_access_token });
                tokens.Add(new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = new_refresh_token });

                var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResult.ExpiresIn);
                tokens.Add(new AuthenticationToken { Name = "expires_at", Value = expiresAt.ToString("o", CultureInfo.InvariantCulture) });

                var info = await HttpContext.AuthenticateAsync("Cookies");
                info.Properties.StoreTokens(tokens);
                await HttpContext.SignInAsync("Cookies", info.Principal, info.Properties);

                return Json(new
                {
                    access_token = new_access_token
                });
            }
            return Json(tokenResult.Error);
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }
    }
}