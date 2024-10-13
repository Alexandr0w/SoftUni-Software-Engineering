namespace CopyDirectory
{

    public class CopyDirectory
    {
        static void Main()
        {
            // C:\Users\Alexander\Documents\GitHub\SoftUni-Software-Engineering\03.CSharp Advanced\04.Streams,FilesAndDirectories-Exercises\03.CopyBinaryFile
            // C:\Users\Alexander\Documents\GitHub\SoftUni-Software-Engineering\03.CSharp Advanced\04.Streams,FilesAndDirectories-Exercises\05.CopyDirectory\output
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo outputDirectory = new DirectoryInfo(outputPath);

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            outputDirectory.Create();

            DirectoryInfo inputDirectory = new DirectoryInfo(inputPath);

            string[] files = Directory.GetFiles(inputPath);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(outputPath, fileName);
                File.Copy(file, destinationPath);
            }
        }
    }
}
