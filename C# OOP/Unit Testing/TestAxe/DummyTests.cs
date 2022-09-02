using NUnit.Framework;
using System;
namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 20);
            dummy = new Dummy(30, 20);


        }
        [Test]
        public void Dummmy_Loses_Health_If_Attacked()
        {
            axe.Attack(dummy);
            Assert.AreEqual(dummy.Health, 20,"Dummy doesn't lose health if attacked.");
        }
        [Test]
        public void Dead_Dummy_Throws_An_Exception()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);


            },"Dead dummy doesn't throw an exception if attacked.");


        }
        [Test]
        public void Dead_Dummy_Can_Give_XP()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.IsTrue(dummy.GiveExperience() == 20);

        }
        [Test]
        public void Alive_Dummy_Can_Give_XP()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();


            });



        }

    }
}
