using VehiclesExtension.Core;
using VehiclesExtension.IO;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.Factories;

namespace VehiclesExtension
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

            VehicleFactory vehicleFactory = new VehicleFactory(); 
            Engine engine = new Engine(reader, writer, vehicleFactory);

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
