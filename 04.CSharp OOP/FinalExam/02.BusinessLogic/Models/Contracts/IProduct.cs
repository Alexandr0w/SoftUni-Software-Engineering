namespace BlackFriday.Models.Contracts
{
    public interface IProduct
    {
        string ProductName { get; }

        double BasePrice { get; set; }

        double BlackFridayPrice { get; }

        bool IsSold { get; set; }

        void UpdatePrice(double newPriceValue);

        void ToggleStatus();
    }
}
