namespace RentOut.Tests
{
    using Microsoft.EntityFrameworkCore;
    using RentOut.Core.Contracts;
    using RentOut.Core.Services;
    using RentOut.Infrastructure.Data;
    using static DatabaseSeeder;

    public class RentierServiceTests
    {
        private DbContextOptions<CarRentingDbContext> dbOptions;
        private CarRentingDbContext dbContext;

        private IRentierService rentierService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
                .UseInMemoryDatabase("CarRentingInMemory")
                .Options;
            this.dbContext = new CarRentingDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task RentierExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingRentierUserId = RentierUser.Id.ToString();

            bool result = await this.rentierService.ExistByIdAsync(existingRentierUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task RentierExistsByUserIdAsyncShouldReturnFalseWhenNotExists()
        {
            string existingRentierUserId = RenterUser.Id.ToString();

            bool result = await this.rentierService.ExistByIdAsync(existingRentierUserId);

            Assert.IsFalse(result);
        }
    }
}
