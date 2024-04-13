using Microsoft.AspNetCore.Mvc;
using RentOut.Core.Contracts;
using RentOut.Core.Services;

namespace RentOut.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly ICarService carService;

        public HomeController(
            ICarService _carService)
        {
            carService = _carService;
        }

        public IActionResult DashBoard()
        {
            return View();
        }

        public async Task<IActionResult> ForReview()
        {
            return View();
        }
    }
}
