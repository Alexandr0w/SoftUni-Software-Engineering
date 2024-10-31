namespace ExplicitInterfaces
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine()!;

            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Citizen citizen = new Citizen(data[0], int.Parse(data[2]), data[1]);
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());

                input = Console.ReadLine()!;
            }
        }
    }
}
