using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentOut.Core.Constants.AdministratorConstants;

namespace RentOut.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
