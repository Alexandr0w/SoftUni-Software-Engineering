namespace WildSurvival
{
    public class Program
    {
        public static void Main()
        {
            Queue<int> bees = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> beeEaters = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (bees.Count > 0 && beeEaters.Count > 0)
            {
                int defenders = bees.Dequeue();
                int attackers = beeEaters.Pop();

                int attackingCapacity = attackers * 7;

                if (attackingCapacity > defenders)
                {
                    int survivors = attackers - defenders / 7;

                    if (beeEaters.Count > 0)
                    {
                        int additive = beeEaters.Pop();
                        beeEaters.Push(additive + survivors);
                    }
                    else
                    {
                        beeEaters.Push(survivors);
                    }
                }
                else
                {
                    int remainingDefenders = defenders - attackingCapacity;
                    if (remainingDefenders > 0)
                    {
                        bees.Enqueue(remainingDefenders); 
                    }
                }
            }

            Console.WriteLine("The final battle is over!");

            if (bees.Count > 0 && beeEaters.Count > 0)
            {
                Console.WriteLine($"Both bee groups and bee-eater groups survived!");
            }
            else if (bees.Count > 0)
            {
                Console.WriteLine($"Bee groups left: {string.Join(", ", bees)}");
            }
            else if (beeEaters.Count > 0)
            {
                Console.WriteLine($"Bee-eater groups left: {string.Join(", ", beeEaters)}");
            }
            else
            {
                Console.WriteLine("But no one made it out alive!");
            }
        }
    }
}
