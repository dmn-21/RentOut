using Microsoft.AspNetCore.Mvc;
using RentOut.Attributes;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Rentier;
using System.Security.Claims;
using static RentOut.Core.Constants.MessageConstants;

namespace RentOut.Controllers
{
    public class RentierController : BaseController
    {
        private readonly IRentierService rentierService;

        public RentierController(IRentierService _rentierService)
        {
            rentierService = _rentierService;
        }

        [HttpGet]
        [NotAnRentier]
        public IActionResult Become()
        {
            var model = new BecomeRentierFormModel();

            return View(model);
        }

        [HttpPost]
        [NotAnRentier]
        public async Task<IActionResult> Become(BecomeRentierFormModel model)
        {
            if (await rentierService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if (await rentierService.UserHasRentsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasRents);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await rentierService.CreateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(CarController.All), "Car");
        }
    }
}
