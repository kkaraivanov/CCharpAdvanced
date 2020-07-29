namespace UnitTestingSkeletonTests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int Expirience = 200;
        private const int AliveHealth = 100;
        private const int DeadHealth = 0;
        private const int AttackPoint = 30;

        private Dummy alive;
        private Dummy dead;

        [SetUp]
        public void SetDummies()
        {
            alive = new Dummy(AliveHealth, Expirience);
            dead = new Dummy(DeadHealth, Expirience);
        }

        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            alive.TakeAttack(AttackPoint);

            Assert.That(alive.Health, Is.EqualTo(70));
        }

        [Test]
        public void DummyExeptionIfAttackedWithoutHealth()
        {
            Assert.That(() =>
                    dead.TakeAttack(AttackPoint),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DummyShouldGiveExperienceIfDead()
        {
            var experience = dead.GiveExperience();

            Assert.That(experience, Is.EqualTo(Expirience));
        }

        [Test]
        public void DummyShouldNotGiveExperienceIfAlive()
        {
            Assert.That(() => alive.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}