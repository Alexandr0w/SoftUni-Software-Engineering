namespace _03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> greaterThanAverageNumbers = new List<int>();
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            double average = sum / (double)numbers.Length;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > average)
                {
                    greaterThanAverageNumbers.Add(numbers[i]);
                }
            }
            greaterThanAverageNumbers.Sort();
            greaterThanAverageNumbers.Reverse();

            if (greaterThanAverageNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                int count = greaterThanAverageNumbers.Count > 5 ? 5 : greaterThanAverageNumbers.Count;
                Console.WriteLine(string.Join(" ", greaterThanAverageNumbers.Take(count)));
            }
        }
    }
}