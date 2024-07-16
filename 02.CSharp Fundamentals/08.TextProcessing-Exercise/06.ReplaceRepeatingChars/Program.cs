using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            if (!string.IsNullOrEmpty(input))
            {
                result = input[0].ToString();

                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i] != input[i - 1])
                    {
                        result += input[i];
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            input.Any(s => s == '+');
            Console.WriteLine(result);
        }
    }
}
