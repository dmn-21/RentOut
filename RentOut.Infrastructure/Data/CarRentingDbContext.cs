using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentOut.Infrastructure.Data.Models;
using RentOut.Infrastructure.Data.SeedDb;

namespace RentOut.Infrastructure.Data
{
    public class CarRentingDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RentierConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Rentier> Rentiers { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } = null!;
    }
}
