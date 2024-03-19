using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentOut.Core.Contracts;
using System.Security.Claims;

namespace RentOut.Attributes
{
    public class NotAnRentierAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IRentierService? rentierService = context.HttpContext.RequestServices.GetService<IRentierService>();

            if (rentierService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (rentierService != null &&
                rentierService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
