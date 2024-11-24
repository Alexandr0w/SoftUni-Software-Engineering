using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int _health, _expirience;

        [SetUp]
        public void SetUp()
        {
            this._health = Random.Shared.Next(10, 100);
            this._expirience = Random.Shared.Next(10, 100);
        }

        [Test]
        public void DummyShouldBeInitializedCorrectly()
        {
            Dummy dummy = new Dummy(this._health, this._expirience);

            Assert.That(dummy.Health, Is.EqualTo(this._health));
            Assert.That(dummy.IsDead(), Is.False);

        }

        [TestCase(0)]
        [TestCase(5)]
        public void DummyShouldBeDeadIfAttackedWithEnoughPower(int attackAdditive)
        {
            Dummy dummy = new Dummy(this._health, this._expirience);

            dummy.TakeAttack(this._health + attackAdditive);

            Assert.That(dummy.Health, Is.EqualTo(-1 * attackAdditive));
            Assert.That(dummy.IsDead, Is.True);
        }

        [Test]
        public void DeadDummyShouldNotBeAbleToTakeAttack()
        {
            Dummy dummy = new Dummy(-1 * this._health, this._expirience);
            Assert.Throws<InvalidOperationException>(
                () => dummy.TakeAttack(1)
            );
        }

        [Test]
        public void AliveDummyShouldNotBeAbleToGiveExperience()
        {
            Dummy dummy = new Dummy(this._health, this._expirience);

            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience()
            );
        }

        [Test]
        public void DeadDummyShouldBeAbleToGiveExperience()
        {
            Dummy dummy = new Dummy(-1 * this._health, this._expirience);

            int result = dummy.GiveExperience();    

            Assert.That(result, Is.EqualTo(this._expirience));
        }
    }
}