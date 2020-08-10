namespace Computers.Tests
{
    using System;
    using NUnit.Framework;

    public class ComputerTests
    {
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("A");
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("A", computer.Name);
        }

        [Test]
        public void Test2()
        {
            Assert.IsEmpty(computer.Parts);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test3(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        public void Test4()
        {
            computer.AddPart(new Part("A", 1));
            computer.AddPart(new Part("B", 1));
            computer.AddPart(new Part("C", 1));

            Assert.AreEqual(3, computer.TotalPrice);
        }

        [Test]
        public void Test5()
        {
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void Test6()
        {
            var part = new Part("A", 1);
            computer.AddPart(part);

            Assert.AreEqual(part, computer.GetPart("A"));
        }

        [Test]
        public void Test7()
        {
            var partA = new Part("A", 1);
            var partB = new Part("B", 1);
            var partC = new Part("C", 1);
            var partD = new Part("D", 1);
            computer.AddPart(partA);
            computer.AddPart(partB);
            computer.AddPart(partC);
            computer.AddPart(partD);

            Assert.AreEqual(true, computer.RemovePart(partC));
        }
    }
}