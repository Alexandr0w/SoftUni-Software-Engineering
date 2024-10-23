using NeedForSpeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsepower, int fuel) : base(horsepower, fuel)
        {
        }

        public override double FuelConsumption { get; } = 10;
    }
}
