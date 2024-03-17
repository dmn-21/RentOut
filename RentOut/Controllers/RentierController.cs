using Microsoft.AspNetCore.Mvc;
using RentOut.Core.Models.Rentier;

namespace RentOut.Controllers
{
    public class RentierController : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            var model = new BecomeRentierFormModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeRentierFormModel model)
        {
            return RedirectToAction(nameof(CarController.All), "Car");
        }
    }
}
