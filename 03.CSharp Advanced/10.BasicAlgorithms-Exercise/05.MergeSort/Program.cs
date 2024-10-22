namespace _05.MergeSort
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            numbers = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> MergeSort(List<int> array)
        {
            if (array.Count <= 1)
            {
                return array;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < array.Count; i++)
            {
                if (i < array.Count / 2)
                {
                    left.Add(array[i]);
                }
                else
                {
                    right.Add(array[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> merdedList = new List<int>();

            while (left.Any() && right.Any())
            {
                int index = 0;

                if (left[index] <= right[index])
                {
                    merdedList.Add(left[index]);
                    left.RemoveAt(index);
                }
                else
                {
                    merdedList.Add(right[index]);
                    right.RemoveAt(index);
                }

                index++;
            }

            while (left.Any())
            {
                int index = 0;

                merdedList.Add(left[index]);
                left.RemoveAt(index);

                index++;
            }

            while (right.Any())
            {
                int index = 0;

                merdedList.Add(right[index]);
                right.RemoveAt(index);

                index++;
            }

            return merdedList;
        }
    }
}