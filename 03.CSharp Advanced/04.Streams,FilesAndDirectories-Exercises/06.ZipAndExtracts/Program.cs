using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            string fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);

            string inputFileName = Path.GetFileName(inputFilePath);
            archive.CreateEntryFromFile(inputFilePath, inputFileName);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath);
            ZipArchiveEntry? entry = archive.GetEntry(fileName);

            if (entry is not null)
            {
                entry.ExtractToFile(outputFilePath);
            }
        }
    }
}
