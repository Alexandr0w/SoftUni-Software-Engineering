using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {

        [Test]
        public void DealerShop_ShouldBeInstantied_Correctly()
        {
            int capacity = 5;

            DealerShop shop = new DealerShop(capacity);

            Assert.Multiple(() =>
            {
                Assert.That(shop.Capacity, Is.EqualTo(capacity));
                Assert.That(shop.Vehicles, Is.Not.Null);
                Assert.That(shop.Vehicles, Is.Empty);
            });
        }

        [TestCase(-1), TestCase(0)]
        public void DealerShop_ShouldNotBeInstantied_WithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new DealerShop(capacity));
        }

        [Test]
        public void Vehicle_Should_BeAdded_Successfully()
        {
            DealerShop shop = new DealerShop(5);
            Vehicle vehicle = new Vehicle("make", "model", 2024);

            string result = shop.AddVehicle(vehicle);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo("Added 2024 make model"));
                Assert.That(shop.Vehicles, Has.Count.EqualTo(1));
                Assert.That(shop.Vehicles.Single(), Is.SameAs(vehicle));
            });
        }

        [Test]
        public void AddShould_ThrowAnException_IfLimitIsReached()
        {
            DealerShop shop = new DealerShop(1);
            Vehicle vehicle1 = new Vehicle("make1", "model1", 2024);
            Vehicle vehicle2 = new Vehicle("make2", "model2", 2024);

            shop.AddVehicle(vehicle1);

            Assert.Throws<InvalidOperationException>(() => shop.AddVehicle(vehicle2));
        }

        [Test]
        public void SellShould_WorkCorrectly()
        {
            DealerShop shop = new DealerShop(1);
            Vehicle vehicle = new Vehicle("make", "model", 2024);

            shop.AddVehicle(vehicle);
            bool couldSell = shop.SellVehicle(vehicle);

            Assert.That(couldSell, Is.True);
            Assert.That(shop.Vehicles, Is.Empty);
        }

        [Test]
        public void SellShould_ReturnFalse_IfVehicleNotFound()
        {
            DealerShop shop = new DealerShop(1);
            Vehicle vehicle1 = new Vehicle("make1", "model1", 2024);
            Vehicle vehicle2 = new Vehicle("make2", "model2", 2024);

            shop.AddVehicle(vehicle1);
            bool couldSell = shop.SellVehicle(vehicle2);

            Assert.That(couldSell, Is.False);
            Assert.That(shop.Vehicles, Has.Count.EqualTo(1));
            Assert.That(shop.Vehicles.Single(), Is.SameAs(vehicle1));
        }

        [Test]
        public void Inventory_Report_ShouldWorkCorrectly()
        {
            DealerShop shop = new DealerShop(5);
            Vehicle vehicle1 = new Vehicle("make1", "model1", 2024);
            Vehicle vehicle2 = new Vehicle("make2", "model2", 2024);

            shop.AddVehicle(vehicle1);
            shop.AddVehicle(vehicle2);

            string report = shop.InventoryReport();
            string expectedOutput = $"Inventory Report{Environment.NewLine}Capacity: 5{Environment.NewLine}Vehicles: 2{Environment.NewLine}2024 make1 model1{Environment.NewLine}2024 make2 model2";
            
            Assert.That(report, Is.EqualTo(expectedOutput));
        }
    }
}
