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
    }
}
