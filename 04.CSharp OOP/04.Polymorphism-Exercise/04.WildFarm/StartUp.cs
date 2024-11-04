using WildFarm.Core;
using WildFarm.IO;
using WildFarm.Factories;
using WildFarm.IO.Interfaces;

namespace WildFarm
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

            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            Engine engine = new Engine(reader, writer, animalFactory, foodFactory);

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
