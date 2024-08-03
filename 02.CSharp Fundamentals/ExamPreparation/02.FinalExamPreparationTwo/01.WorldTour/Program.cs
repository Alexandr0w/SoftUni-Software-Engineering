namespace _01.WorldTour
{
    internal class Program
    {
        static void Main()
        {
            string stops = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Travel")
                {
                    break;
                }

                string[] commandParts = command.Split(':');
                string commandType = commandParts[0];

                switch (commandType)
                {
                    case "Add Stop":
                        int addIndex = int.Parse(commandParts[1]);
                        string addString = commandParts[2];

                        if (addIndex >= 0 && addIndex <= stops.Length)
                        {
                            stops = stops.Insert(addIndex, addString);
                        }

                        Console.WriteLine(stops);
                        break;

                    case "Remove Stop":
                        int startIndex = int.Parse(commandParts[1]);
                        int endIndex = int.Parse(commandParts[2]);

                        if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length &&
                            startIndex <= endIndex)
                        {
                            stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                        }

                        Console.WriteLine(stops);
                        break;

                    case "Switch":
                        string oldString = commandParts[1];
                        string newString = commandParts[2];

                        if (stops.Contains(oldString))
                        {
                            stops = stops.Replace(oldString, newString);
                        }

                        Console.WriteLine(stops);
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
