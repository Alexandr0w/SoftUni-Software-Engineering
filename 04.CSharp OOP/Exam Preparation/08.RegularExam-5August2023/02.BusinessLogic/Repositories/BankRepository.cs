using System.Collections.Generic;
using System.Linq;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _models;

        public BankRepository()
        {
            this._models = new List<IBank>();
            this.Models = this._models.AsReadOnly();
        }
        public IReadOnlyCollection<IBank> Models { get; }

        public void AddModel(IBank model)
            => this._models.Add(model);

        public IBank FirstModel(string name)
            => this._models.FirstOrDefault(m => m.Name == name);

        public bool RemoveModel(IBank model)
            => this._models.Remove(model);
    }
}
