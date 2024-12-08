using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
    public class Tests
    {
        private TradingPlatform platform;
        private Product product1, product2, product3;

        [SetUp]
        public void SetUp()
        {
            platform = new TradingPlatform(3);
            product1 = new Product("Product1", "Category1", 50.0);
            product2 = new Product("Product2", "Category2", 60.0);
            product3 = new Product("Product3", "Category3", 70.0);
        }

        [Test]
        public void AddProduct_ShouldAddProduct_WhenInventoryHasSpace()
        {
            string result = platform.AddProduct(product1);

            Assert.That(result, Is.EqualTo("Product Product1 added successfully"));
            Assert.That(platform.Products.Count, Is.EqualTo(1));
            Assert.Contains(product1, platform.Products.ToList());
        }

        [Test]
        public void AddProduct_ShouldReturnInventoryFullMessage_WhenInventoryIsFull()
        {
            platform.AddProduct(product1);
            platform.AddProduct(product2);
            platform.AddProduct(product3);

            var newProduct = new Product("Product4", "Category4", 80.0);

            string result = platform.AddProduct(newProduct);

            Assert.That(result, Is.EqualTo("Inventory is full"));
            Assert.That(platform.Products.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveProduct_ShouldRemoveProduct_WhenProductExists()
        {
            platform.AddProduct(product1);

            bool result = platform.RemoveProduct(product1);

            Assert.IsTrue(result);
            Assert.That(platform.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveProduct_ShouldReturnFalse_WhenProductDoesNotExist()
        {
            bool result = platform.RemoveProduct(product1);

            Assert.IsFalse(result);
        }

        [Test]
        public void SellProduct_ShouldSellAndRemoveProduct_WhenProductExists()
        {
            platform.AddProduct(product1);

            var soldProduct = platform.SellProduct(product1);

            Assert.That(product1, Is.EqualTo(soldProduct));
            Assert.That(platform.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellProduct_ShouldReturnNull_WhenProductDoesNotExist()
        {
            var soldProduct = platform.SellProduct(product1);

            Assert.IsNull(soldProduct);
        }

        [Test]
        public void InventoryReport_ShouldReturnCorrectReport_WhenInventoryIsEmpty()
        {
            string status = platform.InventoryReport();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine("Available Products: 0");

            string result = sb.ToString().Trim();

            Assert.That(result, Is.EqualTo(status));
        }

        [Test]
        public void InventoryReport_ShouldReturnCorrectReport_WhenInventoryHasOneProduct()
        {
            platform.AddProduct(product1);

            string status = platform.InventoryReport();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine("Available Products: 1");
            sb.AppendLine("Name: Product1, Category: Category1 - $50.00");

            string result = sb.ToString().Trim();

            Assert.That(result, Is.EqualTo(status));
        }

        [Test]
        public void InventoryReport_ShouldReturnCorrectReport_WhenInventoryHasMultipleProducts()
        {
            platform.AddProduct(product1);
            platform.AddProduct(product2);

            string status = platform.InventoryReport();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine("Available Products: 2");
            sb.AppendLine("Name: Product1, Category: Category1 - $50.00");
            sb.AppendLine("Name: Product2, Category: Category2 - $60.00");

            string result = sb.ToString().Trim();

            Assert.That(result, Is.EqualTo(status));
        }

        [Test]
        public void InventoryReport_ShouldNotAddMoreThanLimit_WhenInventoryExceedsLimit()
        {
            platform.AddProduct(product1);
            platform.AddProduct(product2);

            string result = platform.AddProduct(product3);
            string report = platform.InventoryReport();

            Assert.IsFalse(report.Contains("Available Products: 2"));
            Assert.IsFalse(result.Contains("Inventory is full"));
        }
    }
}