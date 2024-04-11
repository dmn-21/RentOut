using RentOut.Core.Models.Admin.User;

namespace RentOut.Core.Contracts
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();
    }
}
