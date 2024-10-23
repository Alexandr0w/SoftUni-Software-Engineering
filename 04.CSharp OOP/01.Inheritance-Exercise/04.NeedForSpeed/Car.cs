using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsepower, int fuel) : base(horsepower, fuel)
        {
        }

        public override double FuelConsumption { get; } = 3;
    }
}
