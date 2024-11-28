namespace FootballManager.Models
{
    public class SeniorManager : Manager
    {
        private const int initialRankingValue = 30;
        public SeniorManager(string name) : base(name, initialRankingValue)
        {
        }

        public override void RankingUpdate(double updateValue) => UpdateRanking(updateValue);
    }
}
