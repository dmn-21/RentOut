using RentOut.Core.Enumeration;
using RentOut.Core.Models.Car;
using RentOut.Core.Models.Home;

namespace RentOut.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarIndexServiceModel>> LastTwoCarsAsync();

        Task<IEnumerable<CarCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(CarFormModel model, int rentierId);

        Task<CarQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int carsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<CarServiceModel>> AllCarsByRentierIdAsync(int rentierId);

        Task<IEnumerable<CarServiceModel>> AllCarsByUserId(string userId);

        Task<bool> ExistsAsync(int id);

        Task<CarDetailsServiceModel> CarDetailsByIdAsync(int id);

        Task EditAsync(int carId, CarFormModel model);

        Task<bool> HasRentierWithIdAsync(int carId, string userId);

        Task<CarFormModel?> GetCarFormModelByIdAsync(int id);
    }
}
