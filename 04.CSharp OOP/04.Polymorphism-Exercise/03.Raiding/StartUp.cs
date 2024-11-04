using Raiding.Core;
using Raiding.IO;
using Raiding.Factories;
using Raiding.IO.Interfaces;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            bool useConsole = true;

            IReader reader;
            IWriter writer;

            if (useConsole)
            {
                reader = new ConsoleReader(); 
                writer = new ConsoleWriter(); 
            }
            else
            {
                string inputFilePath = "../../../input.txt"; 
                string outputFilePath = "../../../output.txt"; 
                reader = new FileReader(inputFilePath); 
                writer = new FileWriter(outputFilePath);
                Console.WriteLine("The result is printed in output.txt file.");
            }

            HeroFactory heroFactory = new HeroFactory(); 
            Engine engine = new Engine(reader, writer, heroFactory);

            try
            {
                engine.Run();
            }
            finally
            {
                if (reader is FileReader fileReader)
                {
                    fileReader.Close(); 
                }

                if (writer is FileWriter fileWriter)
                {
                    fileWriter.Close(); 
                }
            }
        }
    }
}
