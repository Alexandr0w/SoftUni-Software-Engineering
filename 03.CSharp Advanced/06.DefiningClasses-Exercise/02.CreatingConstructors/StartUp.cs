namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Person firstPerson = new Person();
            firstPerson.Name = "Peter";
            firstPerson.Age = 20;

            Person secondPerson = new Person() { Name = "George", Age = 18 };

            Person thirdPerson = new Person("Jose", 43);
        }
    }
}