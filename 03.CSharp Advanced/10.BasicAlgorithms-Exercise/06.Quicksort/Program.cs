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

            SortArray(input, 0, input.Length - 1);

            Console.WriteLine(string.Join(" ", input));
        }
        private static int[] SortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                SortArray(array, leftIndex, j);
            }
            if (i < rightIndex)
            {
                SortArray(array, i, rightIndex);
            }

            return array;
        }
    }
}