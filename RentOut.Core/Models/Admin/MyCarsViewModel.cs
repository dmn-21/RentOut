using RentOut.Core.Models.Car;

namespace RentOut.Core.Models.Admin
{
    public class MyCarsViewModel
    {
        public IEnumerable<CarServiceModel> AddedCars { get; set; } = new List<CarServiceModel>();

        public IEnumerable<CarServiceModel> RentedCars { get; set; } = new List<CarServiceModel>();
    }
}
