using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public virtual bool Eat(IFood food)
        {
            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;

            return true;
        }

        public abstract string ProduceSound();

        public override string ToString() => $"{this.GetType().Name} [{this.Name}, ";
    }
}
