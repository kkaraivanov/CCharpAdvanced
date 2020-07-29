using NUnit.Framework;

namespace Tests
{
    using CarManager;

    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("A", "a6", 10, 100);
        }

        [Test]
        public void InitialiseConstructor()
        {
            Assert.IsNotNull(car);
        }

        [Test]
        public void FuelAmountShoudReternPositiveZero()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void FuelCapacityShoudReternPositiveValue()
        {
            Assert.AreEqual(100, car.FuelCapacity);
        }

        [Test]
        public void FuelConsumptionShoudReternPositiveValue()
        {
            Assert.AreEqual(10, car.FuelConsumption);
        }

        [Test]
        public void ModelShoudReternPositiveNotNullOrEmpty()
        {
            Assert.AreEqual("a6", car.Model);
        }

        [Test]
        public void MakeShoudReternPositiveNotNullOrEmpty()
        {
            Assert.AreEqual("A", car.Make);
        }

        [Test]
        public void MakeIsNullShoudReturnArgument()
        {
            Assert.That(() =>
                new Car("", "a6", 1, 100), Throws.ArgumentException);
            Assert.That(() =>
                new Car(null, "a6", 1, 100), Throws.ArgumentException);
        }

        [Test]
        public void ModelIsNullShoudReturnArgument()
        {
            Assert.That(() =>
                new Car("A", "", 1, 100), Throws.ArgumentException);
            Assert.That(() =>
                new Car("A", null, 1, 100), Throws.ArgumentException);
        }

        [Test]
        public void NegativeOrZeroFuelConsumptionShoudReturnArgument()
        {
            Assert.That(() =>
                new Car("A", "a6", -5, 10), Throws.ArgumentException);
            Assert.That(() =>
                new Car("A", "a6", 0, 10), Throws.ArgumentException);
        }

        [Test]
        public void NegativeOrZeroFuelCapacityShoudReturnArgument()
        {
            Assert.That(() =>
                new Car("A", "a6", 1, -100), Throws.ArgumentException);
            Assert.That(() =>
                new Car("A", "a6", 1, 0), Throws.ArgumentException);
        }

        [Test]
        public void ExpectedRefuelMethod()
        {
            car.Refuel(10);
            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void NegativeRefuelMethodShouldReturnArgument()
        {
            Assert.That(() => car.Refuel(-5), Throws.ArgumentException);
        }

        [Test]
        public void ZeroRefuelMethodShouldReturnArgument()
        {
            Assert.That(() => car.Refuel(0), Throws.ArgumentException);
        }

        [Test]
        public void RefuelMethodOverCpacityShouldReturnCapacity()
        {
            car.Refuel(150);
            
            Assert.AreEqual(100, car.FuelAmount);
        }

        [Test]
        public void RefuelWithZeroShouldReturnArgument()
        {
            Assert.That(() => car.Refuel(0), Throws.ArgumentException);
        }

        [Test]
        public void CarDriveOverDistanceShouldReturnInvalidOperation()
        {
            car.Refuel(1);
            Assert.That(() => car.Drive(100), Throws.InvalidOperationException);
        }

        [Test]
        public void CarDriveDistanceShouldReturnInvalidOperation()
        {
            car.Refuel(10);
            car.Drive(10);
            Assert.AreEqual(9.0, car.FuelAmount);
        }
    }
}