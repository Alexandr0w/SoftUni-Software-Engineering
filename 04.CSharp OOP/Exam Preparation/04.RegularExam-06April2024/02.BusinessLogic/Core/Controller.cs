using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Text;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> _influencers;
        private IRepository<ICampaign> _campaigns;

        public Controller()
        {
            this._influencers = new InfluencerRepository();
            this._campaigns = new CampaignRepository();
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (!IsValidInfluencerType(typeName))
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (this._influencers.FindByName(username) != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            IInfluencer influencer = CreateInfluencer(typeName, username, followers);

            this._influencers.AddModel(influencer);

            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (!IsValidCampaignType(typeName))
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (this._campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign campaign = CreateCampaign(typeName, brand);

            this._campaigns.AddModel(campaign);

            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            if (this._influencers.FindByName(username) == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            }

            if (this._campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            IInfluencer influencer = this._influencers.FindByName(username);
            ICampaign campaign = this._campaigns.FindByName(brand);

            if (campaign.Contributors.Contains(influencer.Username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            bool isEligible = true;
            if (campaign.GetType().Name == nameof(ProductCampaign) && influencer.GetType().Name == nameof(BloggerInfluencer))
            {
                isEligible = false;
            }
            if (campaign.GetType().Name == nameof(ServiceCampaign) && influencer.GetType().Name == nameof(FashionInfluencer))
            {
                isEligible = false;
            }

            if (!isEligible)
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            double profit = influencer.CalculateCampaignPrice();

            if (campaign.Budget < profit)
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EarnFee(profit);
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = this._campaigns.FindByName(brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            campaign.Gain(amount);

            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = this._campaigns.FindByName(brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }

            if (campaign.Budget <= 10000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var influencer in campaign.Contributors)
            {
                var currentInfluencer = this._influencers.FindByName(influencer);

                currentInfluencer.EarnFee(2000);
                currentInfluencer.EndParticipation(campaign.Brand);
            }

            this._campaigns.RemoveModel(campaign);

            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = this._influencers.FindByName(username);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Any())
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            this._influencers.RemoveModel(influencer);

            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            var sortedInfluencer = this._influencers.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers);


            foreach (var influencer in sortedInfluencer)
            {
                sb.AppendLine(influencer.ToString());

                if (influencer.Participations.Any())
                {
                    sb.AppendLine("Active Campaigns:");

                    var sortedCampaign = this._campaigns.Models.Where(c => c.Contributors.Contains(influencer.Username)).OrderBy(c => c.Brand);
                    foreach (var campaign in sortedCampaign)
                    {
                        sb.AppendLine($"--{campaign.ToString()}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        private IInfluencer CreateInfluencer(string influencerTypeName, string influencerName, int followers)
        {
            IInfluencer? influencer = null;

            if (influencerTypeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(influencerName, followers);
            }
            else if (influencerTypeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(influencerName, followers);
            }
            else if (influencerTypeName == nameof(BloggerInfluencer))
            {
                influencer = new BloggerInfluencer(influencerName, followers);
            }

            return influencer!;
        }

        private ICampaign CreateCampaign(string campTypeName, string campBrand)
        {
            ICampaign? campaign = null;
            if (campTypeName == nameof(ProductCampaign))
            {
                campaign = new ProductCampaign(campBrand);
            }
            else if (campTypeName == nameof(ServiceCampaign))
            {
                campaign = new ServiceCampaign(campBrand);
            }

            return campaign!;
        }

        private bool IsValidInfluencerType(string typeName)
            => typeName == nameof(BloggerInfluencer) 
            || typeName == nameof(BusinessInfluencer) 
            || typeName == nameof(FashionInfluencer);

        private bool IsValidCampaignType(string typeName)
            => typeName == nameof(ProductCampaign) || typeName == nameof(ServiceCampaign);
    }
}
