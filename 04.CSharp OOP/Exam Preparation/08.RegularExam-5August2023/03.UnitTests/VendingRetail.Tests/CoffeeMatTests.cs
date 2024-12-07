using NUnit.Framework;
using System;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;
        private int waterCapacity = 2000;
        private int buttonsCount = 6;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
        }

        [Test]
        public void CheckCoffeMatIsCreatedSuccessfully()
        {
            Assert.That(coffeeMat.WaterCapacity, Is.EqualTo(waterCapacity));
            Assert.That(coffeeMat.ButtonsCount, Is.EqualTo(buttonsCount));
            Assert.IsNotNull(coffeeMat);
        }

        [Test]
        public void FillEmptyTank()
        {
            string result = coffeeMat.FillWaterTank();
            string expectedResult = "Water tank is filled with 2000ml";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FillFullTank()
        {
            coffeeMat.FillWaterTank();

            string result = coffeeMat.FillWaterTank();
            string expectedResult = "Water tank is already full!";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddDrinksToDictionary()
        {
            bool isAdded = coffeeMat.AddDrink("Latte", 1.20);

            Assert.IsTrue(isAdded);
        }
        [Test]
        public void AddDrinksToExceedCapacityOfDictionaryDictionary()
        {
            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            bool isAdded = coffeeMat.AddDrink("Americano", 1.40);

            Assert.IsFalse(isAdded);
        }

        [Test]
        public void BuyExisingDrink()
        {
            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);

            coffeeMat.FillWaterTank();

            string result = coffeeMat.BuyDrink("Latte");
            string expectedResult = "Your bill is 1.00$";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CofeeMatIsOutOfWater()
        {
            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);

            string result = coffeeMat.BuyDrink("Latte");
            string expectedResult = "CoffeeMat is out of water!";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TryToBuyUnavailableDrink()
        {
            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);

            coffeeMat.FillWaterTank();

            string result = coffeeMat.BuyDrink("Latte");
            string expectedResult = "Latte is not available!";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CollectIncome()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Macciato");
            coffeeMat.BuyDrink("Capuccino");
            coffeeMat.BuyDrink("Latte");
            coffeeMat.BuyDrink("Milk");
            coffeeMat.BuyDrink("Hot Chocolate");

            double actualIncome = coffeeMat.Income;
            double income = coffeeMat.CollectIncome();
            double testIncome = 7.60, zeroIncome = 0;
            double incomeAfterCollecting = coffeeMat.Income;

            Assert.That(actualIncome, Is.EqualTo((double)income));
            Assert.That(testIncome, Is.EqualTo(income));
            Assert.That(zeroIncome, Is.EqualTo(incomeAfterCollecting));
        }

        [Test]
        public void CheckWaterConsuming()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Macciato");
            coffeeMat.BuyDrink("Capuccino");
            coffeeMat.BuyDrink("Latte");
            coffeeMat.BuyDrink("Milk");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");

            string result = coffeeMat.BuyDrink("Hot Chocolate");
            string expectedResult = "CoffeeMat is out of water!";

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}