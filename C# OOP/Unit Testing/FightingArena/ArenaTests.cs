
using System;
namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        public Arena arena;
        public Warrior firstWarrior;
        public Warrior secondWarrior;
        [SetUp]
        public void SetUp()
        {
            firstWarrior = new Warrior("Zed", 60, 200);
            secondWarrior = new Warrior("Yasuo", 50, 150);
            arena = new Arena();
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);


        }
        [Test]
        public void Check_If_Constuctor_Creates_Empty_Collection()
        {
            Arena newArena = new Arena();
            Assert.AreEqual(0, newArena.Count);


        }
        [Test]
        public void Check_If_Count_Is_Equal_To_The_Warriors_In_Arena()
        {
            Assert.AreEqual(2, arena.Count);

        }
        [Test]
        public void Check_If_Warrior_Is_Added_With_Enroll_Function()
        {
            Warrior warrior = new Warrior("dfsdf", 50, 90);
            arena.Enroll(warrior);
            Assert.AreEqual(3, arena.Count);


        }
        [Test]
        public void Check_If_Exception_Is_Thrown_When_Trying_To_Add_A_Duplicate_Warrior()
        {
            Warrior warrior = new Warrior("Zed", 60, 200);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));


        }
        [Test]
        public void Check_If_Exception_Is_Thrown_When_Attacker_Is_Not_In_Arena()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("boeca", "Zed"));


        }
        [Test]
        public void Check_If_Exception_Is_Thrown_When_Defender_Is_Not_In_Arena()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Zed", "boeca"));


        }
        [Test]
        public void Check_If_Warriors_Can_Attack_If_Both_Are_Enrolled()
        {
            arena.Fight("Zed", "Yasuo");
            Assert.That(firstWarrior.HP == 150 && secondWarrior.HP == 90);


        }

    }
}
