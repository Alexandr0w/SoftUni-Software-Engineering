namespace _02.Robot_sAdventure
{
    internal class Program
    {
        static void Main()
        {
            int[] grid = Console.ReadLine().Split('|').Select(int.Parse).ToArray();
            int totalItemsCollected = 0;

            string command;
            while ((command = Console.ReadLine()) != "Adventure over")
            {
                if (command.StartsWith("Step Backward") || command.StartsWith("Step Forward"))
                {
                    string[] commandParts = command.Split('$');

                    switch (commandParts[0])
                    {
                        case "Step Backward":
                            int startIndexBackward = int.Parse(commandParts[1]);
                            int stepsBackward = int.Parse(commandParts[2]);

                            if (startIndexBackward >= 0 && startIndexBackward < grid.Length)
                            {
                                int targetIndex = (startIndexBackward - stepsBackward) % grid.Length;
                                if (targetIndex < 0)
                                {
                                    targetIndex += grid.Length;
                                }
                                totalItemsCollected += grid[targetIndex];
                                grid[targetIndex] = 0;
                            }
                            break;

                        case "Step Forward":
                            int startIndexForward = int.Parse(commandParts[1]);
                            int stepsForward = int.Parse(commandParts[2]);

                            if (startIndexForward >= 0 && startIndexForward < grid.Length)
                            {
                                int targetIndex = (startIndexForward + stepsForward) % grid.Length;
                                totalItemsCollected += grid[targetIndex];
                                grid[targetIndex] = 0;
                            }
                            break;
                    }
                }
                else if (command.StartsWith("Double"))
                {
                    string[] commandParts = command.Split(' ');
                    int indexToDouble = int.Parse(commandParts[1]);
                    if (indexToDouble >= 0 && indexToDouble < grid.Length)
                    {
                        grid[indexToDouble] *= 2;
                    }
                }
                else if (command == "Switch")
                {
                    Array.Reverse(grid);
                }
            }

            Console.WriteLine(string.Join(" - ", grid));
            Console.WriteLine($"Robo finished the adventure with {totalItemsCollected} items!");
        }
    }
}
