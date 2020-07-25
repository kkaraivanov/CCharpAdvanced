using NUnit.Framework;

namespace UnitTestingSkeletonTests
{
    [TestFixture]
    public class AxeTests
    {
        [SetUp]
        public void Setup()
        {
            var axe = new Axe(1 , 1);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}