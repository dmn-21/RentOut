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
        private IRepository repository;
        private ILogger<CarService> logger;
        private ICarService carService;
        private CarRentingDbContext carRentingDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
                .UseInMemoryDatabase("RentOutDb")
                .Options;

            carRentingDbContext = new CarRentingDbContext(contextOptions);

            carRentingDbContext.Database.EnsureDeleted();
            carRentingDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestCarEdit()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repository = new Repository(carRentingDbContext);
            carService = new CarService(repository, logger);

            await repository.AddAsync(new Car()
            {
                Id = 1,
                Town = "",
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repository.SaveChangesAsync();

            await carService.EditAsync(1, new CarFormModel()
            {
                Town = "",
                ImageUrl = "",
                Title = "",
                Description = "Sports car. 2018y. At 60_000km. Without any remarks on interior and exterior.",
            });

            var dbCar = await repository.GetByIdAsync<Car>(1);

            Assert.That(dbCar.Description, Is.EqualTo("Sports car. 2018y. At 60_000km. Without any remarks on interior and exterior."));
        }

        [Test]
        public async Task TestLastTwoCarsInMemory()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repository = new Repository(carRentingDbContext);
            carService = new CarService(repository, logger);

            await repository.AddAsync(new List<Car>()
            {
                new Car() { Id = 1, Town = "", ImageUrl = "", Title = "", Description = "" },
                new Car() { Id = 2, Town = "", ImageUrl = "", Title = "", Description = "" },
                new Car() { Id = 1010, Town = "", ImageUrl = "", Title = "", Description = "" }
            });

            await repository.SaveChangesAsync();
            var carCollection = await carService.LastTwoCarsAsync();

            Assert.That(3, Is.EqualTo(carCollection.Count()));
            Assert.That(carCollection.Any(c => c.Id == 1), Is.False);
        }

        [Test]
        public async Task TestLastTwoCarsNumberAndOrder()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repoMock = new Mock<IRepository>();
            IQueryable<Car> cars = new List<Car>()
            {
                new Car() { Id = 1 },
                new Car() { Id = 2 },
                new Car() { Id = 1010 }
            }.AsQueryable();
            repoMock.Setup(r => r.AllReadOnly<Car>())
                .Returns(cars);
            repository = repoMock.Object;
            carService = new CarService(repository, logger);

            var carCollection = await carService.LastTwoCarsAsync();

            Assert.That(0, Is.EqualTo(carCollection.Count()));
            Assert.That(carCollection.Any(c => c.Id == 1), Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            carRentingDbContext.Dispose();
        }
    }
}
