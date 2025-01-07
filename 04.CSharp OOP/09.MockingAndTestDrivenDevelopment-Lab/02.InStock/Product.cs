namespace INStock
{
    using INStock.Interfaces;
    using System;

    public class Product : IProduct
    {

        private string label;
        private decimal price;
        private int quantity;


        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }


        public string Label
        {
            get => this.label;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Label parameter is null!");
                }

                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label cannot be empty or whitespace!");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0.0M)
                {
                    throw new ArgumentException("Price cannot be zero or less!");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity cannot be zero or less!");
                }

                this.quantity = value;
            }
        }


        public int CompareTo(IProduct other)
        {
            if (this.Label == other.Label)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}