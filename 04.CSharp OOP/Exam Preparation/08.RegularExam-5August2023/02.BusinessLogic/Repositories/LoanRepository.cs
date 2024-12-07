using System.Collections.Generic;
using System.Linq;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> _models;

        public LoanRepository()
        {
            this._models = new List<ILoan>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<ILoan> Models { get; }

        public void AddModel(ILoan model)
            => this._models.Add(model);

        public ILoan FirstModel(string typeName)
            => this._models.FirstOrDefault(m => m.GetType().Name == typeName);

        public bool RemoveModel(ILoan model)
            => this._models.Remove(model);
    }
}
