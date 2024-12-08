using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories
{
    public class ProductRepository : IRepository<IProduct>
    {
        private List<IProduct> _models;

        public ProductRepository()
        {
            this._models = new List<IProduct>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<IProduct> Models { get; }

        public void AddNew(IProduct model) => this._models.Add(model);

        public bool Exists(string name) => this._models.Any(m => m.ProductName == name);

        public IProduct GetByName(string name) => this._models.FirstOrDefault(m => m.ProductName == name)!;
    }
}
