namespace _01.CookingMasterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double packageOfFlourPrice = double.Parse(Console.ReadLine());
            double singleEggPrice = double.Parse(Console.ReadLine());
            double singleApronPrice = double.Parse(Console.ReadLine());

            int freePackages = students / 5;

            int apronsNeeded = (int)Math.Ceiling(students * 1.2);

            double totalSum = (singleApronPrice * apronsNeeded) +
                              (singleEggPrice * 10 * students) +
                              (packageOfFlourPrice * (students - freePackages));
            if (budget >= totalSum)
            {
                Console.WriteLine($"Items purchased for {totalSum:F2}$.");
            }
            else
            {
                double neededMoney = Math.Abs(totalSum - budget);
                Console.WriteLine($"{neededMoney:F2}$ more needed.");
            }
        }
    }
}
