namespace NauticalCatchChallenge.Models
{
    public class PredatoryFish : Fish
    {
        private const int timeToCatchValue = 60;

        public PredatoryFish(string name, double points) : base(name, points, timeToCatchValue)
        {
        }
    }
}
