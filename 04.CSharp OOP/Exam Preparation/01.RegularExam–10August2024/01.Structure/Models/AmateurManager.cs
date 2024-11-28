namespace FootballManager.Models
{
    public class AmateurManager : Manager
    {
        private const int initialRankingValue = 15;
        public AmateurManager(string name) : base(name, initialRankingValue)
        {
        }

        public override void RankingUpdate(double updateValue) => UpdateRanking(updateValue * 0.75);
    }
}
