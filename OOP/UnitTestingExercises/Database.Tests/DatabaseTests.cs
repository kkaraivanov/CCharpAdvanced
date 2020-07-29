namespace Tests
{
    using System.Linq;
    using Database;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] arrayCapacity;
        private int[] arrayOverCapacity;
        private int[] arrayUnderCapacity;
        private Database db;

        [SetUp]
        public void Setup()
        {
            arrayCapacity = Enumerable.Range(1, 16).ToArray();
            arrayOverCapacity = Enumerable.Range(1, 17).ToArray();
            arrayUnderCapacity = Enumerable.Range(1, 10).ToArray();

            db = new Database(arrayCapacity);
        }

        [Test]
        public void StoringOverArrayCapacityThrow()
        {
            Assert.That(() => new Database(arrayOverCapacity), Throws.InvalidOperationException);
        }

        [Test]
        public void AddShouldThrowWhenEndIsReached()
        {
            Assert.That(() => db.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveFromEmptiCollection()
        {
            var emptyDb = new Database();
            Assert.That(() => emptyDb.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveLastElement()
        {
            var actual = db.Count;
            var expected = arrayCapacity.Last();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FechTest()
        {
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Add(10);

            var actual = db.Fetch();
            var expected = new int[] {1, 2, 3, 4, 5, 6 , 7, 8, 9, 10};

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}