using Microsoft.AspNetCore.Mvc;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Admin;
using System.Security.Claims;

namespace RentOut.Areas.Admin.Controllers
{
    public class CarsController : AdminBaseController
    {
        private readonly ICarService carService;

        private readonly IRentierService rentierService;

        public CarsController(
            ICarService _carService,
            IRentierService _rentierService)
        {
            carService = _carService;
            rentierService = _rentierService;
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            int rentiertId = await rentierService.GetRentierIdAsync(userId) ?? 0;
            var myCars = new MyCarsViewModel()
            {   
                AddedCars = await carService.AllCarsByRentierIdAsync(rentiertId),
                RentedCars = await carService.AllCarsByUserId(userId)
            };

            return View(myCars);
        }

        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            var model = await carService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int carId)
        {
            await carService.ApproveCarAsync(carId);

            return RedirectToAction(nameof(Approve));
        }
    }
}
