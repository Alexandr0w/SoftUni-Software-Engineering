namespace Prototype
{
    public static class Program
    {
        public static void Main()
        {
            string[] veggies = new[] { "Lettuce", "Tomato" };
            Sandwich sandwich = new Sandwich("Wheat", "Bacon", "Cheddar", veggies);

            Sandwich shallowCopy = sandwich.ShallowCopy();
            Sandwich deepCopy = sandwich.DeepCopy();

            veggies[0] = "Cucumber";

            Console.WriteLine($"Original: {sandwich}");
            Console.WriteLine($"Shallow copy: {shallowCopy}");
            Console.WriteLine($"Deep copy: {deepCopy}");
        }
    }
}