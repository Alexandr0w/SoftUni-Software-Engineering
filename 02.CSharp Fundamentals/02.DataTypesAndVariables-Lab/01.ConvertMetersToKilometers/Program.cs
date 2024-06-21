
internal class Program
{
    static void Main()
    {
        double meters = int.Parse(Console.ReadLine());

        double kilometers = meters / 1000;

        Console.WriteLine($"{kilometers:F2}");
    }
}
