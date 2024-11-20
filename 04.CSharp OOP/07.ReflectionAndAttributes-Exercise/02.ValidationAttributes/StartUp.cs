namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main()
        {
            Person person = new Person("Michael", 12);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
