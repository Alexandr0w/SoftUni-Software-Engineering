namespace SumOfIntegers
{
    public class Program
    {
        static void Main()
        {
            string[] sequence = Console.ReadLine().Split(" ");
            int sum = 0;

            foreach (var element in sequence)
            {
                int number = 0;
                try
                {
                    number = int.Parse(element);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }

                sum += number;

                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
