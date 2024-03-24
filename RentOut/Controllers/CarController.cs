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
        public async Task<IActionResult> All([FromQuery] AllCarsQueryModel model)
        {
            var cars = await carService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.CarsPerPage);

            model.TotalCarsCount = cars.TotalCarsCount;
            model.Cars = cars.Cars;
            model.Categories = await carService.AllCategoriesNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<CarServiceModel> model;

            if (await rentierService.ExistByIdAsync(userId))
            {
                int rentierId = await rentierService.GetRentierIdAsync(userId) ?? 0;
                model = await carService.AllCarsByRentierIdAsync(rentierId);
            }
            else
            {
                model = await carService.AllCarsByUserId(userId);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await carService.CarDetailsByIdAsync(id);

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
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await carService.HasRentierWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await carService.GetCarFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarFormModel model)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await carService.HasRentierWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await carService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await carService.AllCategoriesAsync();

                return View(model);
            }

            await carService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
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
