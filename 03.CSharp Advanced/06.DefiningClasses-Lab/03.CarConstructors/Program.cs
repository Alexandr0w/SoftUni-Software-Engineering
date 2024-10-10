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
        }
    }
}