namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car()
            {
                Make = "BMW", 
                Model = "5",
                Year = 2008
            };

            Console.WriteLine($"{car.Make} - {car.Model} - {car.Year}");
        }
    }
}
