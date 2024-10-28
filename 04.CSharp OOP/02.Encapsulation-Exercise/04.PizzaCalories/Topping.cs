using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping : Ingredient
    {
        private static readonly Dictionary<string, double> _typeModifiers = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
        {
            ["Meat"] = 1.2,
            ["Veggies"] = 0.8,
            ["Cheese"] = 1.1,
            ["Sauce"] = 0.9
        };

        public Topping(string type, double weightInGrams) : base(weightInGrams)
        {
            if (!_typeModifiers.ContainsKey(type))
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }

            if (weightInGrams < 1 || weightInGrams > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }

            this.Type = type;
        }
        public string Type { get; }

        public override double Calories => base.Calories * _typeModifiers[this.Type];
    }
}
