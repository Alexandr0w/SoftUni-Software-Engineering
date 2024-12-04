namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double engagementRateValue = 2;
        private const double factor = 0.2;

        public BloggerInfluencer(string username, int followers) : base(username, followers, engagementRateValue)
        {
        }

        public override int CalculateCampaignPrice()
            => (int)Math.Floor(this.Followers * this.EngagementRate * factor);
    }
}
