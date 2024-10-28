namespace ShoppingSpree
{
    public class Program
    {
        public static void Main()
        {
            Person[] people = ReadPeople();
            Product[] products = ReadProducts();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} -");
            }
        }

        private static Person[] ReadPeople()
        {
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            Person[] people = new Person[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                string[] data = input[i].Split("=");

                people[i] = new Person(data[0], decimal.Parse(data[1]));
            }

            return people;
        }

        private static Product[] ReadProducts()
        {
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            Product[] products = new Product[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                string[] data = input[i].Split("=");
                products[i] = new Product(data[0], decimal.Parse(data[1]));
            }

            return products;
        }

        private static void ProcessCommands(Person[] people, Product[] products)
        {
            Dictionary<string, Person> personByName = people.ToDictionary(p => p.Name);
            Dictionary<string, Product> productByName = products.ToDictionary(p => p.Name);

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person =  personByName[data[0]];
                Product product = productByName[data[1]];

                command = Console.ReadLine();
            }
    }
}