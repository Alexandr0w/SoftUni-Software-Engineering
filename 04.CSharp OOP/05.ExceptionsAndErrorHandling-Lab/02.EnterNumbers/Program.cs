namespace EnterNumbers
{
    public class Program
    {
        static void Main()
        {
            {
                List<int> numbers = new List<int>();

                while (numbers.Count < 10)
                {
                    try
                    {
                        if (numbers.Count > 0)
                        {
                            numbers.Add(ReadNumber(numbers.Max(), 100));
                        }
                        else
                        {
                            numbers.Add(ReadNumber(1, 100));
                        }
                    }
                    catch (FormatException formEx)
                    {
                        Console.WriteLine(formEx.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine(string.Join(", ", numbers));
            }
        }

        static int ReadNumber(int start, int end)
        {
            int num;
            try
            {
                num = int.Parse(Console.ReadLine());

                if (num <= start || num >= end)
                {
                    throw new ArgumentException($"Your number is not in range {start} - {end}!");
                }
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Number!");
            }

            return num;
        }
    }
}
