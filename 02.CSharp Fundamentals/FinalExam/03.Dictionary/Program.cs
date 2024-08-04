/*
programmer: an animal, which turns coffee into code | developer: a magician
fish | domino
Hand Over
 */
namespace _03.Dictionary
{
    internal class Program
    {
        static void Main()
        {
            string[] wordDefinitions = Console.ReadLine().Split(" | ");
            Dictionary<string, List<string>> notebook = new Dictionary<string, List<string>>();

            foreach (var entry in wordDefinitions)
            {
                string[] wordAndDefinition = entry.Split(": ");

                if (wordAndDefinition.Length == 2)
                {
                    string word = wordAndDefinition[0];
                    string definition = wordAndDefinition[1];

                    if (!notebook.ContainsKey(word))
                    {
                        notebook[word] = new List<string>();
                    }

                    notebook[word].Add(definition);
                }
            }

            string[] wordsToTest = Console.ReadLine().Split(" | ");

            string command = Console.ReadLine();

            if (command == "Test")
            {
                foreach (string word in wordsToTest)
                {
                    if (notebook.ContainsKey(word))
                    {
                        Console.WriteLine($"{word}:");
                        foreach (var definition in notebook[word])
                        {
                            Console.WriteLine($" -{definition}");
                        }
                    }
                }
            }
            else if (command == "Hand Over")
            {
                Console.WriteLine(string.Join(" ", notebook.Keys));
            }
        }
    }
}
