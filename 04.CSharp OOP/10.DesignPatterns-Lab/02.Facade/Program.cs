namespace Facade
{
    public class Program
    {
        public static void Main()
        {
            Car car = new CarBuilderFacade()
                .Info
                    .WithType("BMW")
                    .WithColor("Black")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Sofia")
                    .AtAddress("Some address 254")
                .Build();

            Console.WriteLine(car);
        }
    }
}
