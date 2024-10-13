using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] allFiles = directoryInfo.GetFiles();

            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();

            foreach (FileInfo file in allFiles)
            {
                if (!filesByExtension.ContainsKey(file.Extension))
                {
                    filesByExtension[file.Extension] = new List<FileInfo>();
                }

                filesByExtension[file.Extension].Add(file);
            }

            StringBuilder resultBuilder = new StringBuilder();
            foreach (var (extension, relatedFiles) in filesByExtension.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                resultBuilder.AppendLine($"{extension}");

                foreach (FileInfo file in relatedFiles.OrderByDescending(x => x.Length))
                {
                    double size = file.Length / 1024.0;
                    resultBuilder.AppendLine($"--{file.Name} - {size}kb");
                }
            }

            return resultBuilder.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, reportFileName);

            File.WriteAllText(desktopPath, textContent);
        }
    }
}