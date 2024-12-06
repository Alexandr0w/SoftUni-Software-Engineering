using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> _models;

        public PlayerRepository()
        {
            this._models = new List<IPlayer>();
            this.Models = this._models.AsReadOnly();    
        }

        public IReadOnlyCollection<IPlayer> Models { get; }

        public void AddModel(IPlayer model) => this._models.Add(model);

        public bool RemoveModel(string name) => this._models.Remove(this._models.FirstOrDefault(p => p.Name == name));

        public bool ExistsModel(string name) => this._models.Any(p => p.Name == name);

        public IPlayer GetModel(string name) => this._models.FirstOrDefault(p => p.Name == name);
    }
}
