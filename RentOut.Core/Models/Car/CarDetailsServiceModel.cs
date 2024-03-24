using RentOut.Core.Models.Rentier;

namespace RentOut.Core.Models.Car
{
    public class CarDetailsServiceModel : CarServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public RentierServiceModel Rentier { get; set; } = null!;
    }
}
