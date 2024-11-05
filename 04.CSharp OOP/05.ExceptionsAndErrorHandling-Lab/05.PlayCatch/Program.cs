namespace PlayCatch
{
    public class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int exceptionCount = 0;

            while (exceptionCount < 3)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                try
                {
                    int index = int.Parse(data[1]);

                    if (command == "Replace")
                    {
                        int element = int.Parse(data[2]);
                        numbers[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int endIndex = int.Parse(data[2]);
                        int[] subArray = new int[endIndex - index + 1];
                        int subArrayIndex = 0;
                        for (int i = index; i <= endIndex; i++)
                        {
                            subArray[subArrayIndex++] = numbers[i];
                        }
                        Console.WriteLine(string.Join(", ", subArray));
                    }
                    else if (command == "Show")
                    {
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
