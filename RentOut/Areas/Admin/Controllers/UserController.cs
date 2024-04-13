using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Admin.User;
using static RentOut.Core.Constants.AdministratorConstants;

namespace RentOut.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(
            IUserService _userService,
            IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }

        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

            if (model == null || model.Any() == false)
            {
                model = await userService.AllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                memoryCache.Set(UsersCacheKey, model, cacheOptions);
            }

            return View(model);
        }
    }
}
