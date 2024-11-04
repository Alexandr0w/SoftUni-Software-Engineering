using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            // True - for Console, False - for File
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
            }

            IVehicleFactory vehicleFactory = new VehicleFactory(); 
            IEngine engine = new Engine(reader, writer, vehicleFactory);

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
