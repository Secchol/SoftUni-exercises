using NUnit.Framework;
using System;
namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [Test]
        public void If_Weapon_Looses_Durability_After_Each_Attack()
        {
            axe = new Axe(10, 10);
            axe.Attack(new Dummy(30, 20));
            Assert.AreEqual(axe.DurabilityPoints, 9, "Axe durability doesn't change after attack.");

        }
        [Test]
        public void Tests_Attacking_With_A_Broken_Weapon()
        {
            axe = new Axe(20, 0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(30, 20));


            });


        }
    }
}