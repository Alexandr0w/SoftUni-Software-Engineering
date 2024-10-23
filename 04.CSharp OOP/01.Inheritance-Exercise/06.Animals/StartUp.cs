namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];
                try
                {
                    if (animalType == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                    }
                    else if (animalType == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(kitten);
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                animalType = Console.ReadLine();
            }
        }
    }
}