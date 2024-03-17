using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RentOut.Infrastructure.Constants.DataConstants;

namespace RentOut.Infrastructure.Data.Models
{
    [Comment("Car category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
