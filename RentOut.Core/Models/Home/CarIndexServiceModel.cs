using RentOut.Core.Contracts;

namespace RentOut.Core.Models.Home
{
    public class CarIndexServiceModel : ICarModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Town { get; set; } = string.Empty;
    }
}
