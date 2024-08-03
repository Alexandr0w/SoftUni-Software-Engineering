using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"(@|#)(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            List<string> validPairs = new List<string>();
            List<string> mirrorWords = new List<string>();

            foreach (Match match in matches)
            {
                string wordOne = match.Groups["wordOne"].Value;
                string wordTwo = match.Groups["wordTwo"].Value;
                validPairs.Add($"{wordOne} <=> {wordTwo}");

                string reversedWordTwo = new string(wordTwo.Reverse().ToArray());
                if (wordOne == reversedWordTwo)
                {
                    mirrorWords.Add($"{wordOne} <=> {wordTwo}");
                }
            }

            if (validPairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{validPairs.Count} word pairs found!");
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
