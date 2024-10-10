namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car()
            {
                Make = "BMW",
                Model = "6",
                Year = 2010,
                FuelQuantity = 1000,
                FuelConsumption = 10
            };

            car.Drive(55);
            Console.WriteLine(car.WhoAmI());
        }
    }
}