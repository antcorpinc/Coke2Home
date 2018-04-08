using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.AccessTokenValidation;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MG.Jarvis.Api.Controllers
{
   // [Authorize]
    public class TestController : Controller
    {
        // https://github.com/IdentityServer/IdentityServer4.AccessTokenValidation/issues/72

        // GET: /<controller>/
        [Route("test")]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult Get()
        {
            var claims = User.Claims.Select(x => $"{x.Type}:{x.Value}");
            return Ok(new
            {
                message="Hello MVC Core Api",
                claims = claims.ToArray()
            });

          //  return Ok("Hello World");

        }
    }
}
