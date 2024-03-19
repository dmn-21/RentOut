using RentOut.Attributes;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RentOut.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;

        private readonly IRentierService rentierService;

        public CarController(
            ICarService _carService,
            IRentierService _rentierService)
        {
            carService = _carService;
            rentierService = _rentierService;

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllCarsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllCarsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new CarDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        [MustBeRentier]
        public async Task<IActionResult> Add()
        {
            var model = new CarFormModel()
            {
                Categories = await carService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeRentier]
        public async Task<IActionResult> Add(CarFormModel model)
        {
            if (await carService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await carService.AllCategoriesAsync();

                return View(model);
            }

            int? rentierId = await rentierService.GetRentierIdAsync(User.Id());

            int newCarId = await carService.CreateAsync(model, rentierId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newCarId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new CarFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new CarDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CarDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
