namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double engagementRateValue = 3;
        private const double factor = 0.15;
        public BusinessInfluencer(string username, int followers) : base(username, followers, engagementRateValue)
        {
        }

        public override int CalculateCampaignPrice()
            => (int)Math.Floor(this.Followers * this.EngagementRate * factor);
    }
}
