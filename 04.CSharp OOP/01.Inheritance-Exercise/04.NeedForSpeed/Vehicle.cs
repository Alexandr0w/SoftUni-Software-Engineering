using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsepower, int fuel)
        {
            this.HorsePower = horsepower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; }
        public double Fuel { get; private set; }
        public virtual double FuelConsumption { get; } = 1.25;

        public void Drive(double kilometers)
        {
            double necessaryFuel = this.FuelConsumption * kilometers;
            this.Fuel -= necessaryFuel;
        }
    }
}
