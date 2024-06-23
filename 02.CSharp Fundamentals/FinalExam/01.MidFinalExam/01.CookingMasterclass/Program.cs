namespace _01.CookingMasterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double PackageOfFlourPrice = double.Parse(Console.ReadLine());
            double SingleEggPrice = double.Parse(Console.ReadLine());
            double SingleApronPrice = double.Parse(Console.ReadLine());

            int freePackages = students / 5;

            int apronsNeeded = (int)Math.Ceiling(students * 1.2);

            double totalSum = (SingleApronPrice * apronsNeeded) +
                              (SingleEggPrice * 10 * students) +
                              (PackageOfFlourPrice * (students - freePackages));
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
