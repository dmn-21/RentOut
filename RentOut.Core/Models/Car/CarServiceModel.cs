using System.ComponentModel.DataAnnotations;
using static RentOut.Core.Constants.MessageConstants;
using static RentOut.Infrastructure.Constants.DataConstants;

namespace RentOut.Core.Models.Car
{
    public class CarServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CarTitleMaxLength,
            MinimumLength = CarTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CarTownMaxLength,
            MinimumLength = CarTownMinLength,
            ErrorMessage = LengthMessage)]
        public string Town { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            CarRentingPriceMin,
            CarRentingPriceMax,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price per day must be a positive number and less than {2} leva")]
        [Display(Name = "Price Per Day")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; }
    }
}
