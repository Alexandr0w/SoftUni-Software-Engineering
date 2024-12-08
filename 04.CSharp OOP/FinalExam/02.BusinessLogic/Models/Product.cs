using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        protected Product(string productName, double basePrice)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new ArgumentException(ExceptionMessages.ProductNameRequired);
            if (basePrice <= 0) throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);

            this.ProductName = productName;
            this.BasePrice = basePrice;
            this.IsSold = false;
        }

        public string ProductName { get; }
        public double BasePrice { get; set; }
        public bool IsSold { get; set; }

        public virtual double BlackFridayPrice => BasePrice;

        public void UpdatePrice(double newPriceValue) => this.BasePrice = newPriceValue;

        public void ToggleStatus() => this.IsSold = !IsSold;

        public override string ToString() 
            => $"Product: {this.ProductName}, Price: {this.BasePrice:F2}, You Save: {(this.BasePrice - this.BlackFridayPrice):F2}";
    }
}
