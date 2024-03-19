using System.ComponentModel.DataAnnotations;
using static RentOut.Core.Constants.MessageConstants;
using static RentOut.Infrastructure.Constants.DataConstants;

namespace RentOut.Core.Models.Rentier
{
    public class BecomeRentierFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RentierPhoneMaxLength,
            MinimumLength = RentierPhoneMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}