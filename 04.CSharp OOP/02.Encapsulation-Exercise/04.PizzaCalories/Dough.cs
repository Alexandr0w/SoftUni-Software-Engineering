using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough : Ingredient
    {
        private readonly static Dictionary<string, double> _flourTypeModifiers = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
        {
            ["White"] = 1.5,
            ["Wholegrain"] = 1
        };

        private readonly static Dictionary<string, double> _bakingTechniqueModifiers = new Dictionary<string, double>(StringComparer.InvariantCultureIgnoreCase)
        {
            ["Crispy"] = 0.9,
            ["Chewy"] = 1.1,
            ["Homemade"] = 1
        };

        public Dough(string flourType, string bakingTechnique, double weightInGrams) : base(weightInGrams)
        {
            if (!_flourTypeModifiers.ContainsKey(flourType) || !_bakingTechniqueModifiers.ContainsKey(bakingTechnique))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            if (weightInGrams < 1 || weightInGrams > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
        }

        public string FlourType { get; }
        public string BakingTechnique { get; }

        public override double Calories => base.Calories * _flourTypeModifiers[this.FlourType] * _bakingTechniqueModifiers[this.BakingTechnique];
    }
}
