using RentOut.Infrastructure.Data;
using RentOut.Infrastructure.Data.Models;
namespace RentOut.Tests
{
    public static class DatabaseSeeder
    {
        public static ApplicationUser RentierUser;
        public static ApplicationUser RenterUser;
        public static Rentier Rentier;

        public static void SeedDatabase(CarRentingDbContext dbContext)
        {
            RentierUser = new ApplicationUser()
            {
                Id = "77777",
                UserName = "rentier@mail.com",
                NormalizedUserName = "rentier@mail.com",
                Email = "rentier@mail.com",
                NormalizedEmail = "rentier@mail.com",
                EmailConfirmed = false,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
                FirstName = "Rentier",
                LastName = "Rentierov"
            };
            RenterUser = new ApplicationUser()
            {
                Id = "777",
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "8d969eaf6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
                SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
                TwoFactorEnabled = false,
                FirstName = "Guest",
                LastName = "Guestov"
            };
            Rentier = new Rentier()
            {
                PhoneNumber = "+359888888888",
                User = RentierUser
            };

            dbContext.Users.Add(RentierUser);
            dbContext.Users.Add(RenterUser);
            dbContext.Rentiers.Add(Rentier);

            dbContext.SaveChanges();
        }
    }
}
