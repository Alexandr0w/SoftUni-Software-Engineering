using System.Collections.Immutable;

namespace BorderControl
{
    public class Program
    {
        private static void Main()
        {
            List<IIdentifiable> entities = new List<IIdentifiable>();

            string input = Console.ReadLine()!;
            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 2)
                {
                    Robot robot = new Robot(data[0], data[1]);
                    entities.Add(robot);
                }
                else if (data.Length == 3)
                {   
                    Citizen citizen = new Citizen(data[0], int.Parse(data[1]), data[2]);
                    entities.Add(citizen);
                }

                input = Console.ReadLine()!;
            }

            string fakeSuffix = Console.ReadLine()!;

            foreach (IIdentifiable entity in entities)
            {
                if (entity.Id.EndsWith(fakeSuffix))
                {
                    Console.WriteLine(entity.Id);
                }
            }
        }
    }
}