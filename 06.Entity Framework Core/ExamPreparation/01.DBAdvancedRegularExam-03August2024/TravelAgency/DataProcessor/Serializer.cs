using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            string result = string.Empty;

            var guides = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new ExportGuideDto
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(tpg => new ExportTourPackageDto
                        {
                            Name = tpg.TourPackage.PackageName,
                            Description = tpg.TourPackage.Description!,
                            Price = tpg.TourPackage.Price
                        })
                        .OrderByDescending(tpg => tpg.Price)
                        .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Count())
                .ThenBy(g => g.FullName)
                .ToArray();

            result = XmlHelper.Serialize(guides, "Guides");
            return result;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            string result = string.Empty;

            var customers = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new ExportCustomerDto
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .Select(b => new ExportBookingDto
                        {
                            Date = b.BookingDate.ToString("yyyy-MM-dd"),
                            TourPackageName = b.TourPackage.PackageName
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.Bookings.Count())
                .ThenBy(c => c.FullName)
                .ToArray();

            result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }
    }
}
