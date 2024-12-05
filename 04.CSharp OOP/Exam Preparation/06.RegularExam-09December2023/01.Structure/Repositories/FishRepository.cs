using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private readonly List<IFish> _models;

        public FishRepository()
        {
            this._models = new List<IFish>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<IFish> Models { get; }

        public void AddModel(IFish model) => this._models.Add(model);

        public IFish GetModel(string name) => this._models.FirstOrDefault(m => m.Name == name)!;
    }
}
