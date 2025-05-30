﻿using FakeAxeAndDummy.Interfaces;

namespace FakeAxeAndDummy
{
    public class Dummy : ITarget
    {
        private int health;
        private int experience;

        public Dummy(int health, int experience)
        {
            Health = health;
            Experience = experience;
        }

        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                health = value;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
            private set
            {
                experience = value;
            }
        }

        public void TakeAttack(int attackPoints)
        {
            if (IsDead())
            {
                throw new InvalidOperationException("Dummy is dead.");
            }

            Health -= attackPoints;
        }

        public int GiveExperience()
        {
            if (!IsDead())
            {
                throw new InvalidOperationException("Target is not dead.");
            }

            return Experience;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}