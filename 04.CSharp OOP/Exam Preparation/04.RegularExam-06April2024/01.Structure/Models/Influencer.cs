using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private readonly List<string> _participants;

        protected Influencer(string username, int followers, double engagementRate)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            if (followers < 0) throw new ArgumentException(ExceptionMessages.FollowersCountNegative);

            this.Username = username;
            this.Followers = followers;
            this.EngagementRate = engagementRate;
            this.Income = 0;

            this._participants = new List<string>();
            this.Participations = this._participants.AsReadOnly();
        }

        public string Username { get; }
        public int Followers { get; }
        public double EngagementRate { get; }
        public double Income { get; private set; }
        public IReadOnlyCollection<string> Participations { get; }

        public void EarnFee(double amount)
            => this.Income += amount;

        public void EnrollCampaign(string brand)
            => this._participants.Add(brand);

        public void EndParticipation(string brand)
            => this._participants.Remove(brand);

        public abstract int CalculateCampaignPrice();

        public override string ToString() 
            => $"{this.Username} - Followers: {this.Followers}, Total Income: {this.Income}";
    }
}
