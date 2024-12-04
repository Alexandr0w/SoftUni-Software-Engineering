using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private readonly List<ICampaign> _models;

        public CampaignRepository()
        {
            this._models = new List<ICampaign>();
            this.Models = this._models.AsReadOnly();
        }

        public IReadOnlyCollection<ICampaign> Models { get; }

        public void AddModel(ICampaign model)
            => this._models.Add(model);

        public bool RemoveModel(ICampaign model)
            => this._models.Remove(model);

        public ICampaign FindByName(string name)
            => this._models.FirstOrDefault(m => m.Brand == name)!;
    }
}
