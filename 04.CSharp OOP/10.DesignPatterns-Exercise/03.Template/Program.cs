using Template.Interfaces;

namespace Template
{
    public static class Program
    {
        public static void Main()
        {
            List<IFood> foods = new List<IFood> { new TwelveGrain(), new Sourdough(), new WholeWheat() };

            foreach (IFood food in foods)
            {
                Console.WriteLine(food.PrepareRecipe());
            }
        }
    }
}
