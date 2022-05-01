using Microsoft.AspNetCore.Mvc;
using Okta_CosmosDb.Models;
using System.Diagnostics;

namespace Okta_CosmosDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if ((User?.Identity?.IsAuthenticated ?? false))
                return RedirectToAction("Index", "Import");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}