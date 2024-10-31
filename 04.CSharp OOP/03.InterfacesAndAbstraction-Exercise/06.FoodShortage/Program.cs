namespace FoodShortage
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            int n  = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 3)
                {
                    Rebel rebel = new Rebel(data[0], int.Parse(data[1]), data[2]);
                    buyers[rebel.Name] = rebel;
                }
                else if (data.Length == 4)
                {
                    Citizen citizen = new Citizen(data[0], int.Parse(data[1]), data[2], data[3]);
                    buyers[citizen.Name] = citizen;
                }
            }

            string buyerName = Console.ReadLine()!;
            while (buyerName != "End")
            {
                if (buyers.ContainsKey(buyerName))
                {
                    buyers[buyerName].BuyFood();
                }

                buyerName = Console.ReadLine()!;
            }

            Console.WriteLine(buyers.Values.Sum(b => b.Food));
        }
    }
}
