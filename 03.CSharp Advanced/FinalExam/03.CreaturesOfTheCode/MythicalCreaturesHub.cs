using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreaturesOfTheCode
{
    public class MythicalCreaturesHub
    {
        public MythicalCreaturesHub(int capacity)
        {
            Capacity = capacity;
            Creatures = new List<Creature>();
        }
        public List<Creature> Creatures { get; set; }
        public int Capacity { get; set; }

        public void AddCreature(Creature creature)
        {
            if (Creatures.Count >= Capacity || Creatures.Any(c => c.Name.Equals(creature.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return; 
            }

            Creatures.Add(creature);
        }

        public bool RemoveCreature(string name)
        {
            Creature? creature = this.Creatures.SingleOrDefault(c => c.Name == name);
            if (creature == null) return false;

            return this.Creatures.Remove(creature);
        }

        public Creature? GetStrongestCreature()
        {
            return this.Creatures.OrderByDescending(c => c.Health).FirstOrDefault();
        }

        public string Details(string creatureName)
        {
            Creature? creature = Creatures.FirstOrDefault(c => c.Name.Equals(creatureName, StringComparison.OrdinalIgnoreCase));

            if (creature != null)
            {
                return creature.ToString();
            }

            return $"Creature with the name {creatureName} not found.";
        }

        public string GetAllCreatures()
        {
            var sortedCreatures = Creatures.OrderBy(c => c.Name).ToList();
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Mythical Creatures:");
            foreach (var creature in sortedCreatures)
            {
                stringBuilder.AppendLine($"{creature.Name} -> {creature.Kind}");
            }

            return stringBuilder.ToString(); 
        }
    }
}
