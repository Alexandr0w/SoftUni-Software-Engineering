namespace BirthdayCelebrations
{
    public class Program
    {
        public static void Main()
        {
            List<IBorn> entities = new List<IBorn>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(data[1], int.Parse(data[2]), data[3], data[4]);
                    entities.Add(citizen);
                }
                else if (data[0] == "Pet")
                {
                    Pet pet = new Pet(data[1], data[2]);
                    entities.Add(pet);
                }

                input = Console.ReadLine();
            }

            string suffix = Console.ReadLine()!;

            foreach (IBorn entity in entities)
            {
                if (entity.BirthDate.EndsWith(suffix))
                {
                    Console.WriteLine(entity.BirthDate);
                }
            }
        }
    }
}