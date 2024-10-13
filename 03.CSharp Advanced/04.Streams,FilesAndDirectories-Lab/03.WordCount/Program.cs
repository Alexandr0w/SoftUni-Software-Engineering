namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            {
                string[] words = wordReader.ReadLine().Split();

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];

                    if (!wordCounts.ContainsKey(word))
                    {
                        wordCounts.Add(word, 0);
                    }
                }
            }

            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                string line = textReader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();

                    foreach (var word in wordCounts)
                    {
                        if (line.Contains(word.Key))
                        {
                            wordCounts[word.Key]++;
                        }
                    }

                    line = textReader.ReadLine();
                }
            }

            using (StreamReader writer = new StreamReader(outputFilePath))
            {
                wordCounts = wordCounts.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);

                foreach (var word in wordCounts)
                {
                    Console.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
