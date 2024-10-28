namespace ShoppingSpree
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Person[] people = ReadPeople();
                Product[] products = ReadProducts();

                ProcessCommands(people, products);
                PrintOutput(people);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
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
                Person person = personByName[data[0]];
                Product product = productByName[data[1]];

                if (person.Purchase(product))
                {
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintOutput(Person[] people)
        {
            foreach (Person person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {    
                    Console.WriteLine($"{person.Name} - { string.Join(", ", person.Bag.Select(p => p.Name)) }");
                }
            }
        }
    }
}