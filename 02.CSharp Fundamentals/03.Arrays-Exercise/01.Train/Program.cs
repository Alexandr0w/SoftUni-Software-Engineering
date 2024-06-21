namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] arr = new int[numberOfWagons];
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());

                arr[i] = numberOfPeople;
                sum += numberOfPeople;
            }

            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(sum);
        }
    }
}
