using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Okta.AspNetCore;

namespace Okta_CosmosDb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if (!(HttpContext.User?.Identity?.IsAuthenticated ?? false))
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Index", "Import");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return new SignOutResult(new[] { OktaDefaults.MvcAuthenticationScheme,
                                         CookieAuthenticationDefaults.AuthenticationScheme });
        }
    }
}
