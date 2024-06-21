namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] element = Console.ReadLine().Split();
            string[] reversedElements = new string[element.Length];

            for (int i = 0; i < element.Length; i++)
            {
                for (int j = reversedElements.Length - 1; j >= 0; j--)
                {
                    reversedElements[i] = element[j];
                    i++;
                }
            }

            Console.WriteLine(string.Join(" ", reversedElements));
        }
    }
}
