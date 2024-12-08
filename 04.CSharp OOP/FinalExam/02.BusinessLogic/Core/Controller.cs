using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System.Text;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        private IApplication _application;

        public Controller()
        {
            this._application = new Application();
        }

        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            if (this._application.Users.Exists(userName))
            {
                return string.Format(OutputMessages.UserAlreadyRegistered, userName);
            }

            if (this._application.Users.Models.Any(u => u is Client client && client.Email == email))
            {
                return string.Format(OutputMessages.SameEmailIsRegistered, email);
            }

            if (hasDataAccess)
            {
                int adminCount = this._application.Users.Models.Count(u => u is Admin);

                if (adminCount >= 2)
                {
                    return string.Format(OutputMessages.AdminCountLimited);
                }

                IUser admin = new Admin(userName, email);

                this._application.Users.AddNew(admin);

                return string.Format(OutputMessages.AdminRegistered, userName);
            }
            else
            {
                IUser client = new Client(userName, email);

                this._application.Users.AddNew(client);

                return string.Format(OutputMessages.ClientRegistered, userName);
            }
        }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            IProduct? product = productType switch
            {
                "Item" => new Item(productName, basePrice),
                "Service" => new Service(productName, basePrice),
                _ => null
            };

            if (product == null)
            {
                return string.Format(OutputMessages.ProductIsNotPresented, productType);
            }

            if (this._application.Products.Exists(productName))
            {
                return string.Format(OutputMessages.ProductNameDuplicated, productName);
            }

            IUser user = this._application.Users.GetByName(userName);

            if (user == null || !user.HasDataAccess)
            {
                return string.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            this._application.Products.AddNew(product);

            return string.Format(OutputMessages.ProductAdded, productType, productName, product.BasePrice);
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            IProduct product = this._application.Products.GetByName(productName);

            if (product == null)
            {
                return string.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            IUser user = this._application.Users.GetByName(userName);

            if (user == null || !user.HasDataAccess)
            {
                return string.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            double oldPriceValue = product.BasePrice;
            product.BasePrice = newPriceValue;

            return string.Format(OutputMessages.ProductPriceUpdated, productName, oldPriceValue, newPriceValue);
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            IUser user = this._application.Users.GetByName(userName);

            if (user == null || user.HasDataAccess) 
            {
                return string.Format(OutputMessages.UserIsNotClient, userName);
            }

            IProduct product = this._application.Products.GetByName(productName);

            if (product == null)
            {
                return string.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            if (product.IsSold)
            {
                return string.Format(OutputMessages.ProductOutOfStock, productName);
            }

            var client = (Client)user; 
            client.PurchaseProduct(productName, blackFridayFlag);
            product.IsSold = true;

            double price = blackFridayFlag ? product.BlackFridayPrice : product.BasePrice;

            return string.Format(OutputMessages.ProductPurchased, userName, productName, price);
        }

        public string RefreshSalesList(string userName)
        {
            IUser user = this._application.Users.GetByName(userName);

            if (user == null || !user.HasDataAccess)
            {
                return string.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            var soldProducts = this._application.Products.Models.Where(p => p.IsSold).ToList();

            foreach (var product in soldProducts)
            {
                product.IsSold = false;
            }

            return string.Format(OutputMessages.SalesListRefreshed, soldProducts.Count);
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            var admins = this._application.Users.Models.Where(u => u is Admin).OrderBy(u => u.UserName).ToList();
            var clients = this._application.Users.Models.OfType<Client>().OrderBy(u => u.UserName).ToList();

            sb.AppendLine("Application administration:");

            foreach (var admin in admins)
            {
                sb.AppendLine(admin.ToString());
            }

            sb.AppendLine("Clients:");
            foreach (var client in clients)
            {
                sb.AppendLine(client.ToString());

                var blackFridayPurchases = client.Purchases.Where(p => p.Value).ToList();

                if (blackFridayPurchases.Any())
                {
                    sb.AppendLine($"-Black Friday Purchases: {blackFridayPurchases.Count}");

                    foreach (var purchase in blackFridayPurchases)
                    {
                        sb.AppendLine($"--{purchase.Key}");
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}
