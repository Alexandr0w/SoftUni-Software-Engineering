using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailBar
{
    public class Menu
    {
        public Menu(int barCapacity)
        {
            this.Cocktails = new List<Cocktail>();
            this.BarCapacity = barCapacity;
        }

        public List<Cocktail> Cocktails { get; set; }
        public int BarCapacity { get; set; }

        public void AddCocktail(Cocktail cocktail)
        {
            if (this.Cocktails.Count >= this.BarCapacity || this.Cocktails.Any(c => c.Name == cocktail.Name)) return;

            this.Cocktails.Add(cocktail);
        }

        public bool RemoveCocktail(string name)
        {
            Cocktail? cocktail = this.Cocktails.SingleOrDefault(c => c.Name == name);
            if (cocktail == null) return false;

            return this.Cocktails.Remove(cocktail);
        }

        public Cocktail? GetMostDiverse()
        {
            return this.Cocktails.OrderByDescending(c => c.Ingredients.Count).FirstOrDefault();
        }

        public string Details(string name)
        {
            var cocktail = Cocktails.FirstOrDefault(c => c.Name == name);
            return cocktail?.ToString();
        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("All Cocktails:");

            sb.Append(string.Join("\n", this.Cocktails.OrderBy(c => c.Name).Select(c => c.Name)));

            return sb.ToString().Trim();
        }
    }
}
