namespace EvenLines
{
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        private const string CharactersToReplace = "-,.!?";

        public static string ProcessLines(string filePath)
        {
            using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new StreamReader(fileStream);

            StringBuilder resultBuilder = new StringBuilder();

            bool shouldBeIncluded = true;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (shouldBeIncluded)
                {
                    foreach (char replaceableSymbol in CharactersToReplace)
                    {
                        line = line.Replace(replaceableSymbol, '@');
                    }

                    string[] words = line.Split(" ");
                    Array.Reverse(words);

                    resultBuilder.AppendLine(string.Join(" ", words));
                }

                shouldBeIncluded = !shouldBeIncluded;
            }

            return resultBuilder.ToString();
        }

        private static string SanitizeLine(string text)
        {
            foreach (char specialSymbol in CharactersToReplace)
            {
                text = text = text.Replace(specialSymbol, '@');
            }

            string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);

            return string.Join(" ", words);
        }
    }
}
