using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RentOut.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOut.Infrastructure.Data.SeedDb
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[] { 
            data.CoupeCategory, data.VanCategory, data.SedanCategory,
            data.WagonCategory, data.SUVCategory, data.CrossoverCategory, 
            data.ElectricCategory, data.ConvertibleCategory, data.HybridCategory});
        }
    }
}
