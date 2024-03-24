using RentOut.Core.Models.Car;
using RentOut.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableCarExtension
    {
        public static IQueryable<CarServiceModel> ProjectToCarServiceModel(this IQueryable<Car> cars)
        {
            return cars
                .Select(h => new CarServiceModel()
                {
                    Id = h.Id,
                    Town = h.Town,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerDay = h.PricePerDay,
                    Title = h.Title
                });
        }
    }
}
