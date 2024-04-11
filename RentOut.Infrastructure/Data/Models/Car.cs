using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static RentOut.Infrastructure.Constants.DataConstants;

namespace RentOut.Infrastructure.Data.Models
{
    [Comment("Car to rent")]
    public class Car
    {
        [Key]
        [Comment("Car identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CarTitleMaxLength)]
        [Comment("Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(CarTownMaxLength)]
        [Comment("Car town")]
        public string Town { get; set; } = string.Empty;

        [Required]
        [MaxLength(CarDescriptionMaxLength)]
        [Comment("Car description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Car image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Daily price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerDay { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Rentier identifier")]
        public int RentierId { get; set; }

        [Comment("User id of the renter")]
        public string? RenterId { get; set; }

        [Comment("Is car approved by admin")]
        public bool IsApproved { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [ForeignKey(nameof(RentierId))]
        public Rentier Rentier { get; set; } = null!;

        [ForeignKey(nameof(RenterId))]
        public ApplicationUser? Renter { get; set; }
    }
}
