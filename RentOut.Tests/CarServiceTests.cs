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
        private IRepository repo;
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
                new Car() { Id = 3 },
                new Car() { Id = 4 },
                new Car() { Id = 5 },
            }
            .AsQueryable();

            repoMock.Setup(r => r.AllReadOnly<Car>())
                .Returns(cars);
            repo = repoMock.Object;
            carService = new CarService(repo, logger);

            var carCollection = await carService.LastTwoCarsAsync();

            Assert.That(0, Is.EqualTo(carCollection.Count()));
            Assert.That(carCollection.Any(c => c.Id == 1), Is.False);
        }

        [Test]
        public async Task TestAllCategoriesAsync()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repoMock = new Mock<IRepository>();

            IQueryable<Category> categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Coupee" },
            }
            .AsQueryable();

            repoMock.Setup(r => r.AllReadOnly<Category>())
                .Returns(categories);
            repo = repoMock.Object;
            carService = new CarService(repo, logger);

            var carCollection = await carService.AllCategoriesAsync();

            Assert.That(1, Is.EqualTo(carCollection.Count()));
        }

        [Test]
        public async Task TestExistsAsync()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repoMock = new Mock<IRepository>();

            IQueryable<Car> cars = new List<Car>()
            {
                new Car() { Id = 7, Town = "Varna",  ImageUrl = "", Title = "", Description = "" },
                new Car() { Id = 77, Town = "Burgas", ImageUrl = "", Title = "", Description = "" }
            }
            .AsQueryable();


            repoMock.Setup(r => r.AllReadOnly<Car>())
                .Returns(cars);
            repo = repoMock.Object;
            carService = new CarService(repo, logger);

            var result = await carService.ExistsAsync(7);

            Assert.True(result);
        }

        [Test]
        public async Task TestIsRentedByIUserWithIdAsync()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repoMock = new Mock<IRepository>();

            IQueryable<Car> cars = new List<Car>()
            {
                new Car() { Id = 7, Town = "Varna",  ImageUrl = "", Title = "", Description = "" },
                new Car() { Id = 77, Town = "Burgas", ImageUrl = "", Title = "", Description = "" }
            }
            .AsQueryable();


            repoMock.Setup(r => r.AllReadOnly<Car>())
                .Returns(cars);
            repo = repoMock.Object;
            carService = new CarService(repo, logger);

            var result = await carService.IsRentedByIUserWithIdAsync(7, "2");

            Assert.False(result);
        }

        [Test]
        public async Task TestIsRentedAsync()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repoMock = new Mock<IRepository>();

            IQueryable<Car> cars = new List<Car>()
            {
                new Car() { Id = 7, Town = "Varna",  ImageUrl = "", Title = "", Description = "" },
                new Car() { Id = 77, Town = "Burgas", ImageUrl = "", Title = "", Description = "" }
            }
            .AsQueryable();


            repoMock.Setup(r => r.AllReadOnly<Car>())
                .Returns(cars);
            repo = repoMock.Object;
            carService = new CarService(repo, logger);

            var result = await carService.IsRentedAsync(7);

            Assert.False(result);
        }

        [Test]
        public async Task TestAllAsync()
        {
            var loggerMock = new Mock<ILogger<CarService>>();
            logger = loggerMock.Object;
            var repoMock = new Mock<IRepository>();

            IQueryable<Car> cars = new List<Car>()
            {
                new Car() { Id = 1 },
                new Car() { Id = 2 },
                new Car() { Id = 3 },
                new Car() { Id = 4 },
                new Car() { Id = 5 },
            }
            .AsQueryable();

            repoMock.Setup(r => r.AllReadOnly<Car>())
                .Returns(cars);
            repo = repoMock.Object;
            carService = new CarService(repo, logger);

            var carCollection = await carService.LastTwoCarsAsync();

            Assert.That(0, Is.EqualTo(carCollection.Count()));
            Assert.That(carCollection.Any(c => c.Id == 1), Is.False);
        }



        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
