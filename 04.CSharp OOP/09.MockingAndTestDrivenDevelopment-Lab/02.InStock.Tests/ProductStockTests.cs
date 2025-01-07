namespace INStock.Tests
{
    using InStock;
    using INStock.Interfaces;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {

        private IProductStock productStock;
        private IProduct product;

        [SetUp]
        public void Init()
        {
            productStock = new ProductStock();
            product = new Product("bira", 1.20M, 2);
        }


        [Test]
        public void ConstructorShouldInitializeCollectionCorrectly()
        {
            Assert.That(this.productStock.Count, Is.EqualTo(0));
        }


        [Test]
        public void PropertyCountShouldReturnCorrectCollectionCount()
        {
            this.productStock.Add(new Product("bira", 1.20M, 2));
            Assert.That(this.productStock.Count, Is.EqualTo(1));
        }

        [Test]
        public void IndexerShouldTakeItemOnIndex()
        {
            this.productStock.Add(this.product);
            IProduct extractedProduct = this.productStock[0];

            Assert.That(product.CompareTo(extractedProduct), Is.EqualTo(0));
        }

        [Test]
        public void IndexerShouldSetItemOnIndex()
        {
            this.productStock.Add(this.product);

            IProduct newProduct = new Product("rakiya special edition", 15.50M, 5);
            this.productStock[0] = newProduct;

            Assert.That(newProduct.CompareTo(this.productStock[0]), Is.EqualTo(0));
        }

        [Test]
        public void IndexerShouldThrowIndexOutOfRangeExceptionInAttemptToTakeProductOnInvalidIndex()
        {
            Assert.That(() => this.productStock[2], Throws.TypeOf<IndexOutOfRangeException>()
                                                          .With.Message
                                                          .EqualTo("Index was out of range!"));
        }


        [Test]
        public void AddMethodShouldAddNewProductInProductStock()
        {
            this.productStock.Add(this.product);
            Assert.That(this.productStock.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodShouldThrowArgumentExceptionInAttemptToAddAlreadyExistingProduct()
        {
            this.productStock.Add(this.product);
            Assert.That(() => this.productStock.Add(this.product), Throws.ArgumentException
                                                                         .With.Message
                                                                         .EqualTo("Product already existing!"));
        }


        [Test]
        public void RemoveMethodShouldRemoveProductSuccessfully()
        {
            this.productStock.Add(this.product);
            this.productStock.Remove(this.product);

            Assert.That(this.productStock.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveMethodShouldReturnTrueWhenProductRemoved()
        {
            this.productStock.Add(this.product);

            Assert.That(this.productStock.Remove(this.product), Is.EqualTo(true));
        }

        [Test]
        public void RemoveMethodShouldReturnFalseWhenProductIsntRemoved()
        {
            Assert.That(this.productStock.Remove(this.product), Is.EqualTo(false));
        }

        [Test]
        public void ContainsMethodShouldReturnTrueWhenSearchingForValidProduct()
        {
            this.productStock.Add(this.product);
            Assert.That(this.productStock.Contains(this.product), Is.EqualTo(true));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenSearchingForInvalidProduct()
        {
            Assert.That(this.productStock.Contains(this.product), Is.EqualTo(false));
        }


        [Test]
        public void FindMethodShouldReturnCorrectProduct()
        {
            this.productStock.Add(this.product);

            IProduct extractedProduct = this.productStock.Find(0);

            Assert.That(extractedProduct.Label, Is.EqualTo(this.product.Label));
        }

        [Test]
        public void FindMethodShouldThrowIndexOutOfRangeExceptionInAttemptToGetItemAtInvalidIndex()
        {
            Assert.That(() => this.productStock.Find(0), Throws.TypeOf<IndexOutOfRangeException>()
                                                               .With.Message
                                                               .EqualTo("Index was out of range!"));
        }


        [Test]
        public void FindByLabelMethodShouldReturnCorrectProduct()
        {
            this.productStock.Add(this.product);

            IProduct extractedProduct = this.productStock.FindByLabel("bira");

            Assert.That(extractedProduct.Label, Is.EqualTo(this.product.Label));
        }

        [Test]
        public void FindByLabelMethodShouldThrowArgumentException()
        {
            Assert.That(() => this.productStock.FindByLabel("bira"), Throws.ArgumentException
                                                                           .With.Message
                                                                           .EqualTo("No such product in stock!"));
        }


        [Test]
        [TestCase(12, 45.0)]
        [TestCase(10.0, 60.0)]
        [TestCase(2.1, 299.99)]
        public void FindAllInRangeMethodShouldReturnCorrectRangeOfProducts(double low, double high)
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct shoes = new Product("LeatherShh", 12.0M, 3);
            IProduct jacket = new Product("Denim", 45.0M, 5);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);

            this.productStock.Add(ball);
            this.productStock.Add(shoes);
            this.productStock.Add(jacket);
            this.productStock.Add(ski);

            IEnumerable<IProduct> expected = new List<IProduct>() { jacket, shoes };
            IEnumerable<IProduct> actual = this.productStock.FindAllInRange(low, high);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(12, 45.0)]
        [TestCase(10.0, 60.0)]
        [TestCase(2.1, 299.99)]
        public void FindAllInRangeMethodShouldReturnEmptyCollection(double low, double high)
        {
            IEnumerable<IProduct> resultCollection = this.productStock.FindAllInRange(low, high).ToList();

            Assert.That(resultCollection.Count(), Is.EqualTo(0));
        }


        [Test]
        public void FindAllByPriceMethodShouldReturnCorrectCollectionOfProductsWithPassedPrice()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct ball2 = new Product("Ball", 2.0M, 10);
            IProduct ball3 = new Product("RoundedBall", 2.0M, 10);
            IProduct ball4 = new Product("OvalBall", 2.0M, 10);

            this.productStock.Add(ball);
            this.productStock.Add(ball2);
            this.productStock.Add(ball3);
            this.productStock.Add(ball4);

            IEnumerable<IProduct> expected = this.productStock.FindAllByPrice(2.0);

            Assert.That(expected.Count(), Is.EqualTo(4));
        }

        [Test]
        public void FindAllByPriceMethodShouldReturnEmptyCollectionOfProductsWithPassedPrice()
        {
            IEnumerable<IProduct> expected = this.productStock.FindAllByPrice(2.0);

            Assert.That(expected.Count(), Is.EqualTo(0));
        }


        [Test]
        public void FindMostExpensiveProductMethodShouldReturnMostExpensiveProduct()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);
            this.productStock.Add(ball);
            this.productStock.Add(ski);

            IProduct mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            Assert.That(mostExpensiveProduct.Label, Is.EqualTo("Snow Floaters"));
        }

        [Test]
        public void FindMostExpensiveProductMethodShouldReturnNull()
        {
            IProduct mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            Assert.That(mostExpensiveProduct, Is.EqualTo(null));
        }


        [Test]
        public void FindAllByQuantityMethodShouldCorrectCollectionOfProductsWithPassedRemainingQuantity()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct shoes = new Product("LeatherShh", 12.0M, 3);
            IProduct jacket = new Product("Denim", 45.0M, 3);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);

            this.productStock.Add(ball);
            this.productStock.Add(shoes);
            this.productStock.Add(jacket);
            this.productStock.Add(ski);

            IEnumerable<IProduct> expected = new List<IProduct>() { shoes, jacket };
            IEnumerable<IProduct> actual = this.productStock.FindAllByQuantity(3);

            Assert.That(actual.Count(), Is.EqualTo(expected.Count()));
        }

        [Test]
        public void FindAllByQuantityMethodShouldEmptyCollectionOfProductsWithPassedRemainingQuantity()
        {
            IEnumerable<IProduct> actual = this.productStock.FindAllByQuantity(3);

            Assert.That(actual.Count(), Is.EqualTo(0));
        }


        [Test]
        public void GetEnumeratorProductShouldReturnAllProductsInStock()
        {
            IProduct ball = new Product("Ballin'", 2.0M, 10);
            IProduct shoes = new Product("LeatherShh", 12.0M, 3);
            IProduct jacket = new Product("Denim", 45.0M, 3);
            IProduct ski = new Product("Snow Floaters", 300.0M, 1);

            this.productStock.Add(ball);
            this.productStock.Add(shoes);
            this.productStock.Add(jacket);
            this.productStock.Add(ski);

            List<IProduct> products = new List<IProduct>() { ball, shoes, jacket, ski };

            IEnumerator<IProduct> enumerator = this.productStock.GetEnumerator();

            int index = 0;
            while (enumerator.MoveNext())
            {
                IProduct currentProduct = enumerator.Current;
                Assert.That(currentProduct.Label, Is.EqualTo(products[index++].Label));
            }
        }
    }
}