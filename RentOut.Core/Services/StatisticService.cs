using Microsoft.EntityFrameworkCore;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Statistics;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalCars = await repository.AllReadOnly<Car>()
                .Where(c => c.IsApproved)
                .CountAsync();

            int totalRents = await repository.AllReadOnly<Car>()
                .Where(h => h.RenterId != null)
                .CountAsync();

            return new StatisticServiceModel()
            {
                TotalCars = totalCars,
                TotalRents = totalRents
            };
        }
    }
}
