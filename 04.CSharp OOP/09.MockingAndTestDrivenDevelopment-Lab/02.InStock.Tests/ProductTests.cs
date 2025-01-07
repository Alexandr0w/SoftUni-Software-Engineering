namespace INStock.Tests
{
    using INStock.Interfaces;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {

        private IProduct product;

        [SetUp]
        public void Init()
        {
            product = new Product("bira", 1.20M, 2);
        }


        [Test]
        public void ConstructorShouldInitializeLabelCorrectly()
        {
            Assert.That(this.product.Label, Is.EqualTo("bira"));
        }

        [Test]
        public void ConstructorShouldInitializePriceCorrectly()
        {
            Assert.That(this.product.Price, Is.EqualTo(1.20M));
        }

        [Test]
        public void ConstructorShouldInitializeQuantityCorrectly()
        {
            Assert.That(this.product.Quantity, Is.EqualTo(2));
        }


        [Test]
        public void LabelPropertySetterShouldThrowArgumentNullExceptionWhenPassedNullValue()
        {

            Assert.That(() => new Product(null, 1.20M, 2), Throws.TypeOf<ArgumentNullException>()
                                                                 .With.Property("ParamName")
                                                                 .EqualTo("Label parameter is null!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("   ")]
        public void LabelPropertyShouldThrowArgumentExceptionWhenPassedEmptyOrWhitespaceValue(string label)
        {
            Assert.That(() => new Product(label, 1.20M, 2), Throws.ArgumentException
                                                                  .With.Message
                                                                  .EqualTo("Label cannot be empty or whitespace!"));
        }


        [Test]
        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void PricePropertyShouldThrowArgumentExceptionInAttemptToSetValueToZeroOrLess(decimal price)
        {
            Assert.That(() => new Product("bira", price, 2), Throws.ArgumentException
                                                                   .With.Message
                                                                   .EqualTo("Price cannot be zero or less!"));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void QuantityPropertyShouldThrowArgumentExceptionInAttemptToSetValueToZeroOrLess(int quantity)
        {
            Assert.That(() => new Product("bira", 1.20M, quantity), Throws.ArgumentException
                                                                          .With.Message
                                                                          .EqualTo("Quantity cannot be zero or less!"));
        }


        [Test]
        public void CompareToMethodShouldCompare2ProductsByLabelAndReturn0()
        {
            IProduct other = new Product("bira", 1.20M, 2);
            Assert.That(this.product.CompareTo(other), Is.EqualTo(0));
        }

        [Test]
        public void CompareToMethodShouldCompare2ProductsByLabelAndReturn1()
        {
            IProduct other = new Product("cola", 1.20M, 2);
            Assert.That(this.product.CompareTo(other), Is.EqualTo(1));
        }
    }
}