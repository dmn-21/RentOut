using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;
using RentOut.Core.Contracts;
using RentOut.Core.Services;
using RentOut.Infrastructure.Data;
using RentOut.Infrastructure.Data.Common;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Tests
{
    [TestFixture]
    public class RentierServiceTests
    {
        private ILogger<RentierService> logger;
        private CarRentingDbContext dbContext;
        private DbContextOptions<CarRentingDbContext> dbOptions;
        private IRepository repository;
        private IRentierService rentierService;

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
        public async Task RentierExistsById()
        {
            var loggerMock = new Mock<ILogger<RentierService>>();
            logger = loggerMock.Object;
            var repository = new Repository(dbContext);
            rentierService = new RentierService(repository, logger);

            await repository.AddAsync(new Rentier()
            {
                Id = 7,
                PhoneNumber = "",
                UserId = "",
            });

            await repository.SaveChangesAsync();

            var dbRentier = await repository.GetByIdAsync<Rentier>(7);

            Assert.That(dbRentier.Id, Is.EqualTo(7));
        }

        [Test]
        public async Task RentierCreateAsyncWithPhoneNumber()
        {
            var loggerMock = new Mock<ILogger<RentierService>>();
            logger = loggerMock.Object;
            var repository = new Repository(dbContext);
            rentierService = new RentierService(repository, logger);

            await repository.AddAsync(new Rentier()
            {
                Id = 7,
                PhoneNumber = "0888888888",
                UserId = "",
            });

            await repository.SaveChangesAsync();

            var dbRentier = await repository.GetByIdAsync<Rentier>(7);

            Assert.That(dbRentier.PhoneNumber, Is.EqualTo("0888888888"));
        }

        [Test]
        public async Task RentierCreateAsyncWithUserId()
        {
            var loggerMock = new Mock<ILogger<RentierService>>();
            logger = loggerMock.Object;
            var repository = new Repository(dbContext);
            rentierService = new RentierService(repository, logger);

            await repository.AddAsync(new Rentier()
            {
                Id = 7,
                PhoneNumber = "",
                UserId = "4",
            });

            await repository.SaveChangesAsync();

            var dbRentier = await repository.GetByIdAsync<Rentier>(7);

            Assert.That(dbRentier.UserId, Is.EqualTo("4"));
        }

        [Test]
        public async Task RentierExistsByUserIdAsyncShouldReturnFalseWhenExists()
        {
            var loggerMock = new Mock<ILogger<RentierService>>();
            logger = loggerMock.Object;
            var repository = new Repository(dbContext);
            rentierService = new RentierService(repository, logger);

            await repository.AddAsync(new Rentier()
            {
                Id = 7,
                PhoneNumber = "",
                UserId = "",
            });

            await repository.SaveChangesAsync();

            bool result = await this.rentierService.ExistByIdAsync("7");

            Assert.False(result);
        }
    }
}
