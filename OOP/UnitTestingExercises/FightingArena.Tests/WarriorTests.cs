using NUnit.Framework;

namespace Tests
{
    using System;
    using FightingArena;

    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(null)]
        [TestCase("")]
        public void InitialisingConstructorWithIncorectNameShouldReturnArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 40));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void InitialisingConstructorWithIncorectDamageShouldReturnArgumentException(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("a", damage, 40));
        }

        [TestCase(-1)]
        public void InitialisingConstructorWithIncorectHPShouldReturnArgumentException(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("a", 10, hp));
        }

        [TestCase(25)]
        [TestCase(30)]
        public void AttackerHPShouldReturnInvalidOperationException(int hp)
        {
            var warrior = new Warrior("a", 10, hp);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("a", 10, 50)));
        }

        [TestCase(25)]
        [TestCase(30)]
        public void DefenderHPShouldReturnInvalidOperationException(int hp)
        {
            var warrior = new Warrior("a", 10, 50);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("a", 10, hp)));
        }

        [Test]
        public void DefenderDamageShouldReturnInvalidOperationException()
        {
            var warrior = new Warrior("a", 10, 40);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("a", 50, 50)));
        }

        [Test]
        public void InitialisingConstructorWithCorectNameShouldReturnProperty()
        {
            var warrionr = new Warrior("a", 10, 40);

            Assert.AreEqual("a", warrionr.Name);
        }

        [Test]
        public void InitialisingConstructorWithCorectDamageShouldReturnProperty()
        {
            var warrionr = new Warrior("a", 10, 40);

            Assert.AreEqual(10, warrionr.Damage);
        }
        
        [Test]
        public void InitialisingConstructorWithCorectHPShouldReturnProperty()
        {
            var warrionr = new Warrior("a", 10, 40);

            Assert.AreEqual(40, warrionr.HP);
        }

        [Test]
        public void DefenderDecraseHPOnAttacker()
        {
            var attacker = new Warrior("a", 10, 50);
            var defender = new Warrior("a", 10, 40);
            attacker.Attack(defender);

            Assert.AreEqual(40, attacker.HP);
        }

        [Test]
        public void AttackerOverHPOnDefender()
        {
            var attacker = new Warrior("a", 50, 50);
            var defender = new Warrior("a", 10, 40);
            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }
    }
}