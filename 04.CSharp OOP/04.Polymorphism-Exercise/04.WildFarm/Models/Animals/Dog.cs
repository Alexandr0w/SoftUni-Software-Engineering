using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.40;

        public override bool Eat(IFood food)
        {
            if (food is not Meat)
            {
                return false;
            }

            return base.Eat(food);
        }

        public override string ProduceSound() => $"Woof!";

        public override string ToString() => base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
