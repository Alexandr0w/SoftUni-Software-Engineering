using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private readonly List<string> _contributors;

        protected Campaign(string brand, double budget)
        {
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException(ExceptionMessages.BrandIsrequired);

            this.Brand = brand;
            this.Budget = budget;

            this._contributors = new List<string>();
            this.Contributors = this._contributors.AsReadOnly();
        }

        public string Brand { get; }
        public double Budget { get; private set; }
        public IReadOnlyCollection<string> Contributors { get; }

        public void Gain(double amount)
            => this.Budget += amount;

        public void Engage(IInfluencer influencer)
        {
            this._contributors.Add(influencer.Username);
            this.Budget -= influencer.CalculateCampaignPrice();
        }

        public override string ToString() 
            => $"{this.GetType().Name} - Brand: {this.Brand}, Budget: {this.Budget}, Contributors: {this.Contributors.Count}";
    }
}
