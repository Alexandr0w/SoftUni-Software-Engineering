namespace GenericCountMethodString
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>();
                box.Value = Console.ReadLine();
                boxes.Add(box);
            }

            string comparisonElement = Console.ReadLine();
            Box<string> comparisonBox = new Box<string> { Value = comparisonElement };

            int result = CountGreaterThan(boxes, comparisonBox);

            Console.WriteLine(result);
        }

        public static int CountGreaterThan<T>(List<Box<T>> list, Box<T> element) where T : IComparable<T>
        {
            int count = 0;

            foreach (var box in list)
            {
                if (box.Value.CompareTo(element.Value) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}