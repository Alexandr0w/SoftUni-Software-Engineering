using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository _divers;
        private FishRepository _fish;

        public Controller()
        {
            this._divers = new DiverRepository();
            this._fish = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (this._divers.GetModel(diverName) != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
            }

            IDiver diver;

            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }

            else
            {
                diver = new ScubaDiver(diverName);
            }

            this._divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != nameof(ReefFish) && fishType != nameof(DeepSeaFish) && fishType != nameof(PredatoryFish))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (this._fish.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }

            IFish fish;

            if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }

            else if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }

            else
            {
                fish = new PredatoryFish(fishName, points);
            }

            this._fish.AddModel(fish);

            return string.Format(OutputMessages.FishCreated, fishName);

        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (this._divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }
            if (this._fish.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = this._divers.GetModel(diverName);

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            IFish currFish = this._fish.GetModel(fishName);

            if (diver.OxygenLevel < currFish.TimeToCatch)
            {
                diver.Miss(currFish.TimeToCatch);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == currFish.TimeToCatch && !isLucky)
            {
                diver.Miss(currFish.TimeToCatch);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else
            {
                diver.Hit(currFish);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverHitsFish, diverName, currFish.Points, fishName);
            }

        }

        public string HealthRecovery()
        {
            int counter = 0;

            foreach (var diver in this._divers.Models.Where(x => x.HasHealthIssues == true))
            {
                counter++;
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return string.Format(OutputMessages.DiversRecovered, counter);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = this._divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var fishName in diver.Catch)
            {
                IFish currFish = this._fish.GetModel(fishName);
                sb.AppendLine(currFish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            var sortedDiver = this._divers.Models
                .Where(d => d.HasHealthIssues == false)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name);

            foreach (var diver in sortedDiver)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
