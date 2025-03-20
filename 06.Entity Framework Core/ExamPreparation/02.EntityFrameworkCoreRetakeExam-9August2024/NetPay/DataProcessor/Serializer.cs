using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            string result = string.Empty;

            var households = context.Households
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .Select(h => new
                {
                    h.ContactPerson,
                    h.Email,
                    h.PhoneNumber,
                    UnpaidExpences = h.Expenses
                    .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                        .Select(e => new
                        {
                            e.ExpenseName,
                            e.Amount,
                            e.DueDate,
                            e.Service.ServiceName
                        })
                        .OrderBy(e => e.DueDate)
                        .ToList()
                })
                .OrderBy(h => h.ContactPerson)
                .ToArray();

            var householdResult = households
                .Select(h => new ExportHouseholdDto
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email!,
                    PhoneNumber = h.PhoneNumber,
                    UnpaidExpenses = h.UnpaidExpences
                        .Select(e => new ExportExpenseDto
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("F2"),
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                            ServiceName = e.ServiceName
                        })
                        .OrderBy(e => e.PaymentDate)
                        .ThenBy(e => e.Amount)
                        .ToArray()
                })
                .OrderBy(h => h.ContactPerson)
                .ToArray();

            result = XmlHelper.Serialize(householdResult, "Households");
            return result;
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            string result = string.Empty;

            var services = context.Services
                .Select(s => new
                {
                    s.ServiceName,
                    Suppliers = s.SuppliersServices
                        .Select(ss => new
                        {
                            ss.Supplier.SupplierName
                        })
                        .OrderBy(s => s.SupplierName)
                        .ToArray()
                })
                .OrderBy(s => s.ServiceName)
                .ToArray();

            result = JsonConvert.SerializeObject(services, Formatting.Indented);
            return result;
        }
    }
}
