namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            byte y = byte.Parse(Console.ReadLine());

            ulong pokeCount = 0;
            double percent = n * 0.50d;

            while (n >= m)
            {
                pokeCount++;
                n -= m;
                if (percent == n && y != 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(pokeCount);
        }
    }
}
