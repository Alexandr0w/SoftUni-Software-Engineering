namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private string _make;
        private string _model;
        private double _fuelConsumption;
        private double _fuelCapacity;

        [SetUp]
        public void SetUp()
        {
            this._make = GenerateRandomString();
            this._model = GenerateRandomString();
            this._fuelConsumption = Random.Shared.NextDouble();
            this._fuelCapacity = this._fuelConsumption * 5;
        }

        [Test]
        public void CarShouldBeCreatedSuccessfully()
        {
            Car car = this.CreateCar();

            Assert.AreEqual(this._make, car.Make);
            Assert.AreEqual(this._model, car.Model);
            Assert.AreEqual(this._fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(this._fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarShouldNotBeCreatedIfMakeIsInvalid(string make)
        {
            Assert.Throws<ArgumentException>(() => _ = new Car(make, this._model, this._fuelConsumption, this._fuelCapacity));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarShouldNotBeCreatedIfModelIsInvalid(string model)
        {
            Assert.Throws<ArgumentException>(() => _ = new Car(this._make, model, this._fuelConsumption, this._fuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarShouldNotBeCreatedIfFuelConsumptionIsInvalid(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => _ = new Car(this._make, this._model, fuelConsumption, this._fuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarShouldNotBeCreatedIfFuelCapacityIsInvalid(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => _ = new Car(this._make, this._model, this._fuelConsumption, fuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowIfInvalidArgumentIsPassed(double refuelAmmount)
        {
            Car car = this.CreateCar();
            Assert.Throws<ArgumentException>(() => car.Refuel(refuelAmmount));
        }

        [TestCase(0.25)]
        [TestCase(0.5)]
        [TestCase(0.75)]
        [TestCase(1)]
        public void RefuelShouldWorkCorrectly(double fillPercentage)
        {
            Car car = this.CreateCar();
            double refuelAmmount = car.FuelCapacity * fillPercentage;

            car.Refuel(refuelAmmount);

            Assert.AreEqual(refuelAmmount, car.FuelAmount);
        }

        [Test]
        public void RefuelShouldBeLimitedToTheFuelCapacity()
        {
            Car car = this.CreateCar();
            double refuelAmmount = car.FuelCapacity * 2;

            car.Refuel(refuelAmmount);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void DriveShouldWorkCorrectly()
        {
            Car car = this.CreateCar();

            car.Refuel(car.FuelCapacity);
            car.Drive(100);

            Assert.AreEqual(car.FuelCapacity - car.FuelConsumption, car.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowsIfFuelIsNotEnough()
        {
            Car car = this.CreateCar();

            car.Refuel(car.FuelCapacity);

            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        private Car CreateCar() => new(this._make, this._model, this._fuelConsumption, this._fuelCapacity);

        private static string GenerateRandomString()
        {
            int randomTextLength = Random.Shared.Next(minValue: 5, maxValue: 50);
            return GenerateRandomString(randomTextLength);
        }

        private static string GenerateRandomString(int length)
        {
            char[] symbols = new char[length];
            for (var i = 0; i < length; i++)
            {
                int randomLetterIndex = Random.Shared.Next(maxValue: 26);
                symbols[i] = (char)('a' + randomLetterIndex);
            }

            return new string(symbols);
        }
    }
}