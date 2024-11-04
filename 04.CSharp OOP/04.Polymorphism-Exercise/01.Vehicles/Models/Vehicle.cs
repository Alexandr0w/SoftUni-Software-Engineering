using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; private set; }

        public bool Drive(double distance)
        {
            if (FuelQuantity < distance * FuelConsumption)
            {
                return false;
            }

            FuelQuantity -= distance * FuelConsumption;

            return true;
        }

        public virtual void Refuel(double ammount)
        {
            FuelQuantity += ammount;
        }

        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}
