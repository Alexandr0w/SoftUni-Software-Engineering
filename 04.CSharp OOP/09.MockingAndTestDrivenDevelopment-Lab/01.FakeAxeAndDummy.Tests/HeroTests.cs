namespace FakeAxeAndDummy.Tests
{
    using NUnit.Framework;
    using FakeAxeAndDummy;

    [TestFixture]
    public class HeroTests
    {

        [Test]
        public void TestHeroConstructor()
        {
            Axe axe = new Axe(10, 10);

            Hero hero = new Hero("George", axe);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Experience, Is.EqualTo(0));
                Assert.That(hero.Weapon, !Is.Null);
                Assert.That(hero.Name, Is.EqualTo("George"));
            });
        }

        [Test]
        public void TestAttackSouldDecreaseDummyHealthAndHeroWeaponDurabilityAndInceaseHeroExperiance()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 90);
            Hero hero = new Hero("George", axe);

            hero.Attack(dummy);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Experience, Is.EqualTo(90));
                Assert.That(dummy.Health, Is.EqualTo(0));
                Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
            });
        }
    }
}