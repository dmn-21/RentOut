using RentOut.Core.Models.Admin;

namespace RentOut.Core.Contracts
{
    public interface IRentService
    {
        Task<IEnumerable<RentServiceModel>> AllAsync();  
    }
}
