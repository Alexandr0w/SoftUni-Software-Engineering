namespace _02.RecursiveFactorial
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }

        static long Factorial(int n)
        {
            if (n <= 0)
            {
                return 1;
            }

            long fact = n * Factorial(n - 1);

            return fact;
        }
    }
}