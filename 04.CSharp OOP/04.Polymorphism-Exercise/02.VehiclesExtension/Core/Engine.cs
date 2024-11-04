using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Factories;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.Models;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Core
{
    public class Engine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly VehicleFactory _vehicleFactory;

        private readonly ICollection<Vehicle> _vehicles;

        public Engine(IReader reader, IWriter writer, VehicleFactory vehicleFactory)
        {
            this._reader = reader;
            this._writer = writer;
            this._vehicleFactory = vehicleFactory;

            _vehicles = new List<Vehicle>();
        }

        public void Run()
        {
            _vehicles.Add(CreateVehicle()); //add Car
            _vehicles.Add(CreateVehicle()); //add Truck
            _vehicles.Add(CreateVehicle()); //add Bus

            int commandsCount = int.Parse(_reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (ArgumentException ex)
                {
                    _writer.WriteLine(ex.Message);
                }
            }

            foreach (var vehicle in _vehicles)
            {
                _writer.WriteLine(vehicle.ToString());
            }
        }

        private void ProcessCommand()
        {
            string[] commandTokens = _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            Vehicle vehicle = _vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);

                bool isDriven = vehicle.Drive(distance);

                if (isDriven)
                {
                    _writer.WriteLine($"{vehicleType} travelled {distance} km");
                }
                else
                {
                    _writer.WriteLine($"{vehicleType} needs refueling");
                }
            }
            else if (command == "DriveEmpty")
            {
                if (vehicle is ISpecializedVehicle specializedVehicle)
                {
                    double distance = double.Parse(commandTokens[2]);

                    bool isDriven = specializedVehicle.DriveEmpty(distance);

                    if (isDriven)
                    {
                        _writer.WriteLine($"{vehicleType} travelled {distance} km");
                    }
                    else
                    {
                        _writer.WriteLine($"{vehicleType} needs refueling");
                    }
                }
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(commandTokens[2]);

                bool isRefueled = vehicle.Refuel(fuelAmount);

                if (!isRefueled)
                {
                    _writer.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
                }
            }
        }

        private Vehicle CreateVehicle()
        {
            string[] data = _reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            return _vehicleFactory.Create(data[0], double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
        }
    }
}