using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            this.car = new Car("Germany", "Audi", 8, 100);


        }
        [Test]
        public void Test_If_Constuctor_Assigns_Properties()
        {
            Assert.That(car.Make == "Germany" && car.Model == "Audi" && car.FuelConsumption == 8 && car.FuelCapacity == 100 && car.FuelAmount == 0);


        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        
        public void Check_If_Make_Throws_Exception_When_Null_Or_Empty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Audi", 8, 100));


        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        
        public void Check_If_Model_Throws_Exception_When_Null_Or_Empty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Germany", model, 8, 100));


        }
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Check_If_FuelCapacity_Throws_Exception_When_Lower_Or_Equal_To_Zero(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Germany", "Audi", 8, fuelCapacity));


        }


        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Check_If_FuelConsumption_Throws_Exception_When_Lower_Or_Equal_To_Zero(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Germany", "Audi", fuelConsumption, 100));


        }


        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void Throws_Exception_When_FuelToRefuel_Is_Negative(int refuelAmount)
        {

            Assert.Throws<ArgumentException>(() => car.Refuel(refuelAmount));

        }
        [Test]
        public void Checks_If_FuelAmount_Is_Increased_When_Car_Gets_Refueled()
        {
            car.Refuel(10);
            Assert.AreEqual(10, car.FuelAmount);


        }
        [Test]
        public void Checks_If_FuelAmount_Is_Set_To_Max_When_TankCapacity_Is_Reached()
        {
            car.Refuel(200);
            Assert.AreEqual(100, car.FuelAmount);

        }
        [Test]
        public void Checks_If_Exception_Is_Thrown_When_Distance_Can_Not_Be_Driven()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(200));


        }
        [Test]
        public void Checks_If_FuelAmount_Is_Lowered_When_Distance_Is_Driven()
        {
            car.Refuel(10);
            car.Drive(100);
            Assert.AreEqual(2, car.FuelAmount);



        }
    }
}