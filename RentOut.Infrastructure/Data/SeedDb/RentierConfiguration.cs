using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentOut.Infrastructure.Data.Models;

namespace RentOut.Infrastructure.Data.SeedDb
{
    internal class RentierConfiguration : IEntityTypeConfiguration<Rentier>
    {
        public void Configure(EntityTypeBuilder<Rentier> builder)
        {
            var data = new SeedData();

            builder.HasData(new Rentier[] { data.Rentier });
        }
    }
}
