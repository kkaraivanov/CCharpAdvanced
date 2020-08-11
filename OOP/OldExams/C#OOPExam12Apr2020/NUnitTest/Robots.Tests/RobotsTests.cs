namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("A", 10);
            manager = new RobotManager(10);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(10, manager.Capacity);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void Test3()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-10));
        }

        [Test]
        public void Test4()
        {
            var newRobot = new Robot("A", 20);
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Add(newRobot));
        }

        [Test]
        public void Test14()
        {
            var newRobot = new Robot("B", 10);
            manager.Add(robot);
            manager.Add(newRobot);

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void Test5()
        {
            for (int i = 0; i < 10; i++)
            {
                manager.Add(new Robot($"A{i}", 10));
            }

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot));
        }

        [Test]
        public void Test6()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Remove("B"));
        }

        [Test]
        public void Test16()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Remove("A"));
        }

        [Test]
        public void Test7()
        {
            manager.Add(robot);
            manager.Remove("A");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void Test8()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Work("B", "J", 10));
        }

        [Test]
        public void Test18()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Work("A", "J", 10));
        }

        [Test]
        public void Test9()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Work("A", "J", 20));
        }

        [Test]
        public void Test10()
        {
            manager.Add(robot);
            manager.Work("A", "J", 5);

            Assert.AreEqual(5, robot.Battery);
        }

        [Test]
        public void Test11()
        {
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Charge("B"));
        }

        [Test]
        public void Test111()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("B"));
        }

        [Test]
        public void Test12()
        {
            manager.Add(robot);
            manager.Work("A", "J", 9);
            manager.Charge("A");

            Assert.AreEqual(10, robot.Battery);
        }
    }
}
