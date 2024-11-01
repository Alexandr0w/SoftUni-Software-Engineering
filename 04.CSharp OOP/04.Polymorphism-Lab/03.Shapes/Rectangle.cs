using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; }
        public double Height { get; }

        public override double CalculateArea() => this.Height * this.Width;

        public override double CalculatePerimeter() => 2 * (this.Height + this.Width);
        
        public override string Draw() => $"Drawing {GetType().Name}";
    }
}
