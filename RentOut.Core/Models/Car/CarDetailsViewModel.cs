using RentOut.Core.Contracts;

namespace RentOut.Core.Models.Car
{
    public class CarDetailsViewModel : ICarModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Town { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
