
internal class Program
{
    static void Main()
    {
        char input = char.Parse(Console.ReadLine());

        if (input >= 65 && input <= 90)
        {
            Console.WriteLine("upper-case");
        }
        else
        {
            Console.WriteLine("lower-case");
        }
    }
}
