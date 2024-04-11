using Microsoft.EntityFrameworkCore;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Admin;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Core.Services
{
    public class RentService : IRentService
    {
        private IRepository repository;

        public RentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<RentServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<Car>()
                .Where(c => c.RenterId != null)
                .Include(c => c.Rentier)
                .Include(c => c.Renter)
                .Select(c => new RentServiceModel()
                {
                    RentierEmail = c.Rentier.User.Email,
                    RentierFullName = $"{c.Rentier.User.FirstName} {c.Rentier.User.LastName}",
                    CarImageUrl = c.ImageUrl,
                    CarTitle = c.Title,
                    RenterEmail = c.Renter != null ? c.Renter.Email : string.Empty,
                    RenterFullName = c.Renter != null ? $"{c.Renter.FirstName} {c.Renter.LastName}" : string.Empty
                })
                .ToListAsync();
        }
    }
}
