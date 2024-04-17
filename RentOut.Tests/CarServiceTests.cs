using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using RentOut.Core.Contracts;
using RentOut.Core.Models.Car;
using RentOut.Core.Services;
using RentOut.Infrastructure.Data;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Tests
{

    [TestFixture]
    public class CarServiceTests
    {
        private ILogger<CarService> logger;
        private ICarService carService;
        private CarRentingDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
                .UseInMemoryDatabase("RentOutB")
                .Options;

            dbContext = new CarRentingDbContext(contextOptions);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task CarExistsById()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repository = new Repository(dbContext);
            carService = new CarService(repository, logger);

            await repository.AddAsync(new Car()
            {
                Id = 7,
                Town = "",
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repository.SaveChangesAsync();

            var dbCar = await repository.GetByIdAsync<Car>(7);

            Assert.That(dbCar.Id, Is.EqualTo(7));
        }

        [Test]
        public async Task TestCarEditAsync()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repository = new Repository(dbContext);
            carService = new CarService(repository, logger);

            await repository.AddAsync(new Car()
            {
                Id = 7,
                Town = "",
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repository.SaveChangesAsync();

            await carService.EditAsync(7, new CarFormModel()
            {
                Town = "",
                ImageUrl = "",
                Title = "",
                Description = "This car is edited",
            });

            var dbCar = await repository.GetByIdAsync<Car>(7);

            Assert.That(dbCar.Description, Is.EqualTo("This car is edited"));
            Assert.That(dbCar.Id, Is.EqualTo(7));
        }

        [Test]
        public async Task TestLastTwoCarsInMemory()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repository = new Repository(dbContext);
            carService = new CarService(repository, logger);

            await repository.AddAsync(new Car()
            {
                Id = 22,
                Town = "",
                ImageUrl = "",
                Title = "",
                Description = ""
            });
            await repository.AddAsync(new Car()
            {
                Id = 33,
                Town = "",
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repository.SaveChangesAsync();
            var carCollection = await carService.LastTwoCarsAsync();

            Assert.That(0, Is.EqualTo(carCollection.Count()));
            Assert.That(carCollection.Any(c => c.Id == 33), Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
