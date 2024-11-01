using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; }

        public override double CalculateArea() => Math.PI * (this.Radius * this.Radius);

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override string Draw() => $"Drawing {GetType().Name}";
    }
}
