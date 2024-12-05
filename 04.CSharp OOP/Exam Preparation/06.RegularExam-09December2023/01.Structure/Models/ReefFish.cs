namespace NauticalCatchChallenge.Models
{
    public class ReefFish : Fish
    {
        private const int timeToCatchValue = 30;

        public ReefFish(string name, double points) : base(name, points, timeToCatchValue)
        {
        }
    }
}
