using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Infrastructure.Data.SeedDb
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(h => h.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Rentier)
                .WithMany(a => a.Cars)
                .HasForeignKey(h => h.RentierId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Car[] { data.SecondCar, data.FirstCar });
        }
    }
}
