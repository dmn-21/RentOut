using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Home;
using RentOut.Models;
using System.Diagnostics;

namespace RentOut.Controllers
{
    public class HomeController : BaseController
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
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
