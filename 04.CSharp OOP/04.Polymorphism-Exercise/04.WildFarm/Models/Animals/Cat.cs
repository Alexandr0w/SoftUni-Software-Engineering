using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.30;

        public override bool Eat(IFood food)
        {
            if (food is not Vegetable and not Meat)
            {
                return false;
            }

            return base.Eat(food);
        }

        public override string ProduceSound() => $"Meow";
    }
}
