using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentOut.Infrastructure.Data.Models;
using RentOut.Infrastructure.Data.SeedDb;

namespace RentOut.Infrastructure.Data
{
    public class CarRentingDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool _seedDb;
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext>
            options, bool seed = true) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }
            _seedDb = seed;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RentierConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());

            builder
                .Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Car>()
                .HasOne(c => c.Rentier)
                .WithMany()
                .HasForeignKey(c => c.RentierId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Rentier> Rentiers { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } = null!;
    }
}
