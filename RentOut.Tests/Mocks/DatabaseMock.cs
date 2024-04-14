using Microsoft.EntityFrameworkCore;
using RentOut.Infrastructure.Data;

namespace RentOut.Tests.Mocks
{
    public class DatabaseMock
    {
        public static CarRentingDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
                    .UseInMemoryDatabase("RentOutDb"
                    + DateTime.Now.Ticks.ToString())
                    .Options;

                return new CarRentingDbContext(dbContextOptions, false);
            }
        }
    }
}
