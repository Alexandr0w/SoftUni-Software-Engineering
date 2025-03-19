using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportCustomerDto[]? customerDtos = XmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, "Customers");

            if (customerDtos != null)
            {
                ICollection<Customer> dbCustomers = new List<Customer>();
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (ExistInDb(customerDto, dbCustomers))
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer customer = new Customer
                    {
                        FullName = customerDto.FullName,
                        Email = customerDto.Email,
                        PhoneNumber = customerDto.PhoneNumber
                    };

                    dbCustomers.Add(customer);
                    sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
                }

                context.Customers.AddRange(dbCustomers);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportBookingDto[]? bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            if (bookingDtos != null)
            {
                ICollection<Booking> dbBookings = new List<Booking>();
                foreach (ImportBookingDto bookingDto in bookingDtos)
                {
                    bool isDateValid = DateTime
                        .TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, 
                                                                            DateTimeStyles.None, out DateTime date);

                    if (!IsValid(bookingDto) || !isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var customer = context.Customers
                        .FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                    var tourPackage = context.TourPackages
                        .FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);

                    if (customer != null || tourPackage != null)
                    {
                        Booking booking = new Booking
                        {
                            BookingDate = date,
                            Customer = customer!,
                            TourPackage = tourPackage!
                        };

                        dbBookings.Add(booking);
                        sb.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDto.BookingDate));
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                context.Bookings.AddRange(dbBookings);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool ExistInDb(ImportCustomerDto customerDto, ICollection<Customer> dbCustomers)
        {
            bool result = dbCustomers.Any(c => c.FullName == customerDto.FullName) ||
                          dbCustomers.Any(c => c.Email == customerDto.Email) ||
                          dbCustomers.Any(c => c.PhoneNumber == customerDto.PhoneNumber);

            return result;
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage!;
            }

            return isValid;
        }
    }
}
