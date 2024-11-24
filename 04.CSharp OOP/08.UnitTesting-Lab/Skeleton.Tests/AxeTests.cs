using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int _attack, _durability;

        [SetUp]
        public void SetUp()
        {
            this._attack = Random.Shared.Next(10, 100);
            this._durability = Random.Shared.Next(10, 100);
        }

        [Test]
        public void AxeShouldBeInitializedCorrectly()
        {
            Axe axe = new Axe(this._attack, this._durability);

            Assert.That(axe.AttackPoints, Is.EqualTo(this._attack));
            Assert.That(axe.DurabilityPoints, Is.EqualTo(this._durability));
        }

        [Test]
        public void AxeShouldBeDurabilityAfterEachAttack()
        {
            Axe axe = new Axe(this._attack, this._durability);

            for (int i = 0; i < _durability; i++)
            {
                Dummy dummy = new Dummy(this._attack, 0);
                axe.Attack(dummy);

                Assert.That(axe.DurabilityPoints, Is.EqualTo(this._durability - (i + 1)));
            }
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void AxeShouldNotBeAbleToAttackIfDurabilityIsEqualToLowerThanZero(int durabilityMultipler)
        {
            Axe axe = new Axe(this._attack, 0);

            Dummy dummy = new Dummy(this._attack, 0);
            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy)    
            );
        }
    }
}