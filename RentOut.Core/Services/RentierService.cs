using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentOut.Core.Contracts;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Core.Services
{
    public class RentierService : IRentierService
    {
        private readonly IRepository repository;

        private readonly ILogger logger;

        public RentierService(
            IRepository _repository,
            ILogger<RentierService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Rentier()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await repository.AllReadOnly<Car>()
                .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Rentier>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Rentier>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetRentierIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Rentier>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
        }
    }
}
