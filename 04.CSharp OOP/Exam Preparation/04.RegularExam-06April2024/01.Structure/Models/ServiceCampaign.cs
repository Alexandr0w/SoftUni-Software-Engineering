﻿namespace InfluencerManagerApp.Models
{
    public class ServiceCampaign : Campaign
    {
        private const double budgetValue = 30000;

        public ServiceCampaign(string brand) : base(brand, budgetValue)
        {
        }
    }
}
