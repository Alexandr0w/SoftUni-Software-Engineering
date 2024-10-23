using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal DefaultPrice = 3.5m;
        private const double DefaultMilliliters = 50;

        public Coffee(string name, double caffeine) : base(name, DefaultPrice, DefaultMilliliters)
        {
            this.Caffeine = caffeine;   
        }

        public double Caffeine { get; }
    }
}
