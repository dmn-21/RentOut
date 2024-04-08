using Microsoft.AspNetCore.Identity;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public ApplicationUser RentierUser { get; set; }

        public ApplicationUser GuestUser { get; set; }

        public Rentier Rentier { get; set; }

        public Category ElectricCategory { get; set; }

        public Category HybridCategory { get; set; }

        public Category SedanCategory { get; set; }

        public Category CoupeCategory { get; set; }

        public Category WagonCategory { get; set; }

        public Category ConvertibleCategory { get; set; }

        public Category CrossoverCategory { get; set; }

        public Category SUVCategory { get; set; }

        public Category VanCategory { get; set; }

        public Car FirstCar { get; set; }

        public Car SecondCar { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedRentiers();
            SeedCategories();
            SeedCars();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            RentierUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "rentier@mail.com",
                NormalizedUserName = "rentier@mail.com",
                Email = "rentier@mail.com",
                NormalizedEmail = "rentier@mail.com"
            };

            RentierUser.PasswordHash =
                hasher.HashPassword(RentierUser, "rentier123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
                hasher.HashPassword(RentierUser, "guest123");
        }

        private void SeedRentiers()
        {
            Rentier = new Rentier()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = RentierUser.Id
            };
        }
        private void SeedCategories()
        {
            ElectricCategory = new Category()
            {
                Id = 1,
                Name = "Electric"
            };

            HybridCategory = new Category()
            {
                Id = 2,
                Name = "Hybrid"
            };

            SedanCategory = new Category()
            {
                Id = 3,
                Name = "Sedan"
            };

            CoupeCategory = new Category()
            {
                Id = 4,
                Name = "Coupe"
            };

            WagonCategory = new Category()
            {
                Id = 5,
                Name = "Wagon"
            };

            ConvertibleCategory = new Category()
            {
                Id = 6,
                Name = "Convertible"
            };

            CrossoverCategory = new Category()
            {
                Id = 7,
                Name = "Crossover"
            };

            SUVCategory = new Category()
            {
                Id = 8,
                Name = "SUV"
            };

            VanCategory = new Category()
            {
                Id = 9,
                Name = "Van"
            };
        }

        private void SeedCars()
        {
            FirstCar = new Car()
            {
                Id = 1,
                Title = "Mercedes s63",
                Town = "Varna",
                Description = "Sports car. 2018y. At 60_000km. Without any remarks on interior and exterior.",
                ImageUrl = "https://images.ams.bg/images/galleries/92496/razkrivat-mansory-mercedes-amg-s63-coup-black-12_big.jpg",
                PricePerDay = 400.00M,
                CategoryId = CoupeCategory.Id,
                RentierId = Rentier.Id,
                RenterId = GuestUser.Id
            };

            SecondCar = new Car()
            {
                Id = 2,
                Title = "BMW i4",
                Town = "Varna",
                Description = "Electric car. 2021y. At 15_000km. Without any remarks on interior and exterior.",
                ImageUrl = "https://www.bristolstreet.co.uk/custom/101374.png",
                PricePerDay = 400.00M,
                CategoryId = ElectricCategory.Id,
                RentierId = Rentier.Id
            };
        }
    }
}
