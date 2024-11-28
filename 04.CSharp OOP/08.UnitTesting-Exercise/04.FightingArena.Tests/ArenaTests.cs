namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior warrior2;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior1 = new Warrior("Thor", 50, 100);
            warrior2 = new Warrior("Loki", 40, 80);
        }

        [Test]
        public void Constructor_ShouldInitializeEmptyCollection()
        {
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Enroll_ShouldAddWarriorToArena()
        {
            arena.Enroll(warrior1);
            Assert.AreEqual(1, arena.Count);
            Assert.Contains(warrior1, arena.Warriors.ToList());
        }

        [Test]
        public void Enroll_ShouldThrowException_WhenWarriorAlreadyEnrolled()
        {
            arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior1));
        }

        [Test]
        public void Fight_ShouldThrowException_WhenAttackerDoesNotExist()
        {
            arena.Enroll(warrior2);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Thor", "Loki"));
        }

        [Test]
        public void Fight_ShouldThrowException_WhenDefenderDoesNotExist()
        {
            arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Thor", "Loki"));
        }

        [Test]
        public void Fight_ShouldAllowValidFight()
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Fight("Thor", "Loki");
            Assert.Less(warrior2.HP, 80);
        }
    }
}
