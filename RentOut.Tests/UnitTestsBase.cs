using AutoMapper;
using Moq;
using RentOut.Infrastructure.Data;
using RentOut.Infrastructure.Data.Models;
using RentOut.Tests.Mocks;
namespace RentOut.Tests
{
    public class UnitTestsBase
    {
        protected CarRentingDbContext _data;
        protected IMapper _mapper;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            _data = DatabaseMock.Instance;
            SeedDatabase();
        }

        public ApplicationUser Renter { get; private set; }

        public Rentier Rentier { get; private set; }

        public Car RentedCar { get; private set; }

        private void SeedDatabase()
        {
            Renter = new ApplicationUser()
            {
                Id = "RenterUserId",
                Email = "rent@er.bg",
                FirstName = "Renter",
                LastName = "User"
            };
            _data.Users.Add(Renter);
            Rentier = new Rentier()
            {
                PhoneNumber = "0888888888",
                User = new ApplicationUser()
                {
                    Id = "TestUserId",
                    Email = "test@test.bg",
                    FirstName = "Test",
                    LastName = "Tester"
                }
            };
            _data.Rentiers.Add(Rentier);

            RentedCar = new Car()
            {
                Title = "First Test Car",
                Town = "Test, 201 Test",
                Description = "This is a test description. This is a test description. This is a test description.",
                ImageUrl = "https://images.ams.bg/images/galleries/92496/razkrivat-mansory-mercedes-amg-s63-coup-black-12_big.jpg",
                Renter = Renter,
                Rentier = Rentier,
                Category = new Category() { Name = "Coupe" }
            };
            _data.Cars.Add(RentedCar);


            var nonRentedCar = new Car()
            {
                Title = "Second Test Car",
                Town = "Test, 204 Test",
                Description = "This is another test description. This is another test description. This is another test description.",
                ImageUrl = "https://www.bristolstreet.co.uk/custom/101374.png",
                Renter = Renter,
                Rentier = Rentier,
                Category = new Category() { Name = "Electric" }
            };
            _data.Cars.Add(nonRentedCar);
            _data.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase() => _data.Dispose();
    }
}
