namespace InfluencerManagerApp.Models
{
    public class ProductCampaign : Campaign
    {
        private const double budgetValue = 60000;

        public ProductCampaign(string brand) : base(brand, budgetValue)
        {
        }
    }
}
