using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailBar
{
    public class Cocktail
    {
        private List<string> _ingredients;

        public Cocktail(string name, decimal price, double volume, string ingredients)
        {
            this.Name = name;
            this.Price = price;
            this.Volume = volume;

            this._ingredients = ingredients.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public double Volume { get; private set; }
        public List<string> Ingredients => this._ingredients;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name}, Price: {this.Price:F2} BGN, Volume: {this.Volume} ml");
            sb.AppendLine($"Ingredients: {string.Join(", ", this.Ingredients)}");

            return sb.ToString().Trim();
        }
    }
}
