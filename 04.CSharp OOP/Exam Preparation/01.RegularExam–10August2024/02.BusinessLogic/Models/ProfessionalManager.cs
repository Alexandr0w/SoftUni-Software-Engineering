namespace FootballManager.Models
{
    public class ProfessionalManager : Manager
    {
        private const int initialRankingValue = 60;

        public ProfessionalManager(string name) : base(name, initialRankingValue)
        {
        }

        public override void RankingUpdate(double updateValue) => UpdateRanking(updateValue * 1.5);
    }
}
