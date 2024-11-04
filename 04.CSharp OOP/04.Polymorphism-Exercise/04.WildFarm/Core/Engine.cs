using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories;
using WildFarm.IO.Interfaces;
using WildFarm.Models;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly AnimalFactory _animalFactory;
        private readonly FoodFactory _foodFactory;

        private readonly ICollection<IAnimal> _animals;

        public Engine(IReader reader, IWriter writer, AnimalFactory animalFactory, FoodFactory foodFactory)
        {
            this._reader = reader;
            this._writer = writer;
            this._animalFactory = animalFactory;
            this._foodFactory = foodFactory;

            _animals = new List<IAnimal>();
        }

        public void Run()
        {
            string command = _reader.ReadLine();
            while (command != "End")
            {
                IAnimal animal = CreateAnimal(command);
                IFood food = CreateFood();

                _writer.WriteLine(animal.ProduceSound());

                bool isEaten = animal.Eat(food);

                if (!isEaten)
                {
                    _writer.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                }

                _animals.Add(animal);

                command = _reader.ReadLine();
            }

            foreach (IAnimal animal in _animals)
            {
                _writer.WriteLine(animal.ToString()!);
            }
        }

        private IAnimal CreateAnimal(string command)
        {
            string[] animalArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = _animalFactory.CreateAnimal(animalArgs);

            return animal;
        }

        private IFood CreateFood()
        {
            string[] foodTokens = _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodTokens[0];
            int foodQuantity = int.Parse(foodTokens[1]);

            IFood food = _foodFactory.CreateFood(foodType, foodQuantity);

            return food;
        }
    }
}