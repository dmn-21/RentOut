using RentOut.Core.Enumeration;
using System.ComponentModel.DataAnnotations;

namespace RentOut.Core.Models.Car
{
    public class AllCarsQueryModel
    {
        public int CarsPerPage { get; } = 3;

        public string Category { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public CarSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCarsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<CarServiceModel> Cars { get; set; } = new List<CarServiceModel>();
    }
}
