using RentOut.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using RentOut.Controllers;

namespace RentOut.Attributes
{
    public class MustBeRentierAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            IRentierService? rentierService = context.HttpContext.RequestServices.GetService<IRentierService>();

            if (rentierService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (rentierService != null &&
                rentierService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(RentierController.Become), "Rentier", null);
            }
        }
    }
}
