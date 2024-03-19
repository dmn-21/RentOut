using Microsoft.EntityFrameworkCore;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Car;
using RentOut.Core.Models.Home;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repository;

        public CarService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<CarCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new CarCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(CarFormModel model, int rentierId)
        {
            Car car = new Car()
            {
                Town = model.Town,
                RentierId = rentierId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerDay = model.PricePerDay,
                Title = model.Title
            };

            await repository.AddAsync(car);
            await repository.SaveChangesAsync();

            return car.Id;
        }

        public async Task<IEnumerable<CarIndexServiceModel>> LastTwoCarsAsync()
        {
            return await repository
                .AllReadOnly<Car>()
                .OrderByDescending(h => h.Id)
                .Take(2)
                .Select(h => new CarIndexServiceModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                })
                .ToListAsync();
        }
    }
}
