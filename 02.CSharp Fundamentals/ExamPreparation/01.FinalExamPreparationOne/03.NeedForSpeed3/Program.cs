namespace _03.NeedForSpeed3
{
    internal class Program
    {
        class Car
        {
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split('|');
                string carName = carData[0];
                int mileage = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);
                cars[carName] = new Car { Mileage = mileage, Fuel = fuel };
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop")
                    break;

                string[] commandParts = command.Split(" : ");
                string action = commandParts[0];
                string carName = commandParts[1];

                if (action == "Drive")
                {
                    int distance = int.Parse(commandParts[2]);
                    int requiredFuel = int.Parse(commandParts[3]);

                    if (cars[carName].Fuel < requiredFuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName].Mileage += distance;
                        cars[carName].Fuel -= requiredFuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {requiredFuel} liters of fuel consumed.");

                        if (cars[carName].Mileage >= 100000)
                        {
                            cars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    int additionalFuel = int.Parse(commandParts[2]);
                    int currentFuel = cars[carName].Fuel;
                    int fuelToFill = Math.Min(additionalFuel, 75 - currentFuel);
                    cars[carName].Fuel += fuelToFill;
                    Console.WriteLine($"{carName} refueled with {fuelToFill} liters");
                }
                else if (action == "Revert")
                {
                    int kilometers = int.Parse(commandParts[2]);
                    if (cars[carName].Mileage - kilometers < 10000)
                    {
                        cars[carName].Mileage = 10000;
                    }
                    else
                    {
                        cars[carName].Mileage -= kilometers;
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}
