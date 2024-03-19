using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Home;
using RentOut.Models;
using System.Diagnostics;

namespace RentOut.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;

        public HomeController(
            ILogger<HomeController> logger,
            ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await _carService.LastTwoCarsAsync();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
