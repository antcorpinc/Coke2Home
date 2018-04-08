using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace MG.Jarvis.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            //return Challenge(new AuthenticationProperties { RedirectUri = "Home/Authenticated" });
            var claims = User.Claims;
             return View();
        }

        [Authorize]
        public IActionResult Authenticated()
        {
            return View();

        }
    }
}