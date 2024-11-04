using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories;
using Vehicles.IO.Interfaces;
using Vehicles.Models;

namespace Vehicles.Core
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

            this._vehicles = new List<Vehicle>();
        }

        public void Run()
        {
            _vehicles.Add(CreateVehicle());
            _vehicles.Add(CreateVehicle());

            int commandsCount = int.Parse(_reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] data = _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];
                string vehicleType = data[1];

                Vehicle vehicle = _vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                if (vehicle is null)
                {
                    throw new ArgumentException("Invalid vehicle type");
                }

                if (command == "Drive")
                {
                    double distance = double.Parse(data[2]);

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
                else if (command == "Refuel")
                {
                    double fuelAmmout = double.Parse(data[2]);
                    vehicle.Refuel(fuelAmmout);
                }
            }

            foreach (var vehicle in _vehicles)
            {
                _writer.WriteLine(vehicle.ToString());
            }
        }

        private Vehicle CreateVehicle()
        {
            string[] data = _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return _vehicleFactory.Create(data[0], double.Parse(data[1]), double.Parse(data[2]));
        }
    }
}
