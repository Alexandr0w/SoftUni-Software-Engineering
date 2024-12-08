namespace BlackFriday.Models
{
    public class Service : Product
    {
        private const double discount = 0.8;

        public Service(string productName, double basePrice) : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice => base.BlackFridayPrice * discount;
    }
}
