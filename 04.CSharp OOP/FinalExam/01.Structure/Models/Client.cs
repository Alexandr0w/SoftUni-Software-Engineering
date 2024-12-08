namespace BlackFriday.Models
{
    internal class Client : User
    {
        private Dictionary<string, bool> _purchases;

        public Client(string userName, string email) : base(userName, email, false)
        {
            this._purchases = new Dictionary<string, bool>();
        }

        public override bool HasDataAccess => false;

        public IReadOnlyDictionary<string, bool> Purchases => _purchases;

        public void PurchaseProduct(string productName, bool blackFridayFlag)
            => this._purchases[productName] = blackFridayFlag;
    }
}
