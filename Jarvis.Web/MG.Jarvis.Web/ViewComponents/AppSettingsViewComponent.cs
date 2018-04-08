using MG.Jarvis.Web.Settings;
using MG.Jarvis.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MG.Jarvis.Web.ViewComponents
{
    public class AppSettingsViewComponent : ViewComponent
    {
        private readonly AppSettings _appSettings;
        public AppSettingsViewComponent(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;           
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
                   
            var idtok = await HttpContext.GetTokenAsync("id_token");
            var accessTok = await HttpContext.GetTokenAsync("access_token");

            var settings = new AppSettingsViewComponentModel()
            {
                
                ApiUrl = _appSettings.BaserUrls.Api,
                AuthUrl = _appSettings.BaserUrls.Auth,
                WebUrl = _appSettings.BaserUrls.Web,
                BackOfficeApiUrl= _appSettings.BaserUrls.BackOfficeApi,
                ExtranetApiUrl = _appSettings.BaserUrls.ExtranetApi,
                UserMgmtApiUrl = _appSettings.BaserUrls.UserMgmtApi,
                //TODO: Remove some of the claims from here
                Name = HttpContext.User.FindFirstValue("name"),
                FirstName = HttpContext.User.FindFirstValue("firstname"),
                AccessToken = accessTok,
                IdToken = idtok,
                SubjectId = HttpContext.User.FindFirstValue("sub"),
                Disabled = HttpContext.User.FindFirstValue("disabled"),
            };
            return View(settings);
        }
    }
}
