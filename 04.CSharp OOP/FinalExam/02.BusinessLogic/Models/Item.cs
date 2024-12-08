namespace BlackFriday.Models
{
    public class Item : Product
    {
        private const double discount = 0.7;

        public Item(string productName, double basePrice) : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice => base.BlackFridayPrice * discount;
    }
}
