public class Program
{
    public static void Main()
    {
        int[] inputNumbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int token = int.Parse(Console.ReadLine());

        Console.WriteLine(BinarySearch(inputNumbers, 0, inputNumbers.Length, token));
    }

    private static int BinarySearch(int[] array, int start, int end, int element)
    {
        try
        {
            if (start > end)
                return -1;
            int middle = (start + end) / 2;

            if (array[middle] == element)
                return middle;

            if (element < array[middle])
                return BinarySearch(array, start, middle - 1, element);
            else
                return BinarySearch(array, middle + 1, end, element);
        }
        catch (IndexOutOfRangeException)
        {
            return -1;
        }
    }
}