using IdentityServer4.AccessTokenValidation;
using MG.Jarvis.Api.Extranet.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {
        #region Public Variables

        #endregion Public Variables
        public BaseController()
        {

        }

        public string LoggedInUserName {
            get {
                string _createdBy = string.Empty;
                if (HttpContext != null && HttpContext.User != null && HttpContext.User.Claims != null)
                {
                    var user = HttpContext.User.Claims.Where(a => a.Type.Equals("username"));
                    if (user != null)
                    {
                        var userName = user.FirstOrDefault();
                        if (userName != null)
                        {
                            _createdBy = userName.Value;
                        }
                    }
                }
                //   var authenticate = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "Bearer");
                //    var authenticateInfo = await HttpContext.Authentication.GetAuthenticateInfoAsync("Bearer");
                //  string accessToken = authenticateInfo.Properties.Items[".Token.access_token"];
                return _createdBy;
            }

        }

        public string LoggedInUserId
        {
            get
            {
                string _createdBy = string.Empty;
                if (HttpContext != null && HttpContext.User != null && HttpContext.User.Claims != null)
                {
                    var user = HttpContext.User.Claims.Where(a => a.Type == "sub");
                    if (user != null)
                    {
                        var userName = user.FirstOrDefault();
                        _createdBy = userName.Value;
                    }
                    //   var authenticate = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "Bearer");
                    //    var authenticateInfo = await HttpContext.Authentication.GetAuthenticateInfoAsync("Bearer");
                    //  string accessToken = authenticateInfo.Properties.Items[".Token.access_token"];
                }
                return _createdBy;
            }

        }
        public int LanguageId
        {
            get
            {
                var languageId = 1;
                if (Request != null)
                {
                    int.TryParse(Request.Headers[Constants.LanguageIdHeader], out languageId);
                }
                return languageId;
            }

        }
        //public string UpdatedBy {
        //    get
        //    {
        //        string _createdBy = string.Empty;
        //        var user = HttpContext.User.Claims.Where(a => a.Type == "username");
        //        if (user != null)
        //        {
        //            var userName = user.FirstOrDefault();
        //            _createdBy = userName.Value;
        //        }
        //        //   var authenticate = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "Bearer");
        //        //    var authenticateInfo = await HttpContext.Authentication.GetAuthenticateInfoAsync("Bearer");
        //        //  string accessToken = authenticateInfo.Properties.Items[".Token.access_token"];
        //        return _createdBy;
        //    }
        //}
    }
}