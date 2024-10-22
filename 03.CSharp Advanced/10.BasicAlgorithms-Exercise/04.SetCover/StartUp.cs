namespace SetCover
{
    public class StartUp
    {
        public static void Main()
        {
            List<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            List<int[]> sets = new List<int[]>();

            int numberOfSets = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSets; i++)
            {
                int[] currentSet = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                sets.Add(currentSet);
            }

            List<int[]> setsToTake = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({setsToTake.Count}):");
            foreach (int[] set in setsToTake)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> setsToTake = new List<int[]>();

            while (universe.Count > 0 && sets.Count > 0)
            {
                var mostmatches = sets.OrderByDescending(x => x.Count(universe.Contains)).First();

                setsToTake.Add(mostmatches);
                sets.Remove(mostmatches);

                List<int> elementsToRemoveFromUniverse = new List<int>();

                foreach (var element in universe)
                {
                    if (mostmatches.Contains(element))
                    {
                        elementsToRemoveFromUniverse.Add(element);
                    }
                }

                foreach (var element in elementsToRemoveFromUniverse)
                {
                    universe.Remove(element);
                }
            }

            return setsToTake;
        }
    }
}