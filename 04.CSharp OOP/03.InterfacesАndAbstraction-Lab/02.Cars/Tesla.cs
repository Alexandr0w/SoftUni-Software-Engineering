using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : BaseCar, ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery) : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; }

        protected override string Describe() => $"{base.Describe()} with {this.Battery} Batteries";
    }
}
