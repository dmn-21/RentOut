using RentOut.Core.Contracts;
using System.Net;
using System.Text.RegularExpressions;

namespace RentOut.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICarModel car)
        {
            string info = car.Title.Replace(" ", "-") + GetTown(car.Town);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetTown(string town)
        {
            town = string.Join("-", town.Split(" ").Take(3));

            return town;
        }
    }
}
