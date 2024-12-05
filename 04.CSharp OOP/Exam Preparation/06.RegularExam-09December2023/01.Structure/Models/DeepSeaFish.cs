namespace NauticalCatchChallenge.Models
{
    public class DeepSeaFish : Fish
    {
        private const int timeToCatchValue = 180;

        public DeepSeaFish(string name, double points) : base(name, points, timeToCatchValue)
        {
        }
    }
}
