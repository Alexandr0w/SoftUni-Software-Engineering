namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car defaultCar = new Car();
            Console.WriteLine(defaultCar.WhoAmI());

            Car car = new Car("BMW", "3", 1997);
            Console.WriteLine(car.WhoAmI());

            Car fullCar = new Car("BMW", "3", 1997, 60, 25);
            Console.WriteLine(fullCar.WhoAmI());

            Tire[] tires = new Tire[2]
            {
                new Tire(2000, 2),
                new Tire(2000, 3)
            };

            Engine engine = new Engine(225, 3000);

            Car enginedCar = new Car("BMW", "3", 1997, 60, 25, engine, tires);
        }
    }
}