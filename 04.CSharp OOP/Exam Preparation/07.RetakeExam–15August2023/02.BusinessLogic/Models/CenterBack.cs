namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double initialRatingValue = 4;
        private const double increaseValue = 1;
        private const double decreaseValue = 1;

        public CenterBack(string name) : base(name, initialRatingValue)
        {
        }

        public override void DecreaseRating()
        {
            base.Rating -= decreaseValue;

            if (base.Rating < 1)
            {
                base.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            base.Rating += increaseValue;

            if (Rating > 10)
            {
                base.Rating = 10;
            }
        }
    }
}
