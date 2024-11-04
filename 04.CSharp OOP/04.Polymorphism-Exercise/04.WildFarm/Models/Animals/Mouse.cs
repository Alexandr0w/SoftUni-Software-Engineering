using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.10;

        public override bool Eat(IFood food)
        {
            if (food is not Vegetable and not Fruit)
            {
                return false;
            }

            return base.Eat(food);
        }

        public override string ProduceSound() => $"Squeak";

        public override string ToString() => base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
