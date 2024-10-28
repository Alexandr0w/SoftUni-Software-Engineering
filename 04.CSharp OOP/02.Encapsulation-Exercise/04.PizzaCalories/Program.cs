namespace PizzaCalories
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Pizza pizza = ReadPizza();
                AddToppings(pizza);
                PrintOutput(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Pizza ReadPizza()
        {
            string[] pizzaInfo = Console.ReadLine().Split();
            string[] doughInfo = Console.ReadLine().Split();

            Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

            return new Pizza(pizzaInfo[1], dough);
        }

        private static void AddToppings(Pizza pizza)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split();

                Topping topping = new Topping(data[1], double.Parse(data[2]));
                pizza.AddTopping(topping);

                input = Console.ReadLine();
            }
        }

        private static void PrintOutput(Pizza pizza) => Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
    }
}