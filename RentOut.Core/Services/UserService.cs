using Microsoft.EntityFrameworkCore;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Admin.User;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;
using System.Threading.Tasks.Sources;

namespace RentOut.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Rentier)
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.Rentier != null ? u.Rentier.PhoneNumber : null ,
                    IsRentier = u.Rentier != null
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
