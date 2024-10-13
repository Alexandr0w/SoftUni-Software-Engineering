namespace LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";
            ProcessLines(inputFilePath, outputFilePath);
        }
        
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader inputFileReader = new StreamReader(inputFileStream);
            using FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            using StreamWriter outputFileWriter = new StreamWriter(outputFileStream);

            int position = 0;
            while (!inputFileReader.EndOfStream)
            {
                string currentLine = inputFileReader.ReadLine();
                outputFileWriter.WriteLine(SanitizeLine(currentLine, ++position));
            }
        }

        private static string SanitizeLine(string text, int position)
        {
            int lettersCount = 0;
            int punctuationsCount = 0;

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    lettersCount++;

                }
                else if (char.IsPunctuation(symbol))
                {
                    punctuationsCount++;
                }
            }

            return $"Line: {position}: {text} ({lettersCount})({punctuationsCount})";
        }
    }
}