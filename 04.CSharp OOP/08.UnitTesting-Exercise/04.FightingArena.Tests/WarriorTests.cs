namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            Warrior warrior = new Warrior("Thor", 50, 100);

            Assert.AreEqual("Thor", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void Name_ShouldThrowException_WhenEmptyOrWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 50, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("   ", 50, 100));
        }

        [Test]
        public void Damage_ShouldThrowException_WhenZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Thor", 0, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Thor", -10, 100));
        }

        [Test]
        public void HP_ShouldThrowException_WhenNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Thor", 50, -5));
        }

        [Test]
        public void Attack_ShouldThrowException_WhenAttackerHPTooLow()
        {
            Warrior attacker = new Warrior("Thor", 50, 20);
            Warrior defender = new Warrior("Loki", 40, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrowException_WhenDefenderHPTooLow()
        {
            Warrior attacker = new Warrior("Thor", 50, 100);
            Warrior defender = new Warrior("Loki", 40, 20);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrowException_WhenDefenderTooStrong()
        {
            Warrior attacker = new Warrior("Thor", 50, 50);
            Warrior defender = new Warrior("Loki", 60, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldReduceHPOfBothWarriors()
        {
            Warrior attacker = new Warrior("Thor", 50, 100);
            Warrior defender = new Warrior("Loki", 30, 70);

            attacker.Attack(defender);

            Assert.AreEqual(70, attacker.HP); 
            Assert.AreEqual(20, defender.HP); 
        }

        [Test]
        public void Attack_ShouldSetDefenderHPToZero_WhenDamageExceedsDefenderHP()
        {
            Warrior attacker = new Warrior("Thor", 80, 100);
            Warrior defender = new Warrior("Loki", 30, 70);

            attacker.Attack(defender);

            Assert.AreEqual(70, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }
    }
}