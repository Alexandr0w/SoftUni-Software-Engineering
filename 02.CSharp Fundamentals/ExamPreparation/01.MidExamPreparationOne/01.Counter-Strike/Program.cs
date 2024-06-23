namespace _01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wins = 0;

            string command;
            while ((command = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(command);

                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    break;
                }

                wins++;
                energy -= distance;

                if (wins % 3 == 0)
                {
                    energy += wins;
                }
            }

            if (command == "End of battle")
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
