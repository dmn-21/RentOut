using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentOut.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
