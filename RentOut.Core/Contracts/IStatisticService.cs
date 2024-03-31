using RentOut.Core.Models.Statistics;

namespace RentOut.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
