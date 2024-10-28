namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        public Chicken(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            if (age < MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
            }

            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public double ProductPerDay => this.CalculateProductPerDay();

        private double CalculateProductPerDay()
        {
            if (this.Age <= 3) return 1.5;
            if (this.Age <= 7) return 2;
            if (this.Age <= 11) return 1;
            return 0.75;
        }
    }
}