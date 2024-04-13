using RentOut.Attributes;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using RentOut.Core.Exceptions;
using RentOut.Core.Extensions;
using RentOut.Core.Constants;
using static RentOut.Core.Constants.MessageConstants;

namespace RentOut.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;

        private readonly IRentierService rentierService;

        private readonly ILogger logger;

        public CarController(
            ICarService _carService,
            IRentierService _rentierService,
            ILogger<CarController> _logger)
        {
            carService = _carService;
            rentierService = _rentierService;
            logger = _logger;
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
        public async Task<IActionResult> Mine() //3:05-3:00 fix bugs
        {
            var userId = User.Id();
            IEnumerable<CarServiceModel> model;

            if (User.IsAdmin())
            {
                return RedirectToAction("Mine", "Cars", new { area = "Admin" });
            }

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
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await carService.CarDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

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
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await carService.AllCategoriesAsync();

                return View(model);
            }

            int? rentierId = await rentierService.GetRentierIdAsync(User.Id());

            int newCarId = await carService.CreateAsync(model, rentierId ?? 0);

            TempData[UserMessageSuccess] = "You successfully added a car!";

            return RedirectToAction(nameof(Details), new { id = newCarId, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await carService.HasRentierWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
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

            if (await carService.HasRentierWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
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

            TempData[UserMessageSuccess] = "You successfully edited a car!";

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await carService.HasRentierWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var car = await carService.CarDetailsByIdAsync(id);

            var model = new CarDetailsViewModel()
            {
                Id = id,
                Town = car.Town,
                ImageUrl = car.ImageUrl,
                Title = car.Title
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CarDetailsViewModel model)
        {
            if (await carService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await carService.HasRentierWithIdAsync(model.Id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await carService.DeleteAsync(model.Id);

            TempData[UserMessageSuccess] = "You successfully deleted a car!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await rentierService.ExistByIdAsync(User.Id())
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await carService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            await carService.RentAsync(id, User.Id());

            TempData[UserMessageSuccess] = "You successfully rented a car!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await carService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            try
            {
                await carService.LeaveAsync(id, User.Id());
            }
            catch (UnauthorizedActionException uae)
            {
                logger.LogError(uae, "CarController/Leave");

                return Unauthorized();
            }

            TempData[UserMessageSuccess] = "You successfully left a car!";

            return RedirectToAction(nameof(All));
        }
    }
}
