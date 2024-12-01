using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System.Text;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private readonly IDealership _dealership = new Dealership();

        public string AddCustomer(string customerTypeName, string customerName)
        {
            ICustomer customer;

            if (customerTypeName == nameof(IndividualClient)) customer = new IndividualClient(customerName);
            else if (customerTypeName == nameof(LegalEntityCustomer)) customer = new LegalEntityCustomer(customerName);
            else return String.Format(OutputMessages.InvalidType, customerTypeName);

            if (this._dealership.Customers.Exists(customerName)) return String.Format(OutputMessages.CustomerAlreadyAdded, customerName);

            this._dealership.Customers.Add(customer);

            return String.Format(OutputMessages.CustomerAddedSuccessfully, customerName);

        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            IVehicle vehicle;

            if (vehicleTypeName == nameof(SaloonCar)) vehicle = new SaloonCar(model, price);
            else if (vehicleTypeName == nameof(SUV)) vehicle = new SUV(model, price);
            else if (vehicleTypeName == nameof(Truck)) vehicle = new Truck(model, price);
            else return String.Format(OutputMessages.InvalidType, vehicleTypeName);

            if (this._dealership.Vehicles.Exists(model)) return String.Format(OutputMessages.VehicleAlreadyAdded, model);

            this._dealership.Vehicles.Add(vehicle);

            return String.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, vehicle.Price);
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            ICustomer customer = this._dealership.Customers.Get(customerName);

            if (customer == null) return String.Format(OutputMessages.CustomerNotFound, customerName);

            IVehicle[] candidateVehicle = this._dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName)
                .ToArray();

            if (candidateVehicle.Length == 0) return String.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);

            if (!PurchaseIsEligible(customer, vehicleTypeName)) return String.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
            
            IVehicle? vehicleToBuy = candidateVehicle
                .Where(v => v.Price <= budget)
                .OrderByDescending(v => v.Price)
                .FirstOrDefault();

            if (vehicleToBuy is null) return String.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);

            customer.BuyVehicle(vehicleToBuy.Model);
            vehicleToBuy.SellVehicle(customer.Name);

            return String.Format(OutputMessages.VehiclePurchasedSuccessfully, customer.Name, vehicleToBuy.Model);
        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Customer Report:");

            foreach (ICustomer customer in this._dealership.Customers.Models.OrderBy(c => c.Name))
            {
                sb.AppendLine();
                sb.AppendLine(customer.ToString());
                sb.Append("-Models:");

                IEnumerable<string> purchases;
                if (customer.Purchases.Count == 0) purchases = new[] { "none" };
                else purchases = customer.Purchases.OrderBy(p => p);

                foreach (string model in purchases)
                {
                    sb.AppendLine();
                    sb.Append($"--{model}");
                }
            }

            return sb.ToString();
        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{vehicleTypeName} Sales Report:");

            int totalSales = 0;

            foreach (IVehicle vehicle in this._dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName)
                .OrderBy(v => v.Model))
            {
                sb.AppendLine($"--{vehicle}");
                totalSales += vehicle.SalesCount;
            }

            sb.Append($"-Total Purchases: {totalSales}");

            return sb.ToString();
        }

        private static bool PurchaseIsEligible(ICustomer customer, string vehicleTypeName)
        {
            if (customer is IndividualClient) return vehicleTypeName == nameof(SaloonCar) || vehicleTypeName == nameof(SUV);
            if (customer is LegalEntityCustomer) return vehicleTypeName == nameof(SUV) || vehicleTypeName == nameof(Truck);

            return false;
        }
    }
}
