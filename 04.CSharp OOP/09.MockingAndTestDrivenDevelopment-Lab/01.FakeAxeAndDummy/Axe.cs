using FakeAxeAndDummy.Interfaces;

namespace FakeAxeAndDummy
{
    public class Axe : IWeapon
    {
        private int attackPoints;
        private int durabilityPoints;

        public Axe(int attack, int durability)
        {
            AttackPoints = attack;
            DurabilityPoints = durability;
        }

        public int AttackPoints
        {
            get
            {
                return attackPoints;
            }
            private set
            {
                attackPoints = value;
            }
        }

        public int DurabilityPoints
        {
            get
            {
                return durabilityPoints;
            }
            private set
            {
                durabilityPoints = value;
            }
        }

        public void Attack(ITarget target)
        {
            if (DurabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(AttackPoints);
            DurabilityPoints -= 1;
        }
    }
}