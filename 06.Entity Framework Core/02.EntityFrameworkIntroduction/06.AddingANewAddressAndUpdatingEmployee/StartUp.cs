using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext dbContext = new SoftUniContext();
            string result = AddNewAddressToEmployee(dbContext);

            Console.WriteLine(result);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            const string newAddressText = "Vitoshka 15";
            const int newAddressTownId = 4;

            Address newAddress = new Address()
            {
                AddressText = newAddressText,
                TownId = newAddressTownId
            };

            Employee nakovEmployee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov")!;

            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            string[] addresses = context.Employees
                .Where(e => e.AddressId.HasValue)
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address!.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, addresses);
        }
    }
}
