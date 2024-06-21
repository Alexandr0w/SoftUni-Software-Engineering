namespace _09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split().Select(int.Parse).ToList();
            int removedValuesSum = 0;

            while (distances.Count > 0)
            {
                int indexToRemove = int.Parse(Console.ReadLine());
                int removedNumber;

                if (indexToRemove < 0)
                {
                    removedNumber = distances[0];
                    distances[0] = distances[distances.Count - 1];
                }

                else if (indexToRemove > distances.Count - 1)
                {
                    removedNumber = distances[distances.Count - 1];
                    distances[distances.Count - 1] = distances[0];
                }
                else
                {
                    removedNumber = distances[indexToRemove];
                    distances.RemoveAt(indexToRemove);
                }

                removedValuesSum += removedNumber;

                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i] <= removedNumber)
                    {
                        distances[i] += removedNumber;
                    }
                    else
                    {
                        distances[i] -= removedNumber;
                    }
                }
            }

            Console.WriteLine(removedValuesSum);
        }
    }
}
