using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.25;

        public override bool Eat(IFood food)
        {
            if (food is not Meat)
            {
                return false;
            }

            return base.Eat(food);
        }

        public override string ProduceSound() => $"Hoot Hoot";
    }
}
