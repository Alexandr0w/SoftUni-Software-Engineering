using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, @"([=\/])([A-Z][A-Za-z]{2,})\1");

            List<string> results = new List<string>();

            int charSum = 0;

            foreach (Match match in matches)
            {
                results.Add(match.Groups[2].Value);
                charSum += match.Groups[2].Value.Length;
            }

            Console.WriteLine($"Destinations: {String.Join(", ", results)}");
            Console.WriteLine($"Travel Points: {charSum}");
        }
    }
}
