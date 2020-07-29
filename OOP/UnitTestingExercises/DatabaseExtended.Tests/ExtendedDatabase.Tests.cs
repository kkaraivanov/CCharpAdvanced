using NUnit.Framework;

namespace Tests
{
    using System;
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void InitialiseNullCollection()
        {
            var db = new ExtendedDatabase();

            Assert.AreEqual(0, db.Count);
        }

        [Test]
        public void InitializeCollection()
        {
            var expected = new Person[]
            {
                new Person(1, "a"),
                new Person(2, "b"),
            };
            var db = new ExtendedDatabase(expected);

            Assert.That(2, Is.EqualTo(db.Count));
        }

        [Test]
        public void TestAddRangeThrowArgument()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i + 1, $"a{i}");
            }

            Assert.That(() => new ExtendedDatabase(persons), Throws.ArgumentException);
        }

        [Test]
        public void AddOver16UsersReturnInvalidOperationException()
        {
            var persons = new Person[16];
            var db = new ExtendedDatabase();

            for (int i = 0; i < persons.Length; i++)
            {
                db.Add(new Person(i + 1, $"a{i}"));
            }

            Assert.That(() => db.Add(new Person(18, "z")), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldIncrementCount()
        {
            var db = new ExtendedDatabase();
            var person = new Person(1, "a");
            db.Add(person);

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void AddDuplicateUserNameToCollectionReturnInvalidOperation()
        {
            var db = new ExtendedDatabase(new Person(2, "a"));

            Assert.That(() => db.Add(new Person(1, "a")), Throws.InvalidOperationException);
        }

        [Test]
        public void AddDuplicateUserIdToCollectionReturnInvalidOperation()
        {
            var db = new ExtendedDatabase(new Person(1, "a"));

            Assert.That(() => db.Add(new Person(1, "b")), Throws.InvalidOperationException);
        }

        [Test]
        public void AddUserCorectId()
        {
            var person = new Person(1, "a");
            var db = new ExtendedDatabase();
            db.Add(person);

            var result = db.FindById(1);

            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void ConstructorAddUserCorectId()
        {
            var persons = new Person[]
            {
                new Person(1, "a"),
                new Person(1, "b")
            };

            Assert.That(() => new ExtendedDatabase(persons), Throws.InvalidOperationException);
        }

        [Test]
        public void ConstructorAddUserCorectUserName()
        {
            var persons = new Person[]
            {
                new Person(1, "a"),
                new Person(2, "a")
            };

            Assert.That(() => new ExtendedDatabase(persons), Throws.InvalidOperationException);
        }

        [Test]
        public void AddUserCorectUserName()
        {
            var person = new Person(1, "a");
            var db = new ExtendedDatabase();
            db.Add(person);

            var result = db.FindByUsername("a");

            Assert.AreEqual("a", result.UserName);
        }

        [Test]
        public void RemoveFromEmptyCollectionReturnInvalidOperation()
        {
            var db = new ExtendedDatabase();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveFromCollectionReturnInvalidOperation()
        {
            var persons = new Person[]
            {
                new Person(1, "a"),
                new Person(2, "b")
            };
            var db = new ExtendedDatabase(persons);
            db.Remove();

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void FindByIdElement()
        {
            var persons = new Person(1, "a");
            var db = new ExtendedDatabase(persons);
            Person actual = db.FindById(1);

            Assert.AreEqual(persons, actual);
        }

        [Test]
        public void FindByIdElementProperties()
        {
            var persons = new Person[]
            {
                new Person(1, "a"),
                new Person(2, "b"),
                new Person(3, "c"),
                new Person(4, "d")
            };
            var db = new ExtendedDatabase(persons);
            Person actual = db.FindById(3);

            Assert.AreEqual(3, actual.Id);
            Assert.AreEqual("c", actual.UserName);
        }

        [Test]
        public void FindByIdUnderZeroArgument()
        {
            var db = new ExtendedDatabase();

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void FindByIdFromEmptyCollection()
        {
            var db = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => db.FindById(1));
        }

        [Test]
        public void FindByIdUnknowUserIdArgument()
        {
            var persons = new Person(1, "a");
            var db = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }

        [Test]
        public void FindByUsername()
        {
            var person = new Person(1, "a");
            var db = new ExtendedDatabase(person);
            Person actual = db.FindByUsername("a");

            Assert.AreEqual(person, actual);
        }

        [Test]
        public void FindByUsernameProperties()
        {
            var person = new Person(1, "a");
            var db = new ExtendedDatabase(person);
            Person actual = db.FindByUsername("a");

            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("a", actual.UserName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUserWithNullOrEmptyArgument(string user)
        {
            var db = new ExtendedDatabase();

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(user));
        }

        [Test]
        public void FindByUserFromEmptyCollection()
        {
            var db = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("a"));
        }

        [Test]
        public void FindByUserUnknowUserNameArgument()
        {
            var persons = new Person(1, "a");
            var db = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("b"));
        }
    }
}