using System.Text;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string result = ProcessExplosions(input);
            Console.WriteLine(result);
        }

        static string ProcessExplosions(string input)
        {
            StringBuilder result = new StringBuilder();

            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    result.Append(input[i]);
                }
                else if (strength == 0)
                {
                    result.Append(input[i]);
                }
                else
                {
                    strength--;
                }
            }

            return result.ToString();
        }
    }
}
