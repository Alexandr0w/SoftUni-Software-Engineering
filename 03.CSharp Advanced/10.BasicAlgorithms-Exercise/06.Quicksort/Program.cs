namespace _06.QuickSort
{
    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        public static void QuickSort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end) return;

            int pivotIndex = Partition(array, start, end);

            QuickSort(array, 0, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, end);
        }

        private static int Partition<T>(T[] array, int start, int end) where T: IComparable<T>
        {
            T pivot = array[end];
            int index = start;

            for (int i = start; i < end; i++)
            {
                if (array[i].CompareTo(pivot) <= 0)
                {
                    (array[i], array[index]) = (array[index++], array[i]);
                }
            }

            (array[end], array[index]) = (array[index], array[end]);
            return index;
        }
    }
}