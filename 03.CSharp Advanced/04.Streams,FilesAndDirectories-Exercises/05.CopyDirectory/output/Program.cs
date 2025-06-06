﻿using System.Buffers;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            //File.Copy(inputFilePath, outputFilePath);

            using FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

            byte[] buffer = ArrayPool<byte>.Shared.Rent(1024);

            int readBytes;
            do
            {
                readBytes = inputFileStream.Read(buffer);
                outputFileStream.Write(buffer, 0, readBytes);
            } 
            while (readBytes != 0);

            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
