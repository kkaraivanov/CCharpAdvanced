using NUnit.Framework;

namespace Tests
{
    using System;
    using System.Linq;
    using FightingArena;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warriorAttacker;
        private Warrior warriorDefender;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warriorAttacker = new Warrior("a", 10, 50);
            warriorDefender = new Warrior("b", 20, 60);
        }

        [Test]
        public void InitialiseConstructor()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrolWarriorShouldReturnInvalidOperationException()
        {
            arena.Enroll(warriorAttacker);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("a", 1, 1)));
        }

        [Test]
        public void EnrolWarriorShouldCountReturnOne()
        {
            arena.Enroll(warriorAttacker);

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrolWarriorShouldWarriorsCountReturnOne()
        {
            arena.Enroll(warriorAttacker);

            Assert.AreEqual(1, arena.Warriors.Count);
        }

        [Test]
        public void EnrolWarriorShouldWarriorsReturnThisWarrior()
        {
            arena.Enroll(warriorAttacker);
            var expect = arena.Warriors.Last();

            Assert.AreEqual(expect.Name, warriorAttacker.Name);
        }

        [Test]
        public void FightWithName()
        {
            Assert.Throws<InvalidOperationException>(()
            => arena.Fight("a", "b"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void FightWithOutAttackerName(string attacker)
        {
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker, warriorDefender.Name));
        }

        [TestCase(null)]
        [TestCase("")]
        public void FightWithOutDefenderName(string defender)
        {
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(warriorAttacker.Name, defender));
        }

        [Test]
        public void FightWithAttackerAtack()
        {
            arena.Enroll(warriorAttacker);
            arena.Enroll(warriorDefender);
            arena.Fight("a", "b");

            Assert.AreEqual(50, warriorDefender.HP);
        }
    }
}
