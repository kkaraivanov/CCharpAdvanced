using NUnit.Framework;

namespace UnitTestingSkeletonTests
{
    using System;

    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetDummy() => dummy = new Dummy(100, 500);

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            var axe = new Axe(10, 5);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
        }

        [Test]
        public void AxeShouldLoseAttackWithBokenWeapoon()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var axe = new Axe(10, 0);
                axe.Attack(dummy);
            }, "Axe is broken.");
        }
    }
}