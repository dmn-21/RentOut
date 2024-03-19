namespace RentOut.Core.Contracts
{
    public interface IRentierService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

        Task<bool> UserHasRentsAsync(string userId);

        Task CreateAsync(string userId, string phoneNumber);

        Task<int?> GetRentierIdAsync(string userId);
    }
}
