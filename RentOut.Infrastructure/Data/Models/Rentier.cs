using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static RentOut.Infrastructure.Constants.DataConstants;

namespace RentOut.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Car Rentier")]
    public class Rentier
    {
        [Key]
        [Comment("Rentier identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(RentierPhoneMaxLength)]
        [Comment("Rentier's phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
