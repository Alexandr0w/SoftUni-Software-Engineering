using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private readonly List<IDiver> _models;

        public DiverRepository()
        {
            this._models = new List<IDiver>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<IDiver> Models { get; }

        public void AddModel(IDiver model) => this._models.Add(model);

        public IDiver GetModel(string name) => this._models.FirstOrDefault(m => m.Name == name)!;
    }
}
