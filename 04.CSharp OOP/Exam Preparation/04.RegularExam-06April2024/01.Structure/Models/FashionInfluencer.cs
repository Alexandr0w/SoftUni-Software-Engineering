namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private const double engagementRateValue = 4;
        private const double factor = 0.1;

        public FashionInfluencer(string username, int followers) : base(username, followers, engagementRateValue)
        {
        }

        public override int CalculateCampaignPrice()
            => (int)Math.Floor(this.Followers * this.EngagementRate * factor);
    }
}
