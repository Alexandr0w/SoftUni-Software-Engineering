using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string? Color { get; set; }

        public Car(string model, Engine engine, int? weight, string? color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(this.Engine.ToString());
            sb.AppendLine($"  Weight: {this.Weight?.ToString() ?? "n/a"}");
            sb.Append($"  Color: {this.Color ?? "n/a"}");

            return sb.ToString();
        }
    }
}
