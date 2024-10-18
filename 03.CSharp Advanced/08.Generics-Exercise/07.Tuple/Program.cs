namespace Tuple
{
    public class Program
    {
        public static void Main()
        {
            string[] firstData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = firstData[0];
            string lastName = firstData[1];
            string address = firstData[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>($"{firstName} {lastName}", address);

            string[] secondData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = secondData[0];
            int litersOfBeer = int.Parse(secondData[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litersOfBeer);

            string[] thirdData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int numberOne = int.Parse(thirdData[0]);
            double numberTwo = double.Parse(thirdData[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(numberOne, numberTwo);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}