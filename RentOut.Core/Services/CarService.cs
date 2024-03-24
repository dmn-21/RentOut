using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentOut.Core.Contracts;
using RentOut.Core.Enumeration;
using RentOut.Core.Models.Car;
using RentOut.Core.Models.Home;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;
using System.Linq;

namespace RentOut.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repository;

        public CarService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<CarQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int carsPerPage = 1)
        {
            var carToShow = repository.AllReadOnly<Car>();

            if (category != null)
            {
                carToShow = carToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                carToShow = carToShow
                    .Where(h => (h.Title.ToLower().Contains(normalizedSearchTerm) ||
                                h.Town.ToLower().Contains(normalizedSearchTerm) ||
                                h.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            carToShow = sorting switch
            {
                CarSorting.Price => carToShow
                    .OrderBy(h => h.PricePerDay),
                CarSorting.NotRentedFirst => carToShow
                    .OrderBy(h => h.RenterId != null)
                    .ThenByDescending(h => h.Id),
                _ => carToShow
                    .OrderByDescending(h => h.Id)
            };

            var cars = await carToShow
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .ProjectToCarServiceModel()
                .ToListAsync();

            int totalCars = await carToShow.CountAsync();

            return new CarQueryServiceModel()
            {
                Cars = cars,
                TotalCarsCount = totalCars
            };
        }

        public async Task<IEnumerable<CarServiceModel>> AllCarsByRentierIdAsync(int rentierId)
        {
            return await repository.AllReadOnly<Car>()
                .Where(h => h.RentierId == rentierId)
                .ProjectToCarServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<CarServiceModel>> AllCarsByUserId(string userId)
        {
            return await repository.AllReadOnly<Car>()
                .Where(h => h.RenterId == userId)
                .ProjectToCarServiceModel()
                .ToListAsync();
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

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
               .Select(c => c.Name)
               .Distinct()
               .ToListAsync();
        }

        public async Task<CarDetailsServiceModel> CarDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Car>()
                .Where(h => h.Id == id)
                .Select(h => new CarDetailsServiceModel()
                {
                    Id = h.Id,
                    Town = h.Town,
                    Rentier = new Models.Rentier.RentierServiceModel()
                    {
                        Email = h.Rentier.User.Email,
                        PhoneNumber = h.Rentier.PhoneNumber,
                    },
                    Category = h.Category.Name,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerDay = h.PricePerDay,
                    Title = h.Title
                })
                .FirstAsync();
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

        public async Task EditAsync(int carId, CarFormModel model)
        {
            var car = await repository.GetByIdAsync<Car>(carId);

            if (car != null)
            {
                car.Town = model.Town;
                car.CategoryId = model.CategoryId;
                car.Description = model.Description;
                car.ImageUrl = model.ImageUrl;
                car.PricePerDay = model.PricePerDay;
                car.Title = model.Title;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Car>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<CarFormModel?> GetCarFormModelByIdAsync(int id)
        {
            var car = await repository.AllReadOnly<Car>()
                .Where(h => h.Id == id)
                .Select(h => new CarFormModel()
                {
                    Town = h.Town,
                    CategoryId = h.CategoryId,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerDay = h.PricePerDay,
                    Title = h.Title
                })
                .FirstOrDefaultAsync();

            if (car != null)
            {
                car.Categories = await AllCategoriesAsync();
            }

            return car;
        }

        public async Task<bool> HasRentierWithIdAsync(int carId, string userId)
        {
            return await repository.AllReadOnly<Car>()
                .AnyAsync(h => h.Id == carId && h.Rentier.UserId == userId);
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
