using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private readonly List<ITeam> _models;

        public TeamRepository()
        {
            this._models = new List<ITeam>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<ITeam> Models { get; }

        public void AddModel(ITeam model) => this._models.Add(model);

        public bool RemoveModel(string name) => this._models.Remove(this._models.FirstOrDefault(p => p.Name == name));

        public bool ExistsModel(string name) => this._models.Any(p => p.Name == name);

        public ITeam GetModel(string name) => this._models.FirstOrDefault(p => p.Name == name);
    }
}
