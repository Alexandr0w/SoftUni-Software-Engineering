namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string[] arrays = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

            List<int> result = new List<int>();

            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                string[] numbers = arrays[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string number in numbers)
                {
                    result.Add(int.Parse(number));
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
